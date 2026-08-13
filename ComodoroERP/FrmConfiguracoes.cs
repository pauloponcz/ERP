using ComodoroERP.Services;

namespace ComodoroERP
{
    public partial class FrmConfiguracoes : Form
    {
        private readonly ConfiguracaoService _configuracaoService = new();

        public FrmConfiguracoes()
        {
            InitializeComponent();

            CarregarConfiguracoes();
        }

        private void CarregarConfiguracoes()
        {
            txtPastaPdfs.Text = _configuracaoService.ObterPastaPdfs();
            txtPastaBackups.Text = _configuracaoService.ObterPastaBackups();
        }

        private void btnSelecionarPastaPdfs_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.Description = "Selecione a pasta onde os PDFs serão salvos";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPastaPdfs.Text = dialog.SelectedPath;
            }
        }

        private void btnSelecionarPastaBackups_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.Description = "Selecione a pasta onde os backups serão salvos";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPastaBackups.Text = dialog.SelectedPath;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPastaPdfs.Text))
            {
                MessageBox.Show("Informe a pasta dos PDFs.");
                txtPastaPdfs.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPastaBackups.Text))
            {
                MessageBox.Show("Informe a pasta dos backups.");
                txtPastaBackups.Focus();
                return;
            }

            try
            {
                Directory.CreateDirectory(txtPastaPdfs.Text);
                Directory.CreateDirectory(txtPastaBackups.Text);

                _configuracaoService.SalvarValor("PastaPdfs", txtPastaPdfs.Text);
                _configuracaoService.SalvarValor("PastaBackups", txtPastaBackups.Text);

                MessageBox.Show("Configurações salvas com sucesso.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar configurações: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}