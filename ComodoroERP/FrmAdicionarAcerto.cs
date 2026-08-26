using ComodoroERP.Models;
using ComodoroERP.Services;
using ComodoroERP.Utils;
using System.Drawing;
using System.Globalization;

namespace ComodoroERP
{
    public partial class FrmAdicionarAcerto : Form
    {
        private readonly AcertoService _acertoService = new();

        public FrmAdicionarAcerto()
        {
            InitializeComponent();

            DarkTitleBar.Ativar(this);

            ConfigurarTela();
            AplicarEstiloVisual();
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
        }

        private void btnSalvar_Click(object? sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            string status = cmbStatusPagamento.Text.Trim();

            var acerto = new Acerto
            {
                NomeEscola = txtNomeEscola.Text.Trim().ToUpper(),
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
                txtNomeEscola.Focus();
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
            if (string.IsNullOrWhiteSpace(txtNomeEscola.Text))
            {
                MessageBox.Show(
                    "Informe o nome da escola.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNomeEscola.Focus();
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
            txtNomeEscola.Clear();
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
                    comboBox.FlatStyle = FlatStyle.Flat;
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
    }
}
