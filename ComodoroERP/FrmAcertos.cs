using ComodoroERP.Services;
using ComodoroERP.Utils;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace ComodoroERP
{
    public partial class FrmAcertos : Form
    {
        private readonly AcertoService _acertoService = new();
        private List<string> _escolasOriginais = new();
        private bool _atualizandoComboEscola = false;

        private int _versaoFiltroEscola = 0;

        private bool _carregandoGrid = false;

        public FrmAcertos()
        {
            InitializeComponent();
            DarkTitleBar.Ativar(this);
            ConfigurarTela();
            AplicarEstiloVisual();
            CarregarAcertos();
        }

        private void ConfigurarTela()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Todos");
            cmbStatus.Items.Add("Pendente");
            cmbStatus.Items.Add("Pago");
            cmbStatus.SelectedIndex = 0;

            dtpDataInicial.Checked = false;
            dtpDataFinal.Checked = false;

            ConfigurarComboPesquisa(cmbFiltroEscola);

            cmbFiltroEscola.TextUpdate -= cmbFiltroEscola_TextUpdate;
            cmbFiltroEscola.TextUpdate += cmbFiltroEscola_TextUpdate;

            cmbFiltroEscola.SelectionChangeCommitted -= cmbFiltroEscola_SelectionChangeCommitted;
            cmbFiltroEscola.SelectionChangeCommitted += cmbFiltroEscola_SelectionChangeCommitted;

            CarregarEscolas();

            dgvAcertos.DataError += dgvAcertos_DataError;
            dgvAcertos.CurrentCellDirtyStateChanged += dgvAcertos_CurrentCellDirtyStateChanged;
            dgvAcertos.CellValueChanged += dgvAcertos_CellValueChanged;
        }



        private void CarregarAcertos()
        {
            try
            {
                _carregandoGrid = true;

                string escolaFiltro = cmbFiltroEscola.Text.Trim();
                string statusFiltro = cmbStatus.Text == "Todos" ? "" : cmbStatus.Text;
                DateTime? dataInicial = dtpDataInicial.Checked ? dtpDataInicial.Value.Date : null;
                DateTime? dataFinal = dtpDataFinal.Checked ? dtpDataFinal.Value.Date : null;

                DataTable tabela = _acertoService.ListarAcertos(escolaFiltro, dataInicial, dataFinal);

                if (!string.IsNullOrWhiteSpace(statusFiltro))
                {
                    DataView view = tabela.DefaultView;
                    view.RowFilter = $"Status = '{statusFiltro.Replace("'", "''")}'";
                    tabela = view.ToTable();
                }

                dgvAcertos.DataSource = null;
                dgvAcertos.Columns.Clear();
                dgvAcertos.AutoGenerateColumns = true;
                dgvAcertos.DataSource = tabela;

                AdicionarColunaSelecionar();
                AdicionarColunaPago();
                FormatarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar acertos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _carregandoGrid = false;
            }
        }


        private void AdicionarColunaSelecionar()
        {
            if (dgvAcertos.Columns.Contains("Selecionar"))
                return;

            var colunaSelecionar = new DataGridViewCheckBoxColumn
            {
                Name = "Selecionar",
                HeaderText = "",
                Width = 35,
                ReadOnly = false
            };

            dgvAcertos.Columns.Insert(0, colunaSelecionar);

            foreach (DataGridViewRow row in dgvAcertos.Rows)
            {
                row.Cells["Selecionar"].Value = false;
            }
        }

        private void AdicionarColunaPago()
        {
            if (dgvAcertos.Columns.Contains("Pago"))
                return;

            var colunaPago = new DataGridViewCheckBoxColumn
            {
                Name = "Pago",
                HeaderText = "Pago",
                Width = 60,
                ReadOnly = false
            };

            int indicePago = dgvAcertos.Columns.Contains("Selecionar") ? 1 : 0;
            dgvAcertos.Columns.Insert(indicePago, colunaPago);

            foreach (DataGridViewRow row in dgvAcertos.Rows)
            {
                string status = row.Cells["Status"].Value?.ToString() ?? "";
                row.Cells["Pago"].Value = status == "Pago";
            }
        }

        private void FormatarGrid()
        {
            dgvAcertos.BackgroundColor = Color.White;
            dgvAcertos.BorderStyle = BorderStyle.None;
            dgvAcertos.GridColor = Color.Gainsboro;
            dgvAcertos.EnableHeadersVisualStyles = false;

            dgvAcertos.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvAcertos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAcertos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9);
            dgvAcertos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvAcertos.DefaultCellStyle.BackColor = Color.White;
            dgvAcertos.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            dgvAcertos.DefaultCellStyle.SelectionBackColor = Color.AliceBlue;
            dgvAcertos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvAcertos.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvAcertos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            dgvAcertos.RowHeadersVisible = false;
            dgvAcertos.AllowUserToAddRows = false;
            dgvAcertos.AllowUserToDeleteRows = false;
            dgvAcertos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAcertos.MultiSelect = false;
            dgvAcertos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAcertos.ReadOnly = false;

            foreach (DataGridViewColumn coluna in dgvAcertos.Columns)
            {
                coluna.ReadOnly = coluna.Name != "Pago" && coluna.Name != "Selecionar";
            }

            if (dgvAcertos.Columns.Contains("Id"))
                dgvAcertos.Columns["Id"].Visible = false;

            if (dgvAcertos.Columns.Contains("Selecionar"))
            {
                dgvAcertos.Columns["Selecionar"].DisplayIndex = 0;
                dgvAcertos.Columns["Selecionar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAcertos.Columns["Selecionar"].Width = 35;
            }

            if (dgvAcertos.Columns.Contains("Pago"))
            {
                dgvAcertos.Columns["Pago"].DisplayIndex = 1;
                dgvAcertos.Columns["Pago"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAcertos.Columns["Pago"].Width = 60;
            }

            if (dgvAcertos.Columns.Contains("Escola"))
                dgvAcertos.Columns["Escola"].FillWeight = 160;

            if (dgvAcertos.Columns.Contains("Serviço"))
                dgvAcertos.Columns["Serviço"].FillWeight = 220;

            if (dgvAcertos.Columns.Contains("Valor"))
            {
                dgvAcertos.Columns["Valor"].DefaultCellStyle.Format = "C2";
                dgvAcertos.Columns["Valor"].FillWeight = 80;
            }

            if (dgvAcertos.Columns.Contains("Status"))
                dgvAcertos.Columns["Status"].FillWeight = 80;

            if (dgvAcertos.Columns.Contains("DataCadastro"))
            {
                dgvAcertos.Columns["DataCadastro"].HeaderText = "Data Cadastro";
                dgvAcertos.Columns["DataCadastro"].FillWeight = 110;
            }

            if (dgvAcertos.Columns.Contains("DataPagamento"))
            {
                dgvAcertos.Columns["DataPagamento"].HeaderText = "Data Pagamento";
                dgvAcertos.Columns["DataPagamento"].FillWeight = 110;
            }
        }

        private void dgvAcertos_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dgvAcertos.IsCurrentCellDirty)
                dgvAcertos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvAcertos_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (_carregandoGrid || e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string nomeColuna = dgvAcertos.Columns[e.ColumnIndex].Name;

            if (nomeColuna == "Selecionar")
                return;

            if (nomeColuna != "Pago")
                return;

            DataGridViewRow row = dgvAcertos.Rows[e.RowIndex];

            if (row.Cells["Id"].Value == null)
                return;

            int id = Convert.ToInt32(row.Cells["Id"].Value);
            bool pago = Convert.ToBoolean(row.Cells["Pago"].Value ?? false);

            try
            {
                if (pago)
                    _acertoService.MarcarComoPago(id);
                else
                    _acertoService.MarcarComoPendente(id);

                CarregarAcertos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar status do acerto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CarregarAcertos();
            }
        }

        private void dgvAcertos_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnFiltrar_Click(object? sender, EventArgs e)
        {
            CarregarAcertos();
        }

        private void btnLimparFiltros_Click(object? sender, EventArgs e)
        {
            _versaoFiltroEscola++;

            cmbFiltroEscola.DroppedDown = false;
            cmbFiltroEscola.SelectedIndex = -1;
            cmbFiltroEscola.Text = "";

            cmbStatus.SelectedIndex = 0;
            dtpDataInicial.Checked = false;
            dtpDataFinal.Checked = false;

            CarregarAcertos();
        }

        private int ObterIdSelecionado()
        {
            dgvAcertos.EndEdit();

            var linhasMarcadas = dgvAcertos.Rows
                .Cast<DataGridViewRow>()
                .Where(row => Convert.ToBoolean(row.Cells["Selecionar"].Value ?? false))
                .ToList();

            if (linhasMarcadas.Count == 0)
            {
                MessageBox.Show(
                    "Selecione um acerto na primeira coluna.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return 0;
            }

            if (linhasMarcadas.Count > 1)
            {
                MessageBox.Show(
                    "Selecione apenas um acerto para editar ou excluir.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return 0;
            }

            object? valorId = linhasMarcadas[0].Cells["Id"].Value;

            if (valorId == null)
                return 0;

            return Convert.ToInt32(valorId);
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            int id = ObterIdSelecionado();

            if (id <= 0)
                return;

            using var tela = new FrmEditarAcerto(id);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarEscolas();
                CarregarAcertos();
            }
        }

        private void btnExcluir_Click(object? sender, EventArgs e)
        {
            int id = ObterIdSelecionado();

            if (id <= 0)
                return;

            DialogResult resultado = MessageBox.Show(
                "Deseja realmente excluir o acerto selecionado?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado != DialogResult.Yes)
                return;

            try
            {
                _acertoService.ExcluirAcerto(id);

                MessageBox.Show(
                    "Acerto excluído com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CarregarEscolas();
                CarregarAcertos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao excluir acerto: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnAtualizar_Click(object? sender, EventArgs e)
        {
            CarregarEscolas();
            CarregarAcertos();
        }

        private void btnFechar_Click(object? sender, EventArgs e)
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
            AplicarEstiloBotaoPrincipal(btnEditar);
            AplicarEstiloBotaoExcluir(btnExcluir);
            AplicarEstiloBotaoPrincipal(btnAtualizar);
            AplicarEstiloBotaoCancelar(btnFechar);

            AplicarEstiloGrid(dgvAcertos);
            AplicarEstiloCampos(this);

            pnlTopo.BackColor = Color.SteelBlue;
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Font = new Font("Segoe UI", 9);

            lblFiltros.ForeColor = Color.FromArgb(35, 35, 35);
            lblFiltros.Font = new Font("Segoe UI Semibold", 11);
            lblAcertos.ForeColor = Color.FromArgb(35, 35, 35);
            lblAcertos.Font = new Font("Segoe UI Semibold", 11);
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


        private void AplicarEstiloBotaoExcluir(Button botao)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.BackColor = Color.IndianRed;
            botao.ForeColor = Color.White;
            botao.Font = new Font("Segoe UI Semibold", 10);
            botao.Cursor = Cursors.Hand;
            botao.FlatAppearance.BorderColor = Color.Firebrick;
            botao.FlatAppearance.BorderSize = 1;
            botao.MouseEnter += (s, e) => { botao.BackColor = Color.Firebrick; };
            botao.MouseLeave += (s, e) => { botao.BackColor = Color.IndianRed; };
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
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            grid.DefaultCellStyle.SelectionBackColor = Color.AliceBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = false;
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

                if (controle is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Font = new Font("Segoe UI", 10);
                }

                if (controle.HasChildren)
                    AplicarEstiloCampos(controle);
            }
        }

        private void ConfigurarComboPesquisa(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox.AutoCompleteMode = AutoCompleteMode.None;
            comboBox.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void CarregarEscolas()
        {
            cmbFiltroEscola.Items.Clear();

            _escolasOriginais = _acertoService
                .ListarEscolas()
                .ToList();

            foreach (var escola in _escolasOriginais)
            {
                cmbFiltroEscola.Items.Add(escola);
            }

            cmbFiltroEscola.SelectedIndex = -1;
        }

        private void cmbFiltroEscola_TextUpdate(object? sender, EventArgs e)
        {
            if (_atualizandoComboEscola)
                return;

            string textoDigitado = cmbFiltroEscola.Text;
            int posicaoCursor = cmbFiltroEscola.SelectionStart;
            int versaoAtual = ++_versaoFiltroEscola;
            bool iniciouAtualizacao = false;

            try
            {
                _atualizandoComboEscola = true;

                var itensFiltrados = _escolasOriginais
                    .Where(escola =>
                        NormalizarTexto(escola)
                            .Contains(NormalizarTexto(textoDigitado)))
                    .ToList();

                cmbFiltroEscola.DroppedDown = false;

                cmbFiltroEscola.BeginUpdate();
                iniciouAtualizacao = true;

                cmbFiltroEscola.Items.Clear();

                foreach (var escola in itensFiltrados)
                {
                    cmbFiltroEscola.Items.Add(escola);
                }

                cmbFiltroEscola.EndUpdate();
                iniciouAtualizacao = false;

                RestaurarTextoFiltroEscola(
                    textoDigitado,
                    posicaoCursor
                );

                if (itensFiltrados.Count > 0 &&
                    cmbFiltroEscola.Focused)
                {
                    cmbFiltroEscola.DroppedDown = true;
                    Cursor.Current = Cursors.Default;

                    BeginInvoke(new Action(() =>
                    {
                        if (cmbFiltroEscola.IsDisposed ||
                            !cmbFiltroEscola.Focused ||
                            versaoAtual != _versaoFiltroEscola)
                        {
                            return;
                        }

                        try
                        {
                            _atualizandoComboEscola = true;

                            RestaurarTextoFiltroEscola(
                                textoDigitado,
                                posicaoCursor
                            );
                        }
                        finally
                        {
                            _atualizandoComboEscola = false;
                        }
                    }));
                }
                else
                {
                    cmbFiltroEscola.DroppedDown = false;
                }
            }
            catch
            {
                cmbFiltroEscola.DroppedDown = false;

                RestaurarTextoFiltroEscola(
                    textoDigitado,
                    posicaoCursor
                );
            }
            finally
            {
                if (iniciouAtualizacao)
                    cmbFiltroEscola.EndUpdate();

                _atualizandoComboEscola = false;
            }
        }

        private void RestaurarTextoFiltroEscola(
            string textoDigitado,
            int posicaoCursor)
        {
            cmbFiltroEscola.SelectedIndex = -1;
            cmbFiltroEscola.Text = textoDigitado;

            cmbFiltroEscola.SelectionStart = Math.Min(
                posicaoCursor,
                cmbFiltroEscola.Text.Length
            );

            cmbFiltroEscola.SelectionLength = 0;
        }

        private void cmbFiltroEscola_SelectionChangeCommitted(
            object? sender,
            EventArgs e)
        {
            if (cmbFiltroEscola.SelectedItem == null)
                return;

            string textoSelecionado =
                cmbFiltroEscola.SelectedItem.ToString() ?? "";

            try
            {
                _atualizandoComboEscola = true;
                _versaoFiltroEscola++;

                cmbFiltroEscola.Text = textoSelecionado;
                cmbFiltroEscola.SelectionStart =
                    cmbFiltroEscola.Text.Length;

                cmbFiltroEscola.SelectionLength = 0;
                cmbFiltroEscola.DroppedDown = false;
            }
            finally
            {
                _atualizandoComboEscola = false;
            }
        }

        private string NormalizarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "";

            string textoNormalizado = texto.Normalize(NormalizationForm.FormD);

            var builder = new StringBuilder();

            foreach (char caractere in textoNormalizado)
            {
                UnicodeCategory categoria = CharUnicodeInfo.GetUnicodeCategory(caractere);

                if (categoria != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(caractere);
                }
            }

            return builder
                .ToString()
                .Normalize(NormalizationForm.FormC)
                .ToUpperInvariant()
                .Trim();
        }
    }
}
