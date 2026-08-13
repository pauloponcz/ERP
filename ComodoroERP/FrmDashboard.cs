using ComodoroERP.Services;
using System.Data;
using System.Globalization;

namespace ComodoroERP
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();

            ConfigurarGrid();
            CarregarDashboard();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private readonly DashboardService _dashboardService = new();

        private void ConfigurarGrid()
        {
            dgvUltimosOrcamentos.DataSource = null;
            dgvUltimosOrcamentos.Columns.Clear();
            dgvUltimosOrcamentos.AutoGenerateColumns = true;

            dgvUltimosOrcamentos.AllowUserToAddRows = false;
            dgvUltimosOrcamentos.AllowUserToDeleteRows = false;
            dgvUltimosOrcamentos.ReadOnly = true;
            dgvUltimosOrcamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUltimosOrcamentos.MultiSelect = false;
            dgvUltimosOrcamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvUltimosOrcamentos.DataError += dgvUltimosOrcamentos_DataError;
        }

        private void CarregarDashboard()
        {
            int total = _dashboardService.ObterTotalOrcamentos();
            int pendentes = _dashboardService.ObterTotalPorStatus("Pendente");
            int pagos = _dashboardService.ObterTotalPorStatus("Pago");
            int cancelados = _dashboardService.ObterTotalPorStatus("Cancelado");

            decimal valorTotal = _dashboardService.ObterValorTotalGeral();
            decimal valorPendente = _dashboardService.ObterValorPorStatus("Pendente");
            decimal valorPago = _dashboardService.ObterValorPorStatus("Pago");

            lblTotalOrcamentos.Text = $"Total de Orçamentos: {total}";
            lblPendentes.Text = $"Pendentes: {pendentes}";
            lblPagos.Text = $"Pagos: {pagos}";
            lblCancelados.Text = $"Cancelados: {cancelados}";

            lblValorTotal.Text = $"Valor Total: {FormatarMoeda(valorTotal)}";
            lblValorPendente.Text = $"Valor Pendente: {FormatarMoeda(valorPendente)}";
            lblValorPago.Text = $"Valor Pago: {FormatarMoeda(valorPago)}";

            DataTable tabela = _dashboardService.ListarUltimosOrcamentos();

            dgvUltimosOrcamentos.DataSource = null;
            dgvUltimosOrcamentos.Columns.Clear();
            dgvUltimosOrcamentos.AutoGenerateColumns = true;
            dgvUltimosOrcamentos.DataSource = tabela;

            FormatarGrid();
        }

        private void FormatarGrid()
        {
            if (dgvUltimosOrcamentos.Columns.Count == 0)
                return;

            if (dgvUltimosOrcamentos.Columns.Contains("Id"))
                dgvUltimosOrcamentos.Columns["Id"].HeaderText = "ID";

            if (dgvUltimosOrcamentos.Columns.Contains("Data"))
                dgvUltimosOrcamentos.Columns["Data"].HeaderText = "Data";

            if (dgvUltimosOrcamentos.Columns.Contains("Cliente"))
                dgvUltimosOrcamentos.Columns["Cliente"].HeaderText = "Cliente";

            if (dgvUltimosOrcamentos.Columns.Contains("Titulo"))
                dgvUltimosOrcamentos.Columns["Titulo"].HeaderText = "Título";

            if (dgvUltimosOrcamentos.Columns.Contains("Status"))
                dgvUltimosOrcamentos.Columns["Status"].HeaderText = "Status";

            if (dgvUltimosOrcamentos.Columns.Contains("ValorTotal"))
            {
                dgvUltimosOrcamentos.Columns["ValorTotal"].HeaderText = "Valor Total";
                dgvUltimosOrcamentos.Columns["ValorTotal"].DefaultCellStyle.Format = "C2";
            }
        }

        private string FormatarMoeda(decimal valor)
        {
            return valor.ToString("C2", new CultureInfo("pt-BR"));
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDashboard();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvUltimosOrcamentos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
    }
}