using ComodoroERP.Utils;
using ComodoroERP.Services;
using System.Reflection;

namespace ComodoroERP
{
    public partial class FrmMenu : FrmBase
    {
        private readonly AtualizacaoService _atualizacaoService = new();

        public FrmMenu()
        {
            InitializeComponent();
            CarregarVersao();
            DarkTitleBar.Ativar(this);

            Shown += FrmMenu_Shown;
        }

        private void CarregarVersao()
        {
            Version? versao = Assembly
                .GetExecutingAssembly()
                .GetName()
                .Version;

            lblVersao.Text = $"ComodoroERP - Versão {versao?.Major}.{versao?.Minor}.{versao?.Build}";
        }

        private async void FrmMenu_Shown(object? sender, EventArgs e)
        {
            await _atualizacaoService.VerificarAtualizacaoAsync();
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