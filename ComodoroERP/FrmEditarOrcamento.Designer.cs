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
            groupBox1 = new GroupBox();
            txtObservacao = new TextBox();
            label5 = new Label();
            numVariacaoNota3 = new NumericUpDown();
            label4 = new Label();
            numVariacaoNota2 = new NumericUpDown();
            label3 = new Label();
            cmbStatus = new ComboBox();
            label2 = new Label();
            txtTitulo = new TextBox();
            label1 = new Label();
            btnSalvar = new Button();
            btnCancelar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota2).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtObservacao);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(numVariacaoNota3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(numVariacaoNota2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmbStatus);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtTitulo);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(458, 326);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "EDITAR ORÇAMENTO";
            // 
            // txtObservacao
            // 
            txtObservacao.Location = new Point(25, 240);
            txtObservacao.Multiline = true;
            txtObservacao.Name = "txtObservacao";
            txtObservacao.Size = new Size(405, 63);
            txtObservacao.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 222);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 8;
            label5.Text = "Observação:";
            // 
            // numVariacaoNota3
            // 
            numVariacaoNota3.Location = new Point(23, 196);
            numVariacaoNota3.Name = "numVariacaoNota3";
            numVariacaoNota3.Size = new Size(405, 23);
            numVariacaoNota3.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 175);
            label4.Name = "label4";
            label4.Size = new Size(113, 15);
            label4.TabIndex = 6;
            label4.Text = "Variação Nota 3 (%):";
            // 
            // numVariacaoNota2
            // 
            numVariacaoNota2.Location = new Point(23, 146);
            numVariacaoNota2.Name = "numVariacaoNota2";
            numVariacaoNota2.Size = new Size(405, 23);
            numVariacaoNota2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 128);
            label3.Name = "label3";
            label3.Size = new Size(113, 15);
            label3.TabIndex = 4;
            label3.Text = "Variação Nota 2 (%):";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(23, 102);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(405, 23);
            cmbStatus.TabIndex = 3;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 84);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Status:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(23, 58);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(405, 23);
            txtTitulo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 40);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 0;
            label1.Text = "Título:";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(21, 344);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(88, 23);
            btnSalvar.TabIndex = 10;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(373, 344);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(88, 23);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmEditarOrcamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 393);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(groupBox1);
            Name = "FrmEditarOrcamento";
            Text = "FrmEditarOrcamento";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private NumericUpDown numVariacaoNota2;
        private Label label3;
        private ComboBox cmbStatus;
        private Label label2;
        private TextBox txtTitulo;
        private Label label1;
        private NumericUpDown numVariacaoNota3;
        private Label label4;
        private TextBox txtObservacao;
        private Label label5;
        private Button btnSalvar;
        private Button btnCancelar;
    }
}