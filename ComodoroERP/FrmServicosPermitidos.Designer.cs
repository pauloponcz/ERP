namespace ComodoroERP
{
    partial class FrmServicosPermitidos
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
            dgvServicosPermitidos = new DataGridView();
            txtFiltroServico = new TextBox();
            lblFiltroServico = new Label();
            cmbFiltroCategoria = new ComboBox();
            lblFiltroCategoria = new Label();
            btnLimparFiltros = new Button();
            btnFiltrar = new Button();
            btnImportarLista = new Button();
            btnFechar = new Button();
            pnlTopo = new Panel();
            lblSubtituloTela = new Label();
            lblTituloTela = new Label();
            pnlFiltros = new Panel();
            lblFiltros = new Label();
            pnlGrid = new Panel();
            lblServicosPermitidos = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvServicosPermitidos).BeginInit();
            pnlTopo.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlGrid.SuspendLayout();
            SuspendLayout();
            // 
            // dgvServicosPermitidos
            // 
            dgvServicosPermitidos.AllowUserToAddRows = false;
            dgvServicosPermitidos.AllowUserToDeleteRows = false;
            dgvServicosPermitidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicosPermitidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServicosPermitidos.Location = new Point(15, 45);
            dgvServicosPermitidos.MultiSelect = false;
            dgvServicosPermitidos.Name = "dgvServicosPermitidos";
            dgvServicosPermitidos.ReadOnly = true;
            dgvServicosPermitidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicosPermitidos.Size = new Size(910, 235);
            dgvServicosPermitidos.TabIndex = 38;
            // 
            // txtFiltroServico
            // 
            txtFiltroServico.Location = new Point(310, 65);
            txtFiltroServico.Name = "txtFiltroServico";
            txtFiltroServico.Size = new Size(330, 25);
            txtFiltroServico.TabIndex = 37;
            // 
            // lblFiltroServico
            // 
            lblFiltroServico.AutoSize = true;
            lblFiltroServico.Location = new Point(310, 42);
            lblFiltroServico.Name = "lblFiltroServico";
            lblFiltroServico.Size = new Size(55, 19);
            lblFiltroServico.TabIndex = 36;
            lblFiltroServico.Text = "Serviço:";
            // 
            // cmbFiltroCategoria
            // 
            cmbFiltroCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroCategoria.FormattingEnabled = true;
            cmbFiltroCategoria.Location = new Point(20, 65);
            cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            cmbFiltroCategoria.Size = new Size(260, 25);
            cmbFiltroCategoria.TabIndex = 35;
            // 
            // lblFiltroCategoria
            // 
            lblFiltroCategoria.AutoSize = true;
            lblFiltroCategoria.Location = new Point(20, 42);
            lblFiltroCategoria.Name = "lblFiltroCategoria";
            lblFiltroCategoria.Size = new Size(71, 19);
            lblFiltroCategoria.TabIndex = 34;
            lblFiltroCategoria.Text = "Categoria:";
            // 
            // btnLimparFiltros
            // 
            btnLimparFiltros.Location = new Point(815, 58);
            btnLimparFiltros.Name = "btnLimparFiltros";
            btnLimparFiltros.Size = new Size(95, 35);
            btnLimparFiltros.TabIndex = 40;
            btnLimparFiltros.Text = "Limpar";
            btnLimparFiltros.UseVisualStyleBackColor = true;
            btnLimparFiltros.Click += btnLimparFiltros_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(705, 58);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(95, 35);
            btnFiltrar.TabIndex = 39;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnImportarLista
            // 
            btnImportarLista.Location = new Point(20, 540);
            btnImportarLista.Name = "btnImportarLista";
            btnImportarLista.Size = new Size(130, 35);
            btnImportarLista.TabIndex = 41;
            btnImportarLista.Text = "Importar Lista";
            btnImportarLista.UseVisualStyleBackColor = true;
            btnImportarLista.Click += btnImportarLista_Click;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(840, 540);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(120, 35);
            btnFechar.TabIndex = 42;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // pnlTopo
            // 
            pnlTopo.BackColor = Color.SteelBlue;
            pnlTopo.Controls.Add(lblSubtituloTela);
            pnlTopo.Controls.Add(lblTituloTela);
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(1000, 75);
            pnlTopo.TabIndex = 43;
            // 
            // lblSubtituloTela
            // 
            lblSubtituloTela.AutoSize = true;
            lblSubtituloTela.Font = new Font("Segoe UI", 9F);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Location = new Point(27, 43);
            lblSubtituloTela.Name = "lblSubtituloTela";
            lblSubtituloTela.Size = new Size(369, 15);
            lblSubtituloTela.TabIndex = 1;
            lblSubtituloTela.Text = "Consulte e importe a lista de serviços permitidos para os orçamentos";
            // 
            // lblTituloTela
            // 
            lblTituloTela.AutoSize = true;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15F);
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Location = new Point(25, 14);
            lblTituloTela.Name = "lblTituloTela";
            lblTituloTela.Size = new Size(223, 28);
            lblTituloTela.TabIndex = 0;
            lblTituloTela.Text = "SERVIÇOS PERMITIDOS";
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.BorderStyle = BorderStyle.FixedSingle;
            pnlFiltros.Controls.Add(lblFiltros);
            pnlFiltros.Controls.Add(lblFiltroCategoria);
            pnlFiltros.Controls.Add(cmbFiltroCategoria);
            pnlFiltros.Controls.Add(lblFiltroServico);
            pnlFiltros.Controls.Add(btnLimparFiltros);
            pnlFiltros.Controls.Add(txtFiltroServico);
            pnlFiltros.Controls.Add(btnFiltrar);
            pnlFiltros.Location = new Point(20, 90);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(940, 115);
            pnlFiltros.TabIndex = 44;
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
            pnlGrid.Controls.Add(lblServicosPermitidos);
            pnlGrid.Controls.Add(dgvServicosPermitidos);
            pnlGrid.Location = new Point(20, 220);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(940, 300);
            pnlGrid.TabIndex = 45;
            // 
            // lblServicosPermitidos
            // 
            lblServicosPermitidos.AutoSize = true;
            lblServicosPermitidos.Font = new Font("Segoe UI Semibold", 11F);
            lblServicosPermitidos.ForeColor = Color.DimGray;
            lblServicosPermitidos.Location = new Point(15, 12);
            lblServicosPermitidos.Name = "lblServicosPermitidos";
            lblServicosPermitidos.Size = new Size(142, 20);
            lblServicosPermitidos.TabIndex = 0;
            lblServicosPermitidos.Text = "Serviços Permitidos";
            // 
            // FrmServicosPermitidos
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(984, 589);
            Controls.Add(pnlGrid);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlTopo);
            Controls.Add(btnFechar);
            Controls.Add(btnImportarLista);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmServicosPermitidos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Serviços Permitidos";
            ((System.ComponentModel.ISupportInitialize)dgvServicosPermitidos).EndInit();
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlGrid.ResumeLayout(false);
            pnlGrid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvServicosPermitidos;
        private TextBox txtFiltroServico;
        private Label lblFiltroServico;
        private ComboBox cmbFiltroCategoria;
        private Label lblFiltroCategoria;
        private Button btnLimparFiltros;
        private Button btnFiltrar;
        private Button btnImportarLista;
        private Button btnFechar;
        private Panel pnlTopo;
        private Label lblSubtituloTela;
        private Label lblTituloTela;
        private Panel pnlFiltros;
        private Label lblFiltros;
        private Panel pnlGrid;
        private Label lblServicosPermitidos;
    }
}