using ComodoroERP.Services;
using ComodoroERP.Utils;
using System.Data;

namespace ComodoroERP
{
    public partial class FrmServicosPermitidos : Form
    {
        private readonly ServicoPermitidoService _service = new();

        public FrmServicosPermitidos()
        {
            InitializeComponent();

            DarkTitleBar.Ativar(this);

            ConfigurarGrid();
            CarregarCategorias();
            CarregarServicos();
            AplicarEstiloVisual();
        }

        private void AplicarEstiloVisual()
        {
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10);

            AplicarEstiloPainel(pnlFiltros);
            AplicarEstiloPainel(pnlGrid);

            AplicarEstiloBotaoPrincipal(btnFiltrar);
            AplicarEstiloBotaoPrincipal(btnLimparFiltros);
            AplicarEstiloBotaoPrincipal(btnImportarLista);
            AplicarEstiloBotaoCancelar(btnFechar);

            AplicarEstiloGrid(dgvServicosPermitidos);

            AplicarEstiloCampos(this);

            pnlTopo.BackColor = Color.SteelBlue;

            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15);

            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Font = new Font("Segoe UI", 9);

            lblFiltros.ForeColor = Color.FromArgb(35, 35, 35);
            lblFiltros.Font = new Font("Segoe UI Semibold", 11);

            lblServicosPermitidos.ForeColor = Color.FromArgb(35, 35, 35);
            lblServicosPermitidos.Font = new Font("Segoe UI Semibold", 11);
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
                    comboBox.FlatStyle = FlatStyle.Standard;
                    comboBox.Font = new Font("Segoe UI", 10);
                }

                if (controle.HasChildren)
                {
                    AplicarEstiloCampos(controle);
                }
            }
        }

        private void dgvServicosPermitidos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void ConfigurarGrid()
        {
            dgvServicosPermitidos.AutoGenerateColumns = true;
            dgvServicosPermitidos.Columns.Clear();

            dgvServicosPermitidos.AllowUserToAddRows = false;
            dgvServicosPermitidos.AllowUserToDeleteRows = false;
            dgvServicosPermitidos.ReadOnly = true;
            dgvServicosPermitidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicosPermitidos.MultiSelect = false;
            dgvServicosPermitidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvServicosPermitidos.DataError += dgvServicosPermitidos_DataError;
        }

        private void CarregarCategorias()
        {
            cmbFiltroCategoria.Items.Clear();
            cmbFiltroCategoria.Items.Add("Todas");

            var categorias = _service.ListarCategorias();

            foreach (var categoria in categorias)
            {
                cmbFiltroCategoria.Items.Add(categoria);
            }

            cmbFiltroCategoria.SelectedIndex = 0;
        }

        private void CarregarServicos()
        {
            string categoriaFiltro = "";
            string servicoFiltro = txtFiltroServico.Text.Trim();

            if (cmbFiltroCategoria.SelectedItem != null && cmbFiltroCategoria.Text != "Todas")
            {
                categoriaFiltro = cmbFiltroCategoria.Text;
            }

            DataTable tabela = _service.ListarServicos(categoriaFiltro, servicoFiltro);

            dgvServicosPermitidos.DataSource = null;
            dgvServicosPermitidos.Columns.Clear();
            dgvServicosPermitidos.AutoGenerateColumns = true;
            dgvServicosPermitidos.DataSource = tabela;

            FormatarGrid();
        }

        private void FormatarGrid()
        {
            if (dgvServicosPermitidos.Columns.Count == 0)
                return;

            if (dgvServicosPermitidos.Columns.Contains("Id"))
                dgvServicosPermitidos.Columns["Id"].HeaderText = "ID";

            if (dgvServicosPermitidos.Columns.Contains("Categoria"))
                dgvServicosPermitidos.Columns["Categoria"].HeaderText = "Categoria";

            if (dgvServicosPermitidos.Columns.Contains("Descricao"))
                dgvServicosPermitidos.Columns["Descricao"].HeaderText = "Serviço Permitido";

            if (dgvServicosPermitidos.Columns.Contains("Ativo"))
                dgvServicosPermitidos.Columns["Ativo"].HeaderText = "Ativo";
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarServicos();
        }

        private void btnLimparFiltros_Click(object sender, EventArgs e)
        {
            txtFiltroServico.Clear();
            cmbFiltroCategoria.SelectedIndex = 0;
            CarregarServicos();
        }

        private void btnImportarLista_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Selecione o arquivo CSV de serviços permitidos";
            dialog.Filter = "Arquivos CSV (*.csv)|*.csv|Todos os arquivos (*.*)|*.*";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                int quantidade = _service.ImportarCsv(dialog.FileName);

                MessageBox.Show($"Importação concluída com sucesso. Serviços novos importados: {quantidade}");

                CarregarCategorias();
                CarregarServicos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao importar CSV: " + ex.Message);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}