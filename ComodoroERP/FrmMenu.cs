using ComodoroERP.Utils;

namespace ComodoroERP
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            DarkTitleBar.Ativar(this);
        }

        private void btnNovoOrcamento_Click(object sender, EventArgs e)
        {
            FrmNovoOrcamento tela = new FrmNovoOrcamento();
            tela.ShowDialog();
        }

        private void btnVerOrcamentos_Click(object sender, EventArgs e)
        {
            FrmOrcamentos tela = new FrmOrcamentos();
            tela.ShowDialog();
        }

        private void btnItensLancados_Click(object sender, EventArgs e)
        {
            FrmItens tela = new FrmItens();
            tela.ShowDialog();
        }

        private void btnServicosPermitidos_Click(object sender, EventArgs e)
        {
            FrmServicosPermitidos tela = new FrmServicosPermitidos();
            tela.ShowDialog();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard tela = new FrmDashboard();
            tela.ShowDialog();
        }


        private void btnAdicionarAcerto_Click(object? sender, EventArgs e)
        {
            using var tela = new FrmAdicionarAcerto();
            tela.ShowDialog();
        }

        private void btnVerAcertos_Click(object? sender, EventArgs e)
        {
            using var tela = new FrmAcertos();
            tela.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            using var tela = new FrmConfiguracoes();
            tela.ShowDialog();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }
    }
}