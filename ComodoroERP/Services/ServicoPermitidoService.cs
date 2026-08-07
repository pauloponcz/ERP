using ComodoroERP.Data;
using Microsoft.Data.Sqlite;
using System.Data;

namespace ComodoroERP.Services
{
    public class ServicoPermitidoService
    {
        public void InserirServico(string categoria, string descricao)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                INSERT INTO ServicosPermitidos
                (
                    Categoria,
                    Descricao,
                    Ativo
                )
                VALUES
                (
                    @Categoria,
                    @Descricao,
                    1
                );
            ";

            command.Parameters.AddWithValue("@Categoria", categoria.Trim().ToUpper());
            command.Parameters.AddWithValue("@Descricao", descricao.Trim().ToUpper());

            command.ExecuteNonQuery();
        }

        public bool ExisteServico(string categoria, string descricao)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT COUNT(1)
                FROM ServicosPermitidos
                WHERE 
                    UPPER(TRIM(Categoria)) = UPPER(TRIM(@Categoria))
                    AND UPPER(TRIM(Descricao)) = UPPER(TRIM(@Descricao));
            ";

            command.Parameters.AddWithValue("@Categoria", categoria);
            command.Parameters.AddWithValue("@Descricao", descricao);

            long quantidade = (long)command.ExecuteScalar();

            return quantidade > 0;
        }

        public void InserirServicoSeNaoExistir(string categoria, string descricao)
        {
            if (string.IsNullOrWhiteSpace(categoria))
                return;

            if (string.IsNullOrWhiteSpace(descricao))
                return;

            if (ExisteServico(categoria, descricao))
                return;

            InserirServico(categoria, descricao);
        }

        public DataTable ListarServicos(string categoriaFiltro = "", string servicoFiltro = "")
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    Id,
                    Categoria,
                    Descricao,
                    CASE 
                        WHEN Ativo = 1 THEN 'Sim'
                        ELSE 'Não'
                    END AS Ativo
                FROM ServicosPermitidos
                WHERE
                    (@CategoriaFiltro = '' OR Categoria = @CategoriaFiltro)
                    AND
                    (@ServicoFiltro = '' OR Descricao LIKE '%' || @ServicoFiltro || '%')
                ORDER BY Categoria, Descricao;
            ";

            command.Parameters.AddWithValue("@CategoriaFiltro", categoriaFiltro);
            command.Parameters.AddWithValue("@ServicoFiltro", servicoFiltro);

            using var reader = command.ExecuteReader();

            var table = new DataTable();
            table.Load(reader);

            return table;
        }

        public List<string> ListarCategorias()
        {
            var categorias = new List<string>();

            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT DISTINCT Categoria
                FROM ServicosPermitidos
                WHERE Ativo = 1
                ORDER BY Categoria;
            ";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                categorias.Add(reader.GetString(0));
            }

            return categorias;
        }

        public int ImportarCsv(string caminhoArquivo)
        {
            int quantidadeImportada = 0;

            if (!File.Exists(caminhoArquivo))
                throw new FileNotFoundException("Arquivo CSV não encontrado.");

            var linhas = File.ReadAllLines(caminhoArquivo);

            foreach (var linha in linhas.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(linha))
                    continue;

                var partes = linha.Split(';');

                if (partes.Length < 2)
                    continue;

                string categoria = partes[0].Trim();
                string descricao = partes[1].Trim();

                if (string.IsNullOrWhiteSpace(categoria) || string.IsNullOrWhiteSpace(descricao))
                    continue;

                bool jaExiste = ExisteServico(categoria, descricao);

                if (!jaExiste)
                {
                    InserirServico(categoria, descricao);
                    quantidadeImportada++;
                }
            }

            return quantidadeImportada;
        }

        public List<string> ListarServicosPorCategoria(string categoria)
        {
            var servicos = new List<string>();

            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT Descricao
                FROM ServicosPermitidos
                WHERE 
                    Ativo = 1
                    AND Categoria = @Categoria
                ORDER BY Descricao;
            ";

            command.Parameters.AddWithValue("@Categoria", categoria);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                servicos.Add(reader.GetString(0));
            }

            return servicos;
        }
    }
}