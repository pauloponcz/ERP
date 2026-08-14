using ComodoroERP.Services;
using ComodoroERP.Utils;
using System.Data;
using System.Globalization;

namespace ComodoroERP
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();

            DarkTitleBar.Ativar(this);

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

            lblTotalOrcamentos.Text = total.ToString();
            lblPendentes.Text = pendentes.ToString();
            lblPagos.Text = pagos.ToString();
            lblCancelados.Text = cancelados.ToString();

            lblValorTotal.Text = FormatarMoeda(valorTotal);
            lblValorPendente.Text = FormatarMoeda(valorPendente);
            lblValorPago.Text = FormatarMoeda(valorPago);

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

        private void AplicarEstiloVisual()
        {
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10);

            AplicarEstiloCard(pnlTotalOrcamentos);
            AplicarEstiloCard(pnlPendentes);
            AplicarEstiloCard(pnlPagos);
            AplicarEstiloCard(pnlCancelados);
            AplicarEstiloCard(pnlValorTotal);
            AplicarEstiloCard(pnlValorPendente);
            AplicarEstiloCard(pnlValorPago);

            AplicarEstiloPainel(pnlGrid);

            AplicarEstiloBotaoPrincipal(btnAtualizar);
            AplicarEstiloBotaoCancelar(btnFechar);

            AplicarEstiloGrid(dgvUltimosOrcamentos);

            AplicarEstiloCampos(this);

            pnlTopo.BackColor = Color.SteelBlue;

            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15);

            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Font = new Font("Segoe UI", 9);

            AplicarEstiloTitulosCards();
            AplicarEstiloValoresCards();

            lblUltimosOrcamentos.ForeColor = Color.FromArgb(35, 35, 35);
            lblUltimosOrcamentos.Font = new Font("Segoe UI Semibold", 11);
        }

        private void AplicarEstiloCard(Panel painel)
        {
            painel.BackColor = Color.White;
            painel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void AplicarEstiloPainel(Panel painel)
        {
            painel.BackColor = Color.White;
            painel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void AplicarEstiloTitulosCards()
        {
            Label[] titulos =
            {
                lblTituloTotalOrcamentos,
                lblTituloPendentes,
                lblTituloPagos,
                lblTituloCancelados,
                lblTituloValorTotal,
                lblTituloValorPendente,
                lblTituloValorPago
            };

            foreach (var label in titulos)
            {
                label.ForeColor = Color.DimGray;
                label.Font = new Font("Segoe UI", 9);
            }
        }

        private void AplicarEstiloValoresCards()
        {
            lblTotalOrcamentos.ForeColor = Color.SteelBlue;
            lblPendentes.ForeColor = Color.DarkOrange;
            lblPagos.ForeColor = Color.SeaGreen;
            lblCancelados.ForeColor = Color.IndianRed;

            lblValorTotal.ForeColor = Color.SteelBlue;
            lblValorPendente.ForeColor = Color.DarkOrange;
            lblValorPago.ForeColor = Color.SeaGreen;

            lblTotalOrcamentos.Font = new Font("Segoe UI Semibold", 18);
            lblPendentes.Font = new Font("Segoe UI Semibold", 18);
            lblPagos.Font = new Font("Segoe UI Semibold", 18);
            lblCancelados.Font = new Font("Segoe UI Semibold", 18);

            lblValorTotal.Font = new Font("Segoe UI Semibold", 16);
            lblValorPendente.Font = new Font("Segoe UI Semibold", 16);
            lblValorPago.Font = new Font("Segoe UI Semibold", 16);
        }

        private void AplicarEstiloBotaoPrincipal(Button botao)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.BackColor = Color.White;
            botao.ForeColor = Color.FromArgb(45, 45, 45);
            botao.Font = new Font("Segoe UI Semibold", 10);
            botao.Cursor = Cursors.Hand;

            botao.FlatAppearance.BorderColor = Color.Gainsboro;
            botao.FlatAppearance.BorderSize = 1;

            botao.MouseEnter += (s, e) =>
            {
                botao.BackColor = Color.AliceBlue;
            };

            botao.MouseLeave += (s, e) =>
            {
                botao.BackColor = Color.White;
            };
        }

        private void AplicarEstiloBotaoCancelar(Button botao)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.BackColor = Color.White;
            botao.ForeColor = Color.DimGray;
            botao.Font = new Font("Segoe UI Semibold", 10);
            botao.Cursor = Cursors.Hand;

            botao.FlatAppearance.BorderColor = Color.Silver;
            botao.FlatAppearance.BorderSize = 1;

            botao.MouseEnter += (s, e) =>
            {
                botao.BackColor = Color.Gainsboro;
            };

            botao.MouseLeave += (s, e) =>
            {
                botao.BackColor = Color.White;
            };
        }

        private void AplicarEstiloGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = Color.Gainsboro;

            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            grid.DefaultCellStyle.SelectionBackColor = Color.AliceBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AplicarEstiloCampos(Control controlePai)
        {
            foreach (Control controle in controlePai.Controls)
            {
                if (controle is Label label)
                {
                    if (label.Parent == pnlTopo)
                        continue;

                    label.ForeColor = Color.DimGray;
                    label.Font = new Font("Segoe UI", 9);
                }

                if (controle.HasChildren)
                {
                    AplicarEstiloCampos(controle);
                }
            }
        }
    }
}