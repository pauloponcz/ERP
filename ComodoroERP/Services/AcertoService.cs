using ComodoroERP.Data;
using ComodoroERP.Models;
using Microsoft.Data.Sqlite;
using System.Data;

namespace ComodoroERP.Services
{
    public class AcertoService
    {
        public void InserirAcerto(Acerto acerto)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                INSERT INTO Acertos (
                    NomeEscola,
                    Servico,
                    Valor,
                    StatusPagamento,
                    DataCriacao,
                    DataPagamento
                )
                VALUES (
                    @NomeEscola,
                    @Servico,
                    @Valor,
                    @StatusPagamento,
                    @DataCriacao,
                    @DataPagamento
                );
            ";

            command.Parameters.AddWithValue("@NomeEscola", acerto.NomeEscola);
            command.Parameters.AddWithValue("@Servico", acerto.Servico);
            command.Parameters.AddWithValue("@Valor", acerto.Valor);
            command.Parameters.AddWithValue("@StatusPagamento", acerto.StatusPagamento);
            command.Parameters.AddWithValue("@DataCriacao", acerto.DataCriacao.ToString("yyyy-MM-dd HH:mm:ss"));

            if (acerto.DataPagamento.HasValue)
                command.Parameters.AddWithValue("@DataPagamento", acerto.DataPagamento.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            else
                command.Parameters.AddWithValue("@DataPagamento", DBNull.Value);

            command.ExecuteNonQuery();
        }

        public DataTable ListarAcertos(
            string escolaFiltro = "",
            DateTime? dataInicial = null,
            DateTime? dataFinal = null)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    Id,
                    NomeEscola AS Escola,
                    Servico AS Serviço,
                    Valor,
                    StatusPagamento AS Status,
                    DataCriacao AS DataCadastro,
                    DataPagamento
                FROM Acertos
                WHERE
                    (@EscolaFiltro = '' OR NomeEscola LIKE '%' || @EscolaFiltro || '%')
                    AND (@DataInicial = '' OR date(DataCriacao) >= date(@DataInicial))
                    AND (@DataFinal = '' OR date(DataCriacao) <= date(@DataFinal))
                ORDER BY DataCriacao DESC, Id DESC;
            ";

            command.Parameters.AddWithValue("@EscolaFiltro", escolaFiltro ?? "");
            command.Parameters.AddWithValue("@DataInicial", dataInicial.HasValue ? dataInicial.Value.ToString("yyyy-MM-dd") : "");
            command.Parameters.AddWithValue("@DataFinal", dataFinal.HasValue ? dataFinal.Value.ToString("yyyy-MM-dd") : "");

            using var reader = command.ExecuteReader();

            var table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Escola", typeof(string));
            table.Columns.Add("Serviço", typeof(string));
            table.Columns.Add("Valor", typeof(decimal));
            table.Columns.Add("Status", typeof(string));
            table.Columns.Add("DataCadastro", typeof(string));
            table.Columns.Add("DataPagamento", typeof(string));

            while (reader.Read())
            {
                table.Rows.Add(
                    reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]),
                    reader["Escola"]?.ToString() ?? "",
                    reader["Serviço"]?.ToString() ?? "",
                    reader["Valor"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Valor"]),
                    reader["Status"]?.ToString() ?? "",
                    reader["DataCadastro"] == DBNull.Value ? "" : Convert.ToDateTime(reader["DataCadastro"]).ToString("dd/MM/yyyy HH:mm"),
                    reader["DataPagamento"] == DBNull.Value ? "" : Convert.ToDateTime(reader["DataPagamento"]).ToString("dd/MM/yyyy HH:mm")
                );
            }

            return table;
        }

        public void MarcarComoPago(int id)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                UPDATE Acertos
                SET
                    StatusPagamento = 'Pago',
                    DataPagamento = @DataPagamento
                WHERE Id = @Id;
            ";

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@DataPagamento", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            command.ExecuteNonQuery();
        }

        public void MarcarComoPendente(int id)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                UPDATE Acertos
                SET
                    StatusPagamento = 'Pendente',
                    DataPagamento = NULL
                WHERE Id = @Id;
            ";

            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
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

        public Acerto? ObterAcertoPorId(int id)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
        SELECT
            Id,
            NomeEscola,
            Servico,
            Valor,
            StatusPagamento,
            DataCriacao,
            DataPagamento
        FROM Acertos
        WHERE Id = @Id;
    ";

            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return new Acerto
            {
                Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]),
                NomeEscola = reader["NomeEscola"]?.ToString() ?? "",
                Servico = reader["Servico"]?.ToString() ?? "",
                Valor = reader["Valor"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Valor"]),
                StatusPagamento = reader["StatusPagamento"]?.ToString() ?? "Pendente",
                DataCriacao = reader["DataCriacao"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["DataCriacao"]),
                DataPagamento = reader["DataPagamento"] == DBNull.Value ? null : Convert.ToDateTime(reader["DataPagamento"])
            };
        }

        public void AtualizarAcerto(Acerto acerto)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
        UPDATE Acertos
        SET
            NomeEscola = @NomeEscola,
            Servico = @Servico,
            Valor = @Valor,
            StatusPagamento = @StatusPagamento,
            DataPagamento = @DataPagamento
        WHERE Id = @Id;
    ";

            command.Parameters.AddWithValue("@Id", acerto.Id);
            command.Parameters.AddWithValue("@NomeEscola", acerto.NomeEscola);
            command.Parameters.AddWithValue("@Servico", acerto.Servico);
            command.Parameters.AddWithValue("@Valor", acerto.Valor);
            command.Parameters.AddWithValue("@StatusPagamento", acerto.StatusPagamento);

            if (acerto.StatusPagamento == "Pago")
                command.Parameters.AddWithValue("@DataPagamento", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            else
                command.Parameters.AddWithValue("@DataPagamento", DBNull.Value);

            command.ExecuteNonQuery();
        }

        public void ExcluirAcerto(int id)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
        DELETE FROM Acertos
        WHERE Id = @Id;
    ";

            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }
    }
}