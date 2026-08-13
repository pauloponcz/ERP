using ComodoroERP.Services;
using System.Data;

namespace ComodoroERP
{
    public partial class FrmItens : Form
    {
        private readonly OrcamentoService _orcamentoService = new();

        public FrmItens()
        {
            InitializeComponent();

            ConfigurarTela();
            ConfigurarGrid();
            CarregarItens();
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

            cmbFiltroCategoria.Items.Clear();
            cmbFiltroCategoria.Items.Add("Todas");
            cmbFiltroCategoria.Items.Add("SERVIÇO DE MANUTENÇÃO ELÉTRICA");
            cmbFiltroCategoria.Items.Add("SERVIÇO DE MANUTENÇÃO HIDRÁULICA");
            cmbFiltroCategoria.Items.Add("SERVIÇO DE MANUTENÇÃO DE PINTURA, TELHADO E PISO");
            cmbFiltroCategoria.Items.Add("SERVIÇO DE MANUTENÇÃO DE PORTA, JANELA, PORTÃO E GRADES");
            cmbFiltroCategoria.Items.Add("SERVIÇO DE MARCENARIA E MAN. DE MOBILIÁRIO EM GERAL E ESCOLAR");
            cmbFiltroCategoria.Items.Add("SERVIÇO DE MANUTENÇÃO E CONSERVAÇÃO DO IMÓVEL EM GERAL");
            cmbFiltroCategoria.SelectedIndex = 0;

            dtpDataInicial.Checked = false;
            dtpDataFinal.Checked = false;
        }

        private void ConfigurarGrid()
        {
            dgvItens.AllowUserToAddRows = false;
            dgvItens.AllowUserToDeleteRows = false;
            dgvItens.ReadOnly = true;
            dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItens.MultiSelect = false;
            dgvItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CarregarItens()
        {
            string clienteFiltro = txtFiltroCliente.Text.Trim();
            string servicoFiltro = txtFiltroServico.Text.Trim();

            string categoriaFiltro = "";
            if (cmbFiltroCategoria.SelectedItem != null && cmbFiltroCategoria.Text != "Todas")
            {
                categoriaFiltro = cmbFiltroCategoria.Text;
            }

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

            DataTable tabela = _orcamentoService.ListarItens(
                clienteFiltro,
                categoriaFiltro,
                servicoFiltro,
                statusFiltro,
                dataInicial,
                dataFinal
            );

            dgvItens.DataSource = tabela;

            FormatarGrid();
        }

        private void FormatarGrid()
        {
            if (dgvItens.Columns.Count == 0)
                return;

            if (dgvItens.Columns.Contains("OrcamentoId"))
                dgvItens.Columns["OrcamentoId"].HeaderText = "Orçamento";

            if (dgvItens.Columns.Contains("Data"))
                dgvItens.Columns["Data"].HeaderText = "Data";

            if (dgvItens.Columns.Contains("Cliente"))
                dgvItens.Columns["Cliente"].HeaderText = "Cliente";

            if (dgvItens.Columns.Contains("Status"))
                dgvItens.Columns["Status"].HeaderText = "Status";

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

            if (dgvItens.Columns.Contains("ValorTotal"))
            {
                dgvItens.Columns["ValorTotal"].HeaderText = "Total";
                dgvItens.Columns["ValorTotal"].DefaultCellStyle.Format = "C2";
            }

            if (dgvItens.Columns.Contains("Cortesia"))
                dgvItens.Columns["Cortesia"].HeaderText = "Cortesia";
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarItens();
        }

        private void btnLimparFiltros_Click(object sender, EventArgs e)
        {
            txtFiltroCliente.Clear();
            txtFiltroServico.Clear();

            cmbFiltroCategoria.SelectedIndex = 0;
            cmbFiltroStatus.SelectedIndex = 0;

            dtpDataInicial.Checked = false;
            dtpDataFinal.Checked = false;

            CarregarItens();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbFiltroStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

    }
}