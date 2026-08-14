namespace ComodoroERP
{
    partial class FrmEditarOrcamento
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
            txtObservacao = new TextBox();
            lblObservacao = new Label();
            numVariacaoNota3 = new NumericUpDown();
            lblVariacaoNota3 = new Label();
            numVariacaoNota2 = new NumericUpDown();
            lblVariacaoNota2 = new Label();
            cmbStatus = new ComboBox();
            lblStatus = new Label();
            txtTitulo = new TextBox();
            lblTitulo = new Label();
            btnSalvar = new Button();
            btnCancelar = new Button();
            pnlTopo = new Panel();
            lblSubtituloTela = new Label();
            lblTituloTela = new Label();
            pnlOrcamento = new Panel();
            lblDadosOrcamento = new Label();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota2).BeginInit();
            pnlTopo.SuspendLayout();
            pnlOrcamento.SuspendLayout();
            SuspendLayout();
            // 
            // txtObservacao
            // 
            txtObservacao.Location = new Point(20, 247);
            txtObservacao.Multiline = true;
            txtObservacao.Name = "txtObservacao";
            txtObservacao.Size = new Size(460, 50);
            txtObservacao.TabIndex = 9;
            // 
            // lblObservacao
            // 
            lblObservacao.AutoSize = true;
            lblObservacao.Location = new Point(20, 225);
            lblObservacao.Name = "lblObservacao";
            lblObservacao.Size = new Size(84, 19);
            lblObservacao.TabIndex = 8;
            lblObservacao.Text = "Observação:";
            // 
            // numVariacaoNota3
            // 
            numVariacaoNota3.Location = new Point(175, 187);
            numVariacaoNota3.Name = "numVariacaoNota3";
            numVariacaoNota3.Size = new Size(130, 25);
            numVariacaoNota3.TabIndex = 7;
            // 
            // lblVariacaoNota3
            // 
            lblVariacaoNota3.AutoSize = true;
            lblVariacaoNota3.Location = new Point(175, 165);
            lblVariacaoNota3.Name = "lblVariacaoNota3";
            lblVariacaoNota3.Size = new Size(132, 19);
            lblVariacaoNota3.TabIndex = 6;
            lblVariacaoNota3.Text = "Variação Nota 3 (%):";
            // 
            // numVariacaoNota2
            // 
            numVariacaoNota2.Location = new Point(20, 187);
            numVariacaoNota2.Name = "numVariacaoNota2";
            numVariacaoNota2.Size = new Size(130, 25);
            numVariacaoNota2.TabIndex = 5;
            // 
            // lblVariacaoNota2
            // 
            lblVariacaoNota2.AutoSize = true;
            lblVariacaoNota2.Location = new Point(20, 165);
            lblVariacaoNota2.Name = "lblVariacaoNota2";
            lblVariacaoNota2.Size = new Size(132, 19);
            lblVariacaoNota2.TabIndex = 4;
            lblVariacaoNota2.Text = "Variação Nota 2 (%):";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(20, 127);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(460, 25);
            cmbStatus.TabIndex = 3;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(20, 105);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 19);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(20, 67);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(460, 25);
            txtTitulo.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(20, 45);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(46, 19);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Título:";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(305, 425);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 35);
            btnSalvar.TabIndex = 10;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(420, 425);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 35);
            btnCancelar.TabIndex = 11;
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
            pnlTopo.Size = new Size(560, 75);
            pnlTopo.TabIndex = 12;
            // 
            // lblSubtituloTela
            // 
            lblSubtituloTela.AutoSize = true;
            lblSubtituloTela.Font = new Font("Segoe UI", 9F);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Location = new Point(27, 43);
            lblSubtituloTela.Name = "lblSubtituloTela";
            lblSubtituloTela.Size = new Size(220, 15);
            lblSubtituloTela.TabIndex = 1;
            lblSubtituloTela.Text = "Altere os dados principais do orçamento";
            // 
            // lblTituloTela
            // 
            lblTituloTela.AutoSize = true;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15F);
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Location = new Point(25, 14);
            lblTituloTela.Name = "lblTituloTela";
            lblTituloTela.Size = new Size(203, 28);
            lblTituloTela.TabIndex = 0;
            lblTituloTela.Text = "EDITAR ORÇAMENTO";
            // 
            // pnlOrcamento
            // 
            pnlOrcamento.BackColor = Color.White;
            pnlOrcamento.BorderStyle = BorderStyle.FixedSingle;
            pnlOrcamento.Controls.Add(txtObservacao);
            pnlOrcamento.Controls.Add(lblDadosOrcamento);
            pnlOrcamento.Controls.Add(lblObservacao);
            pnlOrcamento.Controls.Add(lblTitulo);
            pnlOrcamento.Controls.Add(numVariacaoNota3);
            pnlOrcamento.Controls.Add(txtTitulo);
            pnlOrcamento.Controls.Add(lblVariacaoNota3);
            pnlOrcamento.Controls.Add(lblStatus);
            pnlOrcamento.Controls.Add(numVariacaoNota2);
            pnlOrcamento.Controls.Add(cmbStatus);
            pnlOrcamento.Controls.Add(lblVariacaoNota2);
            pnlOrcamento.Location = new Point(20, 95);
            pnlOrcamento.Name = "pnlOrcamento";
            pnlOrcamento.Size = new Size(505, 315);
            pnlOrcamento.TabIndex = 13;
            // 
            // lblDadosOrcamento
            // 
            lblDadosOrcamento.AutoSize = true;
            lblDadosOrcamento.Font = new Font("Segoe UI Semibold", 11F);
            lblDadosOrcamento.ForeColor = Color.DimGray;
            lblDadosOrcamento.Location = new Point(15, 12);
            lblDadosOrcamento.Name = "lblDadosOrcamento";
            lblDadosOrcamento.Size = new Size(154, 20);
            lblDadosOrcamento.TabIndex = 0;
            lblDadosOrcamento.Text = "Dados do Orçamento";
            // 
            // FrmEditarOrcamento
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(544, 473);
            Controls.Add(pnlOrcamento);
            Controls.Add(pnlTopo);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmEditarOrcamento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Orçamento";
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota2).EndInit();
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlOrcamento.ResumeLayout(false);
            pnlOrcamento.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private NumericUpDown numVariacaoNota2;
        private Label lblVariacaoNota2;
        private ComboBox cmbStatus;
        private Label lblStatus;
        private TextBox txtTitulo;
        private Label lblTitulo;
        private NumericUpDown numVariacaoNota3;
        private Label lblVariacaoNota3;
        private TextBox txtObservacao;
        private Label lblObservacao;
        private Button btnSalvar;
        private Button btnCancelar;
        private Panel pnlTopo;
        private Label lblSubtituloTela;
        private Label lblTituloTela;
        private Panel pnlOrcamento;
        private Label lblDadosOrcamento;
    }
}