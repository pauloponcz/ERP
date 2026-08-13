using ComodoroERP.Models;
using ComodoroERP.Reports;
using ComodoroERP.Services;
using System.Data;
using System.Diagnostics;
using System.Globalization;

namespace ComodoroERP
{
    public partial class FrmDetalhesOrcamento : Form
    {
        private readonly int _orcamentoId;
        private readonly OrcamentoService _orcamentoService = new();

        public FrmDetalhesOrcamento(int orcamentoId)
        {
            InitializeComponent();

            _orcamentoId = orcamentoId;

            ConfigurarGrid();
            CarregarDados();
        }

        private void ConfigurarGrid()
        {
            dgvItens.DataSource = null;
            dgvItens.Columns.Clear();
            dgvItens.AutoGenerateColumns = true;

            dgvItens.AllowUserToAddRows = false;
            dgvItens.AllowUserToDeleteRows = false;
            dgvItens.ReadOnly = true;
            dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItens.MultiSelect = false;
            dgvItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvItens.DataError += dgvItens_DataError;
        }

        private void CarregarDados()
        {
            DataSet dados = _orcamentoService.ObterOrcamentoCompleto(_orcamentoId);

            if (dados.Tables["Cabecalho"] == null || dados.Tables["Cabecalho"]!.Rows.Count == 0)
            {
                MessageBox.Show("Orçamento não encontrado.");
                Close();
                return;
            }

            DataRow cabecalho = dados.Tables["Cabecalho"]!.Rows[0];
            DataTable itens = dados.Tables["Itens"]!;

            decimal valorNota1 = CalcularTotal(itens, 0);
            decimal variacaoNota2 = ConverterDecimal(cabecalho["VariacaoNota2"]);
            decimal variacaoNota3 = ConverterDecimal(cabecalho["VariacaoNota3"]);
            decimal valorNota2 = CalcularTotal(itens, variacaoNota2);
            decimal valorNota3 = CalcularTotal(itens, variacaoNota3);

            lblId.Text = $"ID: {cabecalho["Id"]}";
            lblCliente.Text = $"Cliente: {cabecalho["Cliente"]}";
            lblCnpj.Text = $"CNPJ: {cabecalho["Cnpj"]}";
            lblEndereco.Text = $"Endereço: {cabecalho["Endereco"]} - {cabecalho["BairroCep"]} - {cabecalho["CidadeEstado"]}";
            lblData.Text = $"Data: {Convert.ToDateTime(cabecalho["DataOrcamento"]):dd/MM/yyyy}";
            lblTitulo.Text = $"Título: {cabecalho["Titulo"]}";
            lblStatus.Text = $"Status: {cabecalho["Status"]}";

            lblValorNota1.Text = $"Nota 1: {FormatarMoeda(valorNota1)}";
            lblValorNota2.Text = $"Nota 2 ({variacaoNota2}%): {FormatarMoeda(valorNota2)}";
            lblValorNota3.Text = $"Nota 3 ({variacaoNota3}%): {FormatarMoeda(valorNota3)}";

            dgvItens.DataSource = itens;

            FormatarGrid();
        }

        private void FormatarGrid()
        {
            if (dgvItens.Columns.Count == 0)
                return;

            if (dgvItens.Columns.Contains("Id"))
                dgvItens.Columns["Id"].Visible = false;

            if (dgvItens.Columns.Contains("Categoria"))
                dgvItens.Columns["Categoria"].HeaderText = "Categoria";

            if (dgvItens.Columns.Contains("ServicoPermitido"))
                dgvItens.Columns["ServicoPermitido"].HeaderText = "Serviço Permitido";

            if (dgvItens.Columns.Contains("DescricaoOrcamento"))
                dgvItens.Columns["DescricaoOrcamento"].HeaderText = "Descrição";

            if (dgvItens.Columns.Contains("Quantidade"))
                dgvItens.Columns["Quantidade"].HeaderText = "Qtd";

            if (dgvItens.Columns.Contains("ValorUnitario"))
            {
                dgvItens.Columns["ValorUnitario"].HeaderText = "Valor Unitário";
                dgvItens.Columns["ValorUnitario"].DefaultCellStyle.Format = "C2";
            }

            if (dgvItens.Columns.Contains("Cortesia"))
                dgvItens.Columns["Cortesia"].HeaderText = "Cortesia";

            if (dgvItens.Columns.Contains("ValorTotal"))
            {
                dgvItens.Columns["ValorTotal"].HeaderText = "Total";
                dgvItens.Columns["ValorTotal"].DefaultCellStyle.Format = "C2";
            }

            if (dgvItens.Columns.Contains("Observacao"))
                dgvItens.Columns["Observacao"].HeaderText = "Observação";
        }

        private decimal CalcularTotal(DataTable itens, decimal variacaoPercentual)
        {
            decimal total = 0;

            foreach (DataRow item in itens.Rows)
            {
                bool cortesia = Convert.ToInt32(item["Cortesia"]) == 1;

                if (cortesia)
                    continue;

                decimal valorOriginal = ConverterDecimal(item["ValorTotal"]);

                decimal valorGerado = valorOriginal * (1 + (variacaoPercentual / 100));

                total += valorGerado;
            }

            return total;
        }

        private decimal ConverterDecimal(object valor)
        {
            if (valor == null || valor == DBNull.Value)
                return 0;

            return Convert.ToDecimal(valor);
        }

        private string FormatarMoeda(decimal valor)
        {
            return valor.ToString("C2", new CultureInfo("pt-BR"));
        }

        private void btnGerarPdfs_Click(object sender, EventArgs e)
        {
            try
            {
                var pdfService = new PdfService();

                pdfService.GerarPdfsOrcamento(_orcamentoId);

                MessageBox.Show("PDFs gerados com sucesso.");

                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar PDFs: " + ex.Message);
            }
        }

        private void btnAbrirPastaPdfs_Click(object sender, EventArgs e)
        {
            string pastaPdfs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pdfs");

            if (!Directory.Exists(pastaPdfs))
            {
                MessageBox.Show("A pasta de PDFs ainda não existe.");
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = pastaPdfs,
                UseShellExecute = true
            });
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvItens_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnEditarOrcamento_Click(object sender, EventArgs e)
        {
            using var tela = new FrmEditarOrcamento(_orcamentoId);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarDados();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            using var tela = new FrmAdicionarItemOrcamento(_orcamentoId);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarDados();
            }
        }

        private void btnRemoverItem_Click(object sender, EventArgs e)
        {
            if (dgvItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para remover.");
                return;
            }

            object valorId = dgvItens.SelectedRows[0].Cells["Id"].Value;

            if (valorId == null)
            {
                MessageBox.Show("Não foi possível identificar o item selecionado.");
                return;
            }

            int itemId = Convert.ToInt32(valorId);

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente remover este item?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta != DialogResult.Yes)
                return;

            try
            {
                _orcamentoService.RemoverItemOrcamento(itemId);

                MessageBox.Show("Item removido com sucesso.");

                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover item: " + ex.Message);
            }
        }

        private void btnEditarItem_Click(object sender, EventArgs e)
        {
            if (dgvItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para editar.");
                return;
            }

            DataGridViewRow row = dgvItens.SelectedRows[0];

            var item = new OrcamentoItem
            {
                Id = Convert.ToInt32(row.Cells["Id"].Value),
                OrcamentoId = _orcamentoId,
                Categoria = row.Cells["Categoria"].Value?.ToString() ?? "",
                ServicoPermitido = row.Cells["ServicoPermitido"].Value?.ToString() ?? "",
                DescricaoOrcamento = row.Cells["DescricaoOrcamento"].Value?.ToString() ?? "",
                Quantidade = Convert.ToDecimal(row.Cells["Quantidade"].Value),
                ValorUnitario = Convert.ToDecimal(row.Cells["ValorUnitario"].Value),
                Cortesia = Convert.ToInt32(row.Cells["Cortesia"].Value) == 1,
                ValorTotal = Convert.ToDecimal(row.Cells["ValorTotal"].Value),
                Observacao = row.Cells["Observacao"].Value?.ToString() ?? ""
            };

            using var tela = new FrmEditarItemOrcamento(item);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarDados();
            }
        }


    }
}