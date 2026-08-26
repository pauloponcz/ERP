using ComodoroERP.Models;
using ComodoroERP.Services;
using ComodoroERP.Utils;
using System.Drawing;

namespace ComodoroERP
{
    public partial class FrmEditarAcerto : FrmBase
    {
        private readonly int _acertoId;
        private readonly AcertoService _acertoService = new();

        public FrmEditarAcerto(int acertoId)
        {
            InitializeComponent();
            _acertoId = acertoId;
            DarkTitleBar.Ativar(this);
            ConfigurarTela();
            AplicarEstiloVisual();
            CarregarAcerto();
            Shown += FrmEditarAcerto_Shown;
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

        private void FrmEditarAcerto_Shown(object? sender, EventArgs e)
        {
            txtNomeEscola.Focus();
            txtNomeEscola.Select();
        }

        private void CarregarAcerto()
        {
            try
            {
                Acerto? acerto = _acertoService.ObterAcertoPorId(_acertoId);
                if (acerto == null)
                {
                    MessageBox.Show("Acerto não encontrado.");
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }
                txtNomeEscola.Text = acerto.NomeEscola;
                txtServico.Text = acerto.Servico;
                numValor.Value = acerto.Valor;
                cmbStatusPagamento.Text = acerto.StatusPagamento;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar acerto: " + ex.Message);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnSalvar_Click(object? sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            string status = cmbStatusPagamento.Text.Trim();
            var acerto = new Acerto
            {
                Id = _acertoId,
                NomeEscola = txtNomeEscola.Text.Trim().ToUpper(),
                Servico = txtServico.Text.Trim().ToUpper(),
                Valor = numValor.Value,
                StatusPagamento = status,
                DataPagamento = status == "Pago" ? DateTime.Now : null
            };
            try
            {
                _acertoService.AtualizarAcerto(acerto);
                MessageBox.Show("Acerto atualizado com sucesso.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar acerto: " + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNomeEscola.Text)) { MessageBox.Show("Informe o nome da escola."); txtNomeEscola.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtServico.Text)) { MessageBox.Show("Informe o serviço realizado."); txtServico.Focus(); return false; }
            if (numValor.Value <= 0) { MessageBox.Show("Informe um valor válido."); numValor.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(cmbStatusPagamento.Text)) { MessageBox.Show("Selecione o status do pagamento."); cmbStatusPagamento.Focus(); return false; }
            return true;
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AplicarEstiloVisual()
        {
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10);
            pnlAcerto.BackColor = Color.White;
            pnlAcerto.BorderStyle = BorderStyle.FixedSingle;
            pnlTopo.BackColor = Color.SteelBlue;
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Font = new Font("Segoe UI", 9);
            foreach (Control c in Controls) AplicarEstiloCampos(c);
            btnSalvar.FlatStyle = FlatStyle.Flat; btnSalvar.BackColor = Color.White; btnSalvar.ForeColor = Color.FromArgb(45,45,45); btnSalvar.Font = new Font("Segoe UI Semibold", 10);
            btnCancelar.FlatStyle = FlatStyle.Flat; btnCancelar.BackColor = Color.White; btnCancelar.ForeColor = Color.DimGray; btnCancelar.Font = new Font("Segoe UI Semibold", 10);
        }

        private void AplicarEstiloCampos(Control controlePai)
        {
            foreach (Control controle in controlePai.Controls)
            {
                if (controle is Label label && label.Parent != pnlTopo) { label.ForeColor = Color.DimGray; label.Font = new Font("Segoe UI", 9); }
                if (controle is TextBox textBox) { textBox.BorderStyle = BorderStyle.FixedSingle; textBox.Font = new Font("Segoe UI", 10); }
                if (controle is ComboBox comboBox) { comboBox.FlatStyle = FlatStyle.Standard; comboBox.Font = new Font("Segoe UI", 10); }
                if (controle is NumericUpDown numeric) { numeric.BorderStyle = BorderStyle.FixedSingle; numeric.Font = new Font("Segoe UI", 10); }
                if (controle.HasChildren) AplicarEstiloCampos(controle);
            }
        }
    }
}
