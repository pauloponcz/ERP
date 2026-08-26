namespace ComodoroERP
{
    partial class FrmEditarAcerto
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            pnlTopo = new Panel(); lblSubtituloTela = new Label(); lblTituloTela = new Label(); pnlAcerto = new Panel(); cmbStatusPagamento = new ComboBox(); lblStatusPagamento = new Label(); numValor = new NumericUpDown(); lblValor = new Label(); txtServico = new TextBox(); lblServico = new Label(); txtNomeEscola = new TextBox(); lblNomeEscola = new Label(); btnSalvar = new Button(); btnCancelar = new Button(); pnlTopo.SuspendLayout(); pnlAcerto.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)numValor).BeginInit(); SuspendLayout();
            pnlTopo.BackColor = Color.SteelBlue; pnlTopo.Controls.Add(lblSubtituloTela); pnlTopo.Controls.Add(lblTituloTela); pnlTopo.Location = new Point(0, 0); pnlTopo.Name = "pnlTopo"; pnlTopo.Size = new Size(620, 75);
            lblSubtituloTela.AutoSize = true; lblSubtituloTela.Font = new Font("Segoe UI", 9F); lblSubtituloTela.ForeColor = Color.WhiteSmoke; lblSubtituloTela.Location = new Point(27, 43); lblSubtituloTela.Name = "lblSubtituloTela"; lblSubtituloTela.Text = "Altere os dados do acerto selecionado";
            lblTituloTela.AutoSize = true; lblTituloTela.Font = new Font("Segoe UI Semibold", 15F); lblTituloTela.ForeColor = Color.White; lblTituloTela.Location = new Point(25, 14); lblTituloTela.Name = "lblTituloTela"; lblTituloTela.Text = "EDITAR ACERTO";
            pnlAcerto.BackColor = Color.White; pnlAcerto.BorderStyle = BorderStyle.FixedSingle; pnlAcerto.Controls.Add(cmbStatusPagamento); pnlAcerto.Controls.Add(lblStatusPagamento); pnlAcerto.Controls.Add(numValor); pnlAcerto.Controls.Add(lblValor); pnlAcerto.Controls.Add(txtServico); pnlAcerto.Controls.Add(lblServico); pnlAcerto.Controls.Add(txtNomeEscola); pnlAcerto.Controls.Add(lblNomeEscola); pnlAcerto.Location = new Point(20, 95); pnlAcerto.Name = "pnlAcerto"; pnlAcerto.Size = new Size(565, 255);
            lblNomeEscola.AutoSize = true; lblNomeEscola.Location = new Point(20, 12); lblNomeEscola.Name = "lblNomeEscola"; lblNomeEscola.Text = "Nome da Escola:"; txtNomeEscola.Location = new Point(20, 35); txtNomeEscola.Name = "txtNomeEscola"; txtNomeEscola.Size = new Size(515, 25); txtNomeEscola.TabIndex = 0;
            lblServico.AutoSize = true; lblServico.Location = new Point(20, 62); lblServico.Name = "lblServico"; lblServico.Text = "Serviço Realizado:"; txtServico.Location = new Point(20, 85); txtServico.Name = "txtServico"; txtServico.Size = new Size(515, 25); txtServico.TabIndex = 1;
            lblValor.AutoSize = true; lblValor.Location = new Point(20, 122); lblValor.Name = "lblValor"; lblValor.Text = "Valor do Serviço:"; numValor.DecimalPlaces = 2; numValor.Location = new Point(20, 145); numValor.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 }); numValor.Name = "numValor"; numValor.Size = new Size(200, 25); numValor.TabIndex = 2; numValor.ThousandsSeparator = true;
            lblStatusPagamento.AutoSize = true; lblStatusPagamento.Location = new Point(20, 182); lblStatusPagamento.Name = "lblStatusPagamento"; lblStatusPagamento.Text = "Status do Pagamento:"; cmbStatusPagamento.DropDownStyle = ComboBoxStyle.DropDownList; cmbStatusPagamento.FormattingEnabled = true; cmbStatusPagamento.Location = new Point(20, 205); cmbStatusPagamento.Name = "cmbStatusPagamento"; cmbStatusPagamento.Size = new Size(200, 25); cmbStatusPagamento.TabIndex = 3;
            btnSalvar.Location = new Point(365, 370); btnSalvar.Name = "btnSalvar"; btnSalvar.Size = new Size(100, 35); btnSalvar.TabIndex = 4; btnSalvar.Text = "Salvar"; btnSalvar.Click += btnSalvar_Click;
            btnCancelar.Location = new Point(480, 370); btnCancelar.Name = "btnCancelar"; btnCancelar.Size = new Size(105, 35); btnCancelar.TabIndex = 5; btnCancelar.Text = "Cancelar"; btnCancelar.Click += btnCancelar_Click;
            AutoScaleDimensions = new SizeF(7F, 17F); AutoScaleMode = AutoScaleMode.Font; BackColor = Color.WhiteSmoke; ClientSize = new Size(604, 421); Controls.Add(btnCancelar); Controls.Add(btnSalvar); Controls.Add(pnlAcerto); Controls.Add(pnlTopo); Font = new Font("Segoe UI", 10F); FormBorderStyle = FormBorderStyle.FixedSingle; MaximizeBox = false; MinimizeBox = false; Name = "FrmEditarAcerto"; StartPosition = FormStartPosition.CenterParent; Text = "Editar Acerto"; pnlTopo.ResumeLayout(false); pnlTopo.PerformLayout(); pnlAcerto.ResumeLayout(false); pnlAcerto.PerformLayout(); ((System.ComponentModel.ISupportInitialize)numValor).EndInit(); ResumeLayout(false);
        }
        #endregion
        private Panel pnlTopo; private Label lblSubtituloTela; private Label lblTituloTela; private Panel pnlAcerto; private Label lblNomeEscola; private TextBox txtNomeEscola; private Label lblServico; private TextBox txtServico; private Label lblValor; private NumericUpDown numValor; private Label lblStatusPagamento; private ComboBox cmbStatusPagamento; private Button btnSalvar; private Button btnCancelar;
    }
}
