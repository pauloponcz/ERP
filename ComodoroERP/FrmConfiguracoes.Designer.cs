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
            btnSelecionarModeloNotas = new Button();
            txtModeloNotas = new TextBox();
            label2 = new Label();
            btnSelecionarPastaBackups = new Button();
            btnSelecionarPastaPdfs = new Button();
            txtPastaPdfs = new TextBox();
            label1 = new Label();
            txtPastaBackups = new TextBox();
            label3 = new Label();
            btnSalvar = new Button();
            btnCancelar = new Button();
            pnlTopo = new Panel();
            lblSubtituloTela = new Label();
            lblTituloTela = new Label();
            pnlCaminhos = new Panel();
            lblCaminhosSistema = new Label();
            pnlTopo.SuspendLayout();
            pnlCaminhos.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelecionarModeloNotas
            // 
            btnSelecionarModeloNotas.Location = new Point(570, 186);
            btnSelecionarModeloNotas.Name = "btnSelecionarModeloNotas";
            btnSelecionarModeloNotas.Size = new Size(70, 28);
            btnSelecionarModeloNotas.TabIndex = 22;
            btnSelecionarModeloNotas.Text = "...";
            btnSelecionarModeloNotas.UseVisualStyleBackColor = true;
            btnSelecionarModeloNotas.Click += btnSelecionarModeloNotas_Click;
            // 
            // txtModeloNotas
            // 
            txtModeloNotas.Location = new Point(20, 187);
            txtModeloNotas.Name = "txtModeloNotas";
            txtModeloNotas.Size = new Size(535, 25);
            txtModeloNotas.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 165);
            label2.Name = "label2";
            label2.Size = new Size(151, 19);
            label2.TabIndex = 20;
            label2.Text = "Modelo de Notas Excel:";
            // 
            // btnSelecionarPastaBackups
            // 
            btnSelecionarPastaBackups.Location = new Point(570, 126);
            btnSelecionarPastaBackups.Name = "btnSelecionarPastaBackups";
            btnSelecionarPastaBackups.Size = new Size(70, 28);
            btnSelecionarPastaBackups.TabIndex = 19;
            btnSelecionarPastaBackups.Text = "...";
            btnSelecionarPastaBackups.UseVisualStyleBackColor = true;
            btnSelecionarPastaBackups.Click += btnSelecionarPastaBackups_Click;
            // 
            // btnSelecionarPastaPdfs
            // 
            btnSelecionarPastaPdfs.Location = new Point(570, 66);
            btnSelecionarPastaPdfs.Name = "btnSelecionarPastaPdfs";
            btnSelecionarPastaPdfs.Size = new Size(70, 28);
            btnSelecionarPastaPdfs.TabIndex = 18;
            btnSelecionarPastaPdfs.Text = "...";
            btnSelecionarPastaPdfs.UseVisualStyleBackColor = true;
            btnSelecionarPastaPdfs.Click += btnSelecionarPastaPdfs_Click;
            // 
            // txtPastaPdfs
            // 
            txtPastaPdfs.Location = new Point(20, 67);
            txtPastaPdfs.Name = "txtPastaPdfs";
            txtPastaPdfs.Size = new Size(535, 25);
            txtPastaPdfs.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 45);
            label1.Name = "label1";
            label1.Size = new Size(106, 19);
            label1.TabIndex = 16;
            label1.Text = "Pasta dos PDFs:";
            // 
            // txtPastaBackups
            // 
            txtPastaBackups.Location = new Point(20, 127);
            txtPastaBackups.Name = "txtPastaBackups";
            txtPastaBackups.Size = new Size(535, 25);
            txtPastaBackups.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 105);
            label3.Name = "label3";
            label3.Size = new Size(125, 19);
            label3.TabIndex = 14;
            label3.Text = "Pasta dos Backups:";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(465, 345);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 35);
            btnSalvar.TabIndex = 18;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(580, 345);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 35);
            btnCancelar.TabIndex = 19;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlTopo
            // 
            pnlTopo.BackColor = Color.SteelBlue;
            pnlTopo.Controls.Add(lblTituloTela);
            pnlTopo.Controls.Add(lblSubtituloTela);
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(720, 75);
            pnlTopo.TabIndex = 20;
            // 
            // lblSubtituloTela
            // 
            lblSubtituloTela.AutoSize = true;
            lblSubtituloTela.Font = new Font("Segoe UI", 9F);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Location = new Point(27, 43);
            lblSubtituloTela.Name = "lblSubtituloTela";
            lblSubtituloTela.Size = new Size(220, 15);
            lblSubtituloTela.TabIndex = 0;
            lblSubtituloTela.Text = "Defina os caminhos usados pelo sistema";
            // 
            // lblTituloTela
            // 
            lblTituloTela.AutoSize = true;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15F);
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Location = new Point(25, 14);
            lblTituloTela.Name = "lblTituloTela";
            lblTituloTela.Size = new Size(171, 28);
            lblTituloTela.TabIndex = 1;
            lblTituloTela.Text = "CONFIGURAÇÕES";
            // 
            // pnlCaminhos
            // 
            pnlCaminhos.BackColor = Color.White;
            pnlCaminhos.BorderStyle = BorderStyle.FixedSingle;
            pnlCaminhos.Controls.Add(btnSelecionarModeloNotas);
            pnlCaminhos.Controls.Add(lblCaminhosSistema);
            pnlCaminhos.Controls.Add(txtModeloNotas);
            pnlCaminhos.Controls.Add(label1);
            pnlCaminhos.Controls.Add(label2);
            pnlCaminhos.Controls.Add(txtPastaPdfs);
            pnlCaminhos.Controls.Add(btnSelecionarPastaBackups);
            pnlCaminhos.Controls.Add(label3);
            pnlCaminhos.Controls.Add(btnSelecionarPastaPdfs);
            pnlCaminhos.Controls.Add(txtPastaBackups);
            pnlCaminhos.Location = new Point(20, 95);
            pnlCaminhos.Name = "pnlCaminhos";
            pnlCaminhos.Size = new Size(665, 230);
            pnlCaminhos.TabIndex = 21;
            // 
            // lblCaminhosSistema
            // 
            lblCaminhosSistema.AutoSize = true;
            lblCaminhosSistema.Font = new Font("Segoe UI Semibold", 11F);
            lblCaminhosSistema.ForeColor = Color.DimGray;
            lblCaminhosSistema.Location = new Point(15, 12);
            lblCaminhosSistema.Name = "lblCaminhosSistema";
            lblCaminhosSistema.Size = new Size(154, 20);
            lblCaminhosSistema.TabIndex = 18;
            lblCaminhosSistema.Text = "Caminhos do Sistema";
            // 
            // FrmConfiguracoes
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 391);
            Controls.Add(pnlCaminhos);
            Controls.Add(pnlTopo);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI", 10F);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmConfiguracoes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configurações";
            Load += FrmConfiguracoes_Load;
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlCaminhos.ResumeLayout(false);
            pnlCaminhos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtPastaBackups;
        private Label label3;
        private TextBox txtPastaPdfs;
        private Label label1;
        private Button btnSelecionarPastaBackups;
        private Button btnSelecionarPastaPdfs;
        private Button btnSalvar;
        private Button btnCancelar;
        private Button btnSelecionarModeloNotas;
        private TextBox txtModeloNotas;
        private Label label2;
        private Panel pnlTopo;
        private Label lblTituloTela;
        private Label lblSubtituloTela;
        private Panel pnlCaminhos;
        private Label lblCaminhosSistema;
    }
}