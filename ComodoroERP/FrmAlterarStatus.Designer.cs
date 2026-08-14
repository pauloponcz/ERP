namespace ComodoroERP
{
    partial class FrmAlterarStatus
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
            lblStatusTitulo = new Label();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            pnlTopo = new Panel();
            lblTituloTela = new Label();
            lblSubtituloTela = new Label();
            pnlStatus = new Panel();
            pnlTopo.SuspendLayout();
            pnlStatus.SuspendLayout();
            SuspendLayout();
            // 
            // lblStatusTitulo
            // 
            lblStatusTitulo.AutoSize = true;
            lblStatusTitulo.Font = new Font("Segoe UI Semibold", 11F);
            lblStatusTitulo.ForeColor = Color.DimGray;
            lblStatusTitulo.Location = new Point(15, 12);
            lblStatusTitulo.Name = "lblStatusTitulo";
            lblStatusTitulo.Size = new Size(152, 20);
            lblStatusTitulo.TabIndex = 0;
            lblStatusTitulo.Text = "Status do Orçamento";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(20, 45);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(169, 19);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Status atual / novo status:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(20, 67);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(380, 25);
            cmbStatus.TabIndex = 2;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(225, 220);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 35);
            btnSalvar.TabIndex = 3;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(340, 220);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 35);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlTopo
            // 
            pnlTopo.BackColor = Color.SteelBlue;
            pnlTopo.Controls.Add(lblSubtituloTela);
            pnlTopo.Controls.Add(lblTituloTela);
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(480, 85);
            pnlTopo.TabIndex = 5;
            // 
            // lblTituloTela
            // 
            lblTituloTela.AutoSize = true;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15F);
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Location = new Point(25, 14);
            lblTituloTela.Name = "lblTituloTela";
            lblTituloTela.Size = new Size(167, 28);
            lblTituloTela.TabIndex = 0;
            lblTituloTela.Text = "ALTERAR STATUS";
            // 
            // lblSubtituloTela
            // 
            lblSubtituloTela.AutoSize = true;
            lblSubtituloTela.Font = new Font("Segoe UI", 9F);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Location = new Point(27, 43);
            lblSubtituloTela.Name = "lblSubtituloTela";
            lblSubtituloTela.Size = new Size(237, 15);
            lblSubtituloTela.TabIndex = 1;
            lblSubtituloTela.Text = "Atualize o status do orçamento selecionado";
            // 
            // pnlStatus
            // 
            pnlStatus.BackColor = Color.White;
            pnlStatus.BorderStyle = BorderStyle.FixedSingle;
            pnlStatus.Controls.Add(lblStatusTitulo);
            pnlStatus.Controls.Add(lblStatus);
            pnlStatus.Controls.Add(cmbStatus);
            pnlStatus.Location = new Point(20, 95);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(425, 105);
            pnlStatus.TabIndex = 6;
            // 
            // FrmAlterarStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(464, 261);
            Controls.Add(pnlStatus);
            Controls.Add(pnlTopo);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(27, 43);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAlterarStatus";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alterar Status";
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlStatus.ResumeLayout(false);
            pnlStatus.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblStatusTitulo;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnSalvar;
        private Button btnCancelar;
        private Panel pnlTopo;
        private Label lblSubtituloTela;
        private Label lblTituloTela;
        private Panel pnlStatus;
    }
}