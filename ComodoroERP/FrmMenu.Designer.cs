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
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // btnNovoOrcamento
            // 
            btnNovoOrcamento.Location = new Point(72, 89);
            btnNovoOrcamento.Name = "btnNovoOrcamento";
            btnNovoOrcamento.Size = new Size(130, 45);
            btnNovoOrcamento.TabIndex = 0;
            btnNovoOrcamento.Text = "Novo Orçamento";
            btnNovoOrcamento.UseVisualStyleBackColor = true;
            btnNovoOrcamento.Click += btnNovoOrcamento_Click;
            // 
            // btnVerOrcamentos
            // 
            btnVerOrcamentos.Location = new Point(72, 140);
            btnVerOrcamentos.Name = "btnVerOrcamentos";
            btnVerOrcamentos.Size = new Size(130, 45);
            btnVerOrcamentos.TabIndex = 1;
            btnVerOrcamentos.Text = "Ver Orçamentos";
            btnVerOrcamentos.UseVisualStyleBackColor = true;
            btnVerOrcamentos.Click += btnVerOrcamentos_Click;
            // 
            // btnItensLancados
            // 
            btnItensLancados.Location = new Point(72, 191);
            btnItensLancados.Name = "btnItensLancados";
            btnItensLancados.Size = new Size(130, 45);
            btnItensLancados.TabIndex = 2;
            btnItensLancados.Text = "Itens Lançados";
            btnItensLancados.UseVisualStyleBackColor = true;
            btnItensLancados.Click += btnItensLancados_Click;
            // 
            // btnServicosPermitidos
            // 
            btnServicosPermitidos.Location = new Point(72, 242);
            btnServicosPermitidos.Name = "btnServicosPermitidos";
            btnServicosPermitidos.Size = new Size(130, 45);
            btnServicosPermitidos.TabIndex = 3;
            btnServicosPermitidos.Text = "Serviços Permitidos";
            btnServicosPermitidos.UseVisualStyleBackColor = true;
            btnServicosPermitidos.Click += btnServicosPermitidos_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Location = new Point(72, 293);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(130, 45);
            btnDashboard.TabIndex = 4;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnSair
            // 
            btnSair.Location = new Point(72, 344);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(130, 45);
            btnSair.TabIndex = 5;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(72, 47);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(100, 15);
            lblTitulo.TabIndex = 6;
            lblTitulo.Text = "COMODORO ERP";
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTitulo);
            Controls.Add(btnSair);
            Controls.Add(btnDashboard);
            Controls.Add(btnServicosPermitidos);
            Controls.Add(btnItensLancados);
            Controls.Add(btnVerOrcamentos);
            Controls.Add(btnNovoOrcamento);
            Name = "FrmMenu";
            Text = "FrmMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNovoOrcamento;
        private Button btnVerOrcamentos;
        private Button btnItensLancados;
        private Button btnServicosPermitidos;
        private Button btnDashboard;
        private Button btnSair;
        private Label lblTitulo;
    }
}