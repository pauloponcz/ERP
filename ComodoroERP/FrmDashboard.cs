using ComodoroERP.Services;
using ComodoroERP.Utils;
using System.Data;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace ComodoroERP
{
    public partial class FrmDashboard : FrmBase
    {
        private readonly AcertoDashboardService _dashboardService = new();

        private AcertoDashboardResumo _resumoAtual = new();
        private List<AcertoRankingEscola> _rankingAtual = new();

        public FrmDashboard()
        {
            InitializeComponent();

            DarkTitleBar.Ativar(this);

            ConfigurarTela();
            AplicarEstiloVisual();
            CarregarEscolas();
            CarregarDashboard();
        }

        private void ConfigurarTela()
        {
            cmbEscola.DropDownStyle = ComboBoxStyle.DropDown;
            cmbEscola.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbEscola.AutoCompleteSource = AutoCompleteSource.ListItems;

            dtpDataInicial.Checked = false;
            dtpDataFinal.Checked = false;

            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvRanking.DataSource = null;
            dgvRanking.Columns.Clear();
            dgvRanking.AutoGenerateColumns = true;

            dgvRanking.AllowUserToAddRows = false;
            dgvRanking.AllowUserToDeleteRows = false;
            dgvRanking.ReadOnly = true;
            dgvRanking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRanking.MultiSelect = false;
            dgvRanking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvRanking.DataError += dgvRanking_DataError;
        }

        private void CarregarEscolas()
        {
            string textoAtual = cmbEscola.Text;

            cmbEscola.Items.Clear();

            foreach (string escola in _dashboardService.ListarEscolas())
            {
                cmbEscola.Items.Add(escola);
            }

            cmbEscola.Text = textoAtual;
        }

        private void CarregarDashboard()
        {
            string escolaFiltro = cmbEscola.Text.Trim();
            DateTime? dataInicial = dtpDataInicial.Checked ? dtpDataInicial.Value.Date : null;
            DateTime? dataFinal = dtpDataFinal.Checked ? dtpDataFinal.Value.Date : null;

            _resumoAtual = _dashboardService.ObterResumo(escolaFiltro, dataInicial, dataFinal);
            _rankingAtual = _dashboardService.ListarRankingPorEscola(escolaFiltro, dataInicial, dataFinal);

            lblTotalAcertos.Text = _resumoAtual.TotalAcertos.ToString();
            lblValorTotal.Text = FormatarMoeda(_resumoAtual.ValorTotal);
            lblValorPago.Text = FormatarMoeda(_resumoAtual.ValorPago);
            lblValorPendente.Text = FormatarMoeda(_resumoAtual.ValorPendente);
            lblPercentualPago.Text = FormatarPercentual(_resumoAtual.PercentualPago);

            lblMelhorPagadoraEscola.Text = _resumoAtual.MelhorPagadora;
            lblMelhorPagadoraDetalhe.Text =
                $"{FormatarPercentual(_resumoAtual.MelhorPagadoraPercentual)} pago - {FormatarMoeda(_resumoAtual.MelhorPagadoraValorPago)}";

            lblMaiorDevedoraEscola.Text = _resumoAtual.MaiorDevedora;
            lblMaiorDevedoraDetalhe.Text =
                $"{FormatarMoeda(_resumoAtual.MaiorDevedoraValorPendente)} pendente";

            DataTable tabela = _dashboardService.ListarRankingDataTable(escolaFiltro, dataInicial, dataFinal);

            dgvRanking.DataSource = null;
            dgvRanking.Columns.Clear();
            dgvRanking.AutoGenerateColumns = true;
            dgvRanking.DataSource = tabela;

            FormatarGrid();

            pnlGraficoStatus.Invalidate();
            pnlGraficoDevedores.Invalidate();
            pnlGraficoPagadores.Invalidate();
        }

        private void FormatarGrid()
        {
            if (dgvRanking.Columns.Count == 0)
                return;

            if (dgvRanking.Columns.Contains("Escola"))
            {
                dgvRanking.Columns["Escola"].HeaderText = "Escola";
                dgvRanking.Columns["Escola"].FillWeight = 190;
            }

            if (dgvRanking.Columns.Contains("TotalAcertos"))
            {
                dgvRanking.Columns["TotalAcertos"].HeaderText = "Qtd.";
                dgvRanking.Columns["TotalAcertos"].FillWeight = 55;
            }

            if (dgvRanking.Columns.Contains("ValorTotal"))
            {
                dgvRanking.Columns["ValorTotal"].HeaderText = "Valor Total";
                dgvRanking.Columns["ValorTotal"].DefaultCellStyle.Format = "C2";
                dgvRanking.Columns["ValorTotal"].FillWeight = 95;
            }

            if (dgvRanking.Columns.Contains("ValorPago"))
            {
                dgvRanking.Columns["ValorPago"].HeaderText = "Valor Pago";
                dgvRanking.Columns["ValorPago"].DefaultCellStyle.Format = "C2";
                dgvRanking.Columns["ValorPago"].FillWeight = 95;
            }

            if (dgvRanking.Columns.Contains("ValorPendente"))
            {
                dgvRanking.Columns["ValorPendente"].HeaderText = "Valor Pendente";
                dgvRanking.Columns["ValorPendente"].DefaultCellStyle.Format = "C2";
                dgvRanking.Columns["ValorPendente"].FillWeight = 105;
            }

            if (dgvRanking.Columns.Contains("PercentualPago"))
            {
                dgvRanking.Columns["PercentualPago"].HeaderText = "% Pago";
                dgvRanking.Columns["PercentualPago"].DefaultCellStyle.Format = "N2";
                dgvRanking.Columns["PercentualPago"].FillWeight = 70;
            }
        }

        private string FormatarMoeda(decimal valor)
        {
            return valor.ToString("C2", new CultureInfo("pt-BR"));
        }

        private string FormatarPercentual(decimal valor)
        {
            return valor.ToString("N2", new CultureInfo("pt-BR")) + "%";
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarDashboard();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            cmbEscola.Text = "";
            dtpDataInicial.Checked = false;
            dtpDataFinal.Checked = false;
            CarregarDashboard();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarEscolas();
            CarregarDashboard();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvRanking_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void pnlGraficoStatus_Paint(object sender, PaintEventArgs e)
        {
            DesenharGraficoPagoPendente(e.Graphics, pnlGraficoStatus.ClientRectangle);
        }

        private void pnlGraficoDevedores_Paint(object sender, PaintEventArgs e)
        {
            var dados = _rankingAtual
                .Where(x => x.ValorPendente > 0)
                .OrderByDescending(x => x.ValorPendente)
                .Take(5)
                .Select(x => (Nome: x.Escola, Valor: x.ValorPendente))
                .ToList();

            DesenharGraficoBarras(e.Graphics, pnlGraficoDevedores.ClientRectangle, dados, "Top 5 maiores pendências", Color.IndianRed);
        }

        private void pnlGraficoPagadores_Paint(object sender, PaintEventArgs e)
        {
            var dados = _rankingAtual
                .Where(x => x.ValorPago > 0)
                .OrderByDescending(x => x.ValorPago)
                .Take(5)
                .Select(x => (Nome: x.Escola, Valor: x.ValorPago))
                .ToList();

            DesenharGraficoBarras(e.Graphics, pnlGraficoPagadores.ClientRectangle, dados, "Top 5 maiores pagamentos", Color.SeaGreen);
        }

        private void DesenharGraficoPagoPendente(Graphics graphics, Rectangle area)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);

            using Font fonteTitulo = new Font("Segoe UI Semibold", 10);
            using Font fonteTexto = new Font("Segoe UI", 8);
            using Brush texto = new SolidBrush(Color.FromArgb(45, 45, 45));
            using Brush pago = new SolidBrush(Color.SeaGreen);
            using Brush pendente = new SolidBrush(Color.IndianRed);
            using Brush fundo = new SolidBrush(Color.FromArgb(240, 240, 240));

            graphics.DrawString("Pago x Pendente", fonteTitulo, texto, 15, 12);

            decimal total = _resumoAtual.ValorPago + _resumoAtual.ValorPendente;
            Rectangle barra = new Rectangle(15, 55, area.Width - 30, 28);

            graphics.FillRectangle(fundo, barra);

            if (total > 0)
            {
                int larguraPago = Convert.ToInt32(barra.Width * (_resumoAtual.ValorPago / total));
                int larguraPendente = barra.Width - larguraPago;

                graphics.FillRectangle(pago, new Rectangle(barra.X, barra.Y, larguraPago, barra.Height));
                graphics.FillRectangle(pendente, new Rectangle(barra.X + larguraPago, barra.Y, larguraPendente, barra.Height));
            }

            if (total <= 0)
            {
                graphics.DrawString("Sem dados para o período selecionado.", fonteTexto, texto, 15, 95);
                return;
            }

            graphics.DrawString($"Pago: {FormatarMoeda(_resumoAtual.ValorPago)}", fonteTexto, pago, 15, 95);
            graphics.DrawString($"Pendente: {FormatarMoeda(_resumoAtual.ValorPendente)}", fonteTexto, pendente, 15, 115);
        }

        private void DesenharGraficoBarras(
            Graphics graphics,
            Rectangle area,
            List<(string Nome, decimal Valor)> dados,
            string titulo,
            Color cor)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);

            using Font fonteTitulo = new Font("Segoe UI Semibold", 10);
            using Font fonteTexto = new Font("Segoe UI", 8);
            using Brush texto = new SolidBrush(Color.FromArgb(45, 45, 45));
            using Brush barraBrush = new SolidBrush(cor);

            graphics.DrawString(titulo, fonteTitulo, texto, 15, 12);

            if (dados.Count == 0)
            {
                graphics.DrawString("Sem dados para o período selecionado.", fonteTexto, texto, 15, 55);
                return;
            }

            decimal maiorValor = dados.Max(x => x.Valor);

            int y = 48;
            int alturaBarra = 18;
            int espaco = 31;

            int xNome = 15;
            int larguraNome = 130;

            int xBarra = 165;

            int margemDireita = 15;
            int larguraReservadaValor = 95;

            int larguraMaxima = area.Width - xBarra - larguraReservadaValor - margemDireita;

            if (larguraMaxima < 50)
                larguraMaxima = 50;

            foreach (var item in dados)
            {
                int largura = maiorValor <= 0 ? 0 : Convert.ToInt32(larguraMaxima * (item.Valor / maiorValor));

                string nome = item.Nome;

                if (nome.Length > 20)
                    nome = nome.Substring(0, 20) + "...";

                string valorFormatado = FormatarMoeda(item.Valor);

                graphics.DrawString(
                    nome,
                    fonteTexto,
                    texto,
                    new RectangleF(xNome, y, larguraNome, 20)
                );

                graphics.FillRectangle(
                    barraBrush,
                    new Rectangle(xBarra, y + 2, largura, alturaBarra)
                );

                graphics.DrawString(
                    valorFormatado,
                    fonteTexto,
                    texto,
                    new RectangleF(xBarra + largura + 5, y, larguraReservadaValor, 20)
                );

                y += espaco;
            }
        }

        private void AplicarEstiloVisual()
        {
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10);

            AplicarEstiloPainel(pnlFiltros);

            AplicarEstiloCard(pnlTotalAcertos);
            AplicarEstiloCard(pnlValorTotal);
            AplicarEstiloCard(pnlValorPago);
            AplicarEstiloCard(pnlValorPendente);
            AplicarEstiloCard(pnlPercentualPago);

            AplicarEstiloCard(pnlMelhorPagadora);
            AplicarEstiloCard(pnlMaiorDevedora);

            AplicarEstiloPainel(pnlGraficoStatus);
            AplicarEstiloPainel(pnlGraficoDevedores);
            AplicarEstiloPainel(pnlGraficoPagadores);
            AplicarEstiloPainel(pnlGrid);

            AplicarEstiloBotaoPrincipal(btnFiltrar);
            AplicarEstiloBotaoPrincipal(btnLimpar);
            AplicarEstiloBotaoPrincipal(btnAtualizar);
            AplicarEstiloBotaoCancelar(btnFechar);

            AplicarEstiloGrid(dgvRanking);
            AplicarEstiloCampos(this);

            pnlTopo.BackColor = Color.SteelBlue;

            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15);

            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Font = new Font("Segoe UI", 9);

            AplicarEstiloTitulosCards();
            AplicarEstiloValoresCards();

            lblRanking.ForeColor = Color.FromArgb(35, 35, 35);
            lblRanking.Font = new Font("Segoe UI Semibold", 11);
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
                lblTituloTotalAcertos,
                lblTituloValorTotal,
                lblTituloValorPago,
                lblTituloValorPendente,
                lblTituloPercentualPago,
                lblTituloMelhorPagadora,
                lblTituloMaiorDevedora
            };

            foreach (var label in titulos)
            {
                label.ForeColor = Color.DimGray;
                label.Font = new Font("Segoe UI", 9);
            }
        }

        private void AplicarEstiloValoresCards()
        {
            lblTotalAcertos.ForeColor = Color.SteelBlue;
            lblValorTotal.ForeColor = Color.SteelBlue;
            lblValorPago.ForeColor = Color.SeaGreen;
            lblValorPendente.ForeColor = Color.IndianRed;
            lblPercentualPago.ForeColor = Color.SeaGreen;

            lblTotalAcertos.Font = new Font("Segoe UI Semibold", 17);
            lblValorTotal.Font = new Font("Segoe UI Semibold", 15);
            lblValorPago.Font = new Font("Segoe UI Semibold", 15);
            lblValorPendente.Font = new Font("Segoe UI Semibold", 15);
            lblPercentualPago.Font = new Font("Segoe UI Semibold", 15);

            lblMelhorPagadoraEscola.ForeColor = Color.SeaGreen;
            lblMelhorPagadoraEscola.Font = new Font("Segoe UI Semibold", 10);
            lblMelhorPagadoraDetalhe.ForeColor = Color.DimGray;
            lblMelhorPagadoraDetalhe.Font = new Font("Segoe UI", 8);

            lblMaiorDevedoraEscola.ForeColor = Color.IndianRed;
            lblMaiorDevedoraEscola.Font = new Font("Segoe UI Semibold", 10);
            lblMaiorDevedoraDetalhe.ForeColor = Color.DimGray;
            lblMaiorDevedoraDetalhe.Font = new Font("Segoe UI", 8);
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
            botao.MouseEnter += (s, e) => { botao.BackColor = Color.AliceBlue; };
            botao.MouseLeave += (s, e) => { botao.BackColor = Color.White; };
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
            botao.MouseEnter += (s, e) => { botao.BackColor = Color.Gainsboro; };
            botao.MouseLeave += (s, e) => { botao.BackColor = Color.White; };
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

                if (controle is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Standard;
                    comboBox.Font = new Font("Segoe UI", 10);
                }

                if (controle is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Font = new Font("Segoe UI", 10);
                }

                if (controle.HasChildren)
                    AplicarEstiloCampos(controle);
            }
        }
    }
}
