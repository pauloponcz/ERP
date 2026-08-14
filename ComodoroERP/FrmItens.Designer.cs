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
            lblFiltroCliente = new Label();
            txtFiltroCliente = new TextBox();
            label3 = new Label();
            txtFiltroServico = new TextBox();
            cmbFiltroStatus = new ComboBox();
            label4 = new Label();
            btnLimparFiltros = new Button();
            btnFiltrar = new Button();
            dgvItens = new DataGridView();
            btnFechar = new Button();
            dtpDataFinal = new DateTimePicker();
            label2 = new Label();
            dtpDataInicial = new DateTimePicker();
            label5 = new Label();
            pnlTopo = new Panel();
            lblSubtituloTela = new Label();
            lblTituloTela = new Label();
            pnlFiltros = new Panel();
            lblFiltros = new Label();
            pnlGrid = new Panel();
            lblItensLancados = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvItens).BeginInit();
            pnlTopo.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlGrid.SuspendLayout();
            SuspendLayout();
            // 
            // cmbFiltroCategoria
            // 
            cmbFiltroCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroCategoria.FormattingEnabled = true;
            cmbFiltroCategoria.Items.AddRange(new object[] { "Pendente", "Pago", "Parcial", "Concluído", "Cancelado" });
            cmbFiltroCategoria.Location = new Point(240, 65);
            cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            cmbFiltroCategoria.Size = new Size(230, 25);
            cmbFiltroCategoria.TabIndex = 24;
            cmbFiltroCategoria.SelectedIndexChanged += cmbFiltroStatus_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(240, 42);
            label8.Name = "label8";
            label8.Size = new Size(71, 19);
            label8.TabIndex = 23;
            label8.Text = "Categoria:";
            // 
            // lblFiltroCliente
            // 
            lblFiltroCliente.AutoSize = true;
            lblFiltroCliente.Location = new Point(20, 42);
            lblFiltroCliente.Name = "lblFiltroCliente";
            lblFiltroCliente.Size = new Size(54, 19);
            lblFiltroCliente.TabIndex = 22;
            lblFiltroCliente.Text = "Cliente:";
            // 
            // txtFiltroCliente
            // 
            txtFiltroCliente.Location = new Point(20, 65);
            txtFiltroCliente.Name = "txtFiltroCliente";
            txtFiltroCliente.Size = new Size(200, 25);
            txtFiltroCliente.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(490, 42);
            label3.Name = "label3";
            label3.Size = new Size(55, 19);
            label3.TabIndex = 27;
            label3.Text = "Serviço:";
            label3.Click += label3_Click;
            // 
            // txtFiltroServico
            // 
            txtFiltroServico.Location = new Point(490, 65);
            txtFiltroServico.Name = "txtFiltroServico";
            txtFiltroServico.Size = new Size(210, 25);
            txtFiltroServico.TabIndex = 28;
            txtFiltroServico.TextChanged += textBox1_TextChanged;
            // 
            // cmbFiltroStatus
            // 
            cmbFiltroStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroStatus.FormattingEnabled = true;
            cmbFiltroStatus.Items.AddRange(new object[] { "Pendente", "Pago", "Parcial", "Concluído", "Cancelado" });
            cmbFiltroStatus.Location = new Point(720, 65);
            cmbFiltroStatus.Name = "cmbFiltroStatus";
            cmbFiltroStatus.Size = new Size(130, 25);
            cmbFiltroStatus.TabIndex = 30;
            cmbFiltroStatus.SelectedIndexChanged += cmbFiltroStatus_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(720, 42);
            label4.Name = "label4";
            label4.Size = new Size(50, 19);
            label4.TabIndex = 29;
            label4.Text = "Status:";
            label4.Click += label4_Click;
            // 
            // btnLimparFiltros
            // 
            btnLimparFiltros.Location = new Point(925, 92);
            btnLimparFiltros.Name = "btnLimparFiltros";
            btnLimparFiltros.Size = new Size(95, 35);
            btnLimparFiltros.TabIndex = 32;
            btnLimparFiltros.Text = "Limpar";
            btnLimparFiltros.UseVisualStyleBackColor = true;
            btnLimparFiltros.Click += btnLimparFiltros_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(820, 92);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(95, 35);
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
            dgvItens.Location = new Point(15, 45);
            dgvItens.MultiSelect = false;
            dgvItens.Name = "dgvItens";
            dgvItens.ReadOnly = true;
            dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItens.Size = new Size(1010, 250);
            dgvItens.TabIndex = 33;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(940, 580);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(120, 35);
            btnFechar.TabIndex = 34;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // dtpDataFinal
            // 
            dtpDataFinal.Format = DateTimePickerFormat.Short;
            dtpDataFinal.Location = new Point(350, 97);
            dtpDataFinal.Name = "dtpDataFinal";
            dtpDataFinal.ShowCheckBox = true;
            dtpDataFinal.Size = new Size(140, 25);
            dtpDataFinal.TabIndex = 38;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(270, 100);
            label2.Name = "label2";
            label2.Size = new Size(73, 19);
            label2.TabIndex = 37;
            label2.Text = "Data Final:";
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.Format = DateTimePickerFormat.Short;
            dtpDataInicial.Location = new Point(105, 97);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.ShowCheckBox = true;
            dtpDataInicial.Size = new Size(139, 25);
            dtpDataInicial.TabIndex = 36;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 100);
            label5.Name = "label5";
            label5.Size = new Size(79, 19);
            label5.TabIndex = 35;
            label5.Text = "Data Inicial:";
            // 
            // pnlTopo
            // 
            pnlTopo.BackColor = Color.SteelBlue;
            pnlTopo.Controls.Add(lblSubtituloTela);
            pnlTopo.Controls.Add(lblTituloTela);
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(1100, 75);
            pnlTopo.TabIndex = 39;
            // 
            // lblSubtituloTela
            // 
            lblSubtituloTela.AutoSize = true;
            lblSubtituloTela.Font = new Font("Segoe UI", 9F);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Location = new Point(27, 43);
            lblSubtituloTela.Name = "lblSubtituloTela";
            lblSubtituloTela.Size = new Size(351, 15);
            lblSubtituloTela.TabIndex = 1;
            lblSubtituloTela.Text = "Consulte todos os serviços lançados nos orçamentos cadastrados";
            // 
            // lblTituloTela
            // 
            lblTituloTela.AutoSize = true;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15F);
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Location = new Point(25, 14);
            lblTituloTela.Name = "lblTituloTela";
            lblTituloTela.Size = new Size(175, 28);
            lblTituloTela.TabIndex = 0;
            lblTituloTela.Text = "ITENS LANÇADOS";
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.BorderStyle = BorderStyle.FixedSingle;
            pnlFiltros.Controls.Add(lblFiltros);
            pnlFiltros.Controls.Add(lblFiltroCliente);
            pnlFiltros.Controls.Add(dtpDataFinal);
            pnlFiltros.Controls.Add(txtFiltroCliente);
            pnlFiltros.Controls.Add(btnLimparFiltros);
            pnlFiltros.Controls.Add(label2);
            pnlFiltros.Controls.Add(btnFiltrar);
            pnlFiltros.Controls.Add(label8);
            pnlFiltros.Controls.Add(dtpDataInicial);
            pnlFiltros.Controls.Add(cmbFiltroCategoria);
            pnlFiltros.Controls.Add(label5);
            pnlFiltros.Controls.Add(label3);
            pnlFiltros.Controls.Add(txtFiltroServico);
            pnlFiltros.Controls.Add(label4);
            pnlFiltros.Controls.Add(cmbFiltroStatus);
            pnlFiltros.Location = new Point(20, 90);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(1040, 140);
            pnlFiltros.TabIndex = 40;
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
            pnlGrid.Controls.Add(lblItensLancados);
            pnlGrid.Controls.Add(dgvItens);
            pnlGrid.Location = new Point(20, 245);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(1040, 315);
            pnlGrid.TabIndex = 41;
            // 
            // lblItensLancados
            // 
            lblItensLancados.AutoSize = true;
            lblItensLancados.Font = new Font("Segoe UI Semibold", 11F);
            lblItensLancados.ForeColor = Color.DimGray;
            lblItensLancados.Location = new Point(15, 12);
            lblItensLancados.Name = "lblItensLancados";
            lblItensLancados.Size = new Size(108, 20);
            lblItensLancados.TabIndex = 34;
            lblItensLancados.Text = "Itens Lançados";
            // 
            // FrmItens
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1084, 628);
            Controls.Add(pnlGrid);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlTopo);
            Controls.Add(btnFechar);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmItens";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Itens Lançados";
            ((System.ComponentModel.ISupportInitialize)dgvItens).EndInit();
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlGrid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbFiltroCategoria;
        private Label label8;
        private Label lblFiltroCliente;
        private TextBox txtFiltroCliente;
        private Label label3;
        private TextBox txtFiltroServico;
        private ComboBox cmbFiltroStatus;
        private Label label4;
        private Button btnLimparFiltros;
        private Button btnFiltrar;
        private DataGridView dgvItens;
        private Button btnFechar;
        private DateTimePicker dtpDataFinal;
        private Label label2;
        private DateTimePicker dtpDataInicial;
        private Label label5;
        private Panel pnlTopo;
        private Label lblSubtituloTela;
        private Label lblTituloTela;
        private Panel pnlFiltros;
        private Label lblFiltros;
        private Panel pnlGrid;
        private Label lblItensLancados;
    }
}