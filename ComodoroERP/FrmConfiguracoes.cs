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
            AplicarEstiloVisual();
        }

        private void CarregarConfiguracoes()
        {
            txtPastaPdfs.Text = _configuracaoService.ObterPastaPdfs();
            txtPastaBackups.Text = _configuracaoService.ObterPastaBackups();
            txtModeloNotas.Text = _configuracaoService.ObterModeloNotas();
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

        private void btnSelecionarModeloNotas_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Selecione o modelo de notas em Excel";
            dialog.Filter = "Arquivos Excel (*.xlsx)|*.xlsx";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtModeloNotas.Text = dialog.FileName;
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
                _configuracaoService.SalvarValor("ModeloNotas", txtModeloNotas.Text);

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

        private void FrmConfiguracoes_Load(object sender, EventArgs e)
        {

        }

        private void AplicarEstiloVisual()
        {
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10);

            AplicarEstiloPainel(pnlCaminhos);

            AplicarEstiloBotaoPrincipal(btnSelecionarPastaPdfs);
            AplicarEstiloBotaoPrincipal(btnSelecionarPastaBackups);
            AplicarEstiloBotaoPrincipal(btnSelecionarModeloNotas);
            AplicarEstiloBotaoPrincipal(btnSalvar);

            AplicarEstiloBotaoCancelar(btnCancelar);

            AplicarEstiloCampos(this);

            pnlTopo.BackColor = Color.SteelBlue;

            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15);

            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Font = new Font("Segoe UI", 9);

            lblCaminhosSistema.ForeColor = Color.FromArgb(35, 35, 35);
            lblCaminhosSistema.Font = new Font("Segoe UI Semibold", 11);
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

                if (controle.HasChildren)
                {
                    AplicarEstiloCampos(controle);
                }
            }
        }

    }
}