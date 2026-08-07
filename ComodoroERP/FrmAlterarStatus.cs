using ComodoroERP.Services;

namespace ComodoroERP
{
    public partial class FrmAlterarStatus : Form
    {
        private readonly int _orcamentoId;
        private readonly OrcamentoService _orcamentoService = new();

        public FrmAlterarStatus(int orcamentoId)
        {
            InitializeComponent();

            _orcamentoId = orcamentoId;

            CarregarStatus();
        }

        private void CarregarStatus()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Pendente");
            cmbStatus.Items.Add("Pago");
            cmbStatus.Items.Add("Parcial");
            cmbStatus.Items.Add("Concluído");
            cmbStatus.Items.Add("Cancelado");

            cmbStatus.SelectedIndex = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Selecione o novo status.");
                return;
            }

            string novoStatus = cmbStatus.Text;

            try
            {
                _orcamentoService.AlterarStatus(_orcamentoId, novoStatus);

                MessageBox.Show("Status alterado com sucesso.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar status: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}