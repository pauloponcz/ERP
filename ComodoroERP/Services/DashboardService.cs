using ComodoroERP.Data;
using Microsoft.Data.Sqlite;
using System.Data;

namespace ComodoroERP.Services
{
    public class DashboardService
    {
        public int ObterTotalOrcamentos()
        {
            return ExecutarInteiro("SELECT COUNT(*) FROM Orcamentos;");
        }

        public int ObterTotalPorStatus(string status)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT COUNT(*)
                FROM Orcamentos
                WHERE Status = @Status;
            ";

            command.Parameters.AddWithValue("@Status", status);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public decimal ObterValorTotalGeral()
        {
            return ExecutarDecimal(@"
                SELECT IFNULL(SUM(ValorTotal), 0)
                FROM OrcamentoItens;
            ");
        }

        public decimal ObterValorPorStatus(string status)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT IFNULL(SUM(I.ValorTotal), 0)
                FROM OrcamentoItens I
                INNER JOIN Orcamentos O ON O.Id = I.OrcamentoId
                WHERE O.Status = @Status;
            ";

            command.Parameters.AddWithValue("@Status", status);

            return Convert.ToDecimal(command.ExecuteScalar());
        }

        public DataTable ListarUltimosOrcamentos()
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    O.Id,
                    O.DataOrcamento AS Data,
                    C.Nome AS Cliente,
                    O.Titulo,
                    O.Status,
                    IFNULL(SUM(I.ValorTotal), 0) AS ValorTotal
                FROM Orcamentos O
                INNER JOIN Clientes C ON C.Id = O.ClienteId
                LEFT JOIN OrcamentoItens I ON I.OrcamentoId = O.Id
                GROUP BY
                    O.Id,
                    O.DataOrcamento,
                    C.Nome,
                    O.Titulo,
                    O.Status
                ORDER BY O.Id DESC
                LIMIT 10;
            ";

            using var reader = command.ExecuteReader();

            var table = new DataTable();
            table.Load(reader);

            return table;
        }

        private int ExecutarInteiro(string sql)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = sql;

            return Convert.ToInt32(command.ExecuteScalar());
        }

        private decimal ExecutarDecimal(string sql)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = sql;

            return Convert.ToDecimal(command.ExecuteScalar());
        }
    }
}