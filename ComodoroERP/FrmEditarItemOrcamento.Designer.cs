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
            groupBox1 = new GroupBox();
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
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numValorUnitario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).BeginInit();
            SuspendLayout();
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(282, 374);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(88, 23);
            btnSalvar.TabIndex = 16;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(382, 374);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(88, 23);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtDescricaoServico);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(numValorUnitario);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(chkCortesia);
            groupBox1.Controls.Add(cmbCategoria);
            groupBox1.Controls.Add(txtObservacaoServico);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(numQuantidade);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbServicoPermitido);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(458, 356);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "EDITAR ITEM DO ORÇAMENTO";
            // 
            // txtDescricaoServico
            // 
            txtDescricaoServico.Location = new Point(23, 153);
            txtDescricaoServico.Name = "txtDescricaoServico";
            txtDescricaoServico.Size = new Size(405, 23);
            txtDescricaoServico.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 132);
            label3.Name = "label3";
            label3.Size = new Size(158, 15);
            label3.TabIndex = 14;
            label3.Text = "Descrição para o orçamento:";
            // 
            // numValorUnitario
            // 
            numValorUnitario.DecimalPlaces = 2;
            numValorUnitario.Location = new Point(234, 200);
            numValorUnitario.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numValorUnitario.Name = "numValorUnitario";
            numValorUnitario.Size = new Size(194, 23);
            numValorUnitario.TabIndex = 13;
            numValorUnitario.Value = new decimal(new int[] { 1000000, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(234, 179);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 12;
            label6.Text = "Valor Unitário:";
            // 
            // chkCortesia
            // 
            chkCortesia.AutoSize = true;
            chkCortesia.Location = new Point(22, 231);
            chkCortesia.Name = "chkCortesia";
            chkCortesia.Size = new Size(69, 19);
            chkCortesia.TabIndex = 11;
            chkCortesia.Text = "Cortesia";
            chkCortesia.UseVisualStyleBackColor = true;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(22, 58);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(405, 23);
            cmbCategoria.TabIndex = 10;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
            // 
            // txtObservacaoServico
            // 
            txtObservacaoServico.Location = new Point(22, 276);
            txtObservacaoServico.Multiline = true;
            txtObservacaoServico.Name = "txtObservacaoServico";
            txtObservacaoServico.Size = new Size(405, 63);
            txtObservacaoServico.TabIndex = 9;
            txtObservacaoServico.TextChanged += txtObservacaoServico_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 258);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 8;
            label5.Text = "Observação:";
            label5.Click += label5_Click;
            // 
            // numQuantidade
            // 
            numQuantidade.DecimalPlaces = 2;
            numQuantidade.Location = new Point(23, 200);
            numQuantidade.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numQuantidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantidade.Name = "numQuantidade";
            numQuantidade.Size = new Size(192, 23);
            numQuantidade.TabIndex = 7;
            numQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 179);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 6;
            label4.Text = "Quantidade:";
            // 
            // cmbServicoPermitido
            // 
            cmbServicoPermitido.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicoPermitido.FormattingEnabled = true;
            cmbServicoPermitido.Location = new Point(23, 102);
            cmbServicoPermitido.Name = "cmbServicoPermitido";
            cmbServicoPermitido.Size = new Size(405, 23);
            cmbServicoPermitido.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 84);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 2;
            label2.Text = "Serviço Permitido:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 40);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Categoria:";
            // 
            // FrmEditarItemOrcamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 416);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(groupBox1);
            Name = "FrmEditarItemOrcamento";
            Text = "FrmEditarItemOrcamento";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numValorUnitario).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalvar;
        private Button btnCancelar;
        private GroupBox groupBox1;
        private TextBox txtDescricaoServico;
        private Label label3;
        private NumericUpDown numValorUnitario;
        private Label label6;
        private CheckBox chkCortesia;
        private ComboBox cmbCategoria;
        private TextBox txtObservacaoServico;
        private Label label5;
        private NumericUpDown numQuantidade;
        private Label label4;
        private ComboBox cmbServicoPermitido;
        private Label label2;
        private Label label1;
    }
}