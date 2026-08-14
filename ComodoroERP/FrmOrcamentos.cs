using ComodoroERP.Services;
using System.Data;
using ComodoroERP.Reports;
using System.Drawing;

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
            AplicarEstiloVisual();
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
                var service = new ExcelModeloPdfService();

                var arquivosPdf = service.GerarPdfsPorModeloExcel(idOrcamento);

                MessageBox.Show($"PDFs gerados com sucesso: {arquivosPdf.Count}");
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


        private void AplicarEstiloVisual()
        {
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10);

            AplicarEstiloPainel(pnlFiltros);
            AplicarEstiloPainel(pnlGrid);

            AplicarEstiloBotaoPrincipal(btnFiltrar);
            AplicarEstiloBotaoPrincipal(btnLimparFiltros);
            AplicarEstiloBotaoPrincipal(btnAbrirOrcamento);
            AplicarEstiloBotaoPrincipal(btnAlterarStatus);
            AplicarEstiloBotaoPrincipal(btnGerarPdfs);

            AplicarEstiloBotaoExcluir(btnExcluirOrcamento);
            AplicarEstiloBotaoCancelar(btnFechar);

            AplicarEstiloGrid(dgvOrcamentos);

            AplicarEstiloCampos(this);

            pnlTopo.BackColor = Color.SteelBlue;

            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15);

            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Font = new Font("Segoe UI", 9);
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

        private void AplicarEstiloBotaoExcluir(Button botao)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.BackColor = Color.IndianRed;
            botao.ForeColor = Color.White;
            botao.Font = new Font("Segoe UI Semibold", 10);
            botao.Cursor = Cursors.Hand;

            botao.FlatAppearance.BorderSize = 0;

            botao.MouseEnter += (s, e) =>
            {
                botao.BackColor = Color.Firebrick;
            };

            botao.MouseLeave += (s, e) =>
            {
                botao.BackColor = Color.IndianRed;
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

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}