using ComodoroERP.Services;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ComodoroERP.Reports
{
    public class ExcelModeloPdfService
    {
        private readonly OrcamentoService _orcamentoService = new();
        private readonly ConfiguracaoService _configuracaoService = new();

        private const int xlTypePDF = 0;
        private const int xlShiftDown = -4121;

        public List<string> GerarPdfsPorModeloExcel(int orcamentoId)
        {
            string caminhoModelo = _configuracaoService.ObterModeloNotas();

            if (!File.Exists(caminhoModelo))
                throw new Exception("Modelo de notas não encontrado. Configure o arquivo em Configurações.");

            DataSet dados = _orcamentoService.ObterOrcamentoCompleto(orcamentoId);

            if (dados.Tables["Cabecalho"] == null || dados.Tables["Cabecalho"]!.Rows.Count == 0)
                throw new Exception("Orçamento não encontrado.");

            string pastaPdfs = _configuracaoService.ObterPastaPdfs();

            if (!Directory.Exists(pastaPdfs))
                Directory.CreateDirectory(pastaPdfs);

            string pastaTemporaria = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");

            if (!Directory.Exists(pastaTemporaria))
                Directory.CreateDirectory(pastaTemporaria);

            string caminhoTemporario = Path.Combine(
                pastaTemporaria,
                $"modelo_preenchido_{orcamentoId}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            );

            File.Copy(caminhoModelo, caminhoTemporario, true);

            var arquivosGerados = new List<string>();

            object? excelObj = null;
            object? workbookObj = null;

            try
            {
                Type? excelType = Type.GetTypeFromProgID("Excel.Application");

                if (excelType == null)
                    throw new Exception("Microsoft Excel não está instalado nesta máquina.");

                excelObj = Activator.CreateInstance(excelType);

                if (excelObj == null)
                    throw new Exception("Não foi possível iniciar o Microsoft Excel.");

                dynamic excel = excelObj;

                excel.Visible = false;
                excel.DisplayAlerts = false;

                workbookObj = excel.Workbooks.Open(caminhoTemporario);
                dynamic workbook = workbookObj;

                int totalAbas = workbook.Worksheets.Count;

                for (int i = 1; i <= totalAbas; i++)
                {
                    object? worksheetObj = null;

                    try
                    {
                        worksheetObj = workbook.Worksheets[i];
                        dynamic worksheet = worksheetObj;

                        string nomeAba = worksheet.Name;

                        int numeroNota = ObterNumeroNotaPorNomeAba(nomeAba);

                        PreencherAba(worksheet, dados, numeroNota);

                        string caminhoPdf = MontarCaminhoPdf(
                            pastaPdfs,
                            dados,
                            nomeAba,
                            numeroNota
                        );

                        worksheet.ExportAsFixedFormat(
                            xlTypePDF,
                            caminhoPdf
                        );

                        arquivosGerados.Add(caminhoPdf);
                    }
                    finally
                    {
                        LiberarObjetoCom(worksheetObj);
                    }
                }

                workbook.Close(false);
                excel.Quit();

                return arquivosGerados;
            }
            finally
            {
                LiberarObjetoCom(workbookObj);
                LiberarObjetoCom(excelObj);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                try
                {
                    if (File.Exists(caminhoTemporario))
                        File.Delete(caminhoTemporario);
                }
                catch
                {
                }
            }
        }

        private void PreencherAba(dynamic worksheet, DataSet dados, int numeroNota)
        {
            DataRow cabecalho = dados.Tables["Cabecalho"]!.Rows[0];
            DataTable itens = dados.Tables["Itens"]!;

            decimal variacaoPercentual = ObterVariacaoNota(cabecalho, numeroNota);

            Dictionary<string, string> campos = MontarCamposCabecalho(
                cabecalho,
                itens,
                numeroNota,
                variacaoPercentual
            );

            PreencherItens(worksheet, itens, variacaoPercentual);

            SubstituirCamposSimples(worksheet, campos);
        }

        private void SubstituirCamposSimples(dynamic worksheet, Dictionary<string, string> campos)
        {
            object? usedRangeObj = null;

            try
            {
                usedRangeObj = worksheet.UsedRange;
                dynamic usedRange = usedRangeObj;

                int linhas = usedRange.Rows.Count;
                int colunas = usedRange.Columns.Count;

                for (int linha = 1; linha <= linhas; linha++)
                {
                    for (int coluna = 1; coluna <= colunas; coluna++)
                    {
                        object? cellObj = null;

                        try
                        {
                            cellObj = usedRange.Cells[linha, coluna];
                            dynamic cell = cellObj;

                            object? valorCelula = cell.Value2;

                            if (valorCelula == null)
                                continue;

                            string texto = valorCelula.ToString() ?? "";

                            if (!texto.Contains("{") || !texto.Contains("}"))
                                continue;

                            string novoTexto = Regex.Replace(texto, @"\{([^{}]+)\}", match =>
                            {
                                string chave = match.Groups[1].Value.Trim();

                                if (chave.StartsWith("item_", StringComparison.OrdinalIgnoreCase))
                                    return match.Value;

                                if (campos.TryGetValue(chave, out string? valor))
                                    return valor;

                                return "";
                            });

                            cell.Value2 = novoTexto;
                        }
                        finally
                        {
                            LiberarObjetoCom(cellObj);
                        }
                    }
                }
            }
            finally
            {
                LiberarObjetoCom(usedRangeObj);
            }
        }

        private void PreencherItens(dynamic worksheet, DataTable itens, decimal variacaoPercentual)
        {
            int linhaModelo = EncontrarLinhaModeloItens(worksheet);

            if (linhaModelo == 0)
                return;

            int quantidadeItens = itens.Rows.Count;

            if (quantidadeItens == 0)
            {
                object? linhaModeloObj = null;

                try
                {
                    linhaModeloObj = worksheet.Rows[linhaModelo];
                    dynamic linhaModeloRange = linhaModeloObj;
                    linhaModeloRange.Delete();
                }
                finally
                {
                    LiberarObjetoCom(linhaModeloObj);
                }

                return;
            }

            if (quantidadeItens > 1)
            {
                object? linhasAbaixoObj = null;

                try
                {
                    linhasAbaixoObj = worksheet.Rows[$"{linhaModelo + 1}:{linhaModelo + quantidadeItens - 1}"];
                    dynamic linhasAbaixo = linhasAbaixoObj;
                    linhasAbaixo.Insert(xlShiftDown);
                }
                finally
                {
                    LiberarObjetoCom(linhasAbaixoObj);
                }
            }

            for (int i = 0; i < quantidadeItens; i++)
            {
                int linhaAtual = linhaModelo + i;

                if (i > 0)
                {
                    object? origemObj = null;
                    object? destinoObj = null;

                    try
                    {
                        origemObj = worksheet.Rows[linhaModelo];
                        destinoObj = worksheet.Rows[linhaAtual];

                        dynamic origem = origemObj;
                        dynamic destino = destinoObj;

                        origem.Copy(destino);
                    }
                    finally
                    {
                        LiberarObjetoCom(origemObj);
                        LiberarObjetoCom(destinoObj);
                    }
                }

                PreencherLinhaItem(worksheet, linhaAtual, itens.Rows[i], variacaoPercentual);
            }
        }

        private int EncontrarLinhaModeloItens(dynamic worksheet)
        {
            object? usedRangeObj = null;

            try
            {
                usedRangeObj = worksheet.UsedRange;
                dynamic usedRange = usedRangeObj;

                int linhas = usedRange.Rows.Count;
                int colunas = usedRange.Columns.Count;

                for (int linha = 1; linha <= linhas; linha++)
                {
                    for (int coluna = 1; coluna <= colunas; coluna++)
                    {
                        object? cellObj = null;

                        try
                        {
                            cellObj = usedRange.Cells[linha, coluna];
                            dynamic cell = cellObj;

                            object? valor = cell.Value2;

                            if (valor == null)
                                continue;

                            string texto = valor.ToString() ?? "";

                            if (texto.Contains("{item_", StringComparison.OrdinalIgnoreCase))
                                return linha;
                        }
                        finally
                        {
                            LiberarObjetoCom(cellObj);
                        }
                    }
                }

                return 0;
            }
            finally
            {
                LiberarObjetoCom(usedRangeObj);
            }
        }

        private void PreencherLinhaItem(
            dynamic worksheet,
            int linha,
            DataRow item,
            decimal variacaoPercentual)
        {
            object? usedRangeObj = null;

            try
            {
                usedRangeObj = worksheet.UsedRange;
                dynamic usedRange = usedRangeObj;

                int colunas = usedRange.Columns.Count;

                for (int coluna = 1; coluna <= colunas; coluna++)
                {
                    object? cellObj = null;

                    try
                    {
                        cellObj = worksheet.Cells[linha, coluna];
                        dynamic cell = cellObj;

                        object? valor = cell.Value2;

                        if (valor == null)
                            continue;

                        string texto = valor.ToString() ?? "";

                        if (!texto.Contains("{item_", StringComparison.OrdinalIgnoreCase))
                            continue;

                        string novoTexto = Regex.Replace(texto, @"\{(item_[^{}]+)\}", match =>
                        {
                            string placeholder = match.Groups[1].Value.Trim();

                            return ObterValorItem(item, placeholder, variacaoPercentual);
                        });

                        cell.Value2 = novoTexto;
                    }
                    finally
                    {
                        LiberarObjetoCom(cellObj);
                    }
                }
            }
            finally
            {
                LiberarObjetoCom(usedRangeObj);
            }
        }

        private Dictionary<string, string> MontarCamposCabecalho(
            DataRow cabecalho,
            DataTable itens,
            int numeroNota,
            decimal variacaoPercentual)
        {
            decimal valorTotal = CalcularTotalNota(itens, variacaoPercentual);

            return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["orcamento_id"] = cabecalho["Id"].ToString() ?? "",
                ["nota_numero"] = numeroNota.ToString(),
                ["cliente"] = cabecalho["Cliente"].ToString() ?? "",
                ["cnpj"] = cabecalho["Cnpj"].ToString() ?? "",
                ["endereco"] = cabecalho["Endereco"].ToString() ?? "",
                ["bairro_cep"] = cabecalho["BairroCep"].ToString() ?? "",
                ["cidade_estado"] = cabecalho["CidadeEstado"].ToString() ?? "",
                ["data_orcamento"] = FormatarData(cabecalho["DataOrcamento"]),
                ["titulo"] = cabecalho["Titulo"].ToString() ?? "",
                ["status"] = cabecalho["Status"].ToString() ?? "",
                ["observacao"] = cabecalho["Observacao"].ToString() ?? "",
                ["variacao_percentual"] = variacaoPercentual.ToString("N2", new CultureInfo("pt-BR")),
                ["valor_total"] = FormatarMoeda(valorTotal),
                ["valor_total_numero"] = valorTotal.ToString("N2", new CultureInfo("pt-BR"))
            };
        }

        private string ObterValorItem(DataRow item, string placeholder, decimal variacaoPercentual)
        {
            bool cortesia = ConverterBool(item["Cortesia"]);

            decimal valorOriginal = ConverterDecimal(item["ValorTotal"]);

            decimal valorComVariacao = cortesia
                ? 0
                : valorOriginal * (1 + (variacaoPercentual / 100));

            return placeholder.ToLower() switch
            {
                "item_categoria" => item["Categoria"].ToString() ?? "",
                "item_servico_permitido" => item["ServicoPermitido"].ToString() ?? "",
                "item_descricao" => item["DescricaoOrcamento"].ToString() ?? "",
                "item_quantidade" => ConverterDecimal(item["Quantidade"]).ToString("N2", new CultureInfo("pt-BR")),
                "item_valor_unitario" => FormatarMoeda(ConverterDecimal(item["ValorUnitario"])),
                "item_valor_total" => cortesia ? "CORTESIA" : FormatarMoeda(valorComVariacao),
                "item_observacao" => item["Observacao"].ToString() ?? "",
                "item_cortesia" => cortesia ? "Sim" : "Não",
                _ => ""
            };
        }

        private decimal ObterVariacaoNota(DataRow cabecalho, int numeroNota)
        {
            if (numeroNota == 2)
                return ConverterDecimal(cabecalho["VariacaoNota2"]);

            if (numeroNota == 3)
                return ConverterDecimal(cabecalho["VariacaoNota3"]);

            return 0;
        }

        private int ObterNumeroNotaPorNomeAba(string nomeAba)
        {
            string somenteNumeros = new string(nomeAba.Where(char.IsDigit).ToArray());

            if (int.TryParse(somenteNumeros, out int numero))
                return numero;

            return 1;
        }

        private decimal CalcularTotalNota(DataTable itens, decimal variacaoPercentual)
        {
            decimal total = 0;

            foreach (DataRow item in itens.Rows)
            {
                bool cortesia = ConverterBool(item["Cortesia"]);

                if (cortesia)
                    continue;

                decimal valorOriginal = ConverterDecimal(item["ValorTotal"]);
                decimal valorGerado = valorOriginal * (1 + (variacaoPercentual / 100));

                total += valorGerado;
            }

            return total;
        }

        private string MontarCaminhoPdf(string pastaPdfs, DataSet dados, string nomeAba, int numeroNota)
        {
            DataRow cabecalho = dados.Tables["Cabecalho"]!.Rows[0];

            int id = Convert.ToInt32(cabecalho["Id"]);
            string cliente = cabecalho["Cliente"].ToString() ?? "Cliente";
            string clienteLimpo = LimparNomeArquivo(cliente);
            string abaLimpa = LimparNomeArquivo(nomeAba);

            return Path.Combine(
                pastaPdfs,
                $"Orcamento_{id:000}_Nota_{numeroNota}_{abaLimpa}_{clienteLimpo}.pdf"
            );
        }

        private string FormatarMoeda(decimal valor)
        {
            return valor.ToString("C2", new CultureInfo("pt-BR"));
        }

        private string FormatarData(object valor)
        {
            if (valor == null || valor == DBNull.Value)
                return "";

            return Convert.ToDateTime(valor).ToString("dd/MM/yyyy");
        }

        private decimal ConverterDecimal(object valor)
        {
            if (valor == null || valor == DBNull.Value)
                return 0;

            return Convert.ToDecimal(valor);
        }

        private bool ConverterBool(object valor)
        {
            if (valor == null || valor == DBNull.Value)
                return false;

            string texto = valor.ToString()!.Trim().ToLower();

            return texto == "1" || texto == "true" || texto == "sim";
        }

        private string LimparNomeArquivo(string texto)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                texto = texto.Replace(c.ToString(), "");
            }

            return texto.Replace(" ", "_");
        }

        private void LiberarObjetoCom(object? objeto)
        {
            if (objeto == null)
                return;

            try
            {
                if (Marshal.IsComObject(objeto))
                    Marshal.ReleaseComObject(objeto);
            }
            catch
            {
            }
        }
    }
}