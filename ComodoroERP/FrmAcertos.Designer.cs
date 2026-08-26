namespace ComodoroERP
{
    partial class FrmAcertos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlTopo = new Panel();
            lblSubtituloTela = new Label();
            lblTituloTela = new Label();
            pnlFiltros = new Panel();
            btnLimparFiltros = new Button();
            btnFiltrar = new Button();
            dtpDataFinal = new DateTimePicker();
            lblDataFinal = new Label();
            dtpDataInicial = new DateTimePicker();
            lblDataInicial = new Label();
            cmbStatus = new ComboBox();
            lblStatus = new Label();
            lblFiltroEscola = new Label();
            lblFiltros = new Label();
            pnlGrid = new Panel();
            dgvAcertos = new DataGridView();
            lblAcertos = new Label();
            btnEditar = new Button();
            btnExcluir = new Button();
            btnAtualizar = new Button();
            btnFechar = new Button();
            cmbFiltroEscola = new ComboBox();
            pnlTopo.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAcertos).BeginInit();
            SuspendLayout();
            // 
            // pnlTopo
            // 
            pnlTopo.BackColor = Color.SteelBlue;
            pnlTopo.Controls.Add(lblSubtituloTela);
            pnlTopo.Controls.Add(lblTituloTela);
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(1000, 75);
            pnlTopo.TabIndex = 0;
            // 
            // lblSubtituloTela
            // 
            lblSubtituloTela.AutoSize = true;
            lblSubtituloTela.Font = new Font("Segoe UI", 9F);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Location = new Point(27, 43);
            lblSubtituloTela.Name = "lblSubtituloTela";
            lblSubtituloTela.Size = new Size(314, 15);
            lblSubtituloTela.TabIndex = 1;
            lblSubtituloTela.Text = "Consulte acertos avulsos e marque pagamentos realizados";
            // 
            // lblTituloTela
            // 
            lblTituloTela.AutoSize = true;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15F);
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Location = new Point(25, 14);
            lblTituloTela.Name = "lblTituloTela";
            lblTituloTela.Size = new Size(136, 28);
            lblTituloTela.TabIndex = 0;
            lblTituloTela.Text = "VER ACERTOS";
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.BorderStyle = BorderStyle.FixedSingle;
            pnlFiltros.Controls.Add(cmbFiltroEscola);
            pnlFiltros.Controls.Add(btnLimparFiltros);
            pnlFiltros.Controls.Add(btnFiltrar);
            pnlFiltros.Controls.Add(dtpDataFinal);
            pnlFiltros.Controls.Add(lblDataFinal);
            pnlFiltros.Controls.Add(dtpDataInicial);
            pnlFiltros.Controls.Add(lblDataInicial);
            pnlFiltros.Controls.Add(cmbStatus);
            pnlFiltros.Controls.Add(lblStatus);
            pnlFiltros.Controls.Add(lblFiltroEscola);
            pnlFiltros.Controls.Add(lblFiltros);
            pnlFiltros.Location = new Point(20, 90);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(940, 125);
            pnlFiltros.TabIndex = 1;
            // 
            // btnLimparFiltros
            // 
            btnLimparFiltros.BackColor = Color.White;
            btnLimparFiltros.Cursor = Cursors.Hand;
            btnLimparFiltros.FlatAppearance.BorderColor = Color.Gainsboro;
            btnLimparFiltros.FlatStyle = FlatStyle.Flat;
            btnLimparFiltros.Font = new Font("Segoe UI Semibold", 10F);
            btnLimparFiltros.ForeColor = Color.FromArgb(45, 45, 45);
            btnLimparFiltros.Location = new Point(815, 65);
            btnLimparFiltros.Name = "btnLimparFiltros";
            btnLimparFiltros.Size = new Size(95, 35);
            btnLimparFiltros.TabIndex = 10;
            btnLimparFiltros.Text = "Limpar";
            btnLimparFiltros.UseVisualStyleBackColor = false;
            btnLimparFiltros.Click += btnLimparFiltros_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.White;
            btnFiltrar.Cursor = Cursors.Hand;
            btnFiltrar.FlatAppearance.BorderColor = Color.Gainsboro;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Segoe UI Semibold", 10F);
            btnFiltrar.ForeColor = Color.FromArgb(45, 45, 45);
            btnFiltrar.Location = new Point(705, 65);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(95, 35);
            btnFiltrar.TabIndex = 9;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // dtpDataFinal
            // 
            dtpDataFinal.Format = DateTimePickerFormat.Short;
            dtpDataFinal.Location = new Point(520, 72);
            dtpDataFinal.Name = "dtpDataFinal";
            dtpDataFinal.ShowCheckBox = true;
            dtpDataFinal.Size = new Size(140, 25);
            dtpDataFinal.TabIndex = 8;
            // 
            // lblDataFinal
            // 
            lblDataFinal.AutoSize = true;
            lblDataFinal.Location = new Point(520, 49);
            lblDataFinal.Name = "lblDataFinal";
            lblDataFinal.Size = new Size(73, 19);
            lblDataFinal.TabIndex = 7;
            lblDataFinal.Text = "Data Final:";
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.Format = DateTimePickerFormat.Short;
            dtpDataInicial.Location = new Point(360, 72);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.ShowCheckBox = true;
            dtpDataInicial.Size = new Size(140, 25);
            dtpDataInicial.TabIndex = 6;
            // 
            // lblDataInicial
            // 
            lblDataInicial.AutoSize = true;
            lblDataInicial.Location = new Point(360, 49);
            lblDataInicial.Name = "lblDataInicial";
            lblDataInicial.Size = new Size(79, 19);
            lblDataInicial.TabIndex = 5;
            lblDataInicial.Text = "Data Inicial:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(220, 72);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(120, 25);
            cmbStatus.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(220, 49);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 19);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status:";
            // 
            // lblFiltroEscola
            // 
            lblFiltroEscola.AutoSize = true;
            lblFiltroEscola.Location = new Point(20, 49);
            lblFiltroEscola.Name = "lblFiltroEscola";
            lblFiltroEscola.Size = new Size(49, 19);
            lblFiltroEscola.TabIndex = 1;
            lblFiltroEscola.Text = "Escola:";
            // 
            // lblFiltros
            // 
            lblFiltros.AutoSize = true;
            lblFiltros.Font = new Font("Segoe UI Semibold", 11F);
            lblFiltros.ForeColor = Color.FromArgb(35, 35, 35);
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
            pnlGrid.Controls.Add(dgvAcertos);
            pnlGrid.Controls.Add(lblAcertos);
            pnlGrid.Location = new Point(20, 235);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(940, 300);
            pnlGrid.TabIndex = 2;
            // 
            // dgvAcertos
            // 
            dgvAcertos.AllowUserToAddRows = false;
            dgvAcertos.AllowUserToDeleteRows = false;
            dgvAcertos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAcertos.BackgroundColor = Color.White;
            dgvAcertos.BorderStyle = BorderStyle.None;
            dgvAcertos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAcertos.Location = new Point(15, 45);
            dgvAcertos.MultiSelect = false;
            dgvAcertos.Name = "dgvAcertos";
            dgvAcertos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAcertos.Size = new Size(910, 235);
            dgvAcertos.TabIndex = 1;
            // 
            // lblAcertos
            // 
            lblAcertos.AutoSize = true;
            lblAcertos.Font = new Font("Segoe UI Semibold", 11F);
            lblAcertos.ForeColor = Color.FromArgb(35, 35, 35);
            lblAcertos.Location = new Point(15, 12);
            lblAcertos.Name = "lblAcertos";
            lblAcertos.Size = new Size(60, 20);
            lblAcertos.TabIndex = 0;
            lblAcertos.Text = "Acertos";
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.White;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatAppearance.BorderColor = Color.Gainsboro;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI Semibold", 10F);
            btnEditar.ForeColor = Color.FromArgb(45, 45, 45);
            btnEditar.Location = new Point(610, 555);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(110, 35);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = Color.IndianRed;
            btnExcluir.Cursor = Cursors.Hand;
            btnExcluir.FlatAppearance.BorderColor = Color.Firebrick;
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.Font = new Font("Segoe UI Semibold", 10F);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.Location = new Point(730, 555);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(110, 35);
            btnExcluir.TabIndex = 13;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.BackColor = Color.White;
            btnAtualizar.Cursor = Cursors.Hand;
            btnAtualizar.FlatAppearance.BorderColor = Color.Gainsboro;
            btnAtualizar.FlatStyle = FlatStyle.Flat;
            btnAtualizar.Font = new Font("Segoe UI Semibold", 10F);
            btnAtualizar.ForeColor = Color.FromArgb(45, 45, 45);
            btnAtualizar.Location = new Point(20, 555);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(110, 35);
            btnAtualizar.TabIndex = 14;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = false;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.White;
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.FlatAppearance.BorderColor = Color.Silver;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Segoe UI Semibold", 10F);
            btnFechar.ForeColor = Color.DimGray;
            btnFechar.Location = new Point(850, 555);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(110, 35);
            btnFechar.TabIndex = 15;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // cmbFiltroEscola
            // 
            cmbFiltroEscola.FormattingEnabled = true;
            cmbFiltroEscola.Location = new Point(20, 72);
            cmbFiltroEscola.Name = "cmbFiltroEscola";
            cmbFiltroEscola.Size = new Size(180, 25);
            cmbFiltroEscola.TabIndex = 11;
            // 
            // FrmAcertos
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(984, 611);
            Controls.Add(btnFechar);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(btnAtualizar);
            Controls.Add(pnlGrid);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlTopo);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAcertos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ver Acertos";
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAcertos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTopo;
        private Label lblSubtituloTela;
        private Label lblTituloTela;
        private Panel pnlFiltros;
        private Label lblFiltros;
        private Label lblFiltroEscola;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblDataInicial;
        private DateTimePicker dtpDataInicial;
        private Label lblDataFinal;
        private DateTimePicker dtpDataFinal;
        private Button btnFiltrar;
        private Button btnLimparFiltros;
        private Panel pnlGrid;
        private Label lblAcertos;
        private DataGridView dgvAcertos;
        private Button btnEditar;
        private Button btnExcluir;
        private Button btnAtualizar;
        private Button btnFechar;
        private ComboBox cmbFiltroEscola;
    }
}
