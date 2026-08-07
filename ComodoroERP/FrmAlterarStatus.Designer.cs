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
            label1 = new Label();
            label2 = new Label();
            cmbStatus = new ComboBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 25);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 0;
            label1.Text = "Alterar Status";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 69);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 1;
            label2.Text = "Novo Status:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(113, 66);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(207, 23);
            cmbStatus.TabIndex = 2;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(114, 115);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 31);
            btnSalvar.TabIndex = 3;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(220, 115);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 31);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmAlterarStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 216);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(cmbStatus);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmAlterarStatus";
            Text = "FrmAlterarStatus";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbStatus;
        private Button btnSalvar;
        private Button btnCancelar;
    }
}