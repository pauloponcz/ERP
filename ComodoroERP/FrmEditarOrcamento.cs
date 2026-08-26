using ComodoroERP.Services;
using ComodoroERP.Utils;
using System.Data;

namespace ComodoroERP
{
    public partial class FrmEditarOrcamento : FrmBase
    {
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private readonly int _orcamentoId;
        private readonly OrcamentoService _orcamentoService = new();

        public FrmEditarOrcamento(int orcamentoId)
        {
            InitializeComponent();

            _orcamentoId = orcamentoId;

            DarkTitleBar.Ativar(this);

            ConfigurarTela();
            AplicarEstiloVisual();
            CarregarDados();
        }

        private void ConfigurarTela()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Pendente");
            cmbStatus.Items.Add("Pago");
            cmbStatus.Items.Add("Parcial");
            cmbStatus.Items.Add("Concluído");
            cmbStatus.Items.Add("Cancelado");

            numVariacaoNota2.Minimum = -100;
            numVariacaoNota2.Maximum = 100;
            numVariacaoNota2.DecimalPlaces = 2;

            numVariacaoNota3.Minimum = -100;
            numVariacaoNota3.Maximum = 100;
            numVariacaoNota3.DecimalPlaces = 2;
        }

        private void CarregarDados()
        {
            DataSet dados = _orcamentoService.ObterOrcamentoCompleto(_orcamentoId);

            if (dados.Tables["Cabecalho"] == null || dados.Tables["Cabecalho"]!.Rows.Count == 0)
            {
                MessageBox.Show("Orçamento não encontrado.");
                Close();
                return;
            }

            DataRow cabecalho = dados.Tables["Cabecalho"]!.Rows[0];

            txtTitulo.Text = cabecalho["Titulo"].ToString();
            cmbStatus.Text = cabecalho["Status"].ToString();
            numVariacaoNota2.Value = Convert.ToDecimal(cabecalho["VariacaoNota2"]);
            numVariacaoNota3.Value = Convert.ToDecimal(cabecalho["VariacaoNota3"]);
            txtObservacao.Text = cabecalho["Observacao"].ToString();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Informe o título do orçamento.");
                txtTitulo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Selecione o status.");
                cmbStatus.Focus();
                return;
            }

            try
            {
                _orcamentoService.AtualizarDadosOrcamento(
                    _orcamentoId,
                    txtTitulo.Text,
                    cmbStatus.Text,
                    numVariacaoNota2.Value,
                    numVariacaoNota3.Value,
                    txtObservacao.Text
                );

                MessageBox.Show("Orçamento atualizado com sucesso.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar orçamento: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AplicarEstiloVisual()
        {
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10);

            AplicarEstiloPainel(pnlOrcamento);

            AplicarEstiloBotaoPrincipal(btnSalvar);
            AplicarEstiloBotaoCancelar(btnCancelar);

            AplicarEstiloCampos(this);

            pnlTopo.BackColor = Color.SteelBlue;

            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15);

            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Font = new Font("Segoe UI", 9);

            lblDadosOrcamento.ForeColor = Color.FromArgb(35, 35, 35);
            lblDadosOrcamento.Font = new Font("Segoe UI Semibold", 11);
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
    }
}
