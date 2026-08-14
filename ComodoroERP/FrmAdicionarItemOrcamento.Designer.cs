namespace ComodoroERP
{
    partial class FrmAdicionarItemOrcamento
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
            label3 = new Label();
            numValorUnitario = new NumericUpDown();
            label6 = new Label();
            chkCortesia = new CheckBox();
            cmbCategoria = new ComboBox();
            txtObservacaoServico = new TextBox();
            label5 = new Label();
            numQuantidade = new NumericUpDown();
            label4 = new Label();
            cmbServicoPermitido = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            pnlTopo = new Panel();
            lblSubtituloTela = new Label();
            lblTituloTela = new Label();
            pnlServico = new Panel();
            lblDadosServico = new Label();
            ((System.ComponentModel.ISupportInitialize)numValorUnitario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).BeginInit();
            pnlTopo.SuspendLayout();
            pnlServico.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(365, 425);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 35);
            btnSalvar.TabIndex = 13;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(480, 425);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 35);
            btnCancelar.TabIndex = 14;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 165);
            label3.Name = "label3";
            label3.Size = new Size(183, 19);
            label3.TabIndex = 14;
            label3.Text = "Descrição para o orçamento:";
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
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 280);
            label5.Name = "label5";
            label5.Size = new Size(84, 19);
            label5.TabIndex = 8;
            label5.Text = "Observação:";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 225);
            label4.Name = "label4";
            label4.Size = new Size(84, 19);
            label4.TabIndex = 6;
            label4.Text = "Quantidade:";
            // 
            // cmbServicoPermitido
            // 
            cmbServicoPermitido.FormattingEnabled = true;
            cmbServicoPermitido.Location = new Point(20, 127);
            cmbServicoPermitido.Name = "cmbServicoPermitido";
            cmbServicoPermitido.Size = new Size(515, 25);
            cmbServicoPermitido.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 105);
            label2.Name = "label2";
            label2.Size = new Size(117, 19);
            label2.TabIndex = 2;
            label2.Text = "Serviço Permitido:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 45);
            label1.Name = "label1";
            label1.Size = new Size(71, 19);
            label1.TabIndex = 0;
            label1.Text = "Categoria:";
            // 
            // pnlTopo
            // 
            pnlTopo.BackColor = Color.SteelBlue;
            pnlTopo.Controls.Add(lblSubtituloTela);
            pnlTopo.Controls.Add(lblTituloTela);
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(620, 75);
            pnlTopo.TabIndex = 15;
            // 
            // lblSubtituloTela
            // 
            lblSubtituloTela.AutoSize = true;
            lblSubtituloTela.Font = new Font("Segoe UI", 9F);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Location = new Point(27, 43);
            lblSubtituloTela.Name = "lblSubtituloTela";
            lblSubtituloTela.Size = new Size(273, 15);
            lblSubtituloTela.TabIndex = 1;
            lblSubtituloTela.Text = "Inclua um novo serviço ao orçamento selecionado";
            // 
            // lblTituloTela
            // 
            lblTituloTela.AutoSize = true;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15F);
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Location = new Point(25, 14);
            lblTituloTela.Name = "lblTituloTela";
            lblTituloTela.Size = new Size(169, 28);
            lblTituloTela.TabIndex = 0;
            lblTituloTela.Text = "ADICIONAR ITEM";
            // 
            // pnlServico
            // 
            pnlServico.BackColor = Color.White;
            pnlServico.BorderStyle = BorderStyle.FixedSingle;
            pnlServico.Controls.Add(txtObservacaoServico);
            pnlServico.Controls.Add(chkCortesia);
            pnlServico.Controls.Add(label5);
            pnlServico.Controls.Add(numValorUnitario);
            pnlServico.Controls.Add(txtDescricaoServico);
            pnlServico.Controls.Add(label6);
            pnlServico.Controls.Add(lblDadosServico);
            pnlServico.Controls.Add(label3);
            pnlServico.Controls.Add(label1);
            pnlServico.Controls.Add(cmbCategoria);
            pnlServico.Controls.Add(numQuantidade);
            pnlServico.Controls.Add(label2);
            pnlServico.Controls.Add(label4);
            pnlServico.Controls.Add(cmbServicoPermitido);
            pnlServico.Location = new Point(20, 95);
            pnlServico.Name = "pnlServico";
            pnlServico.Size = new Size(565, 315);
            pnlServico.TabIndex = 16;
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
            // FrmAdicionarItemOrcamento
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(604, 481);
            Controls.Add(pnlServico);
            Controls.Add(pnlTopo);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAdicionarItemOrcamento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adicionar Item ao Orçamento";
            Load += FrmAdicionarItemOrcamento_Load;
            ((System.ComponentModel.ISupportInitialize)numValorUnitario).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).EndInit();
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlServico.ResumeLayout(false);
            pnlServico.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalvar;
        private Button btnCancelar;
        private ComboBox cmbCategoria;
        private TextBox txtObservacaoServico;
        private Label label5;
        private NumericUpDown numQuantidade;
        private Label label4;
        private ComboBox cmbServicoPermitido;
        private Label label2;
        private Label label1;
        private NumericUpDown numValorUnitario;
        private Label label6;
        private CheckBox chkCortesia;
        private TextBox txtDescricaoServico;
        private Label label3;
        private Panel pnlTopo;
        private Label lblSubtituloTela;
        private Label lblTituloTela;
        private Panel pnlServico;
        private Label lblDadosServico;
    }
}