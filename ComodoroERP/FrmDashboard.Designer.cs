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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            fileSystemWatcher1 = new FileSystemWatcher();
            label6 = new Label();
            lblQtdOrcamentos = new Label();
            lblTotalGeral = new Label();
            lblTotalConcluido = new Label();
            lblTotalPago = new Label();
            lblTotalPendente = new Label();
            btnFechar = new Button();
            btnAtualizar = new Button();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 34);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 0;
            label1.Text = "DASHBOARD";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 76);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 1;
            label2.Text = "Total Pendente:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 100);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 2;
            label3.Text = "Total Pago: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 154);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 4;
            label4.Text = "Total Geral:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(49, 126);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 3;
            label5.Text = "Total Concluído:";
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(49, 181);
            label6.Name = "label6";
            label6.Size = new Size(75, 15);
            label6.TabIndex = 5;
            label6.Text = "Orçamentos:";
            // 
            // lblQtdOrcamentos
            // 
            lblQtdOrcamentos.AutoSize = true;
            lblQtdOrcamentos.Location = new Point(149, 181);
            lblQtdOrcamentos.Name = "lblQtdOrcamentos";
            lblQtdOrcamentos.Size = new Size(13, 15);
            lblQtdOrcamentos.TabIndex = 10;
            lblQtdOrcamentos.Text = "0";
            // 
            // lblTotalGeral
            // 
            lblTotalGeral.AutoSize = true;
            lblTotalGeral.Location = new Point(149, 154);
            lblTotalGeral.Name = "lblTotalGeral";
            lblTotalGeral.Size = new Size(44, 15);
            lblTotalGeral.TabIndex = 9;
            lblTotalGeral.Text = "R$ 0,00";
            // 
            // lblTotalConcluido
            // 
            lblTotalConcluido.AutoSize = true;
            lblTotalConcluido.Location = new Point(149, 126);
            lblTotalConcluido.Name = "lblTotalConcluido";
            lblTotalConcluido.Size = new Size(44, 15);
            lblTotalConcluido.TabIndex = 8;
            lblTotalConcluido.Text = "R$ 0,00";
            // 
            // lblTotalPago
            // 
            lblTotalPago.AutoSize = true;
            lblTotalPago.Location = new Point(149, 100);
            lblTotalPago.Name = "lblTotalPago";
            lblTotalPago.Size = new Size(44, 15);
            lblTotalPago.TabIndex = 7;
            lblTotalPago.Text = "R$ 0,00";
            // 
            // lblTotalPendente
            // 
            lblTotalPendente.AutoSize = true;
            lblTotalPendente.Location = new Point(149, 76);
            lblTotalPendente.Name = "lblTotalPendente";
            lblTotalPendente.Size = new Size(44, 15);
            lblTotalPendente.TabIndex = 6;
            lblTotalPendente.Text = "R$ 0,00";
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(154, 230);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(99, 23);
            btnFechar.TabIndex = 42;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(49, 230);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(99, 23);
            btnAtualizar.TabIndex = 41;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnFechar);
            Controls.Add(btnAtualizar);
            Controls.Add(lblQtdOrcamentos);
            Controls.Add(lblTotalGeral);
            Controls.Add(lblTotalConcluido);
            Controls.Add(lblTotalPago);
            Controls.Add(lblTotalPendente);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmDashboard";
            Text = "FrmDashboard";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private FileSystemWatcher fileSystemWatcher1;
        private Label label6;
        private Label lblQtdOrcamentos;
        private Label lblTotalGeral;
        private Label lblTotalConcluido;
        private Label lblTotalPago;
        private Label lblTotalPendente;
        private Button btnFechar;
        private Button btnAtualizar;
    }
}