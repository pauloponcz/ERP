using ComodoroERP.Data;
using ComodoroERP.Models;
using Microsoft.Data.Sqlite;
using System.Data;

namespace ComodoroERP.Services
{
    public class OrcamentoService
    {
        public int SalvarOrcamento(
            Cliente cliente,
            Orcamento orcamento,
            List<OrcamentoItem> itens)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                int clienteId = InserirCliente(connection, transaction, cliente);

                orcamento.ClienteId = clienteId;

                int orcamentoId = InserirOrcamento(connection, transaction, orcamento);

                foreach (var item in itens)
                {
                    item.OrcamentoId = orcamentoId;
                    InserirItem(connection, transaction, item);
                }

                transaction.Commit();

                return orcamentoId;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private int InserirCliente(
            SqliteConnection connection,
            SqliteTransaction transaction,
            Cliente cliente)
        {
            using var command = connection.CreateCommand();
            command.Transaction = transaction;

            command.CommandText = @"
                INSERT INTO Clientes 
                (
                    Nome,
                    Cnpj,
                    Endereco,
                    BairroCep,
                    CidadeEstado
                )
                VALUES
                (
                    @Nome,
                    @Cnpj,
                    @Endereco,
                    @BairroCep,
                    @CidadeEstado
                );

                SELECT last_insert_rowid();
            ";

            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@Cnpj", cliente.Cnpj);
            command.Parameters.AddWithValue("@Endereco", cliente.Endereco);
            command.Parameters.AddWithValue("@BairroCep", cliente.BairroCep);
            command.Parameters.AddWithValue("@CidadeEstado", cliente.CidadeEstado);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        private int InserirOrcamento(
            SqliteConnection connection,
            SqliteTransaction transaction,
            Orcamento orcamento)
        {
            using var command = connection.CreateCommand();
            command.Transaction = transaction;

            command.CommandText = @"
                INSERT INTO Orcamentos
                (
                    ClienteId,
                    Titulo,
                    DataOrcamento,
                    Status,
                    VariacaoNota2,
                    VariacaoNota3,
                    Observacao,
                    DataCriacao
                )
                VALUES
                (
                    @ClienteId,
                    @Titulo,
                    @DataOrcamento,
                    @Status,
                    @VariacaoNota2,
                    @VariacaoNota3,
                    @Observacao,
                    @DataCriacao
                );

                SELECT last_insert_rowid();
            ";

            command.Parameters.AddWithValue("@ClienteId", orcamento.ClienteId);
            command.Parameters.AddWithValue("@Titulo", orcamento.Titulo);
            command.Parameters.AddWithValue("@DataOrcamento", orcamento.DataOrcamento.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Status", orcamento.Status);
            command.Parameters.AddWithValue("@VariacaoNota2", orcamento.VariacaoNota2);
            command.Parameters.AddWithValue("@VariacaoNota3", orcamento.VariacaoNota3);
            command.Parameters.AddWithValue("@Observacao", orcamento.Observacao);
            command.Parameters.AddWithValue("@DataCriacao", orcamento.DataCriacao.ToString("yyyy-MM-dd HH:mm:ss"));

            return Convert.ToInt32(command.ExecuteScalar());
        }

        private void InserirItem(
            SqliteConnection connection,
            SqliteTransaction transaction,
            OrcamentoItem item)
        {
            using var command = connection.CreateCommand();
            command.Transaction = transaction;

            command.CommandText = @"
                INSERT INTO OrcamentoItens
                (
                    OrcamentoId,
                    Categoria,
                    ServicoPermitido,
                    DescricaoOrcamento,
                    Quantidade,
                    ValorUnitario,
                    Cortesia,
                    ValorTotal,
                    Observacao
                )
                VALUES
                (
                    @OrcamentoId,
                    @Categoria,
                    @ServicoPermitido,
                    @DescricaoOrcamento,
                    @Quantidade,
                    @ValorUnitario,
                    @Cortesia,
                    @ValorTotal,
                    @Observacao
                );
            ";

            command.Parameters.AddWithValue("@OrcamentoId", item.OrcamentoId);
            command.Parameters.AddWithValue("@Categoria", item.Categoria);
            command.Parameters.AddWithValue("@ServicoPermitido", item.ServicoPermitido);
            command.Parameters.AddWithValue("@DescricaoOrcamento", item.DescricaoOrcamento);
            command.Parameters.AddWithValue("@Quantidade", item.Quantidade);
            command.Parameters.AddWithValue("@ValorUnitario", item.ValorUnitario);
            command.Parameters.AddWithValue("@Cortesia", item.Cortesia ? 1 : 0);
            command.Parameters.AddWithValue("@ValorTotal", item.ValorTotal);
            command.Parameters.AddWithValue("@Observacao", item.Observacao);

            command.ExecuteNonQuery();
        }

        public DataTable ListarOrcamentos(
            string clienteFiltro = "",
            string statusFiltro = "")
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    O.Id,
                    O.DataOrcamento AS Data,
                    C.Nome AS Cliente,
                    C.Cnpj,
                    O.Titulo,
                    O.Status,
                    IFNULL(SUM(I.ValorTotal), 0) AS ValorOriginal,
                    IFNULL(SUM(I.ValorTotal), 0) AS ValorNota1,
                    IFNULL(SUM(I.ValorTotal * (1 + (O.VariacaoNota2 / 100))), 0) AS ValorNota2,
                    IFNULL(SUM(I.ValorTotal * (1 + (O.VariacaoNota3 / 100))), 0) AS ValorNota3
                FROM Orcamentos O
                INNER JOIN Clientes C ON C.Id = O.ClienteId
                LEFT JOIN OrcamentoItens I ON I.OrcamentoId = O.Id
                WHERE
                    (@ClienteFiltro = '' OR C.Nome LIKE '%' || @ClienteFiltro || '%')
                    AND
                    (@StatusFiltro = '' OR O.Status = @StatusFiltro)
                GROUP BY
                    O.Id,
                    O.DataOrcamento,
                    C.Nome,
                    C.Cnpj,
                    O.Titulo,
                    O.Status,
                    O.VariacaoNota2,
                    O.VariacaoNota3
                ORDER BY O.Id DESC;
            ";

            command.Parameters.AddWithValue("@ClienteFiltro", clienteFiltro);
            command.Parameters.AddWithValue("@StatusFiltro", statusFiltro);

            using var reader = command.ExecuteReader();

            var table = new DataTable();
            table.Load(reader);

            return table;
        }

        public DataTable ListarItens(
            string clienteFiltro = "",
            string categoriaFiltro = "",
            string servicoFiltro = "",
            string statusFiltro = "")
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    O.Id AS OrcamentoId,
                    O.DataOrcamento AS Data,
                    C.Nome AS Cliente,
                    O.Status,
                    I.Categoria,
                    I.ServicoPermitido,
                    I.DescricaoOrcamento,
                    I.Quantidade,
                    I.ValorUnitario,
                    I.ValorTotal,
                    CASE 
                        WHEN I.Cortesia = 1 THEN 'Sim'
                        ELSE 'Não'
                    END AS Cortesia
                FROM OrcamentoItens I
                INNER JOIN Orcamentos O ON O.Id = I.OrcamentoId
                INNER JOIN Clientes C ON C.Id = O.ClienteId
                WHERE
                    (@ClienteFiltro = '' OR C.Nome LIKE '%' || @ClienteFiltro || '%')
                    AND
                    (@CategoriaFiltro = '' OR I.Categoria = @CategoriaFiltro)
                    AND
                    (@ServicoFiltro = '' OR I.ServicoPermitido LIKE '%' || @ServicoFiltro || '%' OR I.DescricaoOrcamento LIKE '%' || @ServicoFiltro || '%')
                    AND
                    (@StatusFiltro = '' OR O.Status = @StatusFiltro)
                ORDER BY O.Id DESC, I.Id ASC;
            ";

            command.Parameters.AddWithValue("@ClienteFiltro", clienteFiltro);
            command.Parameters.AddWithValue("@CategoriaFiltro", categoriaFiltro);
            command.Parameters.AddWithValue("@ServicoFiltro", servicoFiltro);
            command.Parameters.AddWithValue("@StatusFiltro", statusFiltro);

            using var reader = command.ExecuteReader();

            var table = new DataTable();
            table.Load(reader);

            return table;
        }

        public void AlterarStatus(int orcamentoId, string novoStatus)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                UPDATE Orcamentos
                SET Status = @Status
                WHERE Id = @Id;
            ";

            command.Parameters.AddWithValue("@Status", novoStatus);
            command.Parameters.AddWithValue("@Id", orcamentoId);

            command.ExecuteNonQuery();
        }

        public DataSet ObterOrcamentoCompleto(int orcamentoId)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            var dataSet = new DataSet();

            using var commandCabecalho = connection.CreateCommand();

            commandCabecalho.CommandText = @"
        SELECT
            O.Id,
            O.Titulo,
            O.DataOrcamento,
            O.Status,
            O.VariacaoNota2,
            O.VariacaoNota3,
            O.Observacao,
            C.Nome AS Cliente,
            C.Cnpj,
            C.Endereco,
            C.BairroCep,
            C.CidadeEstado
        FROM Orcamentos O
        INNER JOIN Clientes C ON C.Id = O.ClienteId
        WHERE O.Id = @Id;
    ";

            commandCabecalho.Parameters.AddWithValue("@Id", orcamentoId);

            using var readerCabecalho = commandCabecalho.ExecuteReader();

            var tabelaCabecalho = new DataTable("Cabecalho");
            tabelaCabecalho.Load(readerCabecalho);
            dataSet.Tables.Add(tabelaCabecalho);

            using var commandItens = connection.CreateCommand();

            commandItens.CommandText = @"
        SELECT
            Id,
            Categoria,
            ServicoPermitido,
            DescricaoOrcamento,
            Quantidade,
            ValorUnitario,
            Cortesia,
            ValorTotal,
            Observacao
        FROM OrcamentoItens
        WHERE OrcamentoId = @Id
        ORDER BY Id;
    ";

            commandItens.Parameters.AddWithValue("@Id", orcamentoId);

            using var readerItens = commandItens.ExecuteReader();

            var tabelaItens = new DataTable("Itens");
            tabelaItens.Load(readerItens);
            dataSet.Tables.Add(tabelaItens);

            return dataSet;
        }

        public void RegistrarNotaGerada(
    int orcamentoId,
    int numeroNota,
    decimal percentualVariacao,
    decimal valorTotal,
    string caminhoPdf)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
        DELETE FROM NotasGeradas
        WHERE OrcamentoId = @OrcamentoId
          AND NumeroNota = @NumeroNota;

        INSERT INTO NotasGeradas
        (
            OrcamentoId,
            NumeroNota,
            PercentualVariacao,
            ValorTotal,
            CaminhoPdf,
            DataGeracao
        )
        VALUES
        (
            @OrcamentoId,
            @NumeroNota,
            @PercentualVariacao,
            @ValorTotal,
            @CaminhoPdf,
            @DataGeracao
        );
    ";

            command.Parameters.AddWithValue("@OrcamentoId", orcamentoId);
            command.Parameters.AddWithValue("@NumeroNota", numeroNota);
            command.Parameters.AddWithValue("@PercentualVariacao", percentualVariacao);
            command.Parameters.AddWithValue("@ValorTotal", valorTotal);
            command.Parameters.AddWithValue("@CaminhoPdf", caminhoPdf);
            command.Parameters.AddWithValue("@DataGeracao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            command.ExecuteNonQuery();
        }

        public void AtualizarDadosOrcamento(
    int orcamentoId,
    string titulo,
    string status,
    decimal variacaoNota2,
    decimal variacaoNota3,
    string observacao)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
        UPDATE Orcamentos
        SET
            Titulo = @Titulo,
            Status = @Status,
            VariacaoNota2 = @VariacaoNota2,
            VariacaoNota3 = @VariacaoNota3,
            Observacao = @Observacao
        WHERE Id = @Id;
    ";

            command.Parameters.AddWithValue("@Titulo", titulo.Trim().ToUpper());
            command.Parameters.AddWithValue("@Status", status);
            command.Parameters.AddWithValue("@VariacaoNota2", variacaoNota2);
            command.Parameters.AddWithValue("@VariacaoNota3", variacaoNota3);
            command.Parameters.AddWithValue("@Observacao", observacao.Trim());
            command.Parameters.AddWithValue("@Id", orcamentoId);

            command.ExecuteNonQuery();
        }

    }
}