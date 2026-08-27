using ComodoroERP.Data;
using Microsoft.Data.Sqlite;
using System.Data;

namespace ComodoroERP.Services
{
    public class AcertoDashboardResumo
    {
        public int TotalAcertos { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorPendente { get; set; }
        public decimal PercentualPago { get; set; }
        public string MelhorPagadora { get; set; } = "-";
        public decimal MelhorPagadoraPercentual { get; set; }
        public decimal MelhorPagadoraValorPago { get; set; }
        public string MaiorDevedora { get; set; } = "-";
        public decimal MaiorDevedoraValorPendente { get; set; }
    }

    public class AcertoRankingEscola
    {
        public string Escola { get; set; } = "";
        public int TotalAcertos { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorPendente { get; set; }
        public decimal PercentualPago { get; set; }
    }

    public class AcertoDashboardService
    {
        public AcertoDashboardResumo ObterResumo(string escolaFiltro = "", DateTime? dataInicial = null, DateTime? dataFinal = null)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            var resumo = new AcertoDashboardResumo();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    SELECT
                        COUNT(1) AS TotalAcertos,
                        IFNULL(SUM(Valor), 0) AS ValorTotal,
                        IFNULL(SUM(CASE WHEN UPPER(TRIM(IFNULL(StatusPagamento, ''))) = 'PAGO' THEN Valor ELSE 0 END), 0) AS ValorPago,
                        IFNULL(SUM(CASE WHEN UPPER(TRIM(IFNULL(StatusPagamento, ''))) <> 'PAGO' THEN Valor ELSE 0 END), 0) AS ValorPendente
                    FROM Acertos
                    WHERE
                        (@EscolaFiltro = '' OR NomeEscola LIKE '%' || @EscolaFiltro || '%')
                        AND (@DataInicial = '' OR date(DataCriacao) >= date(@DataInicial))
                        AND (@DataFinal = '' OR date(DataCriacao) <= date(@DataFinal));
                ";

                AdicionarParametrosFiltro(command, escolaFiltro, dataInicial, dataFinal);

                using var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    resumo.TotalAcertos = reader["TotalAcertos"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TotalAcertos"]);
                    resumo.ValorTotal = reader["ValorTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ValorTotal"]);
                    resumo.ValorPago = reader["ValorPago"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ValorPago"]);
                    resumo.ValorPendente = reader["ValorPendente"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ValorPendente"]);
                    resumo.PercentualPago = resumo.ValorTotal <= 0 ? 0 : Math.Round((resumo.ValorPago / resumo.ValorTotal) * 100, 2);
                }
            }

            var ranking = ListarRankingPorEscola(escolaFiltro, dataInicial, dataFinal);

            AcertoRankingEscola? melhorPagadora = ranking
                .Where(x => x.ValorTotal > 0 && x.ValorPago > 0)
                .OrderByDescending(x => x.PercentualPago)
                .ThenByDescending(x => x.ValorPago)
                .FirstOrDefault();

            if (melhorPagadora != null)
            {
                resumo.MelhorPagadora = melhorPagadora.Escola;
                resumo.MelhorPagadoraPercentual = melhorPagadora.PercentualPago;
                resumo.MelhorPagadoraValorPago = melhorPagadora.ValorPago;
            }

            AcertoRankingEscola? maiorDevedora = ranking
                .Where(x => x.ValorPendente > 0)
                .OrderByDescending(x => x.ValorPendente)
                .FirstOrDefault();

            if (maiorDevedora != null)
            {
                resumo.MaiorDevedora = maiorDevedora.Escola;
                resumo.MaiorDevedoraValorPendente = maiorDevedora.ValorPendente;
            }

            return resumo;
        }

        public List<AcertoRankingEscola> ListarRankingPorEscola(string escolaFiltro = "", DateTime? dataInicial = null, DateTime? dataFinal = null)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    NomeEscola AS Escola,
                    COUNT(1) AS TotalAcertos,
                    IFNULL(SUM(Valor), 0) AS ValorTotal,
                    IFNULL(SUM(CASE WHEN UPPER(TRIM(IFNULL(StatusPagamento, ''))) = 'PAGO' THEN Valor ELSE 0 END), 0) AS ValorPago,
                    IFNULL(SUM(CASE WHEN UPPER(TRIM(IFNULL(StatusPagamento, ''))) <> 'PAGO' THEN Valor ELSE 0 END), 0) AS ValorPendente
                FROM Acertos
                WHERE
                    (@EscolaFiltro = '' OR NomeEscola LIKE '%' || @EscolaFiltro || '%')
                    AND (@DataInicial = '' OR date(DataCriacao) >= date(@DataInicial))
                    AND (@DataFinal = '' OR date(DataCriacao) <= date(@DataFinal))
                GROUP BY NomeEscola
                ORDER BY ValorPendente DESC, ValorTotal DESC;
            ";

            AdicionarParametrosFiltro(command, escolaFiltro, dataInicial, dataFinal);

            using var reader = command.ExecuteReader();

            var ranking = new List<AcertoRankingEscola>();

            while (reader.Read())
            {
                decimal valorTotal = reader["ValorTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ValorTotal"]);
                decimal valorPago = reader["ValorPago"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ValorPago"]);
                decimal valorPendente = reader["ValorPendente"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ValorPendente"]);

                ranking.Add(new AcertoRankingEscola
                {
                    Escola = reader["Escola"]?.ToString() ?? "",
                    TotalAcertos = reader["TotalAcertos"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TotalAcertos"]),
                    ValorTotal = valorTotal,
                    ValorPago = valorPago,
                    ValorPendente = valorPendente,
                    PercentualPago = valorTotal <= 0 ? 0 : Math.Round((valorPago / valorTotal) * 100, 2)
                });
            }

            return ranking;
        }

        public DataTable ListarRankingDataTable(string escolaFiltro = "", DateTime? dataInicial = null, DateTime? dataFinal = null)
        {
            var table = new DataTable();

            table.Columns.Add("Escola", typeof(string));
            table.Columns.Add("TotalAcertos", typeof(int));
            table.Columns.Add("ValorTotal", typeof(decimal));
            table.Columns.Add("ValorPago", typeof(decimal));
            table.Columns.Add("ValorPendente", typeof(decimal));
            table.Columns.Add("PercentualPago", typeof(decimal));

            foreach (var item in ListarRankingPorEscola(escolaFiltro, dataInicial, dataFinal))
            {
                table.Rows.Add(item.Escola, item.TotalAcertos, item.ValorTotal, item.ValorPago, item.ValorPendente, item.PercentualPago);
            }

            return table;
        }

        public List<string> ListarEscolas()
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT DISTINCT
                    NomeEscola
                FROM Acertos
                WHERE NomeEscola IS NOT NULL
                  AND TRIM(NomeEscola) <> ''
                ORDER BY NomeEscola;
            ";

            using var reader = command.ExecuteReader();

            var escolas = new List<string>();

            while (reader.Read())
            {
                escolas.Add(reader["NomeEscola"]?.ToString() ?? "");
            }

            return escolas;
        }

        private void AdicionarParametrosFiltro(SqliteCommand command, string escolaFiltro, DateTime? dataInicial, DateTime? dataFinal)
        {
            command.Parameters.AddWithValue("@EscolaFiltro", escolaFiltro ?? "");
            command.Parameters.AddWithValue("@DataInicial", dataInicial.HasValue ? dataInicial.Value.ToString("yyyy-MM-dd") : "");
            command.Parameters.AddWithValue("@DataFinal", dataFinal.HasValue ? dataFinal.Value.ToString("yyyy-MM-dd") : "");
        }
    }
}
