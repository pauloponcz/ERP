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
            label3 = new Label();
            cmbFiltroCategoria = new ComboBox();
            label8 = new Label();
            btnLimparFiltros = new Button();
            btnFiltrar = new Button();
            btnImportarLista = new Button();
            btnFechar = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvServicosPermitidos).BeginInit();
            SuspendLayout();

            // 
            // dgvServicosPermitidos
            // 
            dgvServicosPermitidos.AllowUserToAddRows = false;
            dgvServicosPermitidos.AllowUserToDeleteRows = false;
            dgvServicosPermitidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicosPermitidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServicosPermitidos.Location = new Point(21, 70);
            dgvServicosPermitidos.MultiSelect = false;
            dgvServicosPermitidos.Name = "dgvServicosPermitidos";
            dgvServicosPermitidos.ReadOnly = true;
            dgvServicosPermitidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicosPermitidos.Size = new Size(755, 296);
            dgvServicosPermitidos.TabIndex = 38;

            // 
            // txtFiltroServico
            // 
            txtFiltroServico.Location = new Point(272, 12);
            txtFiltroServico.Name = "txtFiltroServico";
            txtFiltroServico.Size = new Size(126, 23);
            txtFiltroServico.TabIndex = 37;

            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(224, 15);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 36;
            label3.Text = "Serviço:";

            // 
            // cmbFiltroCategoria
            // 
            cmbFiltroCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroCategoria.FormattingEnabled = true;
            cmbFiltroCategoria.Location = new Point(77, 12);
            cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            cmbFiltroCategoria.Size = new Size(136, 23);
            cmbFiltroCategoria.TabIndex = 35;

            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 15);
            label8.Name = "label8";
            label8.Size = new Size(61, 15);
            label8.TabIndex = 34;
            label8.Text = "Categoria:";

            // 
            // btnLimparFiltros
            // 
            btnLimparFiltros.Location = new Point(126, 41);
            btnLimparFiltros.Name = "btnLimparFiltros";
            btnLimparFiltros.Size = new Size(99, 23);
            btnLimparFiltros.TabIndex = 40;
            btnLimparFiltros.Text = "Limpar Filtros";
            btnLimparFiltros.UseVisualStyleBackColor = true;
            btnLimparFiltros.Click += btnLimparFiltros_Click;

            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(21, 41);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(99, 23);
            btnFiltrar.TabIndex = 39;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;

            // 
            // btnImportarLista
            // 
            btnImportarLista.Location = new Point(231, 41);
            btnImportarLista.Name = "btnImportarLista";
            btnImportarLista.Size = new Size(99, 23);
            btnImportarLista.TabIndex = 41;
            btnImportarLista.Text = "Importar Lista";
            btnImportarLista.UseVisualStyleBackColor = true;
            btnImportarLista.Click += btnImportarLista_Click;

            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(21, 372);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(99, 23);
            btnFechar.TabIndex = 42;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;

            // 
            // FrmServicosPermitidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnFechar);
            Controls.Add(btnImportarLista);
            Controls.Add(btnLimparFiltros);
            Controls.Add(btnFiltrar);
            Controls.Add(dgvServicosPermitidos);
            Controls.Add(txtFiltroServico);
            Controls.Add(label3);
            Controls.Add(cmbFiltroCategoria);
            Controls.Add(label8);
            Name = "FrmServicosPermitidos";
            Text = "Serviços Permitidos";

            ((System.ComponentModel.ISupportInitialize)dgvServicosPermitidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvServicosPermitidos;
        private TextBox txtFiltroServico;
        private Label label3;
        private ComboBox cmbFiltroCategoria;
        private Label label8;
        private Button btnLimparFiltros;
        private Button btnFiltrar;
        private Button btnImportarLista;
        private Button btnFechar;
    }
}