using ClosedXML.Excel;
using ComodoroERP.Services;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ComodoroERP.Reports
{
    public class ExcelNotaService
    {
        private readonly OrcamentoService _orcamentoService = new();
        private readonly ConfiguracaoService _configuracaoService = new();

        public List<string> GerarNotasExcel(int orcamentoId)
        {
            string caminhoModelo = _configuracaoService.ObterModeloNotas();

            if (!File.Exists(caminhoModelo))
                throw new Exception("Modelo de notas não encontrado. Configure o arquivo em Configurações.");

            DataSet dados = _orcamentoService.ObterOrcamentoCompleto(orcamentoId);

            if (dados.Tables["Cabecalho"] == null || dados.Tables["Cabecalho"]!.Rows.Count == 0)
                throw new Exception("Orçamento não encontrado.");

            string pastaSaida = Path.Combine(
                _configuracaoService.ObterPastaPdfs(),
                "excel"
            );

            if (!Directory.Exists(pastaSaida))
                Directory.CreateDirectory(pastaSaida);

            var arquivosGerados = new List<string>();

            using var workbookModelo = new XLWorkbook(caminhoModelo);

            foreach (var abaModelo in workbookModelo.Worksheets)
            {
                string nomeAba = abaModelo.Name;

                using var workbookSaida = new XLWorkbook();

                abaModelo.CopyTo(workbookSaida, nomeAba);

                var abaSaida = workbookSaida.Worksheet(nomeAba);

                int numeroNota = ObterNumeroNotaPorNomeAba(nomeAba);

                PreencherAba(abaSaida, dados, numeroNota);

                string nomeArquivo = MontarNomeArquivo(dados, nomeAba, numeroNota);

                string caminhoSaida = Path.Combine(pastaSaida, nomeArquivo);

                workbookSaida.SaveAs(caminhoSaida);

                arquivosGerados.Add(caminhoSaida);
            }

            return arquivosGerados;
        }

        private void PreencherAba(IXLWorksheet aba, DataSet dados, int numeroNota)
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

            SubstituirCamposSimples(aba, campos);
            PreencherItens(aba, itens, variacaoPercentual);
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

        private void SubstituirCamposSimples(IXLWorksheet aba, Dictionary<string, string> campos)
        {
            foreach (var celula in aba.CellsUsed())
            {
                string texto = celula.GetString();

                if (string.IsNullOrWhiteSpace(texto))
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

                celula.Value = novoTexto;
            }
        }

        private void PreencherItens(IXLWorksheet aba, DataTable itens, decimal variacaoPercentual)
        {
            var linhaModelo = EncontrarLinhaModeloItens(aba);

            if (linhaModelo == null)
                return;

            int numeroLinhaModelo = linhaModelo.Value;

            var placeholdersPorColuna = new Dictionary<int, string>();

            foreach (var celula in aba.Row(numeroLinhaModelo).CellsUsed())
            {
                string texto = celula.GetString();

                Match match = Regex.Match(texto, @"\{(item_[^{}]+)\}", RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    placeholdersPorColuna[celula.Address.ColumnNumber] = match.Groups[1].Value.Trim();
                }
            }

            if (placeholdersPorColuna.Count == 0)
                return;

            int quantidadeItens = itens.Rows.Count;

            if (quantidadeItens > 1)
            {
                aba.Row(numeroLinhaModelo).InsertRowsBelow(quantidadeItens - 1);
            }

            for (int i = 0; i < quantidadeItens; i++)
            {
                int linhaAtual = numeroLinhaModelo + i;

                if (i > 0)
                {
                    aba.Row(numeroLinhaModelo).CopyTo(aba.Row(linhaAtual));
                }

                DataRow item = itens.Rows[i];

                foreach (var colunaPlaceholder in placeholdersPorColuna)
                {
                    int coluna = colunaPlaceholder.Key;
                    string placeholder = colunaPlaceholder.Value;

                    string valor = ObterValorItem(item, placeholder, variacaoPercentual);

                    aba.Cell(linhaAtual, coluna).Value = valor;
                }
            }
        }

        private int? EncontrarLinhaModeloItens(IXLWorksheet aba)
        {
            foreach (var linha in aba.RowsUsed())
            {
                foreach (var celula in linha.CellsUsed())
                {
                    string texto = celula.GetString();

                    if (texto.Contains("{item_", StringComparison.OrdinalIgnoreCase))
                    {
                        return linha.RowNumber();
                    }
                }
            }

            return null;
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

        private string MontarNomeArquivo(DataSet dados, string nomeAba, int numeroNota)
        {
            DataRow cabecalho = dados.Tables["Cabecalho"]!.Rows[0];

            int id = Convert.ToInt32(cabecalho["Id"]);
            string cliente = cabecalho["Cliente"].ToString() ?? "Cliente";
            string clienteLimpo = LimparNomeArquivo(cliente);
            string abaLimpa = LimparNomeArquivo(nomeAba);

            return $"Orcamento_{id:000}_Nota_{numeroNota}_{abaLimpa}_{clienteLimpo}.xlsx";
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
    }
}