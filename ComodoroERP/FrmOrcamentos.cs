using ComodoroERP.Services;
using System.Data;
using ComodoroERP.Reports;

namespace ComodoroERP
{
    public partial class FrmOrcamentos : Form
    {
        private readonly OrcamentoService _orcamentoService = new();

        public FrmOrcamentos()
        {
            InitializeComponent();
            ConfigurarTela();
            ConfigurarGrid();
            CarregarOrcamentos();
        }

        private void ConfigurarTela()
        {
            cmbFiltroStatus.Items.Clear();
            cmbFiltroStatus.Items.Add("Todos");
            cmbFiltroStatus.Items.Add("Pendente");
            cmbFiltroStatus.Items.Add("Pago");
            cmbFiltroStatus.Items.Add("Parcial");
            cmbFiltroStatus.Items.Add("Concluído");
            cmbFiltroStatus.Items.Add("Cancelado");
            cmbFiltroStatus.SelectedIndex = 0;

            dtpDataInicial.Checked = false;
            dtpDataFinal.Checked = false;
        }

        private void ConfigurarGrid()
        {
            dgvOrcamentos.AllowUserToAddRows = false;
            dgvOrcamentos.AllowUserToDeleteRows = false;
            dgvOrcamentos.ReadOnly = true;
            dgvOrcamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrcamentos.MultiSelect = false;
            dgvOrcamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CarregarOrcamentos()
        {
            string clienteFiltro = txtFiltroCliente.Text.Trim();

            string statusFiltro = "";

            if (cmbFiltroStatus.SelectedItem != null && cmbFiltroStatus.Text != "Todos")
            {
                statusFiltro = cmbFiltroStatus.Text;
            }

            DateTime? dataInicial = null;
            DateTime? dataFinal = null;

            if (dtpDataInicial.Checked)
            {
                dataInicial = dtpDataInicial.Value.Date;
            }

            if (dtpDataFinal.Checked)
            {
                dataFinal = dtpDataFinal.Value.Date;
            }

            DataTable tabela = _orcamentoService.ListarOrcamentos(
                clienteFiltro,
                statusFiltro,
                dataInicial,
                dataFinal
            );

            dgvOrcamentos.DataSource = tabela;

            FormatarGrid();
        }

        private void FormatarGrid()
        {
            if (dgvOrcamentos.Columns.Count == 0)
                return;

            if (dgvOrcamentos.Columns.Contains("Id"))
                dgvOrcamentos.Columns["Id"].HeaderText = "ID";

            if (dgvOrcamentos.Columns.Contains("Data"))
                dgvOrcamentos.Columns["Data"].HeaderText = "Data";

            if (dgvOrcamentos.Columns.Contains("Cliente"))
                dgvOrcamentos.Columns["Cliente"].HeaderText = "Cliente";

            if (dgvOrcamentos.Columns.Contains("Cnpj"))
                dgvOrcamentos.Columns["Cnpj"].HeaderText = "CNPJ";

            if (dgvOrcamentos.Columns.Contains("Titulo"))
                dgvOrcamentos.Columns["Titulo"].HeaderText = "Título";

            if (dgvOrcamentos.Columns.Contains("Status"))
                dgvOrcamentos.Columns["Status"].HeaderText = "Status";

            FormatarColunaMoeda("ValorOriginal", "Valor Original");
            FormatarColunaMoeda("ValorNota1", "Nota 1");
            FormatarColunaMoeda("ValorNota2", "Nota 2");
            FormatarColunaMoeda("ValorNota3", "Nota 3");
        }

        private void FormatarColunaMoeda(string nomeColuna, string titulo)
        {
            if (!dgvOrcamentos.Columns.Contains(nomeColuna))
                return;

            dgvOrcamentos.Columns[nomeColuna].HeaderText = titulo;
            dgvOrcamentos.Columns[nomeColuna].DefaultCellStyle.Format = "C2";
        }

        private int ObterIdOrcamentoSelecionado()
        {
            if (dgvOrcamentos.SelectedRows.Count == 0)
                return 0;

            object valor = dgvOrcamentos.SelectedRows[0].Cells["Id"].Value;

            if (valor == null)
                return 0;

            return Convert.ToInt32(valor);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarOrcamentos();
        }

        private void btnLimparFiltros_Click(object sender, EventArgs e)
        {
            txtFiltroCliente.Clear();
            cmbFiltroStatus.SelectedIndex = 0;

            dtpDataInicial.Checked = false;
            dtpDataFinal.Checked = false;

            CarregarOrcamentos();
        }

        private void btnAlterarStatus_Click(object sender, EventArgs e)
        {
            int idOrcamento = ObterIdOrcamentoSelecionado();

            if (idOrcamento == 0)
            {
                MessageBox.Show("Selecione um orçamento para alterar o status.");
                return;
            }

            using var tela = new FrmAlterarStatus(idOrcamento);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarOrcamentos();
            }
        }

        private void btnGerarPdfs_Click(object sender, EventArgs e)
        {
            int idOrcamento = ObterIdOrcamentoSelecionado();

            if (idOrcamento == 0)
            {
                MessageBox.Show("Selecione um orçamento para gerar os PDFs.");
                return;
            }

            try
            {
                var pdfService = new PdfService();

                pdfService.GerarPdfsOrcamento(idOrcamento);

                MessageBox.Show("PDFs gerados com sucesso na pasta 'pdfs' do sistema.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar PDFs: " + ex.Message);
            }
        }

        private void btnAbrirOrcamento_Click(object sender, EventArgs e)
        {
            int idOrcamento = ObterIdOrcamentoSelecionado();

            if (idOrcamento == 0)
            {
                MessageBox.Show("Selecione um orçamento para abrir.");
                return;
            }

            using var tela = new FrmDetalhesOrcamento(idOrcamento);
            tela.ShowDialog();

            CarregarOrcamentos();
        }

        private void btnExcluirOrcamento_Click(object sender, EventArgs e)
        {
            int idOrcamento = ObterIdOrcamentoSelecionado();

            if (idOrcamento == 0)
            {
                MessageBox.Show("Selecione um orçamento para excluir.");
                return;
            }

            DialogResult resposta = MessageBox.Show(
                $"Deseja realmente excluir o orçamento {idOrcamento}?\n\nEssa ação irá apagar os itens e PDFs gerados.",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resposta != DialogResult.Yes)
                return;

            try
            {
                _orcamentoService.ExcluirOrcamento(idOrcamento);

                MessageBox.Show("Orçamento excluído com sucesso.");

                CarregarOrcamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir orçamento: " + ex.Message);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}