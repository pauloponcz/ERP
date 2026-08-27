namespace ComodoroERP
{
    partial class FrmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlTopo = new Panel();
            lblSubtituloTela = new Label();
            lblTituloTela = new Label();
            pnlFiltros = new Panel();
            btnLimpar = new Button();
            btnFiltrar = new Button();
            dtpDataFinal = new DateTimePicker();
            lblDataFinal = new Label();
            dtpDataInicial = new DateTimePicker();
            lblDataInicial = new Label();
            cmbEscola = new ComboBox();
            lblEscola = new Label();
            lblFiltros = new Label();
            pnlTotalAcertos = new Panel();
            lblTotalAcertos = new Label();
            lblTituloTotalAcertos = new Label();
            pnlValorTotal = new Panel();
            lblValorTotal = new Label();
            lblTituloValorTotal = new Label();
            pnlValorPago = new Panel();
            lblValorPago = new Label();
            lblTituloValorPago = new Label();
            pnlValorPendente = new Panel();
            lblValorPendente = new Label();
            lblTituloValorPendente = new Label();
            pnlPercentualPago = new Panel();
            lblPercentualPago = new Label();
            lblTituloPercentualPago = new Label();
            pnlMelhorPagadora = new Panel();
            lblMelhorPagadoraDetalhe = new Label();
            lblMelhorPagadoraEscola = new Label();
            lblTituloMelhorPagadora = new Label();
            pnlMaiorDevedora = new Panel();
            lblMaiorDevedoraDetalhe = new Label();
            lblMaiorDevedoraEscola = new Label();
            lblTituloMaiorDevedora = new Label();
            pnlGraficoStatus = new Panel();
            pnlGraficoDevedores = new Panel();
            pnlGraficoPagadores = new Panel();
            pnlGrid = new Panel();
            lblRanking = new Label();
            dgvRanking = new DataGridView();
            btnAtualizar = new Button();
            btnFechar = new Button();
            pnlTopo.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlTotalAcertos.SuspendLayout();
            pnlValorTotal.SuspendLayout();
            pnlValorPago.SuspendLayout();
            pnlValorPendente.SuspendLayout();
            pnlPercentualPago.SuspendLayout();
            pnlMelhorPagadora.SuspendLayout();
            pnlMaiorDevedora.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRanking).BeginInit();
            SuspendLayout();
            // 
            // pnlTopo
            // 
            pnlTopo.BackColor = Color.SteelBlue;
            pnlTopo.Controls.Add(lblSubtituloTela);
            pnlTopo.Controls.Add(lblTituloTela);
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(1180, 75);
            pnlTopo.TabIndex = 0;
            // 
            // lblSubtituloTela
            // 
            lblSubtituloTela.AutoSize = true;
            lblSubtituloTela.Font = new Font("Segoe UI", 9F);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Location = new Point(27, 43);
            lblSubtituloTela.Name = "lblSubtituloTela";
            lblSubtituloTela.Size = new Size(333, 15);
            lblSubtituloTela.TabIndex = 1;
            lblSubtituloTela.Text = "Acompanhe pagamentos, pendências e desempenho por escola";
            // 
            // lblTituloTela
            // 
            lblTituloTela.AutoSize = true;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15F);
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Location = new Point(25, 14);
            lblTituloTela.Name = "lblTituloTela";
            lblTituloTela.Size = new Size(240, 28);
            lblTituloTela.TabIndex = 0;
            lblTituloTela.Text = "DASHBOARD DE ACERTOS";
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.BorderStyle = BorderStyle.FixedSingle;
            pnlFiltros.Controls.Add(btnLimpar);
            pnlFiltros.Controls.Add(btnFiltrar);
            pnlFiltros.Controls.Add(dtpDataFinal);
            pnlFiltros.Controls.Add(lblDataFinal);
            pnlFiltros.Controls.Add(dtpDataInicial);
            pnlFiltros.Controls.Add(lblDataInicial);
            pnlFiltros.Controls.Add(cmbEscola);
            pnlFiltros.Controls.Add(lblEscola);
            pnlFiltros.Controls.Add(lblFiltros);
            pnlFiltros.Location = new Point(20, 90);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(1125, 90);
            pnlFiltros.TabIndex = 1;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(1010, 38);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(90, 35);
            btnLimpar.TabIndex = 8;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(905, 38);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(90, 35);
            btnFiltrar.TabIndex = 7;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // dtpDataFinal
            // 
            dtpDataFinal.Format = DateTimePickerFormat.Short;
            dtpDataFinal.Location = new Point(735, 45);
            dtpDataFinal.Name = "dtpDataFinal";
            dtpDataFinal.ShowCheckBox = true;
            dtpDataFinal.Size = new Size(145, 25);
            dtpDataFinal.TabIndex = 6;
            // 
            // lblDataFinal
            // 
            lblDataFinal.AutoSize = true;
            lblDataFinal.Location = new Point(735, 22);
            lblDataFinal.Name = "lblDataFinal";
            lblDataFinal.Size = new Size(73, 19);
            lblDataFinal.TabIndex = 5;
            lblDataFinal.Text = "Data Final:";
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.Format = DateTimePickerFormat.Short;
            dtpDataInicial.Location = new Point(565, 45);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.ShowCheckBox = true;
            dtpDataInicial.Size = new Size(145, 25);
            dtpDataInicial.TabIndex = 4;
            // 
            // lblDataInicial
            // 
            lblDataInicial.AutoSize = true;
            lblDataInicial.Location = new Point(565, 22);
            lblDataInicial.Name = "lblDataInicial";
            lblDataInicial.Size = new Size(79, 19);
            lblDataInicial.TabIndex = 3;
            lblDataInicial.Text = "Data Inicial:";
            // 
            // cmbEscola
            // 
            cmbEscola.FormattingEnabled = true;
            cmbEscola.Location = new Point(145, 45);
            cmbEscola.Name = "cmbEscola";
            cmbEscola.Size = new Size(390, 25);
            cmbEscola.TabIndex = 2;
            // 
            // lblEscola
            // 
            lblEscola.AutoSize = true;
            lblEscola.Location = new Point(145, 22);
            lblEscola.Name = "lblEscola";
            lblEscola.Size = new Size(49, 19);
            lblEscola.TabIndex = 1;
            lblEscola.Text = "Escola:";
            // 
            // lblFiltros
            // 
            lblFiltros.AutoSize = true;
            lblFiltros.Font = new Font("Segoe UI Semibold", 11F);
            lblFiltros.ForeColor = Color.FromArgb(35, 35, 35);
            lblFiltros.Location = new Point(15, 35);
            lblFiltros.Name = "lblFiltros";
            lblFiltros.Size = new Size(51, 20);
            lblFiltros.TabIndex = 0;
            lblFiltros.Text = "Filtros";
            // 
            // pnlTotalAcertos
            // 
            pnlTotalAcertos.BackColor = Color.White;
            pnlTotalAcertos.BorderStyle = BorderStyle.FixedSingle;
            pnlTotalAcertos.Controls.Add(lblTotalAcertos);
            pnlTotalAcertos.Controls.Add(lblTituloTotalAcertos);
            pnlTotalAcertos.Location = new Point(20, 195);
            pnlTotalAcertos.Name = "pnlTotalAcertos";
            pnlTotalAcertos.Size = new Size(210, 80);
            pnlTotalAcertos.TabIndex = 2;
            // 
            // lblTotalAcertos
            // 
            lblTotalAcertos.AutoSize = true;
            lblTotalAcertos.Font = new Font("Segoe UI Semibold", 17F);
            lblTotalAcertos.ForeColor = Color.SteelBlue;
            lblTotalAcertos.Location = new Point(15, 35);
            lblTotalAcertos.Name = "lblTotalAcertos";
            lblTotalAcertos.Size = new Size(26, 31);
            lblTotalAcertos.TabIndex = 1;
            lblTotalAcertos.Text = "0";
            // 
            // lblTituloTotalAcertos
            // 
            lblTituloTotalAcertos.AutoSize = true;
            lblTituloTotalAcertos.Location = new Point(15, 12);
            lblTituloTotalAcertos.Name = "lblTituloTotalAcertos";
            lblTituloTotalAcertos.Size = new Size(101, 19);
            lblTituloTotalAcertos.TabIndex = 0;
            lblTituloTotalAcertos.Text = "Total de Acertos";
            // 
            // pnlValorTotal
            // 
            pnlValorTotal.BackColor = Color.White;
            pnlValorTotal.BorderStyle = BorderStyle.FixedSingle;
            pnlValorTotal.Controls.Add(lblValorTotal);
            pnlValorTotal.Controls.Add(lblTituloValorTotal);
            pnlValorTotal.Location = new Point(245, 195);
            pnlValorTotal.Name = "pnlValorTotal";
            pnlValorTotal.Size = new Size(210, 80);
            pnlValorTotal.TabIndex = 3;
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Font = new Font("Segoe UI Semibold", 15F);
            lblValorTotal.ForeColor = Color.SteelBlue;
            lblValorTotal.Location = new Point(15, 37);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(79, 28);
            lblValorTotal.TabIndex = 1;
            lblValorTotal.Text = "R$ 0,00";
            // 
            // lblTituloValorTotal
            // 
            lblTituloValorTotal.AutoSize = true;
            lblTituloValorTotal.Location = new Point(15, 12);
            lblTituloValorTotal.Name = "lblTituloValorTotal";
            lblTituloValorTotal.Size = new Size(73, 19);
            lblTituloValorTotal.TabIndex = 0;
            lblTituloValorTotal.Text = "Valor Total";
            // 
            // pnlValorPago
            // 
            pnlValorPago.BackColor = Color.White;
            pnlValorPago.BorderStyle = BorderStyle.FixedSingle;
            pnlValorPago.Controls.Add(lblValorPago);
            pnlValorPago.Controls.Add(lblTituloValorPago);
            pnlValorPago.Location = new Point(470, 195);
            pnlValorPago.Name = "pnlValorPago";
            pnlValorPago.Size = new Size(210, 80);
            pnlValorPago.TabIndex = 4;
            // 
            // lblValorPago
            // 
            lblValorPago.AutoSize = true;
            lblValorPago.Font = new Font("Segoe UI Semibold", 15F);
            lblValorPago.ForeColor = Color.SeaGreen;
            lblValorPago.Location = new Point(15, 37);
            lblValorPago.Name = "lblValorPago";
            lblValorPago.Size = new Size(79, 28);
            lblValorPago.TabIndex = 1;
            lblValorPago.Text = "R$ 0,00";
            // 
            // lblTituloValorPago
            // 
            lblTituloValorPago.AutoSize = true;
            lblTituloValorPago.Location = new Point(15, 12);
            lblTituloValorPago.Name = "lblTituloValorPago";
            lblTituloValorPago.Size = new Size(72, 19);
            lblTituloValorPago.TabIndex = 0;
            lblTituloValorPago.Text = "Valor Pago";
            // 
            // pnlValorPendente
            // 
            pnlValorPendente.BackColor = Color.White;
            pnlValorPendente.BorderStyle = BorderStyle.FixedSingle;
            pnlValorPendente.Controls.Add(lblValorPendente);
            pnlValorPendente.Controls.Add(lblTituloValorPendente);
            pnlValorPendente.Location = new Point(695, 195);
            pnlValorPendente.Name = "pnlValorPendente";
            pnlValorPendente.Size = new Size(210, 80);
            pnlValorPendente.TabIndex = 5;
            // 
            // lblValorPendente
            // 
            lblValorPendente.AutoSize = true;
            lblValorPendente.Font = new Font("Segoe UI Semibold", 15F);
            lblValorPendente.ForeColor = Color.IndianRed;
            lblValorPendente.Location = new Point(15, 37);
            lblValorPendente.Name = "lblValorPendente";
            lblValorPendente.Size = new Size(79, 28);
            lblValorPendente.TabIndex = 1;
            lblValorPendente.Text = "R$ 0,00";
            // 
            // lblTituloValorPendente
            // 
            lblTituloValorPendente.AutoSize = true;
            lblTituloValorPendente.Location = new Point(15, 12);
            lblTituloValorPendente.Name = "lblTituloValorPendente";
            lblTituloValorPendente.Size = new Size(102, 19);
            lblTituloValorPendente.TabIndex = 0;
            lblTituloValorPendente.Text = "Valor Pendente";
            // 
            // pnlPercentualPago
            // 
            pnlPercentualPago.BackColor = Color.White;
            pnlPercentualPago.BorderStyle = BorderStyle.FixedSingle;
            pnlPercentualPago.Controls.Add(lblPercentualPago);
            pnlPercentualPago.Controls.Add(lblTituloPercentualPago);
            pnlPercentualPago.Location = new Point(920, 195);
            pnlPercentualPago.Name = "pnlPercentualPago";
            pnlPercentualPago.Size = new Size(225, 80);
            pnlPercentualPago.TabIndex = 6;
            // 
            // lblPercentualPago
            // 
            lblPercentualPago.AutoSize = true;
            lblPercentualPago.Font = new Font("Segoe UI Semibold", 15F);
            lblPercentualPago.ForeColor = Color.SeaGreen;
            lblPercentualPago.Location = new Point(15, 37);
            lblPercentualPago.Name = "lblPercentualPago";
            lblPercentualPago.Size = new Size(70, 28);
            lblPercentualPago.TabIndex = 1;
            lblPercentualPago.Text = "0,00%";
            // 
            // lblTituloPercentualPago
            // 
            lblTituloPercentualPago.AutoSize = true;
            lblTituloPercentualPago.Location = new Point(15, 12);
            lblTituloPercentualPago.Name = "lblTituloPercentualPago";
            lblTituloPercentualPago.Size = new Size(54, 19);
            lblTituloPercentualPago.TabIndex = 0;
            lblTituloPercentualPago.Text = "% Pago";
            // 
            // pnlMelhorPagadora
            // 
            pnlMelhorPagadora.BackColor = Color.White;
            pnlMelhorPagadora.BorderStyle = BorderStyle.FixedSingle;
            pnlMelhorPagadora.Controls.Add(lblMelhorPagadoraDetalhe);
            pnlMelhorPagadora.Controls.Add(lblMelhorPagadoraEscola);
            pnlMelhorPagadora.Controls.Add(lblTituloMelhorPagadora);
            pnlMelhorPagadora.Location = new Point(20, 290);
            pnlMelhorPagadora.Name = "pnlMelhorPagadora";
            pnlMelhorPagadora.Size = new Size(555, 80);
            pnlMelhorPagadora.TabIndex = 7;
            // 
            // lblMelhorPagadoraDetalhe
            // 
            lblMelhorPagadoraDetalhe.AutoSize = true;
            lblMelhorPagadoraDetalhe.Location = new Point(15, 55);
            lblMelhorPagadoraDetalhe.Name = "lblMelhorPagadoraDetalhe";
            lblMelhorPagadoraDetalhe.Size = new Size(14, 19);
            lblMelhorPagadoraDetalhe.TabIndex = 2;
            lblMelhorPagadoraDetalhe.Text = "-";
            // 
            // lblMelhorPagadoraEscola
            // 
            lblMelhorPagadoraEscola.AutoSize = true;
            lblMelhorPagadoraEscola.Font = new Font("Segoe UI Semibold", 10F);
            lblMelhorPagadoraEscola.ForeColor = Color.SeaGreen;
            lblMelhorPagadoraEscola.Location = new Point(15, 32);
            lblMelhorPagadoraEscola.Name = "lblMelhorPagadoraEscola";
            lblMelhorPagadoraEscola.Size = new Size(14, 19);
            lblMelhorPagadoraEscola.TabIndex = 1;
            lblMelhorPagadoraEscola.Text = "-";
            // 
            // lblTituloMelhorPagadora
            // 
            lblTituloMelhorPagadora.AutoSize = true;
            lblTituloMelhorPagadora.Location = new Point(15, 10);
            lblTituloMelhorPagadora.Name = "lblTituloMelhorPagadora";
            lblTituloMelhorPagadora.Size = new Size(163, 19);
            lblTituloMelhorPagadora.TabIndex = 0;
            lblTituloMelhorPagadora.Text = "Escola que mais paga certo";
            // 
            // pnlMaiorDevedora
            // 
            pnlMaiorDevedora.BackColor = Color.White;
            pnlMaiorDevedora.BorderStyle = BorderStyle.FixedSingle;
            pnlMaiorDevedora.Controls.Add(lblMaiorDevedoraDetalhe);
            pnlMaiorDevedora.Controls.Add(lblMaiorDevedoraEscola);
            pnlMaiorDevedora.Controls.Add(lblTituloMaiorDevedora);
            pnlMaiorDevedora.Location = new Point(590, 290);
            pnlMaiorDevedora.Name = "pnlMaiorDevedora";
            pnlMaiorDevedora.Size = new Size(555, 80);
            pnlMaiorDevedora.TabIndex = 8;
            // 
            // lblMaiorDevedoraDetalhe
            // 
            lblMaiorDevedoraDetalhe.AutoSize = true;
            lblMaiorDevedoraDetalhe.Location = new Point(15, 55);
            lblMaiorDevedoraDetalhe.Name = "lblMaiorDevedoraDetalhe";
            lblMaiorDevedoraDetalhe.Size = new Size(14, 19);
            lblMaiorDevedoraDetalhe.TabIndex = 2;
            lblMaiorDevedoraDetalhe.Text = "-";
            // 
            // lblMaiorDevedoraEscola
            // 
            lblMaiorDevedoraEscola.AutoSize = true;
            lblMaiorDevedoraEscola.Font = new Font("Segoe UI Semibold", 10F);
            lblMaiorDevedoraEscola.ForeColor = Color.IndianRed;
            lblMaiorDevedoraEscola.Location = new Point(15, 32);
            lblMaiorDevedoraEscola.Name = "lblMaiorDevedoraEscola";
            lblMaiorDevedoraEscola.Size = new Size(14, 19);
            lblMaiorDevedoraEscola.TabIndex = 1;
            lblMaiorDevedoraEscola.Text = "-";
            // 
            // lblTituloMaiorDevedora
            // 
            lblTituloMaiorDevedora.AutoSize = true;
            lblTituloMaiorDevedora.Location = new Point(15, 10);
            lblTituloMaiorDevedora.Name = "lblTituloMaiorDevedora";
            lblTituloMaiorDevedora.Size = new Size(144, 19);
            lblTituloMaiorDevedora.TabIndex = 0;
            lblTituloMaiorDevedora.Text = "Escola que mais deve";
            // 
            // pnlGraficoStatus
            // 
            pnlGraficoStatus.BackColor = Color.White;
            pnlGraficoStatus.BorderStyle = BorderStyle.FixedSingle;
            pnlGraficoStatus.Location = new Point(20, 385);
            pnlGraficoStatus.Name = "pnlGraficoStatus";
            pnlGraficoStatus.Size = new Size(360, 165);
            pnlGraficoStatus.TabIndex = 9;
            pnlGraficoStatus.Paint += pnlGraficoStatus_Paint;
            // 
            // pnlGraficoDevedores
            // 
            pnlGraficoDevedores.BackColor = Color.White;
            pnlGraficoDevedores.BorderStyle = BorderStyle.FixedSingle;
            pnlGraficoDevedores.Location = new Point(400, 385);
            pnlGraficoDevedores.Name = "pnlGraficoDevedores";
            pnlGraficoDevedores.Size = new Size(360, 165);
            pnlGraficoDevedores.TabIndex = 10;
            pnlGraficoDevedores.Paint += pnlGraficoDevedores_Paint;
            // 
            // pnlGraficoPagadores
            // 
            pnlGraficoPagadores.BackColor = Color.White;
            pnlGraficoPagadores.BorderStyle = BorderStyle.FixedSingle;
            pnlGraficoPagadores.Location = new Point(785, 385);
            pnlGraficoPagadores.Name = "pnlGraficoPagadores";
            pnlGraficoPagadores.Size = new Size(360, 165);
            pnlGraficoPagadores.TabIndex = 11;
            pnlGraficoPagadores.Paint += pnlGraficoPagadores_Paint;
            // 
            // pnlGrid
            // 
            pnlGrid.BackColor = Color.White;
            pnlGrid.BorderStyle = BorderStyle.FixedSingle;
            pnlGrid.Controls.Add(lblRanking);
            pnlGrid.Controls.Add(dgvRanking);
            pnlGrid.Location = new Point(20, 565);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(1125, 240);
            pnlGrid.TabIndex = 12;
            // 
            // lblRanking
            // 
            lblRanking.AutoSize = true;
            lblRanking.Font = new Font("Segoe UI Semibold", 11F);
            lblRanking.ForeColor = Color.FromArgb(35, 35, 35);
            lblRanking.Location = new Point(15, 12);
            lblRanking.Name = "lblRanking";
            lblRanking.Size = new Size(137, 20);
            lblRanking.TabIndex = 1;
            lblRanking.Text = "Ranking por escola";
            // 
            // dgvRanking
            // 
            dgvRanking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRanking.Location = new Point(15, 45);
            dgvRanking.Name = "dgvRanking";
            dgvRanking.Size = new Size(1095, 175);
            dgvRanking.TabIndex = 0;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(915, 820);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(110, 35);
            btnAtualizar.TabIndex = 13;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(1035, 820);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(110, 35);
            btnFechar.TabIndex = 14;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1164, 871);
            Controls.Add(btnFechar);
            Controls.Add(btnAtualizar);
            Controls.Add(pnlGrid);
            Controls.Add(pnlGraficoPagadores);
            Controls.Add(pnlGraficoDevedores);
            Controls.Add(pnlGraficoStatus);
            Controls.Add(pnlMaiorDevedora);
            Controls.Add(pnlMelhorPagadora);
            Controls.Add(pnlPercentualPago);
            Controls.Add(pnlValorPendente);
            Controls.Add(pnlValorPago);
            Controls.Add(pnlValorTotal);
            Controls.Add(pnlTotalAcertos);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlTopo);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmDashboard";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dashboard de Acertos";
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlTotalAcertos.ResumeLayout(false);
            pnlTotalAcertos.PerformLayout();
            pnlValorTotal.ResumeLayout(false);
            pnlValorTotal.PerformLayout();
            pnlValorPago.ResumeLayout(false);
            pnlValorPago.PerformLayout();
            pnlValorPendente.ResumeLayout(false);
            pnlValorPendente.PerformLayout();
            pnlPercentualPago.ResumeLayout(false);
            pnlPercentualPago.PerformLayout();
            pnlMelhorPagadora.ResumeLayout(false);
            pnlMelhorPagadora.PerformLayout();
            pnlMaiorDevedora.ResumeLayout(false);
            pnlMaiorDevedora.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRanking).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTopo;
        private Label lblSubtituloTela;
        private Label lblTituloTela;
        private Panel pnlFiltros;
        private Label lblFiltros;
        private Label lblEscola;
        private ComboBox cmbEscola;
        private Label lblDataInicial;
        private DateTimePicker dtpDataInicial;
        private Label lblDataFinal;
        private DateTimePicker dtpDataFinal;
        private Button btnFiltrar;
        private Button btnLimpar;
        private Panel pnlTotalAcertos;
        private Label lblTotalAcertos;
        private Label lblTituloTotalAcertos;
        private Panel pnlValorTotal;
        private Label lblValorTotal;
        private Label lblTituloValorTotal;
        private Panel pnlValorPago;
        private Label lblValorPago;
        private Label lblTituloValorPago;
        private Panel pnlValorPendente;
        private Label lblValorPendente;
        private Label lblTituloValorPendente;
        private Panel pnlPercentualPago;
        private Label lblPercentualPago;
        private Label lblTituloPercentualPago;
        private Panel pnlMelhorPagadora;
        private Label lblMelhorPagadoraDetalhe;
        private Label lblMelhorPagadoraEscola;
        private Label lblTituloMelhorPagadora;
        private Panel pnlMaiorDevedora;
        private Label lblMaiorDevedoraDetalhe;
        private Label lblMaiorDevedoraEscola;
        private Label lblTituloMaiorDevedora;
        private Panel pnlGraficoStatus;
        private Panel pnlGraficoDevedores;
        private Panel pnlGraficoPagadores;
        private Panel pnlGrid;
        private Label lblRanking;
        private DataGridView dgvRanking;
        private Button btnAtualizar;
        private Button btnFechar;
    }
}
