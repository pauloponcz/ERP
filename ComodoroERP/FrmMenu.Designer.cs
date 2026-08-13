namespace ComodoroERP
{
    partial class FrmMenu
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
            btnNovoOrcamento = new Button();
            btnVerOrcamentos = new Button();
            btnItensLancados = new Button();
            btnServicosPermitidos = new Button();
            btnDashboard = new Button();
            btnSair = new Button();
            groupBox1 = new GroupBox();
            btnConfiguracoes = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnNovoOrcamento
            // 
            btnNovoOrcamento.Location = new Point(25, 17);
            btnNovoOrcamento.Name = "btnNovoOrcamento";
            btnNovoOrcamento.Size = new Size(130, 45);
            btnNovoOrcamento.TabIndex = 0;
            btnNovoOrcamento.Text = "Novo Orçamento";
            btnNovoOrcamento.UseVisualStyleBackColor = true;
            btnNovoOrcamento.Click += btnNovoOrcamento_Click;
            // 
            // btnVerOrcamentos
            // 
            btnVerOrcamentos.Location = new Point(25, 68);
            btnVerOrcamentos.Name = "btnVerOrcamentos";
            btnVerOrcamentos.Size = new Size(130, 45);
            btnVerOrcamentos.TabIndex = 1;
            btnVerOrcamentos.Text = "Ver Orçamentos";
            btnVerOrcamentos.UseVisualStyleBackColor = true;
            btnVerOrcamentos.Click += btnVerOrcamentos_Click;
            // 
            // btnItensLancados
            // 
            btnItensLancados.Location = new Point(25, 119);
            btnItensLancados.Name = "btnItensLancados";
            btnItensLancados.Size = new Size(130, 45);
            btnItensLancados.TabIndex = 2;
            btnItensLancados.Text = "Itens Lançados";
            btnItensLancados.UseVisualStyleBackColor = true;
            btnItensLancados.Click += btnItensLancados_Click;
            // 
            // btnServicosPermitidos
            // 
            btnServicosPermitidos.Location = new Point(25, 170);
            btnServicosPermitidos.Name = "btnServicosPermitidos";
            btnServicosPermitidos.Size = new Size(130, 45);
            btnServicosPermitidos.TabIndex = 3;
            btnServicosPermitidos.Text = "Serviços Permitidos";
            btnServicosPermitidos.UseVisualStyleBackColor = true;
            btnServicosPermitidos.Click += btnServicosPermitidos_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Location = new Point(25, 221);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(130, 45);
            btnDashboard.TabIndex = 4;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnSair
            // 
            btnSair.Location = new Point(37, 353);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(130, 45);
            btnSair.TabIndex = 5;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDashboard);
            groupBox1.Controls.Add(btnServicosPermitidos);
            groupBox1.Controls.Add(btnItensLancados);
            groupBox1.Controls.Add(btnVerOrcamentos);
            groupBox1.Controls.Add(btnNovoOrcamento);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(189, 274);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "COMODORO ERP";
            // 
            // btnConfiguracoes
            // 
            btnConfiguracoes.Location = new Point(37, 302);
            btnConfiguracoes.Name = "btnConfiguracoes";
            btnConfiguracoes.Size = new Size(130, 45);
            btnConfiguracoes.TabIndex = 8;
            btnConfiguracoes.Text = "Configurações";
            btnConfiguracoes.UseVisualStyleBackColor = true;
            btnConfiguracoes.Click += btnConfiguracoes_Click;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(223, 450);
            Controls.Add(btnConfiguracoes);
            Controls.Add(groupBox1);
            Controls.Add(btnSair);
            Name = "FrmMenu";
            Text = "FrmMenu";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnNovoOrcamento;
        private Button btnVerOrcamentos;
        private Button btnItensLancados;
        private Button btnServicosPermitidos;
        private Button btnDashboard;
        private Button btnSair;
        private GroupBox groupBox1;
        private Button btnConfiguracoes;
    }
}