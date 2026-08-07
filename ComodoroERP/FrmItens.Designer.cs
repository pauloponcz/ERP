namespace ComodoroERP
{
    partial class FrmItens
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
            cmbFiltroCategoria = new ComboBox();
            label8 = new Label();
            label1 = new Label();
            txtFiltroCliente = new TextBox();
            label3 = new Label();
            txtFiltroServico = new TextBox();
            cmbFiltroStatus = new ComboBox();
            label4 = new Label();
            btnLimparFiltros = new Button();
            btnFiltrar = new Button();
            dgvItens = new DataGridView();
            btnFechar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvItens).BeginInit();
            SuspendLayout();
            // 
            // cmbFiltroCategoria
            // 
            cmbFiltroCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroCategoria.FormattingEnabled = true;
            cmbFiltroCategoria.Items.AddRange(new object[] { "Pendente", "Pago", "Parcial", "Concluído", "Cancelado" });
            cmbFiltroCategoria.Location = new Point(253, 12);
            cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            cmbFiltroCategoria.Size = new Size(136, 23);
            cmbFiltroCategoria.TabIndex = 24;
            cmbFiltroCategoria.SelectedIndexChanged += cmbFiltroStatus_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(192, 15);
            label8.Name = "label8";
            label8.Size = new Size(61, 15);
            label8.TabIndex = 23;
            label8.Text = "Categoria:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 15);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 22;
            label1.Text = "Cliente:";
            // 
            // txtFiltroCliente
            // 
            txtFiltroCliente.Location = new Point(60, 12);
            txtFiltroCliente.Name = "txtFiltroCliente";
            txtFiltroCliente.Size = new Size(126, 23);
            txtFiltroCliente.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(400, 15);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 27;
            label3.Text = "Serviço:";
            label3.Click += label3_Click;
            // 
            // txtFiltroServico
            // 
            txtFiltroServico.Location = new Point(448, 12);
            txtFiltroServico.Name = "txtFiltroServico";
            txtFiltroServico.Size = new Size(126, 23);
            txtFiltroServico.TabIndex = 28;
            txtFiltroServico.TextChanged += textBox1_TextChanged;
            // 
            // cmbFiltroStatus
            // 
            cmbFiltroStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroStatus.FormattingEnabled = true;
            cmbFiltroStatus.Items.AddRange(new object[] { "Pendente", "Pago", "Parcial", "Concluído", "Cancelado" });
            cmbFiltroStatus.Location = new Point(626, 12);
            cmbFiltroStatus.Name = "cmbFiltroStatus";
            cmbFiltroStatus.Size = new Size(136, 23);
            cmbFiltroStatus.TabIndex = 30;
            cmbFiltroStatus.SelectedIndexChanged += cmbFiltroStatus_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(581, 15);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 29;
            label4.Text = "Status:";
            label4.Click += label4_Click;
            // 
            // btnLimparFiltros
            // 
            btnLimparFiltros.Location = new Point(112, 43);
            btnLimparFiltros.Name = "btnLimparFiltros";
            btnLimparFiltros.Size = new Size(99, 23);
            btnLimparFiltros.TabIndex = 32;
            btnLimparFiltros.Text = "Limpar Filtros";
            btnLimparFiltros.UseVisualStyleBackColor = true;
            btnLimparFiltros.Click += btnLimparFiltros_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(7, 43);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(99, 23);
            btnFiltrar.TabIndex = 31;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // dgvItens
            // 
            dgvItens.AllowUserToAddRows = false;
            dgvItens.AllowUserToDeleteRows = false;
            dgvItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItens.Location = new Point(7, 72);
            dgvItens.MultiSelect = false;
            dgvItens.Name = "dgvItens";
            dgvItens.ReadOnly = true;
            dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItens.Size = new Size(755, 296);
            dgvItens.TabIndex = 33;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(7, 374);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(99, 23);
            btnFechar.TabIndex = 34;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // FrmItens
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 450);
            Controls.Add(btnFechar);
            Controls.Add(dgvItens);
            Controls.Add(btnLimparFiltros);
            Controls.Add(btnFiltrar);
            Controls.Add(cmbFiltroStatus);
            Controls.Add(label4);
            Controls.Add(txtFiltroServico);
            Controls.Add(label3);
            Controls.Add(cmbFiltroCategoria);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(txtFiltroCliente);
            Name = "FrmItens";
            Text = "FrmItens";
            ((System.ComponentModel.ISupportInitialize)dgvItens).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbFiltroCategoria;
        private Label label8;
        private Label label1;
        private TextBox txtFiltroCliente;
        private Label label3;
        private TextBox txtFiltroServico;
        private ComboBox cmbFiltroStatus;
        private Label label4;
        private Button btnLimparFiltros;
        private Button btnFiltrar;
        private DataGridView dgvItens;
        private Button btnFechar;
    }
}