namespace ComodoroERP
{
    partial class FrmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            fileSystemWatcher1 = new FileSystemWatcher();
            lblTotalOrcamentos = new Label();
            lblPendentes = new Label();
            lblPagos = new Label();
            lblCancelados = new Label();
            lblValorTotal = new Label();
            btnAtualizar = new Button();
            btnFechar = new Button();
            lblValorPendente = new Label();
            lblValorPago = new Label();
            dgvUltimosOrcamentos = new DataGridView();
            pnlTopo = new Panel();
            lblTituloTela = new Label();
            lblSubtituloTela = new Label();
            pnlTotalOrcamentos = new Panel();
            lblTituloTotalOrcamentos = new Label();
            pnlPendentes = new Panel();
            lblTituloPendentes = new Label();
            pnlPagos = new Panel();
            lblTituloPagos = new Label();
            lblTituloCancelados = new Label();
            pnlCancelados = new Panel();
            lblTituloValorTotal = new Label();
            pnlValorTotal = new Panel();
            lblTituloValorPendente = new Label();
            pnlValorPendente = new Panel();
            lblTituloValorPago = new Label();
            pnlValorPago = new Panel();
            pnlGrid = new Panel();
            lblUltimosOrcamentos = new Label();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUltimosOrcamentos).BeginInit();
            pnlTopo.SuspendLayout();
            pnlTotalOrcamentos.SuspendLayout();
            pnlPendentes.SuspendLayout();
            pnlPagos.SuspendLayout();
            pnlCancelados.SuspendLayout();
            pnlValorTotal.SuspendLayout();
            pnlValorPendente.SuspendLayout();
            pnlValorPago.SuspendLayout();
            pnlGrid.SuspendLayout();
            SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // lblTotalOrcamentos
            // 
            lblTotalOrcamentos.AutoSize = true;
            lblTotalOrcamentos.Font = new Font("Segoe UI Semibold", 18F);
            lblTotalOrcamentos.ForeColor = Color.SteelBlue;
            lblTotalOrcamentos.Location = new Point(15, 35);
            lblTotalOrcamentos.Name = "lblTotalOrcamentos";
            lblTotalOrcamentos.Size = new Size(27, 32);
            lblTotalOrcamentos.TabIndex = 1;
            lblTotalOrcamentos.Text = "0";
            // 
            // lblPendentes
            // 
            lblPendentes.AutoSize = true;
            lblPendentes.Font = new Font("Segoe UI Semibold", 18F);
            lblPendentes.ForeColor = Color.DarkOrange;
            lblPendentes.Location = new Point(15, 35);
            lblPendentes.Name = "lblPendentes";
            lblPendentes.Size = new Size(27, 32);
            lblPendentes.TabIndex = 2;
            lblPendentes.Text = "0";
            // 
            // lblPagos
            // 
            lblPagos.AutoSize = true;
            lblPagos.Font = new Font("Segoe UI Semibold", 18F);
            lblPagos.ForeColor = Color.SeaGreen;
            lblPagos.Location = new Point(15, 35);
            lblPagos.Name = "lblPagos";
            lblPagos.Size = new Size(27, 32);
            lblPagos.TabIndex = 3;
            lblPagos.Text = "0";
            // 
            // lblCancelados
            // 
            lblCancelados.AutoSize = true;
            lblCancelados.Font = new Font("Segoe UI Semibold", 18F);
            lblCancelados.ForeColor = Color.IndianRed;
            lblCancelados.Location = new Point(15, 35);
            lblCancelados.Name = "lblCancelados";
            lblCancelados.Size = new Size(27, 32);
            lblCancelados.TabIndex = 4;
            lblCancelados.Text = "0";
            lblCancelados.Click += label4_Click;
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Font = new Font("Segoe UI Semibold", 16F);
            lblValorTotal.ForeColor = Color.SteelBlue;
            lblValorTotal.Location = new Point(15, 35);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(86, 30);
            lblValorTotal.TabIndex = 5;
            lblValorTotal.Text = "R$ 0,00";
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(725, 570);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(110, 35);
            btnAtualizar.TabIndex = 41;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(850, 570);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(110, 35);
            btnFechar.TabIndex = 42;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // lblValorPendente
            // 
            lblValorPendente.AutoSize = true;
            lblValorPendente.Font = new Font("Segoe UI Semibold", 16F);
            lblValorPendente.ForeColor = Color.DarkOrange;
            lblValorPendente.Location = new Point(15, 35);
            lblValorPendente.Name = "lblValorPendente";
            lblValorPendente.Size = new Size(86, 30);
            lblValorPendente.TabIndex = 7;
            lblValorPendente.Text = "R$ 0,00";
            // 
            // lblValorPago
            // 
            lblValorPago.AutoSize = true;
            lblValorPago.Font = new Font("Segoe UI Semibold", 16F);
            lblValorPago.ForeColor = Color.SeaGreen;
            lblValorPago.Location = new Point(15, 35);
            lblValorPago.Name = "lblValorPago";
            lblValorPago.Size = new Size(86, 30);
            lblValorPago.TabIndex = 6;
            lblValorPago.Text = "R$ 0,00";
            // 
            // dgvUltimosOrcamentos
            // 
            dgvUltimosOrcamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUltimosOrcamentos.Location = new Point(15, 45);
            dgvUltimosOrcamentos.Name = "dgvUltimosOrcamentos";
            dgvUltimosOrcamentos.Size = new Size(910, 185);
            dgvUltimosOrcamentos.TabIndex = 0;
            // 
            // pnlTopo
            // 
            pnlTopo.BackColor = Color.SteelBlue;
            pnlTopo.Controls.Add(lblSubtituloTela);
            pnlTopo.Controls.Add(lblTituloTela);
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(1000, 75);
            pnlTopo.TabIndex = 45;
            // 
            // lblTituloTela
            // 
            lblTituloTela.AutoSize = true;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15F);
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Location = new Point(25, 14);
            lblTituloTela.Name = "lblTituloTela";
            lblTituloTela.Size = new Size(131, 28);
            lblTituloTela.TabIndex = 0;
            lblTituloTela.Text = "DASHBOARD";
            // 
            // lblSubtituloTela
            // 
            lblSubtituloTela.AutoSize = true;
            lblSubtituloTela.Font = new Font("Segoe UI", 9F);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Location = new Point(27, 43);
            lblSubtituloTela.Name = "lblSubtituloTela";
            lblSubtituloTela.Size = new Size(293, 15);
            lblSubtituloTela.TabIndex = 1;
            lblSubtituloTela.Text = "Acompanhe os principais indicadores dos orçamentos";
            // 
            // pnlTotalOrcamentos
            // 
            pnlTotalOrcamentos.BackColor = Color.White;
            pnlTotalOrcamentos.BorderStyle = BorderStyle.FixedSingle;
            pnlTotalOrcamentos.Controls.Add(lblTituloTotalOrcamentos);
            pnlTotalOrcamentos.Controls.Add(lblTotalOrcamentos);
            pnlTotalOrcamentos.Location = new Point(20, 95);
            pnlTotalOrcamentos.Name = "pnlTotalOrcamentos";
            pnlTotalOrcamentos.Size = new Size(220, 80);
            pnlTotalOrcamentos.TabIndex = 46;
            // 
            // lblTituloTotalOrcamentos
            // 
            lblTituloTotalOrcamentos.AutoSize = true;
            lblTituloTotalOrcamentos.Font = new Font("Segoe UI", 9F);
            lblTituloTotalOrcamentos.ForeColor = Color.DimGray;
            lblTituloTotalOrcamentos.Location = new Point(15, 12);
            lblTituloTotalOrcamentos.Name = "lblTituloTotalOrcamentos";
            lblTituloTotalOrcamentos.Size = new Size(117, 15);
            lblTituloTotalOrcamentos.TabIndex = 0;
            lblTituloTotalOrcamentos.Text = "Total de Orçamentos";
            // 
            // pnlPendentes
            // 
            pnlPendentes.BackColor = Color.White;
            pnlPendentes.BorderStyle = BorderStyle.FixedSingle;
            pnlPendentes.Controls.Add(lblTituloPendentes);
            pnlPendentes.Controls.Add(lblPendentes);
            pnlPendentes.Location = new Point(260, 95);
            pnlPendentes.Name = "pnlPendentes";
            pnlPendentes.Size = new Size(220, 80);
            pnlPendentes.TabIndex = 47;
            // 
            // lblTituloPendentes
            // 
            lblTituloPendentes.AutoSize = true;
            lblTituloPendentes.Font = new Font("Segoe UI", 9F);
            lblTituloPendentes.ForeColor = Color.DimGray;
            lblTituloPendentes.Location = new Point(15, 12);
            lblTituloPendentes.Name = "lblTituloPendentes";
            lblTituloPendentes.Size = new Size(62, 15);
            lblTituloPendentes.TabIndex = 0;
            lblTituloPendentes.Text = "Pendentes";
            // 
            // pnlPagos
            // 
            pnlPagos.BackColor = Color.White;
            pnlPagos.BorderStyle = BorderStyle.FixedSingle;
            pnlPagos.Controls.Add(lblTituloPagos);
            pnlPagos.Controls.Add(lblPagos);
            pnlPagos.Location = new Point(500, 95);
            pnlPagos.Name = "pnlPagos";
            pnlPagos.Size = new Size(220, 80);
            pnlPagos.TabIndex = 48;
            // 
            // lblTituloPagos
            // 
            lblTituloPagos.AutoSize = true;
            lblTituloPagos.Font = new Font("Segoe UI", 9F);
            lblTituloPagos.ForeColor = Color.DimGray;
            lblTituloPagos.Location = new Point(15, 12);
            lblTituloPagos.Name = "lblTituloPagos";
            lblTituloPagos.Size = new Size(39, 15);
            lblTituloPagos.TabIndex = 0;
            lblTituloPagos.Text = "Pagos";
            // 
            // lblTituloCancelados
            // 
            lblTituloCancelados.AutoSize = true;
            lblTituloCancelados.Font = new Font("Segoe UI", 9F);
            lblTituloCancelados.ForeColor = Color.DimGray;
            lblTituloCancelados.Location = new Point(15, 12);
            lblTituloCancelados.Name = "lblTituloCancelados";
            lblTituloCancelados.Size = new Size(68, 15);
            lblTituloCancelados.TabIndex = 0;
            lblTituloCancelados.Text = "Cancelados";
            // 
            // pnlCancelados
            // 
            pnlCancelados.BackColor = Color.White;
            pnlCancelados.BorderStyle = BorderStyle.FixedSingle;
            pnlCancelados.Controls.Add(lblTituloCancelados);
            pnlCancelados.Controls.Add(lblCancelados);
            pnlCancelados.Location = new Point(740, 95);
            pnlCancelados.Name = "pnlCancelados";
            pnlCancelados.Size = new Size(220, 80);
            pnlCancelados.TabIndex = 49;
            // 
            // lblTituloValorTotal
            // 
            lblTituloValorTotal.AutoSize = true;
            lblTituloValorTotal.Font = new Font("Segoe UI", 9F);
            lblTituloValorTotal.ForeColor = Color.DimGray;
            lblTituloValorTotal.Location = new Point(15, 12);
            lblTituloValorTotal.Name = "lblTituloValorTotal";
            lblTituloValorTotal.Size = new Size(62, 15);
            lblTituloValorTotal.TabIndex = 0;
            lblTituloValorTotal.Text = "Valor Total";
            // 
            // pnlValorTotal
            // 
            pnlValorTotal.BackColor = Color.White;
            pnlValorTotal.BorderStyle = BorderStyle.FixedSingle;
            pnlValorTotal.Controls.Add(lblTituloValorTotal);
            pnlValorTotal.Controls.Add(lblValorTotal);
            pnlValorTotal.Location = new Point(20, 195);
            pnlValorTotal.Name = "pnlValorTotal";
            pnlValorTotal.Size = new Size(300, 80);
            pnlValorTotal.TabIndex = 50;
            // 
            // lblTituloValorPendente
            // 
            lblTituloValorPendente.AutoSize = true;
            lblTituloValorPendente.Font = new Font("Segoe UI", 9F);
            lblTituloValorPendente.ForeColor = Color.DimGray;
            lblTituloValorPendente.Location = new Point(15, 12);
            lblTituloValorPendente.Name = "lblTituloValorPendente";
            lblTituloValorPendente.Size = new Size(86, 15);
            lblTituloValorPendente.TabIndex = 0;
            lblTituloValorPendente.Text = "Valor Pendente";
            // 
            // pnlValorPendente
            // 
            pnlValorPendente.BackColor = Color.White;
            pnlValorPendente.BorderStyle = BorderStyle.FixedSingle;
            pnlValorPendente.Controls.Add(lblTituloValorPendente);
            pnlValorPendente.Controls.Add(lblValorPendente);
            pnlValorPendente.Location = new Point(340, 195);
            pnlValorPendente.Name = "pnlValorPendente";
            pnlValorPendente.Size = new Size(300, 80);
            pnlValorPendente.TabIndex = 51;
            // 
            // lblTituloValorPago
            // 
            lblTituloValorPago.AutoSize = true;
            lblTituloValorPago.Font = new Font("Segoe UI", 9F);
            lblTituloValorPago.ForeColor = Color.DimGray;
            lblTituloValorPago.Location = new Point(15, 12);
            lblTituloValorPago.Name = "lblTituloValorPago";
            lblTituloValorPago.Size = new Size(63, 15);
            lblTituloValorPago.TabIndex = 0;
            lblTituloValorPago.Text = "Valor Pago";
            // 
            // pnlValorPago
            // 
            pnlValorPago.BackColor = Color.White;
            pnlValorPago.BorderStyle = BorderStyle.FixedSingle;
            pnlValorPago.Controls.Add(lblValorPago);
            pnlValorPago.Controls.Add(lblTituloValorPago);
            pnlValorPago.Location = new Point(660, 195);
            pnlValorPago.Name = "pnlValorPago";
            pnlValorPago.Size = new Size(300, 80);
            pnlValorPago.TabIndex = 52;
            // 
            // pnlGrid
            // 
            pnlGrid.BackColor = Color.White;
            pnlGrid.BorderStyle = BorderStyle.FixedSingle;
            pnlGrid.Controls.Add(lblUltimosOrcamentos);
            pnlGrid.Controls.Add(dgvUltimosOrcamentos);
            pnlGrid.ForeColor = SystemColors.ControlLight;
            pnlGrid.Location = new Point(20, 300);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(940, 250);
            pnlGrid.TabIndex = 53;
            // 
            // lblUltimosOrcamentos
            // 
            lblUltimosOrcamentos.AutoSize = true;
            lblUltimosOrcamentos.Font = new Font("Segoe UI Semibold", 11F);
            lblUltimosOrcamentos.ForeColor = Color.DimGray;
            lblUltimosOrcamentos.Location = new Point(15, 12);
            lblUltimosOrcamentos.Name = "lblUltimosOrcamentos";
            lblUltimosOrcamentos.Size = new Size(147, 20);
            lblUltimosOrcamentos.TabIndex = 1;
            lblUltimosOrcamentos.Text = "Últimos Orçamentos";
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(984, 615);
            Controls.Add(pnlGrid);
            Controls.Add(pnlValorPago);
            Controls.Add(pnlValorPendente);
            Controls.Add(pnlValorTotal);
            Controls.Add(pnlCancelados);
            Controls.Add(pnlPagos);
            Controls.Add(pnlPendentes);
            Controls.Add(pnlTotalOrcamentos);
            Controls.Add(pnlTopo);
            Controls.Add(btnFechar);
            Controls.Add(btnAtualizar);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmDashboard";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUltimosOrcamentos).EndInit();
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlTotalOrcamentos.ResumeLayout(false);
            pnlTotalOrcamentos.PerformLayout();
            pnlPendentes.ResumeLayout(false);
            pnlPendentes.PerformLayout();
            pnlPagos.ResumeLayout(false);
            pnlPagos.PerformLayout();
            pnlCancelados.ResumeLayout(false);
            pnlCancelados.PerformLayout();
            pnlValorTotal.ResumeLayout(false);
            pnlValorTotal.PerformLayout();
            pnlValorPendente.ResumeLayout(false);
            pnlValorPendente.PerformLayout();
            pnlValorPago.ResumeLayout(false);
            pnlValorPago.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlGrid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FileSystemWatcher fileSystemWatcher1;
        private Button btnFechar;
        private Label lblValorTotal;
        private Label lblCancelados;
        private Label lblPagos;
        private Label lblPendentes;
        private Label lblTotalOrcamentos;
        private Button btnAtualizar;
        private DataGridView dgvUltimosOrcamentos;
        private Label lblValorPendente;
        private Label lblValorPago;
        private Panel pnlTotalOrcamentos;
        private Panel pnlTopo;
        private Label lblSubtituloTela;
        private Label lblTituloTela;
        private Panel pnlPagos;
        private Label lblTituloPagos;
        private Panel pnlPendentes;
        private Label lblTituloPendentes;
        private Label lblTituloTotalOrcamentos;
        private Panel pnlValorTotal;
        private Label lblTituloValorTotal;
        private Panel pnlCancelados;
        private Label lblTituloCancelados;
        private Panel pnlGrid;
        private Label lblUltimosOrcamentos;
        private Panel pnlValorPago;
        private Label lblTituloValorPago;
        private Panel pnlValorPendente;
        private Label lblTituloValorPendente;
    }
}