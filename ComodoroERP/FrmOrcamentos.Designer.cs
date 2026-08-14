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
            lblFiltroCliente = new Label();
            txtFiltroCliente = new TextBox();
            cmbFiltroStatus = new ComboBox();
            lblFiltroStatus = new Label();
            lblDataInicial = new Label();
            dtpDataInicial = new DateTimePicker();
            lblDataFinal = new Label();
            dtpDataFinal = new DateTimePicker();
            dgvOrcamentos = new DataGridView();
            btnFiltrar = new Button();
            btnLimparFiltros = new Button();
            btnGerarPdfs = new Button();
            btnAlterarStatus = new Button();
            btnFechar = new Button();
            btnAbrirOrcamento = new Button();
            btnExcluirOrcamento = new Button();
            pnlTopo = new Panel();
            lblTituloTela = new Label();
            lblSubtituloTela = new Label();
            pnlFiltros = new Panel();
            lblFiltros = new Label();
            pnlGrid = new Panel();
            lblOrcamentos = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrcamentos).BeginInit();
            pnlTopo.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlGrid.SuspendLayout();
            SuspendLayout();
            // 
            // lblFiltroCliente
            // 
            lblFiltroCliente.AutoSize = true;
            lblFiltroCliente.Location = new Point(20, 42);
            lblFiltroCliente.Name = "lblFiltroCliente";
            lblFiltroCliente.Size = new Size(54, 19);
            lblFiltroCliente.TabIndex = 3;
            lblFiltroCliente.Text = "Cliente:";
            lblFiltroCliente.Click += label1_Click;
            // 
            // txtFiltroCliente
            // 
            txtFiltroCliente.Location = new Point(20, 65);
            txtFiltroCliente.Name = "txtFiltroCliente";
            txtFiltroCliente.Size = new Size(260, 25);
            txtFiltroCliente.TabIndex = 2;
            // 
            // cmbFiltroStatus
            // 
            cmbFiltroStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroStatus.FormattingEnabled = true;
            cmbFiltroStatus.Items.AddRange(new object[] { "Pendente", "Pago", "Parcial", "Concluído", "Cancelado" });
            cmbFiltroStatus.Location = new Point(300, 65);
            cmbFiltroStatus.Name = "cmbFiltroStatus";
            cmbFiltroStatus.Size = new Size(145, 25);
            cmbFiltroStatus.TabIndex = 15;
            // 
            // lblFiltroStatus
            // 
            lblFiltroStatus.AutoSize = true;
            lblFiltroStatus.Location = new Point(300, 42);
            lblFiltroStatus.Name = "lblFiltroStatus";
            lblFiltroStatus.Size = new Size(50, 19);
            lblFiltroStatus.TabIndex = 14;
            lblFiltroStatus.Text = "Status:";
            // 
            // lblDataInicial
            // 
            lblDataInicial.AutoSize = true;
            lblDataInicial.Location = new Point(465, 42);
            lblDataInicial.Name = "lblDataInicial";
            lblDataInicial.Size = new Size(79, 19);
            lblDataInicial.TabIndex = 16;
            lblDataInicial.Text = "Data Inicial:";
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.Format = DateTimePickerFormat.Short;
            dtpDataInicial.Location = new Point(465, 65);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.ShowCheckBox = true;
            dtpDataInicial.Size = new Size(120, 25);
            dtpDataInicial.TabIndex = 17;
            // 
            // lblDataFinal
            // 
            lblDataFinal.AutoSize = true;
            lblDataFinal.Location = new Point(605, 42);
            lblDataFinal.Name = "lblDataFinal";
            lblDataFinal.Size = new Size(73, 19);
            lblDataFinal.TabIndex = 18;
            lblDataFinal.Text = "Data Final:";
            lblDataFinal.Click += label3_Click;
            // 
            // dtpDataFinal
            // 
            dtpDataFinal.Format = DateTimePickerFormat.Short;
            dtpDataFinal.Location = new Point(605, 65);
            dtpDataFinal.Name = "dtpDataFinal";
            dtpDataFinal.ShowCheckBox = true;
            dtpDataFinal.Size = new Size(120, 25);
            dtpDataFinal.TabIndex = 19;
            // 
            // dgvOrcamentos
            // 
            dgvOrcamentos.AllowUserToAddRows = false;
            dgvOrcamentos.AllowUserToDeleteRows = false;
            dgvOrcamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrcamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrcamentos.Location = new Point(15, 45);
            dgvOrcamentos.MultiSelect = false;
            dgvOrcamentos.Name = "dgvOrcamentos";
            dgvOrcamentos.ReadOnly = true;
            dgvOrcamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrcamentos.Size = new Size(960, 260);
            dgvOrcamentos.TabIndex = 21;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(755, 60);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(95, 35);
            btnFiltrar.TabIndex = 22;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnLimparFiltros
            // 
            btnLimparFiltros.Location = new Point(865, 60);
            btnLimparFiltros.Name = "btnLimparFiltros";
            btnLimparFiltros.Size = new Size(95, 35);
            btnLimparFiltros.TabIndex = 23;
            btnLimparFiltros.Text = "Limpar";
            btnLimparFiltros.UseVisualStyleBackColor = true;
            btnLimparFiltros.Click += btnLimparFiltros_Click;
            // 
            // btnGerarPdfs
            // 
            btnGerarPdfs.Location = new Point(300, 570);
            btnGerarPdfs.Name = "btnGerarPdfs";
            btnGerarPdfs.Size = new Size(130, 35);
            btnGerarPdfs.TabIndex = 25;
            btnGerarPdfs.Text = "Gerar PDFs";
            btnGerarPdfs.UseVisualStyleBackColor = true;
            btnGerarPdfs.Click += btnGerarPdfs_Click;
            // 
            // btnAlterarStatus
            // 
            btnAlterarStatus.Location = new Point(160, 570);
            btnAlterarStatus.Name = "btnAlterarStatus";
            btnAlterarStatus.Size = new Size(130, 35);
            btnAlterarStatus.TabIndex = 24;
            btnAlterarStatus.Text = "Alterar Status";
            btnAlterarStatus.UseVisualStyleBackColor = true;
            btnAlterarStatus.Click += btnAlterarStatus_Click;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(890, 570);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(120, 35);
            btnFechar.TabIndex = 27;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // btnAbrirOrcamento
            // 
            btnAbrirOrcamento.Location = new Point(20, 570);
            btnAbrirOrcamento.Name = "btnAbrirOrcamento";
            btnAbrirOrcamento.Size = new Size(130, 35);
            btnAbrirOrcamento.TabIndex = 26;
            btnAbrirOrcamento.Text = "Abrir Orçamento";
            btnAbrirOrcamento.UseVisualStyleBackColor = true;
            btnAbrirOrcamento.Click += btnAbrirOrcamento_Click;
            // 
            // btnExcluirOrcamento
            // 
            btnExcluirOrcamento.Location = new Point(436, 570);
            btnExcluirOrcamento.Name = "btnExcluirOrcamento";
            btnExcluirOrcamento.Size = new Size(100, 35);
            btnExcluirOrcamento.TabIndex = 28;
            btnExcluirOrcamento.Text = "Excluir";
            btnExcluirOrcamento.UseVisualStyleBackColor = true;
            btnExcluirOrcamento.Click += btnExcluirOrcamento_Click;
            // 
            // pnlTopo
            // 
            pnlTopo.BackColor = Color.SteelBlue;
            pnlTopo.Controls.Add(lblSubtituloTela);
            pnlTopo.Controls.Add(lblTituloTela);
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(1050, 75);
            pnlTopo.TabIndex = 29;
            // 
            // lblTituloTela
            // 
            lblTituloTela.AutoSize = true;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15F);
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Location = new Point(25, 14);
            lblTituloTela.Name = "lblTituloTela";
            lblTituloTela.Size = new Size(184, 28);
            lblTituloTela.TabIndex = 0;
            lblTituloTela.Text = "VER ORÇAMENTOS";
            // 
            // lblSubtituloTela
            // 
            lblSubtituloTela.AutoSize = true;
            lblSubtituloTela.Font = new Font("Segoe UI", 9F);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Location = new Point(27, 43);
            lblSubtituloTela.Name = "lblSubtituloTela";
            lblSubtituloTela.Size = new Size(371, 15);
            lblSubtituloTela.TabIndex = 1;
            lblSubtituloTela.Text = "Consulte, filtre, altere status e gere PDFs dos orçamentos cadastrados";
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.BorderStyle = BorderStyle.FixedSingle;
            pnlFiltros.Controls.Add(lblFiltros);
            pnlFiltros.Controls.Add(lblFiltroCliente);
            pnlFiltros.Controls.Add(txtFiltroCliente);
            pnlFiltros.Controls.Add(lblFiltroStatus);
            pnlFiltros.Controls.Add(cmbFiltroStatus);
            pnlFiltros.Controls.Add(lblDataInicial);
            pnlFiltros.Controls.Add(dtpDataInicial);
            pnlFiltros.Controls.Add(btnLimparFiltros);
            pnlFiltros.Controls.Add(lblDataFinal);
            pnlFiltros.Controls.Add(btnFiltrar);
            pnlFiltros.Controls.Add(dtpDataFinal);
            pnlFiltros.Location = new Point(20, 90);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(990, 120);
            pnlFiltros.TabIndex = 30;
            // 
            // lblFiltros
            // 
            lblFiltros.AutoSize = true;
            lblFiltros.Font = new Font("Segoe UI Semibold", 11F);
            lblFiltros.ForeColor = Color.DimGray;
            lblFiltros.Location = new Point(15, 12);
            lblFiltros.Name = "lblFiltros";
            lblFiltros.Size = new Size(51, 20);
            lblFiltros.TabIndex = 0;
            lblFiltros.Text = "Filtros";
            // 
            // pnlGrid
            // 
            pnlGrid.BackColor = Color.White;
            pnlGrid.BorderStyle = BorderStyle.FixedSingle;
            pnlGrid.Controls.Add(lblOrcamentos);
            pnlGrid.Controls.Add(dgvOrcamentos);
            pnlGrid.Location = new Point(20, 225);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(990, 325);
            pnlGrid.TabIndex = 31;
            // 
            // lblOrcamentos
            // 
            lblOrcamentos.AutoSize = true;
            lblOrcamentos.Font = new Font("Segoe UI Semibold", 11F);
            lblOrcamentos.ForeColor = Color.DimGray;
            lblOrcamentos.Location = new Point(15, 12);
            lblOrcamentos.Name = "lblOrcamentos";
            lblOrcamentos.Size = new Size(91, 20);
            lblOrcamentos.TabIndex = 0;
            lblOrcamentos.Text = "Orçamentos";
            // 
            // FrmOrcamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1034, 634);
            Controls.Add(pnlGrid);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlTopo);
            Controls.Add(btnExcluirOrcamento);
            Controls.Add(btnFechar);
            Controls.Add(btnAbrirOrcamento);
            Controls.Add(btnGerarPdfs);
            Controls.Add(btnAlterarStatus);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "FrmOrcamentos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ver Orçamentos";
            ((System.ComponentModel.ISupportInitialize)dgvOrcamentos).EndInit();
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlGrid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblFiltroCliente;
        private TextBox txtFiltroCliente;
        private ComboBox cmbFiltroStatus;
        private Label lblFiltroStatus;
        private Label lblDataInicial;
        private DateTimePicker dtpDataInicial;
        private Label lblDataFinal;
        private DateTimePicker dtpDataFinal;
        private DataGridView dgvOrcamentos;
        private Button btnFiltrar;
        private Button btnLimparFiltros;
        private Button btnGerarPdfs;
        private Button btnAlterarStatus;
        private Button btnFechar;
        private Button btnAbrirOrcamento;
        private Button btnExcluirOrcamento;
        private Panel pnlTopo;
        private Label lblSubtituloTela;
        private Label lblTituloTela;
        private Panel pnlFiltros;
        private Label lblFiltros;
        private Panel pnlGrid;
        private Label lblOrcamentos;
    }
}