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
            AplicarEstiloVisual();
            CarregarItens();
        }

        private void AplicarEstiloVisual()
        {
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10);

            AplicarEstiloPainel(pnlFiltros);
            AplicarEstiloPainel(pnlGrid);

            AplicarEstiloBotaoPrincipal(btnFiltrar);
            AplicarEstiloBotaoPrincipal(btnLimparFiltros);
            AplicarEstiloBotaoCancelar(btnFechar);

            AplicarEstiloGrid(dgvItens);

            AplicarEstiloCampos(this);

            pnlTopo.BackColor = Color.SteelBlue;

            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15);

            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Font = new Font("Segoe UI", 9);

            lblFiltros.ForeColor = Color.FromArgb(35, 35, 35);
            lblFiltros.Font = new Font("Segoe UI Semibold", 11);

            lblItensLancados.ForeColor = Color.FromArgb(35, 35, 35);
            lblItensLancados.Font = new Font("Segoe UI Semibold", 11);
        }

        private void AplicarEstiloPainel(Panel painel)
        {
            painel.BackColor = Color.White;
            painel.BorderStyle = BorderStyle.FixedSingle;
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

                if (controle is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.Font = new Font("Segoe UI", 10);
                }

                if (controle is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                    comboBox.Font = new Font("Segoe UI", 10);
                }

                if (controle is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Font = new Font("Segoe UI", 10);
                }

                if (controle.HasChildren)
                {
                    AplicarEstiloCampos(controle);
                }
            }
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