namespace ComodoroERP
{
    partial class FrmEditarItemOrcamento
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
            btnSalvar = new Button();
            btnCancelar = new Button();
            txtDescricaoServico = new TextBox();
            lblDescricaoServico = new Label();
            numValorUnitario = new NumericUpDown();
            label6 = new Label();
            chkCortesia = new CheckBox();
            cmbCategoria = new ComboBox();
            txtObservacaoServico = new TextBox();
            label5 = new Label();
            numQuantidade = new NumericUpDown();
            lblQuantidade = new Label();
            cmbServicoPermitido = new ComboBox();
            lblServicoPermitido = new Label();
            lblCategoria = new Label();
            lblSubtituloTela = new Label();
            lblTituloTela = new Label();
            pnlServico = new Panel();
            lblDadosServico = new Label();
            pnlTopo = new Panel();
            ((System.ComponentModel.ISupportInitialize)numValorUnitario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).BeginInit();
            pnlServico.SuspendLayout();
            pnlTopo.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(365, 428);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 35);
            btnSalvar.TabIndex = 16;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(480, 428);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 35);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtDescricaoServico
            // 
            txtDescricaoServico.Location = new Point(20, 187);
            txtDescricaoServico.Name = "txtDescricaoServico";
            txtDescricaoServico.Size = new Size(515, 25);
            txtDescricaoServico.TabIndex = 15;
            // 
            // lblDescricaoServico
            // 
            lblDescricaoServico.AutoSize = true;
            lblDescricaoServico.Location = new Point(20, 165);
            lblDescricaoServico.Name = "lblDescricaoServico";
            lblDescricaoServico.Size = new Size(183, 19);
            lblDescricaoServico.TabIndex = 14;
            lblDescricaoServico.Text = "Descrição para o orçamento:";
            // 
            // numValorUnitario
            // 
            numValorUnitario.DecimalPlaces = 2;
            numValorUnitario.Location = new Point(155, 247);
            numValorUnitario.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numValorUnitario.Name = "numValorUnitario";
            numValorUnitario.Size = new Size(130, 25);
            numValorUnitario.TabIndex = 13;
            numValorUnitario.Value = new decimal(new int[] { 1000000, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(155, 225);
            label6.Name = "label6";
            label6.Size = new Size(96, 19);
            label6.TabIndex = 12;
            label6.Text = "Valor Unitário:";
            // 
            // chkCortesia
            // 
            chkCortesia.AutoSize = true;
            chkCortesia.Location = new Point(315, 249);
            chkCortesia.Name = "chkCortesia";
            chkCortesia.Size = new Size(78, 23);
            chkCortesia.TabIndex = 11;
            chkCortesia.Text = "Cortesia";
            chkCortesia.UseVisualStyleBackColor = true;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(20, 67);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(515, 25);
            cmbCategoria.TabIndex = 10;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
            // 
            // txtObservacaoServico
            // 
            txtObservacaoServico.Location = new Point(105, 277);
            txtObservacaoServico.Multiline = true;
            txtObservacaoServico.Name = "txtObservacaoServico";
            txtObservacaoServico.Size = new Size(430, 25);
            txtObservacaoServico.TabIndex = 9;
            txtObservacaoServico.TextChanged += txtObservacaoServico_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 280);
            label5.Name = "label5";
            label5.Size = new Size(84, 19);
            label5.TabIndex = 8;
            label5.Text = "Observação:";
            label5.Click += label5_Click;
            // 
            // numQuantidade
            // 
            numQuantidade.DecimalPlaces = 2;
            numQuantidade.Location = new Point(20, 247);
            numQuantidade.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numQuantidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantidade.Name = "numQuantidade";
            numQuantidade.Size = new Size(110, 25);
            numQuantidade.TabIndex = 7;
            numQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQuantidade
            // 
            lblQuantidade.AutoSize = true;
            lblQuantidade.Location = new Point(20, 225);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(84, 19);
            lblQuantidade.TabIndex = 6;
            lblQuantidade.Text = "Quantidade:";
            // 
            // cmbServicoPermitido
            // 
            cmbServicoPermitido.FormattingEnabled = true;
            cmbServicoPermitido.Location = new Point(20, 127);
            cmbServicoPermitido.Name = "cmbServicoPermitido";
            cmbServicoPermitido.Size = new Size(515, 25);
            cmbServicoPermitido.TabIndex = 3;
            // 
            // lblServicoPermitido
            // 
            lblServicoPermitido.AutoSize = true;
            lblServicoPermitido.Location = new Point(20, 105);
            lblServicoPermitido.Name = "lblServicoPermitido";
            lblServicoPermitido.Size = new Size(117, 19);
            lblServicoPermitido.TabIndex = 2;
            lblServicoPermitido.Text = "Serviço Permitido:";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(20, 45);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(71, 19);
            lblCategoria.TabIndex = 0;
            lblCategoria.Text = "Categoria:";
            // 
            // lblSubtituloTela
            // 
            lblSubtituloTela.AutoSize = true;
            lblSubtituloTela.Font = new Font("Segoe UI", 9F);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Location = new Point(27, 49);
            lblSubtituloTela.Name = "lblSubtituloTela";
            lblSubtituloTela.Size = new Size(289, 15);
            lblSubtituloTela.TabIndex = 1;
            lblSubtituloTela.Text = "Altere os dados do serviço selecionado no orçamento";
            // 
            // lblTituloTela
            // 
            lblTituloTela.AutoSize = true;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15F);
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Location = new Point(25, 16);
            lblTituloTela.Name = "lblTituloTela";
            lblTituloTela.Size = new Size(128, 28);
            lblTituloTela.TabIndex = 0;
            lblTituloTela.Text = "EDITAR ITEM";
            // 
            // pnlServico
            // 
            pnlServico.BackColor = Color.White;
            pnlServico.BorderStyle = BorderStyle.FixedSingle;
            pnlServico.Controls.Add(txtObservacaoServico);
            pnlServico.Controls.Add(chkCortesia);
            pnlServico.Controls.Add(label5);
            pnlServico.Controls.Add(label6);
            pnlServico.Controls.Add(numValorUnitario);
            pnlServico.Controls.Add(txtDescricaoServico);
            pnlServico.Controls.Add(lblDadosServico);
            pnlServico.Controls.Add(lblDescricaoServico);
            pnlServico.Controls.Add(cmbCategoria);
            pnlServico.Controls.Add(lblCategoria);
            pnlServico.Controls.Add(numQuantidade);
            pnlServico.Controls.Add(cmbServicoPermitido);
            pnlServico.Controls.Add(lblQuantidade);
            pnlServico.Controls.Add(lblServicoPermitido);
            pnlServico.Location = new Point(20, 108);
            pnlServico.Name = "pnlServico";
            pnlServico.Size = new Size(565, 315);
            pnlServico.TabIndex = 19;
            // 
            // lblDadosServico
            // 
            lblDadosServico.AutoSize = true;
            lblDadosServico.Font = new Font("Segoe UI Semibold", 11F);
            lblDadosServico.ForeColor = Color.DimGray;
            lblDadosServico.Location = new Point(15, 12);
            lblDadosServico.Name = "lblDadosServico";
            lblDadosServico.Size = new Size(129, 20);
            lblDadosServico.TabIndex = 0;
            lblDadosServico.Text = "Dados do Serviço";
            // 
            // pnlTopo
            // 
            pnlTopo.BackColor = Color.SteelBlue;
            pnlTopo.Controls.Add(lblSubtituloTela);
            pnlTopo.Controls.Add(lblTituloTela);
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(620, 85);
            pnlTopo.TabIndex = 18;
            // 
            // FrmEditarItemOrcamento
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(604, 472);
            Controls.Add(pnlServico);
            Controls.Add(pnlTopo);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmEditarItemOrcamento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Item do Orçamento";
            ((System.ComponentModel.ISupportInitialize)numValorUnitario).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).EndInit();
            pnlServico.ResumeLayout(false);
            pnlServico.PerformLayout();
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalvar;
        private Button btnCancelar;
        private TextBox txtDescricaoServico;
        private Label lblDescricaoServico;
        private NumericUpDown numValorUnitario;
        private Label label6;
        private CheckBox chkCortesia;
        private ComboBox cmbCategoria;
        private TextBox txtObservacaoServico;
        private Label label5;
        private NumericUpDown numQuantidade;
        private Label lblQuantidade;
        private ComboBox cmbServicoPermitido;
        private Label lblServicoPermitido;
        private Label lblCategoria;
        private Label lblSubtituloTela;
        private Label lblTituloTela;
        private Panel pnlServico;
        private Label lblDadosServico;
        private Panel pnlTopo;
    }
}