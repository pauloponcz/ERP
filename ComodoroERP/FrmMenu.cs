using ComodoroERP.Services;
using ComodoroERP.Utils;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace ComodoroERP
{
    public partial class FrmMenu : FrmBase
    {
        private readonly AtualizacaoService _atualizacaoService = new();

        private AtualizacaoDisponivel? _atualizacaoDisponivel;

        private Panel? pnlNotificacaoAtualizacao;
        private Label? lblNotificacaoTitulo;
        private Label? lblNotificacaoTexto;
        private Label? lblAtualizarSistema;
        private Button? btnFecharNotificacao;

        public FrmMenu()
        {
            InitializeComponent();

            CarregarVersao();
            DarkTitleBar.Ativar(this);

            CriarNotificacaoAtualizacao();

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
            await VerificarAtualizacaoVisualAsync();
        }

        private async Task VerificarAtualizacaoVisualAsync()
        {
            _atualizacaoDisponivel = await _atualizacaoService.VerificarAtualizacaoDisponivelAsync();

            if (_atualizacaoDisponivel == null)
                return;

            MostrarNotificacaoAtualizacao(_atualizacaoDisponivel);
        }

        private void CriarNotificacaoAtualizacao()
        {
            pnlNotificacaoAtualizacao = new Panel
            {
                Name = "pnlNotificacaoAtualizacao",
                Size = new Size(324, 78),
                Location = new Point(20, 78),
                BackColor = Color.Transparent,
                Visible = false
            };

            pnlNotificacaoAtualizacao.Paint += pnlNotificacaoAtualizacao_Paint;
            pnlNotificacaoAtualizacao.Resize += pnlNotificacaoAtualizacao_Resize;

            lblNotificacaoTitulo = new Label
            {
                AutoSize = false,
                Location = new Point(16, 10),
                Size = new Size(245, 20),
                Font = new Font("Segoe UI Semibold", 9F),
                ForeColor = Color.FromArgb(80, 55, 0),
                Text = "Atualização disponível"
            };

            lblNotificacaoTexto = new Label
            {
                AutoSize = false,
                Location = new Point(16, 32),
                Size = new Size(205, 35),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(80, 55, 0),
                Text = ""
            };

            lblAtualizarSistema = new Label
            {
                AutoSize = true,
                Location = new Point(238, 44),
                Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Underline),
                ForeColor = Color.FromArgb(120, 80, 0),
                Cursor = Cursors.Hand,
                Text = "Atualizar"
            };

            lblAtualizarSistema.Click += lblAtualizarSistema_Click;
            lblAtualizarSistema.MouseEnter += (s, e) =>
            {
                lblAtualizarSistema.ForeColor = Color.FromArgb(60, 40, 0);
            };
            lblAtualizarSistema.MouseLeave += (s, e) =>
            {
                lblAtualizarSistema.ForeColor = Color.FromArgb(120, 80, 0);
            };

            btnFecharNotificacao = new Button
            {
                Size = new Size(24, 24),
                Location = new Point(288, 8),
                Text = "X",
                Font = new Font("Segoe UI Semibold", 8F),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 244, 190),
                ForeColor = Color.FromArgb(100, 70, 0),
                Cursor = Cursors.Hand,
                TabStop = false
            };

            btnFecharNotificacao.FlatAppearance.BorderSize = 0;
            btnFecharNotificacao.Click += btnFecharNotificacao_Click;

            pnlNotificacaoAtualizacao.Controls.Add(lblNotificacaoTitulo);
            pnlNotificacaoAtualizacao.Controls.Add(lblNotificacaoTexto);
            pnlNotificacaoAtualizacao.Controls.Add(lblAtualizarSistema);
            pnlNotificacaoAtualizacao.Controls.Add(btnFecharNotificacao);

            Controls.Add(pnlNotificacaoAtualizacao);
            pnlNotificacaoAtualizacao.BringToFront();
        }

        private void MostrarNotificacaoAtualizacao(AtualizacaoDisponivel atualizacao)
        {
            if (pnlNotificacaoAtualizacao == null || lblNotificacaoTexto == null)
                return;

            lblNotificacaoTexto.Text =
                $"Nova versão {_atualizacaoService.FormatarVersao(atualizacao.NovaVersao)} disponível.";

            AjustarTelaParaNotificacao(true);

            pnlNotificacaoAtualizacao.Visible = true;
            pnlNotificacaoAtualizacao.BringToFront();
            pnlNotificacaoAtualizacao.Invalidate();
        }

        private void OcultarNotificacaoAtualizacao()
        {
            if (pnlNotificacaoAtualizacao != null)
                pnlNotificacaoAtualizacao.Visible = false;

            AjustarTelaParaNotificacao(false);
        }

        private void AjustarTelaParaNotificacao(bool mostrar)
        {
            if (mostrar)
            {
                ClientSize = new Size(364, 700);

                pnlMenu.Location = new Point(30, 170);
                btnConfiguracoes.Location = new Point(70, 568);
                btnSair.Location = new Point(70, 614);
                lblVersao.Location = new Point(12, 678);
            }
            else
            {
                ClientSize = new Size(364, 615);

                pnlMenu.Location = new Point(30, 90);
                btnConfiguracoes.Location = new Point(70, 488);
                btnSair.Location = new Point(70, 534);
                lblVersao.Location = new Point(12, 593);
            }
        }

        private void pnlNotificacaoAtualizacao_Resize(object? sender, EventArgs e)
        {
            if (pnlNotificacaoAtualizacao == null)
                return;

            using GraphicsPath path = CriarRetanguloArredondado(
                new Rectangle(0, 0, pnlNotificacaoAtualizacao.Width, pnlNotificacaoAtualizacao.Height),
                14
            );

            pnlNotificacaoAtualizacao.Region = new Region(path);
        }

        private void pnlNotificacaoAtualizacao_Paint(object? sender, PaintEventArgs e)
        {
            if (pnlNotificacaoAtualizacao == null)
                return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle area = new Rectangle(
                0,
                0,
                pnlNotificacaoAtualizacao.Width - 1,
                pnlNotificacaoAtualizacao.Height - 1
            );

            using GraphicsPath path = CriarRetanguloArredondado(area, 14);

            using SolidBrush fundo = new SolidBrush(Color.FromArgb(255, 244, 190));
            using Pen borda = new Pen(Color.FromArgb(230, 185, 80), 1);

            e.Graphics.FillPath(fundo, path);
            e.Graphics.DrawPath(borda, path);
        }

        private GraphicsPath CriarRetanguloArredondado(Rectangle rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            path.AddArc(rectangle.X, rectangle.Y, diameter, diameter, 180, 90);
            path.AddArc(rectangle.Right - diameter, rectangle.Y, diameter, diameter, 270, 90);
            path.AddArc(rectangle.Right - diameter, rectangle.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rectangle.X, rectangle.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();

            return path;
        }

        private async void lblAtualizarSistema_Click(object? sender, EventArgs e)
        {
            if (_atualizacaoDisponivel == null)
                return;

            try
            {
                if (lblAtualizarSistema != null)
                {
                    lblAtualizarSistema.Enabled = false;
                    lblAtualizarSistema.Text = "Atualizando...";
                }

                if (lblNotificacaoTexto != null)
                    lblNotificacaoTexto.Text = "Baixando atualização. Aguarde...";

                await _atualizacaoService.InstalarAtualizacaoAsync(_atualizacaoDisponivel);
            }
            catch (Exception ex)
            {
                if (lblAtualizarSistema != null)
                {
                    lblAtualizarSistema.Enabled = true;
                    lblAtualizarSistema.Text = "Atualizar";
                }

                if (lblNotificacaoTexto != null)
                    lblNotificacaoTexto.Text = "Erro ao atualizar. Tente novamente.";

                MessageBox.Show(
                    "Erro ao atualizar o sistema:\n\n" + ex.Message,
                    "Atualização",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnFecharNotificacao_Click(object? sender, EventArgs e)
        {
            OcultarNotificacaoAtualizacao();
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