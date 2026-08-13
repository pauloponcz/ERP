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
            groupBox1 = new GroupBox();
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
            groupBox2 = new GroupBox();
            dgvItens = new DataGridView();
            btnGerarPdfs = new Button();
            btnFechar = new Button();
            btnAbrirPastaPdfs = new Button();
            btnEditarOrcamento = new Button();
            btnAdicionarItem = new Button();
            btnRemoverItem = new Button();
            label1 = new Label();
            label2 = new Label();
            btnEditarItem = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItens).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblValorNota3);
            groupBox1.Controls.Add(lblValorNota2);
            groupBox1.Controls.Add(lblValorNota1);
            groupBox1.Controls.Add(lblStatus);
            groupBox1.Controls.Add(lblTitulo);
            groupBox1.Controls.Add(lblData);
            groupBox1.Controls.Add(lblEndereco);
            groupBox1.Controls.Add(lblCnpj);
            groupBox1.Controls.Add(lblCliente);
            groupBox1.Controls.Add(lblId);
            groupBox1.Location = new Point(16, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(690, 204);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "DETALHES DO ORÇAMENTO";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // lblValorNota3
            // 
            lblValorNota3.AutoSize = true;
            lblValorNota3.Location = new Point(6, 179);
            lblValorNota3.Name = "lblValorNota3";
            lblValorNota3.Size = new Size(38, 15);
            lblValorNota3.TabIndex = 9;
            lblValorNota3.Text = "label1";
            // 
            // lblValorNota2
            // 
            lblValorNota2.AutoSize = true;
            lblValorNota2.Location = new Point(6, 164);
            lblValorNota2.Name = "lblValorNota2";
            lblValorNota2.Size = new Size(38, 15);
            lblValorNota2.TabIndex = 8;
            lblValorNota2.Text = "label1";
            // 
            // lblValorNota1
            // 
            lblValorNota1.AutoSize = true;
            lblValorNota1.Location = new Point(6, 149);
            lblValorNota1.Name = "lblValorNota1";
            lblValorNota1.Size = new Size(38, 15);
            lblValorNota1.TabIndex = 7;
            lblValorNota1.Text = "label1";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(6, 120);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(38, 15);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "label1";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(6, 105);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(38, 15);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "label1";
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Location = new Point(6, 90);
            lblData.Name = "lblData";
            lblData.Size = new Size(38, 15);
            lblData.TabIndex = 4;
            lblData.Text = "label1";
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.Location = new Point(6, 75);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(38, 15);
            lblEndereco.TabIndex = 3;
            lblEndereco.Text = "label1";
            // 
            // lblCnpj
            // 
            lblCnpj.AutoSize = true;
            lblCnpj.Location = new Point(6, 60);
            lblCnpj.Name = "lblCnpj";
            lblCnpj.Size = new Size(38, 15);
            lblCnpj.TabIndex = 2;
            lblCnpj.Text = "label1";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(6, 45);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(38, 15);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "label1";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(6, 30);
            lblId.Name = "lblId";
            lblId.Size = new Size(38, 15);
            lblId.TabIndex = 0;
            lblId.Text = "label1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvItens);
            groupBox2.Location = new Point(16, 215);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(690, 187);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "ITENS DO ORÇAMENTO";
            // 
            // dgvItens
            // 
            dgvItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItens.Location = new Point(6, 22);
            dgvItens.Name = "dgvItens";
            dgvItens.Size = new Size(678, 154);
            dgvItens.TabIndex = 0;
            // 
            // btnGerarPdfs
            // 
            btnGerarPdfs.Location = new Point(276, 443);
            btnGerarPdfs.Name = "btnGerarPdfs";
            btnGerarPdfs.Size = new Size(90, 26);
            btnGerarPdfs.TabIndex = 11;
            btnGerarPdfs.Text = "Gerar PDFs";
            btnGerarPdfs.UseVisualStyleBackColor = true;
            btnGerarPdfs.Click += btnGerarPdfs_Click;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(616, 475);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(90, 26);
            btnFechar.TabIndex = 12;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // btnAbrirPastaPdfs
            // 
            btnAbrirPastaPdfs.Location = new Point(372, 443);
            btnAbrirPastaPdfs.Name = "btnAbrirPastaPdfs";
            btnAbrirPastaPdfs.Size = new Size(117, 26);
            btnAbrirPastaPdfs.TabIndex = 13;
            btnAbrirPastaPdfs.Text = "Abrir Pasta PDFs";
            btnAbrirPastaPdfs.UseVisualStyleBackColor = true;
            btnAbrirPastaPdfs.Click += btnAbrirPastaPdfs_Click;
            // 
            // btnEditarOrcamento
            // 
            btnEditarOrcamento.Location = new Point(153, 443);
            btnEditarOrcamento.Name = "btnEditarOrcamento";
            btnEditarOrcamento.Size = new Size(117, 26);
            btnEditarOrcamento.TabIndex = 14;
            btnEditarOrcamento.Text = "Editar Orçamento";
            btnEditarOrcamento.UseVisualStyleBackColor = true;
            btnEditarOrcamento.Click += btnEditarOrcamento_Click;
            // 
            // btnAdicionarItem
            // 
            btnAdicionarItem.Location = new Point(153, 408);
            btnAdicionarItem.Name = "btnAdicionarItem";
            btnAdicionarItem.Size = new Size(101, 26);
            btnAdicionarItem.TabIndex = 15;
            btnAdicionarItem.Text = "Adicionar Item";
            btnAdicionarItem.UseVisualStyleBackColor = true;
            btnAdicionarItem.Click += btnAdicionarItem_Click;
            // 
            // btnRemoverItem
            // 
            btnRemoverItem.Location = new Point(260, 408);
            btnRemoverItem.Name = "btnRemoverItem";
            btnRemoverItem.Size = new Size(100, 26);
            btnRemoverItem.TabIndex = 16;
            btnRemoverItem.Text = "Remover Item";
            btnRemoverItem.UseVisualStyleBackColor = true;
            btnRemoverItem.Click += btnRemoverItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 414);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 17;
            label1.Text = "Ações dos itens:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 449);
            label2.Name = "label2";
            label2.Size = new Size(130, 15);
            label2.TabIndex = 18;
            label2.Text = "Ações dos orçamentos:";
            // 
            // btnEditarItem
            // 
            btnEditarItem.Location = new Point(366, 408);
            btnEditarItem.Name = "btnEditarItem";
            btnEditarItem.Size = new Size(100, 26);
            btnEditarItem.TabIndex = 19;
            btnEditarItem.Text = "Editar Item";
            btnEditarItem.UseVisualStyleBackColor = true;
            btnEditarItem.Click += btnEditarItem_Click;
            // 
            // FrmDetalhesOrcamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(721, 513);
            Controls.Add(btnEditarItem);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRemoverItem);
            Controls.Add(btnAdicionarItem);
            Controls.Add(btnEditarOrcamento);
            Controls.Add(btnAbrirPastaPdfs);
            Controls.Add(btnFechar);
            Controls.Add(btnGerarPdfs);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmDetalhesOrcamento";
            Text = "Detalhes do Orçamento";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvItens).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
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
        private GroupBox groupBox2;
        private DataGridView dgvItens;
        private Button btnGerarPdfs;
        private Button btnFechar;
        private Button btnAbrirPastaPdfs;
        private Button btnEditarOrcamento;
        private Button btnAdicionarItem;
        private Button btnRemoverItem;
        private Label label1;
        private Label label2;
        private Button btnEditarItem;
    }
}