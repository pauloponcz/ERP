namespace ComodoroERP
{
    partial class FrmConfiguracoes
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
            groupBox1 = new GroupBox();
            btnSelecionarPastaBackups = new Button();
            btnSelecionarPastaPdfs = new Button();
            txtPastaPdfs = new TextBox();
            label1 = new Label();
            txtPastaBackups = new TextBox();
            label3 = new Label();
            btnSalvar = new Button();
            btnCancelar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSelecionarPastaBackups);
            groupBox1.Controls.Add(btnSelecionarPastaPdfs);
            groupBox1.Controls.Add(txtPastaPdfs);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtPastaBackups);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(449, 146);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "CONFIGURAÇÕES";
            // 
            // btnSelecionarPastaBackups
            // 
            btnSelecionarPastaBackups.Location = new Point(398, 101);
            btnSelecionarPastaBackups.Name = "btnSelecionarPastaBackups";
            btnSelecionarPastaBackups.Size = new Size(45, 23);
            btnSelecionarPastaBackups.TabIndex = 19;
            btnSelecionarPastaBackups.Text = "...";
            btnSelecionarPastaBackups.UseVisualStyleBackColor = true;
            btnSelecionarPastaBackups.Click += btnSelecionarPastaBackups_Click;
            // 
            // btnSelecionarPastaPdfs
            // 
            btnSelecionarPastaPdfs.Location = new Point(398, 48);
            btnSelecionarPastaPdfs.Name = "btnSelecionarPastaPdfs";
            btnSelecionarPastaPdfs.Size = new Size(45, 23);
            btnSelecionarPastaPdfs.TabIndex = 18;
            btnSelecionarPastaPdfs.Text = "...";
            btnSelecionarPastaPdfs.UseVisualStyleBackColor = true;
            btnSelecionarPastaPdfs.Click += btnSelecionarPastaPdfs_Click;
            // 
            // txtPastaPdfs
            // 
            txtPastaPdfs.Location = new Point(22, 49);
            txtPastaPdfs.Name = "txtPastaPdfs";
            txtPastaPdfs.Size = new Size(370, 23);
            txtPastaPdfs.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 28);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 16;
            label1.Text = "Pasta dos PDFs:";
            // 
            // txtPastaBackups
            // 
            txtPastaBackups.Location = new Point(22, 101);
            txtPastaBackups.Name = "txtPastaBackups";
            txtPastaBackups.Size = new Size(370, 23);
            txtPastaBackups.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 80);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 14;
            label3.Text = "Pasta dos Backups:";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(274, 164);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(88, 23);
            btnSalvar.TabIndex = 18;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(374, 164);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(88, 23);
            btnCancelar.TabIndex = 19;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmConfiguracoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 206);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(groupBox1);
            Name = "FrmConfiguracoes";
            Text = "FrmConfiguracoes";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtPastaBackups;
        private Label label3;
        private TextBox txtPastaPdfs;
        private Label label1;
        private Button btnSelecionarPastaBackups;
        private Button btnSelecionarPastaPdfs;
        private Button btnSalvar;
        private Button btnCancelar;
    }
}