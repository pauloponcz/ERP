using ComodoroERP.Data;
using Microsoft.Data.Sqlite;

namespace ComodoroERP.Services
{
    public class ConfiguracaoService
    {
        public string ObterValor(string chave, string valorPadrao)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT Valor
                FROM Configuracoes
                WHERE Chave = @Chave;
            ";

            command.Parameters.AddWithValue("@Chave", chave);

            object? resultado = command.ExecuteScalar();

            if (resultado == null || resultado == DBNull.Value)
                return valorPadrao;

            return resultado.ToString() ?? valorPadrao;
        }

        public void SalvarValor(string chave, string valor)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                INSERT INTO Configuracoes
                (
                    Chave,
                    Valor
                )
                VALUES
                (
                    @Chave,
                    @Valor
                )
                ON CONFLICT(Chave)
                DO UPDATE SET Valor = excluded.Valor;
            ";

            command.Parameters.AddWithValue("@Chave", chave);
            command.Parameters.AddWithValue("@Valor", valor);

            command.ExecuteNonQuery();
        }

        public string ObterPastaPdfs()
        {
            string pastaPadrao = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pdfs");

            return ObterValor("PastaPdfs", pastaPadrao);
        }

        public string ObterPastaBackups()
        {
            string pastaPadrao = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backups");

            return ObterValor("PastaBackups", pastaPadrao);
        }
    }
}