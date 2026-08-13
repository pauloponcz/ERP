namespace ComodoroERP
{
    partial class FrmOrcamentos
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
            txtFiltroCliente = new TextBox();
            cmbFiltroStatus = new ComboBox();
            label8 = new Label();
            label2 = new Label();
            dtpDataInicial = new DateTimePicker();
            label3 = new Label();
            dtpDataFinal = new DateTimePicker();
            chkUsarFiltroData = new CheckBox();
            dgvOrcamentos = new DataGridView();
            btnFiltrar = new Button();
            btnLimparFiltros = new Button();
            btnGerarPdfs = new Button();
            btnAlterarStatus = new Button();
            btnFechar = new Button();
            btnAbrirOrcamento = new Button();
            btnExcluirOrcamento = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrcamentos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 12);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 3;
            label1.Text = "Cliente:";
            label1.Click += label1_Click;
            // 
            // txtFiltroCliente
            // 
            txtFiltroCliente.Location = new Point(68, 9);
            txtFiltroCliente.Name = "txtFiltroCliente";
            txtFiltroCliente.Size = new Size(126, 23);
            txtFiltroCliente.TabIndex = 2;
            // 
            // cmbFiltroStatus
            // 
            cmbFiltroStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroStatus.FormattingEnabled = true;
            cmbFiltroStatus.Items.AddRange(new object[] { "Pendente", "Pago", "Parcial", "Concluído", "Cancelado" });
            cmbFiltroStatus.Location = new Point(245, 9);
            cmbFiltroStatus.Name = "cmbFiltroStatus";
            cmbFiltroStatus.Size = new Size(88, 23);
            cmbFiltroStatus.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(200, 12);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 14;
            label8.Text = "Status:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(342, 12);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 16;
            label2.Text = "Data:";
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.Location = new Point(405, 9);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.Size = new Size(248, 23);
            dtpDataInicial.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(659, 14);
            label3.Name = "label3";
            label3.Size = new Size(25, 15);
            label3.TabIndex = 18;
            label3.Text = "Até";
            label3.Click += label3_Click;
            // 
            // dtpDataFinal
            // 
            dtpDataFinal.Location = new Point(690, 9);
            dtpDataFinal.Name = "dtpDataFinal";
            dtpDataFinal.Size = new Size(248, 23);
            dtpDataFinal.TabIndex = 19;
            // 
            // chkUsarFiltroData
            // 
            chkUsarFiltroData.AutoSize = true;
            chkUsarFiltroData.Location = new Point(384, 13);
            chkUsarFiltroData.Name = "chkUsarFiltroData";
            chkUsarFiltroData.Size = new Size(15, 14);
            chkUsarFiltroData.TabIndex = 20;
            chkUsarFiltroData.UseVisualStyleBackColor = true;
            // 
            // dgvOrcamentos
            // 
            dgvOrcamentos.AllowUserToAddRows = false;
            dgvOrcamentos.AllowUserToDeleteRows = false;
            dgvOrcamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrcamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrcamentos.Location = new Point(15, 75);
            dgvOrcamentos.MultiSelect = false;
            dgvOrcamentos.Name = "dgvOrcamentos";
            dgvOrcamentos.ReadOnly = true;
            dgvOrcamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrcamentos.Size = new Size(923, 296);
            dgvOrcamentos.TabIndex = 21;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(15, 40);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(99, 23);
            btnFiltrar.TabIndex = 22;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnLimparFiltros
            // 
            btnLimparFiltros.Location = new Point(120, 40);
            btnLimparFiltros.Name = "btnLimparFiltros";
            btnLimparFiltros.Size = new Size(99, 23);
            btnLimparFiltros.TabIndex = 23;
            btnLimparFiltros.Text = "Limpar Filtros";
            btnLimparFiltros.UseVisualStyleBackColor = true;
            btnLimparFiltros.Click += btnLimparFiltros_Click;
            // 
            // btnGerarPdfs
            // 
            btnGerarPdfs.Location = new Point(225, 377);
            btnGerarPdfs.Name = "btnGerarPdfs";
            btnGerarPdfs.Size = new Size(99, 23);
            btnGerarPdfs.TabIndex = 25;
            btnGerarPdfs.Text = "Gerar PDFs";
            btnGerarPdfs.UseVisualStyleBackColor = true;
            btnGerarPdfs.Click += btnGerarPdfs_Click;
            // 
            // btnAlterarStatus
            // 
            btnAlterarStatus.Location = new Point(120, 377);
            btnAlterarStatus.Name = "btnAlterarStatus";
            btnAlterarStatus.Size = new Size(99, 23);
            btnAlterarStatus.TabIndex = 24;
            btnAlterarStatus.Text = "Alterar Status";
            btnAlterarStatus.UseVisualStyleBackColor = true;
            btnAlterarStatus.Click += btnAlterarStatus_Click;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(839, 412);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(99, 23);
            btnFechar.TabIndex = 27;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // btnAbrirOrcamento
            // 
            btnAbrirOrcamento.Location = new Point(15, 377);
            btnAbrirOrcamento.Name = "btnAbrirOrcamento";
            btnAbrirOrcamento.Size = new Size(99, 23);
            btnAbrirOrcamento.TabIndex = 26;
            btnAbrirOrcamento.Text = "Abrir Orçamento";
            btnAbrirOrcamento.UseVisualStyleBackColor = true;
            btnAbrirOrcamento.Click += btnAbrirOrcamento_Click;
            // 
            // btnExcluirOrcamento
            // 
            btnExcluirOrcamento.Location = new Point(374, 377);
            btnExcluirOrcamento.Name = "btnExcluirOrcamento";
            btnExcluirOrcamento.Size = new Size(99, 23);
            btnExcluirOrcamento.TabIndex = 28;
            btnExcluirOrcamento.Text = "Excluir Orçamento";
            btnExcluirOrcamento.UseVisualStyleBackColor = true;
            btnExcluirOrcamento.Click += btnExcluirOrcamento_Click;
            // 
            // FrmOrcamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 447);
            Controls.Add(btnExcluirOrcamento);
            Controls.Add(btnFechar);
            Controls.Add(btnAbrirOrcamento);
            Controls.Add(btnGerarPdfs);
            Controls.Add(btnAlterarStatus);
            Controls.Add(btnLimparFiltros);
            Controls.Add(btnFiltrar);
            Controls.Add(dgvOrcamentos);
            Controls.Add(chkUsarFiltroData);
            Controls.Add(dtpDataFinal);
            Controls.Add(label3);
            Controls.Add(dtpDataInicial);
            Controls.Add(label2);
            Controls.Add(cmbFiltroStatus);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(txtFiltroCliente);
            Name = "FrmOrcamentos";
            Text = "FrmOrcamentos";
            ((System.ComponentModel.ISupportInitialize)dgvOrcamentos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtFiltroCliente;
        private ComboBox cmbFiltroStatus;
        private Label label8;
        private Label label2;
        private DateTimePicker dtpDataInicial;
        private Label label3;
        private DateTimePicker dtpDataFinal;
        private CheckBox chkUsarFiltroData;
        private DataGridView dgvOrcamentos;
        private Button btnFiltrar;
        private Button btnLimparFiltros;
        private Button btnGerarPdfs;
        private Button btnAlterarStatus;
        private Button btnFechar;
        private Button btnAbrirOrcamento;
        private Button btnExcluirOrcamento;
    }
}