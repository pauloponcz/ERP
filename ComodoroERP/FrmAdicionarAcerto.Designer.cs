namespace ComodoroERP
{
    partial class FrmAdicionarAcerto
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
            pnlTopo = new Panel();
            lblSubtituloTela = new Label();
            lblTituloTela = new Label();
            pnlAcerto = new Panel();
            cmbNomeEscola = new ComboBox();
            cmbStatusPagamento = new ComboBox();
            lblStatusPagamento = new Label();
            numValor = new NumericUpDown();
            lblValor = new Label();
            txtServico = new TextBox();
            lblServico = new Label();
            lblNomeEscola = new Label();
            lblDadosAcerto = new Label();
            btnSalvar = new Button();
            btnCancelar = new Button();
            pnlTopo.SuspendLayout();
            pnlAcerto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numValor).BeginInit();
            SuspendLayout();
            // 
            // pnlTopo
            // 
            pnlTopo.BackColor = Color.SteelBlue;
            pnlTopo.Controls.Add(lblSubtituloTela);
            pnlTopo.Controls.Add(lblTituloTela);
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(620, 75);
            pnlTopo.TabIndex = 0;
            // 
            // lblSubtituloTela
            // 
            lblSubtituloTela.AutoSize = true;
            lblSubtituloTela.Font = new Font("Segoe UI", 9F);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Location = new Point(27, 43);
            lblSubtituloTela.Name = "lblSubtituloTela";
            lblSubtituloTela.Size = new Size(284, 15);
            lblSubtituloTela.TabIndex = 1;
            lblSubtituloTela.Text = "Cadastre serviços avulsos separados dos orçamentos";
            // 
            // lblTituloTela
            // 
            lblTituloTela.AutoSize = true;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15F);
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Location = new Point(25, 14);
            lblTituloTela.Name = "lblTituloTela";
            lblTituloTela.Size = new Size(196, 28);
            lblTituloTela.TabIndex = 0;
            lblTituloTela.Text = "ADICIONAR ACERTO";
            // 
            // pnlAcerto
            // 
            pnlAcerto.BackColor = Color.White;
            pnlAcerto.BorderStyle = BorderStyle.FixedSingle;
            pnlAcerto.Controls.Add(cmbNomeEscola);
            pnlAcerto.Controls.Add(cmbStatusPagamento);
            pnlAcerto.Controls.Add(lblStatusPagamento);
            pnlAcerto.Controls.Add(numValor);
            pnlAcerto.Controls.Add(lblValor);
            pnlAcerto.Controls.Add(txtServico);
            pnlAcerto.Controls.Add(lblServico);
            pnlAcerto.Controls.Add(lblNomeEscola);
            pnlAcerto.Controls.Add(lblDadosAcerto);
            pnlAcerto.Location = new Point(20, 95);
            pnlAcerto.Name = "pnlAcerto";
            pnlAcerto.Size = new Size(565, 255);
            pnlAcerto.TabIndex = 1;
            // 
            // cmbNomeEscola
            // 
            cmbNomeEscola.FormattingEnabled = true;
            cmbNomeEscola.Location = new Point(20, 35);
            cmbNomeEscola.Name = "cmbNomeEscola";
            cmbNomeEscola.Size = new Size(515, 25);
            cmbNomeEscola.TabIndex = 0;
            // 
            // cmbStatusPagamento
            // 
            cmbStatusPagamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusPagamento.FormattingEnabled = true;
            cmbStatusPagamento.Location = new Point(20, 205);
            cmbStatusPagamento.Name = "cmbStatusPagamento";
            cmbStatusPagamento.Size = new Size(200, 25);
            cmbStatusPagamento.TabIndex = 3;
            // 
            // lblStatusPagamento
            // 
            lblStatusPagamento.AutoSize = true;
            lblStatusPagamento.Location = new Point(20, 182);
            lblStatusPagamento.Name = "lblStatusPagamento";
            lblStatusPagamento.Size = new Size(144, 19);
            lblStatusPagamento.TabIndex = 7;
            lblStatusPagamento.Text = "Status do Pagamento:";
            // 
            // numValor
            // 
            numValor.DecimalPlaces = 2;
            numValor.Location = new Point(20, 145);
            numValor.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numValor.Name = "numValor";
            numValor.Size = new Size(200, 25);
            numValor.TabIndex = 2;
            numValor.ThousandsSeparator = true;
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(20, 122);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(110, 19);
            lblValor.TabIndex = 5;
            lblValor.Text = "Valor do Serviço:";
            // 
            // txtServico
            // 
            txtServico.Location = new Point(20, 85);
            txtServico.Name = "txtServico";
            txtServico.Size = new Size(515, 25);
            txtServico.TabIndex = 1;
            // 
            // lblServico
            // 
            lblServico.AutoSize = true;
            lblServico.Location = new Point(20, 62);
            lblServico.Name = "lblServico";
            lblServico.Size = new Size(116, 19);
            lblServico.TabIndex = 3;
            lblServico.Text = "Serviço Realizado:";
            // 
            // lblNomeEscola
            // 
            lblNomeEscola.AutoSize = true;
            lblNomeEscola.Location = new Point(20, 12);
            lblNomeEscola.Name = "lblNomeEscola";
            lblNomeEscola.Size = new Size(109, 19);
            lblNomeEscola.TabIndex = 1;
            lblNomeEscola.Text = "Nome da Escola:";
            // 
            // lblDadosAcerto
            // 
            lblDadosAcerto.AutoSize = true;
            lblDadosAcerto.Location = new Point(15, -100);
            lblDadosAcerto.Name = "lblDadosAcerto";
            lblDadosAcerto.Size = new Size(112, 19);
            lblDadosAcerto.TabIndex = 0;
            lblDadosAcerto.Text = "Dados do Acerto";
            lblDadosAcerto.Visible = false;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.White;
            btnSalvar.Cursor = Cursors.Hand;
            btnSalvar.FlatAppearance.BorderColor = Color.Gainsboro;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Segoe UI Semibold", 10F);
            btnSalvar.ForeColor = Color.FromArgb(45, 45, 45);
            btnSalvar.Location = new Point(365, 370);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 35);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderColor = Color.Silver;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 10F);
            btnCancelar.ForeColor = Color.DimGray;
            btnCancelar.Location = new Point(480, 370);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 35);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmAdicionarAcerto
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(604, 421);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(pnlAcerto);
            Controls.Add(pnlTopo);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAdicionarAcerto";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adicionar Acerto";
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlAcerto.ResumeLayout(false);
            pnlAcerto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numValor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTopo;
        private Label lblSubtituloTela;
        private Label lblTituloTela;
        private Panel pnlAcerto;
        private Label lblDadosAcerto;
        private Label lblNomeEscola;
        private Label lblServico;
        private TextBox txtServico;
        private Label lblValor;
        private NumericUpDown numValor;
        private Label lblStatusPagamento;
        private ComboBox cmbStatusPagamento;
        private Button btnSalvar;
        private Button btnCancelar;
        private ComboBox cmbNomeEscola;
    }
}
