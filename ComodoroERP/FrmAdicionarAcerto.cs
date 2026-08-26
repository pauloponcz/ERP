using ComodoroERP.Models;
using ComodoroERP.Services;
using ComodoroERP.Utils;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace ComodoroERP
{
    public partial class FrmAdicionarAcerto : Form
    {
        private readonly AcertoService _acertoService = new();
        private int _versaoFiltroEscola = 0;

        private List<string> _escolasOriginais = new();
        private bool _atualizandoComboEscola = false;

        public FrmAdicionarAcerto()
        {
            InitializeComponent();

            DarkTitleBar.Ativar(this);

            ConfigurarTela();
            AplicarEstiloVisual();

            Shown += FrmAdicionarAcerto_Shown;
        }

        private void FrmAdicionarAcerto_Shown(object? sender, EventArgs e)
        {
            cmbNomeEscola.Focus();
            cmbNomeEscola.Select();
            cmbNomeEscola.SelectionStart = cmbNomeEscola.Text.Length;
        }

        private void ConfigurarTela()
        {
            cmbStatusPagamento.Items.Clear();
            cmbStatusPagamento.Items.Add("Pendente");
            cmbStatusPagamento.Items.Add("Pago");
            cmbStatusPagamento.SelectedIndex = 0;

            numValor.DecimalPlaces = 2;
            numValor.Minimum = 0;
            numValor.Maximum = 999999999;
            numValor.ThousandsSeparator = true;

            ConfigurarComboPesquisa(cmbNomeEscola);

            cmbNomeEscola.TextUpdate -= cmbNomeEscola_TextUpdate;
            cmbNomeEscola.TextUpdate += cmbNomeEscola_TextUpdate;

            cmbNomeEscola.SelectionChangeCommitted -= cmbNomeEscola_SelectionChangeCommitted;
            cmbNomeEscola.SelectionChangeCommitted += cmbNomeEscola_SelectionChangeCommitted;

            CarregarEscolas();
        }

        private void btnSalvar_Click(object? sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            string status = cmbStatusPagamento.Text.Trim();

            var acerto = new Acerto
            {
                NomeEscola = cmbNomeEscola.Text.Trim().ToUpper(),
                Servico = txtServico.Text.Trim().ToUpper(),
                Valor = numValor.Value,
                StatusPagamento = status,
                DataCriacao = DateTime.Now,
                DataPagamento = status == "Pago" ? DateTime.Now : null
            };

            try
            {
                _acertoService.InserirAcerto(acerto);

                MessageBox.Show(
                    "Acerto cadastrado com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimparCampos();
                cmbNomeEscola.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao cadastrar acerto: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(cmbNomeEscola.Text))
            {
                MessageBox.Show(
                    "Informe o nome da escola.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbNomeEscola.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtServico.Text))
            {
                MessageBox.Show(
                    "Informe o serviço realizado.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtServico.Focus();
                return false;
            }

            if (numValor.Value <= 0)
            {
                MessageBox.Show(
                    "Informe um valor válido para o serviço.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                numValor.Focus();
                return false;
            }

            if (cmbStatusPagamento.SelectedItem == null || string.IsNullOrWhiteSpace(cmbStatusPagamento.Text))
            {
                MessageBox.Show(
                    "Selecione o status de pagamento.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbStatusPagamento.Focus();
                return false;
            }

            return true;
        }

        private void LimparCampos()
        {
            cmbNomeEscola.Text = "";
            txtServico.Clear();
            numValor.Value = 0;
            cmbStatusPagamento.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void AplicarEstiloVisual()
        {
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10);

            AplicarEstiloPainel(pnlAcerto);

            AplicarEstiloBotaoPrincipal(btnSalvar);
            AplicarEstiloBotaoCancelar(btnCancelar);

            AplicarEstiloCampos(this);

            pnlTopo.BackColor = Color.SteelBlue;

            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15);

            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Font = new Font("Segoe UI", 9);

            lblDadosAcerto.ForeColor = Color.FromArgb(35, 35, 35);
            lblDadosAcerto.Font = new Font("Segoe UI Semibold", 11);
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

                if (controle is NumericUpDown numeric)
                {
                    numeric.BorderStyle = BorderStyle.FixedSingle;
                    numeric.Font = new Font("Segoe UI", 10);
                }

                if (controle.HasChildren)
                {
                    AplicarEstiloCampos(controle);
                }
            }
        }

        private void ConfigurarComboPesquisa(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox.AutoCompleteMode = AutoCompleteMode.None;
            comboBox.AutoCompleteSource = AutoCompleteSource.None;
            comboBox.FlatStyle = FlatStyle.Standard;
        }

        private void CarregarEscolas()
        {
            cmbNomeEscola.Items.Clear();

            _escolasOriginais = _acertoService
                .ListarEscolas()
                .ToList();

            foreach (var escola in _escolasOriginais)
            {
                cmbNomeEscola.Items.Add(escola);
            }
        }

        private void cmbNomeEscola_TextUpdate(object? sender, EventArgs e)
        {
            if (_atualizandoComboEscola)
                return;

            string textoDigitado = cmbNomeEscola.Text;
            int posicaoCursor = cmbNomeEscola.SelectionStart;
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

                cmbNomeEscola.DroppedDown = false;

                cmbNomeEscola.BeginUpdate();
                iniciouAtualizacao = true;

                cmbNomeEscola.Items.Clear();

                foreach (var escola in itensFiltrados)
                {
                    cmbNomeEscola.Items.Add(escola);
                }

                cmbNomeEscola.EndUpdate();
                iniciouAtualizacao = false;

                RestaurarTextoDigitado(textoDigitado, posicaoCursor);

                if (itensFiltrados.Count > 0 && cmbNomeEscola.Focused)
                {
                    cmbNomeEscola.DroppedDown = true;
                    Cursor.Current = Cursors.Default;

                    BeginInvoke(new Action(() =>
                    {
                        if (cmbNomeEscola.IsDisposed ||
                            !cmbNomeEscola.Focused ||
                            versaoAtual != _versaoFiltroEscola)
                        {
                            return;
                        }

                        try
                        {
                            _atualizandoComboEscola = true;

                            RestaurarTextoDigitado(
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
                    cmbNomeEscola.DroppedDown = false;
                }
            }
            catch
            {
                cmbNomeEscola.DroppedDown = false;

                RestaurarTextoDigitado(
                    textoDigitado,
                    posicaoCursor
                );
            }
            finally
            {
                if (iniciouAtualizacao)
                    cmbNomeEscola.EndUpdate();

                _atualizandoComboEscola = false;
            }
        }

        private void RestaurarTextoDigitado(
            string textoDigitado,
            int posicaoCursor)
        {
            cmbNomeEscola.SelectedIndex = -1;
            cmbNomeEscola.Text = textoDigitado;

            cmbNomeEscola.SelectionStart = Math.Min(
                posicaoCursor,
                cmbNomeEscola.Text.Length
            );

            cmbNomeEscola.SelectionLength = 0;
        }

        private void cmbNomeEscola_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            if (cmbNomeEscola.SelectedIndex < 0)
                return;

            if (cmbNomeEscola.SelectedItem == null)
                return;

            string textoSelecionado = cmbNomeEscola.SelectedItem.ToString() ?? "";

            try
            {
                _atualizandoComboEscola = true;

                cmbNomeEscola.Text = textoSelecionado;
                cmbNomeEscola.SelectionStart = cmbNomeEscola.Text.Length;
                cmbNomeEscola.SelectionLength = 0;
            }
            finally
            {
                _atualizandoComboEscola = false;
            }
        }

        private void FiltrarComboBox(
            ComboBox comboBox,
            List<string> listaOriginal,
            string textoDigitado,
            ref bool atualizando)
        {
            try
            {
                atualizando = true;

                int posicaoCursor = comboBox.SelectionStart;

                string textoNormalizado = NormalizarTexto(textoDigitado);

                var itensFiltrados = listaOriginal
                    .Where(item => NormalizarTexto(item).Contains(textoNormalizado))
                    .ToList();

                comboBox.DroppedDown = false;

                comboBox.BeginUpdate();
                comboBox.Items.Clear();

                foreach (var item in itensFiltrados)
                {
                    comboBox.Items.Add(item);
                }

                comboBox.EndUpdate();

                comboBox.Text = textoDigitado;
                comboBox.SelectionStart = Math.Min(posicaoCursor, comboBox.Text.Length);
                comboBox.SelectionLength = 0;

                if (itensFiltrados.Count > 0 && comboBox.Focused)
                {
                    comboBox.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {
                comboBox.DroppedDown = false;
            }
            finally
            {
                atualizando = false;
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
