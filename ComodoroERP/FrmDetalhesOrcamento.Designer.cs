namespace ComodoroERP
{
    partial class FrmDetalhesOrcamento
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
            lblValorNota3 = new Label();
            lblValorNota2 = new Label();
            lblValorNota1 = new Label();
            lblStatus = new Label();
            lblTitulo = new Label();
            lblData = new Label();
            lblEndereco = new Label();
            lblCnpj = new Label();
            lblCliente = new Label();
            lblId = new Label();
            dgvItens = new DataGridView();
            btnGerarPdfs = new Button();
            btnFechar = new Button();
            btnAbrirPastaPdfs = new Button();
            btnEditarOrcamento = new Button();
            btnAdicionarItem = new Button();
            btnRemoverItem = new Button();
            btnEditarItem = new Button();
            pnlTopo = new Panel();
            lblTituloTela = new Label();
            lblSubtituloTela = new Label();
            pnlDados = new Panel();
            lblDadosOrcamento = new Label();
            pnlItens = new Panel();
            lblItensOrcamento = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvItens).BeginInit();
            pnlTopo.SuspendLayout();
            pnlDados.SuspendLayout();
            pnlItens.SuspendLayout();
            SuspendLayout();
            // 
            // lblValorNota3
            // 
            lblValorNota3.AutoSize = true;
            lblValorNota3.Font = new Font("Segoe UI Semibold", 10F);
            lblValorNota3.Location = new Point(820, 105);
            lblValorNota3.Name = "lblValorNota3";
            lblValorNota3.Size = new Size(107, 19);
            lblValorNota3.TabIndex = 9;
            lblValorNota3.Text = "Nota 3: R$ 0,00";
            // 
            // lblValorNota2
            // 
            lblValorNota2.AutoSize = true;
            lblValorNota2.Font = new Font("Segoe UI Semibold", 10F);
            lblValorNota2.Location = new Point(670, 105);
            lblValorNota2.Name = "lblValorNota2";
            lblValorNota2.Size = new Size(107, 19);
            lblValorNota2.TabIndex = 8;
            lblValorNota2.Text = "Nota 2: R$ 0,00";
            // 
            // lblValorNota1
            // 
            lblValorNota1.AutoSize = true;
            lblValorNota1.Font = new Font("Segoe UI Semibold", 10F);
            lblValorNota1.Location = new Point(520, 105);
            lblValorNota1.Name = "lblValorNota1";
            lblValorNota1.Size = new Size(105, 19);
            lblValorNota1.TabIndex = 7;
            lblValorNota1.Text = "Nota 1: R$ 0,00";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(160, 45);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 19);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Status:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(20, 135);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(46, 19);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "Título:";
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Location = new Point(390, 45);
            lblData.Name = "lblData";
            lblData.Size = new Size(41, 19);
            lblData.TabIndex = 4;
            lblData.Text = "Data:";
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.Location = new Point(20, 105);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(68, 19);
            lblEndereco.TabIndex = 3;
            lblEndereco.Text = "Endereço:";
            // 
            // lblCnpj
            // 
            lblCnpj.AutoSize = true;
            lblCnpj.Location = new Point(520, 75);
            lblCnpj.Name = "lblCnpj";
            lblCnpj.Size = new Size(43, 19);
            lblCnpj.TabIndex = 2;
            lblCnpj.Text = "CNPJ:";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(20, 75);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(54, 19);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Cliente:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(20, 45);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 19);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            // 
            // dgvItens
            // 
            dgvItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItens.Location = new Point(15, 45);
            dgvItens.Name = "dgvItens";
            dgvItens.Size = new Size(960, 220);
            dgvItens.TabIndex = 0;
            // 
            // btnGerarPdfs
            // 
            btnGerarPdfs.Location = new Point(560, 590);
            btnGerarPdfs.Name = "btnGerarPdfs";
            btnGerarPdfs.Size = new Size(110, 35);
            btnGerarPdfs.TabIndex = 11;
            btnGerarPdfs.Text = "Gerar PDFs";
            btnGerarPdfs.UseVisualStyleBackColor = true;
            btnGerarPdfs.Click += btnGerarPdfs_Click;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(890, 590);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(120, 35);
            btnFechar.TabIndex = 12;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // btnAbrirPastaPdfs
            // 
            btnAbrirPastaPdfs.Location = new Point(680, 590);
            btnAbrirPastaPdfs.Name = "btnAbrirPastaPdfs";
            btnAbrirPastaPdfs.Size = new Size(145, 35);
            btnAbrirPastaPdfs.TabIndex = 13;
            btnAbrirPastaPdfs.Text = "Abrir Pasta PDFs";
            btnAbrirPastaPdfs.UseVisualStyleBackColor = true;
            btnAbrirPastaPdfs.Click += btnAbrirPastaPdfs_Click;
            // 
            // btnEditarOrcamento
            // 
            btnEditarOrcamento.Location = new Point(405, 590);
            btnEditarOrcamento.Name = "btnEditarOrcamento";
            btnEditarOrcamento.Size = new Size(145, 35);
            btnEditarOrcamento.TabIndex = 14;
            btnEditarOrcamento.Text = "Editar Orçamento";
            btnEditarOrcamento.UseVisualStyleBackColor = true;
            btnEditarOrcamento.Click += btnEditarOrcamento_Click;
            // 
            // btnAdicionarItem
            // 
            btnAdicionarItem.Location = new Point(20, 590);
            btnAdicionarItem.Name = "btnAdicionarItem";
            btnAdicionarItem.Size = new Size(125, 35);
            btnAdicionarItem.TabIndex = 15;
            btnAdicionarItem.Text = "Adicionar Item";
            btnAdicionarItem.UseVisualStyleBackColor = true;
            btnAdicionarItem.Click += btnAdicionarItem_Click;
            // 
            // btnRemoverItem
            // 
            btnRemoverItem.Location = new Point(275, 590);
            btnRemoverItem.Name = "btnRemoverItem";
            btnRemoverItem.Size = new Size(120, 35);
            btnRemoverItem.TabIndex = 16;
            btnRemoverItem.Text = "Remover Item";
            btnRemoverItem.UseVisualStyleBackColor = true;
            btnRemoverItem.Click += btnRemoverItem_Click;
            // 
            // btnEditarItem
            // 
            btnEditarItem.Location = new Point(155, 590);
            btnEditarItem.Name = "btnEditarItem";
            btnEditarItem.Size = new Size(110, 35);
            btnEditarItem.TabIndex = 19;
            btnEditarItem.Text = "Editar Item";
            btnEditarItem.UseVisualStyleBackColor = true;
            btnEditarItem.Click += btnEditarItem_Click;
            // 
            // pnlTopo
            // 
            pnlTopo.BackColor = Color.SteelBlue;
            pnlTopo.Controls.Add(lblSubtituloTela);
            pnlTopo.Controls.Add(lblTituloTela);
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(1050, 75);
            pnlTopo.TabIndex = 20;
            // 
            // lblTituloTela
            // 
            lblTituloTela.AutoSize = true;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15F);
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Location = new Point(25, 14);
            lblTituloTela.Name = "lblTituloTela";
            lblTituloTela.Size = new Size(266, 28);
            lblTituloTela.TabIndex = 21;
            lblTituloTela.Text = "DETALHES DO ORÇAMENTO";
            // 
            // lblSubtituloTela
            // 
            lblSubtituloTela.AutoSize = true;
            lblSubtituloTela.Font = new Font("Segoe UI", 9F);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Location = new Point(27, 43);
            lblSubtituloTela.Name = "lblSubtituloTela";
            lblSubtituloTela.Size = new Size(348, 15);
            lblSubtituloTela.TabIndex = 22;
            lblSubtituloTela.Text = "Visualize os dados, itens e ações disponíveis para este orçamento";
            // 
            // pnlDados
            // 
            pnlDados.BackColor = Color.White;
            pnlDados.BorderStyle = BorderStyle.FixedSingle;
            pnlDados.Controls.Add(lblValorNota3);
            pnlDados.Controls.Add(lblDadosOrcamento);
            pnlDados.Controls.Add(lblValorNota2);
            pnlDados.Controls.Add(lblId);
            pnlDados.Controls.Add(lblValorNota1);
            pnlDados.Controls.Add(lblEndereco);
            pnlDados.Controls.Add(lblStatus);
            pnlDados.Controls.Add(lblCliente);
            pnlDados.Controls.Add(lblTitulo);
            pnlDados.Controls.Add(lblCnpj);
            pnlDados.Controls.Add(lblData);
            pnlDados.Location = new Point(20, 90);
            pnlDados.Name = "pnlDados";
            pnlDados.Size = new Size(990, 180);
            pnlDados.TabIndex = 21;
            // 
            // lblDadosOrcamento
            // 
            lblDadosOrcamento.AutoSize = true;
            lblDadosOrcamento.Font = new Font("Segoe UI Semibold", 11F);
            lblDadosOrcamento.ForeColor = Color.DimGray;
            lblDadosOrcamento.Location = new Point(15, 12);
            lblDadosOrcamento.Name = "lblDadosOrcamento";
            lblDadosOrcamento.Size = new Size(154, 20);
            lblDadosOrcamento.TabIndex = 0;
            lblDadosOrcamento.Text = "Dados do Orçamento";
            // 
            // pnlItens
            // 
            pnlItens.BackColor = Color.White;
            pnlItens.BorderStyle = BorderStyle.FixedSingle;
            pnlItens.Controls.Add(dgvItens);
            pnlItens.Controls.Add(lblItensOrcamento);
            pnlItens.Location = new Point(20, 285);
            pnlItens.Name = "pnlItens";
            pnlItens.Size = new Size(990, 285);
            pnlItens.TabIndex = 22;
            // 
            // lblItensOrcamento
            // 
            lblItensOrcamento.AutoSize = true;
            lblItensOrcamento.Font = new Font("Segoe UI Semibold", 11F);
            lblItensOrcamento.ForeColor = Color.DimGray;
            lblItensOrcamento.Location = new Point(15, 12);
            lblItensOrcamento.Name = "lblItensOrcamento";
            lblItensOrcamento.Size = new Size(143, 20);
            lblItensOrcamento.TabIndex = 0;
            lblItensOrcamento.Text = "Itens do Orçamento";
            // 
            // FrmDetalhesOrcamento
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1034, 661);
            Controls.Add(pnlItens);
            Controls.Add(pnlDados);
            Controls.Add(pnlTopo);
            Controls.Add(btnEditarItem);
            Controls.Add(btnRemoverItem);
            Controls.Add(btnAdicionarItem);
            Controls.Add(btnEditarOrcamento);
            Controls.Add(btnAbrirPastaPdfs);
            Controls.Add(btnFechar);
            Controls.Add(btnGerarPdfs);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmDetalhesOrcamento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalhes do Orçamento";
            ((System.ComponentModel.ISupportInitialize)dgvItens).EndInit();
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlDados.ResumeLayout(false);
            pnlDados.PerformLayout();
            pnlItens.ResumeLayout(false);
            pnlItens.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblId;
        private Label lblValorNota3;
        private Label lblValorNota2;
        private Label lblValorNota1;
        private Label lblStatus;
        private Label lblTitulo;
        private Label lblData;
        private Label lblEndereco;
        private Label lblCnpj;
        private Label lblCliente;
        private DataGridView dgvItens;
        private Button btnGerarPdfs;
        private Button btnFechar;
        private Button btnAbrirPastaPdfs;
        private Button btnEditarOrcamento;
        private Button btnAdicionarItem;
        private Button btnRemoverItem;
        private Button btnEditarItem;
        private Panel pnlTopo;
        private Label lblSubtituloTela;
        private Label lblTituloTela;
        private Panel pnlDados;
        private Label lblDadosOrcamento;
        private Panel pnlItens;
        private Label lblItensOrcamento;
    }
}