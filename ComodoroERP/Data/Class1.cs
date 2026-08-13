using Microsoft.Data.Sqlite;

namespace ComodoroERP.Data
{
    public static class Database
    {
        private static readonly string PastaDados = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dados");
        private static readonly string CaminhoBanco = Path.Combine(PastaDados, "comodoro.db");

        public static string ConnectionString => $"Data Source={CaminhoBanco}";

        public static void Inicializar()
        {
            CriarPastaDados();
            CriarTabelas();
        }

        private static void CriarPastaDados()
        {
            if (!Directory.Exists(PastaDados))
            {
                Directory.CreateDirectory(PastaDados);
            }
        }

        private static void CriarTabelas()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            string sql = @"
                CREATE TABLE IF NOT EXISTS Clientes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Cnpj TEXT,
                    Endereco TEXT,
                    BairroCep TEXT,
                    CidadeEstado TEXT
                );

                CREATE TABLE IF NOT EXISTS Orcamentos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ClienteId INTEGER NOT NULL,
                    Titulo TEXT NOT NULL,
                    DataOrcamento TEXT NOT NULL,
                    Status TEXT NOT NULL,
                    VariacaoNota2 REAL NOT NULL,
                    VariacaoNota3 REAL NOT NULL,
                    Observacao TEXT,
                    DataCriacao TEXT NOT NULL,
                    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
                );

                CREATE TABLE IF NOT EXISTS OrcamentoItens (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    OrcamentoId INTEGER NOT NULL,
                    Categoria TEXT NOT NULL,
                    ServicoPermitido TEXT NOT NULL,
                    DescricaoOrcamento TEXT NOT NULL,
                    Quantidade REAL NOT NULL,
                    ValorUnitario REAL NOT NULL,
                    Cortesia INTEGER NOT NULL,
                    ValorTotal REAL NOT NULL,
                    Observacao TEXT,
                    FOREIGN KEY (OrcamentoId) REFERENCES Orcamentos(Id)
                );

                CREATE TABLE IF NOT EXISTS ServicosPermitidos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Categoria TEXT NOT NULL,
                    Descricao TEXT NOT NULL,
                    Ativo INTEGER NOT NULL DEFAULT 1
                );

                CREATE TABLE IF NOT EXISTS NotasGeradas (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    OrcamentoId INTEGER NOT NULL,
                    NumeroNota INTEGER NOT NULL,
                    PercentualVariacao REAL NOT NULL,
                    ValorTotal REAL NOT NULL,
                    CaminhoPdf TEXT,
                    DataGeracao TEXT,
                    FOREIGN KEY (OrcamentoId) REFERENCES Orcamentos(Id)
                );

                CREATE TABLE IF NOT EXISTS Configuracoes (
                    Chave TEXT PRIMARY KEY,
                    Valor TEXT NOT NULL
                );

            ";

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }
    }
}