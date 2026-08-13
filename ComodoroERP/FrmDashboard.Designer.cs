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
            groupBox1 = new GroupBox();
            lblValorPago = new Label();
            lblValorPendente = new Label();
            groupBox2 = new GroupBox();
            dgvUltimosOrcamentos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUltimosOrcamentos).BeginInit();
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
            lblTotalOrcamentos.Location = new Point(28, 41);
            lblTotalOrcamentos.Name = "lblTotalOrcamentos";
            lblTotalOrcamentos.Size = new Size(135, 15);
            lblTotalOrcamentos.TabIndex = 1;
            lblTotalOrcamentos.Text = "Total de Orçamentos: 12";
            // 
            // lblPendentes
            // 
            lblPendentes.AutoSize = true;
            lblPendentes.Location = new Point(188, 41);
            lblPendentes.Name = "lblPendentes";
            lblPendentes.Size = new Size(74, 15);
            lblPendentes.TabIndex = 2;
            lblPendentes.Text = "Pendentes: 5";
            // 
            // lblPagos
            // 
            lblPagos.AutoSize = true;
            lblPagos.Location = new Point(290, 41);
            lblPagos.Name = "lblPagos";
            lblPagos.Size = new Size(51, 15);
            lblPagos.TabIndex = 3;
            lblPagos.Text = "Pagos: 6";
            // 
            // lblCancelados
            // 
            lblCancelados.AutoSize = true;
            lblCancelados.Location = new Point(376, 41);
            lblCancelados.Name = "lblCancelados";
            lblCancelados.Size = new Size(80, 15);
            lblCancelados.TabIndex = 4;
            lblCancelados.Text = "Cancelados: 1";
            lblCancelados.Click += label4_Click;
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Location = new Point(28, 85);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(126, 15);
            lblValorTotal.TabIndex = 5;
            lblValorTotal.Text = "Valor Total: R$ 8.500,00";
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(12, 415);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(99, 23);
            btnAtualizar.TabIndex = 41;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(529, 415);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(99, 23);
            btnFechar.TabIndex = 42;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblValorPendente);
            groupBox1.Controls.Add(lblValorPago);
            groupBox1.Controls.Add(lblValorTotal);
            groupBox1.Controls.Add(lblCancelados);
            groupBox1.Controls.Add(lblPagos);
            groupBox1.Controls.Add(lblPendentes);
            groupBox1.Controls.Add(lblTotalOrcamentos);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(616, 130);
            groupBox1.TabIndex = 43;
            groupBox1.TabStop = false;
            groupBox1.Text = "DASHBOARD";
            // 
            // lblValorPago
            // 
            lblValorPago.AutoSize = true;
            lblValorPago.Location = new Point(347, 85);
            lblValorPago.Name = "lblValorPago";
            lblValorPago.Size = new Size(127, 15);
            lblValorPago.TabIndex = 6;
            lblValorPago.Text = "Valor Pago: R$ 5.500,00";
            // 
            // lblValorPendente
            // 
            lblValorPendente.AutoSize = true;
            lblValorPendente.Location = new Point(173, 85);
            lblValorPendente.Name = "lblValorPendente";
            lblValorPendente.Size = new Size(150, 15);
            lblValorPendente.TabIndex = 7;
            lblValorPendente.Text = "Valor Pendente: R$ 3.000,00";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvUltimosOrcamentos);
            groupBox2.Location = new Point(12, 148);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(616, 261);
            groupBox2.TabIndex = 44;
            groupBox2.TabStop = false;
            groupBox2.Text = "ÚLTIMOS ORÇAMENTOS";
            // 
            // dgvUltimosOrcamentos
            // 
            dgvUltimosOrcamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUltimosOrcamentos.Location = new Point(6, 22);
            dgvUltimosOrcamentos.Name = "dgvUltimosOrcamentos";
            dgvUltimosOrcamentos.Size = new Size(604, 233);
            dgvUltimosOrcamentos.TabIndex = 0;
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 450);
            Controls.Add(groupBox2);
            Controls.Add(btnFechar);
            Controls.Add(groupBox1);
            Controls.Add(btnAtualizar);
            Name = "FrmDashboard";
            Text = "FrmDashboard";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUltimosOrcamentos).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private FileSystemWatcher fileSystemWatcher1;
        private Button btnFechar;
        private GroupBox groupBox1;
        private Label lblValorTotal;
        private Label lblCancelados;
        private Label lblPagos;
        private Label lblPendentes;
        private Label lblTotalOrcamentos;
        private Button btnAtualizar;
        private GroupBox groupBox2;
        private DataGridView dgvUltimosOrcamentos;
        private Label lblValorPendente;
        private Label lblValorPago;
    }
}