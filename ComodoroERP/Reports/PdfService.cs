using ComodoroERP.Services;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Data;
using System.Diagnostics;

namespace ComodoroERP.Reports
{
    public class PdfService
    {
        private readonly OrcamentoService _orcamentoService = new();

        public void GerarPdfsOrcamento(int orcamentoId)
        {
            DataSet dados = _orcamentoService.ObterOrcamentoCompleto(orcamentoId);

            if (dados.Tables["Cabecalho"] == null || dados.Tables["Cabecalho"]!.Rows.Count == 0)
                throw new Exception("Orçamento não encontrado.");

            string pastaPdfs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pdfs");

            if (!Directory.Exists(pastaPdfs))
                Directory.CreateDirectory(pastaPdfs);

            GerarPdfNota(dados, 1, 0, pastaPdfs);
            GerarPdfNota(dados, 2, ObterVariacao(dados, "VariacaoNota2"), pastaPdfs);
            GerarPdfNota(dados, 3, ObterVariacao(dados, "VariacaoNota3"), pastaPdfs);

            AbrirPasta(pastaPdfs);
        }

        private decimal ObterVariacao(DataSet dados, string coluna)
        {
            var cabecalho = dados.Tables["Cabecalho"]!.Rows[0];

            if (cabecalho[coluna] == DBNull.Value)
                return 0;

            return Convert.ToDecimal(cabecalho[coluna]);
        }

        private void GerarPdfNota(DataSet dados, int numeroNota, decimal variacaoPercentual, string pastaPdfs)
        {
            var cabecalho = dados.Tables["Cabecalho"]!.Rows[0];
            var itens = dados.Tables["Itens"]!;

            int id = Convert.ToInt32(cabecalho["Id"]);
            string cliente = cabecalho["Cliente"].ToString() ?? "";
            string clienteArquivo = LimparNomeArquivo(cliente);

            string caminhoPdf = Path.Combine(
                pastaPdfs,
                $"Orcamento_{id:000}_Nota_{numeroNota}_{clienteArquivo}.pdf"
            );

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(35);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

                    page.Header().Element(c =>
                    {
                        MontarCabecalho(c, cabecalho, numeroNota);
                    });

                    page.Content().Element(c =>
                    {
                        MontarConteudo(c, itens, variacaoPercentual);
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text($"Orçamento {id:000} - Nota {numeroNota}")
                        .FontSize(8);
                });
            })
            .GeneratePdf(caminhoPdf);

            decimal valorTotalNota = CalcularTotalNota(itens, variacaoPercentual);

            _orcamentoService.RegistrarNotaGerada(
                id,
                numeroNota,
                variacaoPercentual,
                valorTotalNota,
                caminhoPdf
            );
        }

        private decimal CalcularTotalNota(DataTable itens, decimal variacaoPercentual)
        {
            decimal total = 0;

            foreach (DataRow item in itens.Rows)
            {
                bool cortesia = Convert.ToInt32(item["Cortesia"]) == 1;

                if (cortesia)
                    continue;

                decimal valorOriginal = Convert.ToDecimal(item["ValorTotal"]);

                decimal valorGerado = valorOriginal * (1 + (variacaoPercentual / 100));

                total += valorGerado;
            }

            return total;
        }

        private void AbrirPasta(string pasta)
        {
            if (!Directory.Exists(pasta))
                return;

            Process.Start(new ProcessStartInfo
            {
                FileName = pasta,
                UseShellExecute = true
            });
        }

        private void MontarCabecalho(IContainer container, DataRow cabecalho, int numeroNota)
        {
            container.Column(col =>
            {
                col.Item().Text("COMODORO SERVIÇOS").Bold().FontSize(16);
                col.Item().Text("CNPJ 43.927.965/0001-37");
                col.Item().Text("CONTATO: 41 996990677");
                col.Item().Text("RUA: JOÃO KOLESKI 376");

                col.Item().PaddingTop(15).Text($"NOTA {numeroNota}").Bold().FontSize(13);

                col.Item().PaddingTop(10).Text($"CLIENTE: {cabecalho["Cliente"]}");
                col.Item().Text($"CNPJ: {cabecalho["Cnpj"]}");
                col.Item().Text($"ENDEREÇO: {cabecalho["Endereco"]}");
                col.Item().Text($"{cabecalho["BairroCep"]}");
                col.Item().Text($"{cabecalho["CidadeEstado"]}");

                col.Item().PaddingTop(10).Text(cabecalho["Titulo"].ToString() ?? "").Bold();
                col.Item().Text($"DATA: {Convert.ToDateTime(cabecalho["DataOrcamento"]):dd/MM/yyyy}");
            });
        }

        private void MontarConteudo(IContainer container, DataTable itens, decimal variacaoPercentual)
        {
            decimal totalGeral = 0;

            container.PaddingTop(20).Column(col =>
            {
                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(4);
                        columns.RelativeColumn(1);
                    });

                    table.Header(header =>
                    {
                        header.Cell().BorderBottom(1).Padding(5).Text("SERVIÇO").Bold();
                        header.Cell().BorderBottom(1).Padding(5).AlignRight().Text("VALOR").Bold();
                    });

                    foreach (DataRow item in itens.Rows)
                    {
                        string descricao = item["DescricaoOrcamento"].ToString() ?? "";
                        bool cortesia = Convert.ToInt32(item["Cortesia"]) == 1;
                        decimal valorOriginal = Convert.ToDecimal(item["ValorTotal"]);

                        decimal valorGerado = cortesia
                            ? 0
                            : valorOriginal * (1 + (variacaoPercentual / 100));

                        table.Cell().Padding(5).Text(descricao);

                        if (cortesia)
                        {
                            table.Cell().Padding(5).AlignRight().Text("CORTESIA");
                        }
                        else
                        {
                            table.Cell().Padding(5).AlignRight().Text(FormatarMoeda(valorGerado));
                            totalGeral += valorGerado;
                        }
                    }
                });

                col.Item().PaddingTop(20).AlignRight().Text($"TOTAL DEVIDO: {FormatarMoeda(totalGeral)}").Bold().FontSize(12);
            });
        }

        private string FormatarMoeda(decimal valor)
        {
            return valor.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
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