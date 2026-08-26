using ComodoroERP.Models;
using ComodoroERP.Services;
using ComodoroERP.Utils;
using System.Globalization;
using System.Text;

namespace ComodoroERP
{
    public partial class FrmAdicionarItemOrcamento : FrmBase
    {

        private void FrmAdicionarItemOrcamento_Load(object sender, EventArgs e)
        {

        }

        private readonly int _orcamentoId;
        private readonly OrcamentoService _orcamentoService = new();
        private readonly ServicoPermitidoService _servicoPermitidoService = new();

        private List<string> _categoriasOriginais = new();
        private List<string> _servicosOriginais = new();

        private bool _atualizandoComboCategoria = false;
        private bool _atualizandoComboServico = false;

        public FrmAdicionarItemOrcamento(int orcamentoId)
        {
            InitializeComponent();

            DarkTitleBar.Ativar(this);

            _orcamentoId = orcamentoId;

            ConfigurarTela();
            AplicarEstiloVisual();
            CarregarCategorias();
        }

        private void AplicarEstiloVisual()
        {
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10);

            AplicarEstiloPainel(pnlServico);

            AplicarEstiloBotaoPrincipal(btnSalvar);
            AplicarEstiloBotaoCancelar(btnCancelar);

            AplicarEstiloCampos(this);

            pnlTopo.BackColor = Color.SteelBlue;

            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15);

            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Font = new Font("Segoe UI", 9);

            lblDadosServico.ForeColor = Color.FromArgb(35, 35, 35);
            lblDadosServico.Font = new Font("Segoe UI Semibold", 11);
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

        private void ConfigurarTela()
        {
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicoPermitido.DropDownStyle = ComboBoxStyle.DropDownList;

            numQuantidade.Minimum = 1;
            numQuantidade.Maximum = 100000;
            numQuantidade.DecimalPlaces = 2;
            numQuantidade.Value = 1;

            numValorUnitario.Minimum = 0;
            numValorUnitario.Maximum = 1000000;
            numValorUnitario.DecimalPlaces = 2;
            numValorUnitario.Value = 0;

            numQuantidade.Value = 1;

            ConfigurarComboPesquisa(cmbCategoria);
            ConfigurarComboPesquisa(cmbServicoPermitido);

            cmbCategoria.TextUpdate -= cmbCategoria_TextUpdate;
            cmbCategoria.TextUpdate += cmbCategoria_TextUpdate;

            cmbServicoPermitido.TextUpdate -= cmbServicoPermitido_TextUpdate;
            cmbServicoPermitido.TextUpdate += cmbServicoPermitido_TextUpdate;

            cmbCategoria.SelectedIndexChanged -= cmbCategoria_SelectedIndexChanged;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;

            cmbCategoria.Leave -= cmbCategoria_Leave;
            cmbCategoria.Leave += cmbCategoria_Leave;

            CarregarCategoriasPermitidas();

        }

        private void ConfigurarComboPesquisa(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;

            comboBox.AutoCompleteMode = AutoCompleteMode.None;
            comboBox.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void CarregarCategorias()
        {
            cmbCategoria.Items.Clear();
            cmbServicoPermitido.Items.Clear();

            var categorias = _servicoPermitidoService.ListarCategorias();

            foreach (var categoria in categorias)
            {
                cmbCategoria.Items.Add(categoria);
            }

            if (cmbCategoria.Items.Count > 0)
            {
                cmbCategoria.SelectedIndex = 0;
            }
        }

        private void CarregarCategoriasPermitidas()
        {
            cmbCategoria.Items.Clear();

            _categoriasOriginais = _servicoPermitidoService
                .ListarCategorias()
                .ToList();

            foreach (var categoria in _categoriasOriginais)
            {
                cmbCategoria.Items.Add(categoria);
            }

            cmbCategoria.SelectedIndex = -1;
            cmbCategoria.Text = "";

            cmbServicoPermitido.Items.Clear();
            cmbServicoPermitido.SelectedIndex = -1;
            cmbServicoPermitido.Text = "";

            _servicosOriginais.Clear();
        }

        private void CarregarServicosPorCategoria()
        {
            string categoria = cmbCategoria.Text.Trim();

            cmbServicoPermitido.Items.Clear();
            cmbServicoPermitido.SelectedIndex = -1;
            cmbServicoPermitido.Text = "";

            _servicosOriginais.Clear();

            if (string.IsNullOrWhiteSpace(categoria))
                return;

            bool categoriaExiste = _categoriasOriginais
                .Any(c => NormalizarTexto(c) == NormalizarTexto(categoria));

            if (!categoriaExiste)
                return;

            _servicosOriginais = _servicoPermitidoService
                .ListarServicosPorCategoria(categoria)
                .ToList();

            foreach (var servico in _servicosOriginais)
            {
                cmbServicoPermitido.Items.Add(servico);
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_atualizandoComboCategoria)
                return;

            if (cmbCategoria.SelectedIndex < 0)
                return;

            CarregarServicosPorCategoria();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            string categoria = cmbCategoria.Text.Trim();
            string servicoPermitido = cmbServicoPermitido.Text.Trim();

            bool categoriaExiste = _categoriasOriginais
                .Any(c => NormalizarTexto(c) == NormalizarTexto(categoria));

            if (!categoriaExiste)
            {
                MessageBox.Show(
                    "Selecione uma categoria válida da lista.",
                    "Categoria inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbCategoria.Focus();
                return;
            }

            bool servicoExiste = _servicosOriginais
                .Any(s => NormalizarTexto(s) == NormalizarTexto(servicoPermitido));

            if (!servicoExiste)
            {
                MessageBox.Show(
                    "Selecione um serviço permitido válido da lista.",
                    "Serviço inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbServicoPermitido.Focus();
                return;
            }

            decimal quantidade = numQuantidade.Value;
            decimal valorUnitario = numValorUnitario.Value;
            bool cortesia = chkCortesia.Checked;

            decimal total = cortesia ? 0 : quantidade * valorUnitario;

            var item = new OrcamentoItem
            {
                OrcamentoId = _orcamentoId,
                Categoria = categoria,
                ServicoPermitido = servicoPermitido,
                DescricaoOrcamento = txtDescricaoServico.Text.Trim().ToUpper(),
                Quantidade = quantidade,
                ValorUnitario = valorUnitario,
                Cortesia = cortesia,
                ValorTotal = total,
                Observacao = txtObservacaoServico.Text.Trim()
            };

            try
            {
                _orcamentoService.AdicionarItemOrcamento(_orcamentoId, item);

                MessageBox.Show(
                    "Item adicionado com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao adicionar item: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool ValidarCampos()
        {
            if (cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Selecione a categoria.");
                cmbCategoria.Focus();
                return false;
            }

            if (cmbServicoPermitido.SelectedItem == null)
            {
                MessageBox.Show("Selecione o serviço permitido.");
                cmbServicoPermitido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescricaoServico.Text))
            {
                MessageBox.Show("Informe a descrição do serviço.");
                txtDescricaoServico.Focus();
                return false;
            }

            if (numQuantidade.Value <= 0)
            {
                MessageBox.Show("Informe uma quantidade válida.");
                numQuantidade.Focus();
                return false;
            }

            if (!chkCortesia.Checked && numValorUnitario.Value <= 0)
            {
                MessageBox.Show("Informe um valor unitário válido.");
                numValorUnitario.Focus();
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmbCategoria_TextUpdate(object sender, EventArgs e)
        {
            if (_atualizandoComboCategoria)
                return;

            string textoDigitado = cmbCategoria.Text;

            if (string.IsNullOrWhiteSpace(textoDigitado))
            {
                try
                {
                    _atualizandoComboCategoria = true;

                    cmbCategoria.DroppedDown = false;
                    cmbCategoria.Items.Clear();

                    foreach (var categoria in _categoriasOriginais)
                    {
                        cmbCategoria.Items.Add(categoria);
                    }

                    cmbCategoria.Text = "";
                    cmbCategoria.SelectionStart = 0;
                }
                finally
                {
                    _atualizandoComboCategoria = false;
                }

                return;
            }

            FiltrarComboBox(
                cmbCategoria,
                _categoriasOriginais,
                textoDigitado,
                ref _atualizandoComboCategoria
            );
        }

        private void cmbServicoPermitido_TextUpdate(object sender, EventArgs e)
        {
            if (_atualizandoComboServico)
                return;

            string textoDigitado = cmbServicoPermitido.Text;

            if (string.IsNullOrWhiteSpace(textoDigitado))
            {
                try
                {
                    _atualizandoComboServico = true;

                    cmbServicoPermitido.DroppedDown = false;
                    cmbServicoPermitido.Items.Clear();

                    foreach (var servico in _servicosOriginais)
                    {
                        cmbServicoPermitido.Items.Add(servico);
                    }

                    cmbServicoPermitido.Text = "";
                    cmbServicoPermitido.SelectionStart = 0;
                }
                finally
                {
                    _atualizandoComboServico = false;
                }

                return;
            }

            FiltrarComboBox(
                cmbServicoPermitido,
                _servicosOriginais,
                textoDigitado,
                ref _atualizandoComboServico
            );
        }

        private void cmbCategoria_Leave(object sender, EventArgs e)
        {
            string categoria = cmbCategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(categoria))
            {
                cmbServicoPermitido.Items.Clear();
                cmbServicoPermitido.Text = "";
                _servicosOriginais.Clear();
                return;
            }

            bool categoriaExiste = _categoriasOriginais
                .Any(c => NormalizarTexto(c) == NormalizarTexto(categoria));

            if (!categoriaExiste)
            {
                MessageBox.Show(
                    "Categoria não encontrada na lista de serviços permitidos.",
                    "Categoria inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbCategoria.Text = "";
                cmbServicoPermitido.Items.Clear();
                cmbServicoPermitido.Text = "";
                _servicosOriginais.Clear();

                cmbCategoria.Focus();
                return;
            }

            CarregarServicosPorCategoria();
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
