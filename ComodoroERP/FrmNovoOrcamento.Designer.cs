namespace ComodoroERP
{
    partial class FrmNovoOrcamento
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
            grpServicos = new GroupBox();
            label17 = new Label();
            txtObservacaoServico = new TextBox();
            btnCancelar = new Button();
            btnSalvarOrcamento = new Button();
            btnRemoverServico = new Button();
            btnAdicionarServico = new Button();
            dgvServicos = new DataGridView();
            chkCortesia = new CheckBox();
            numValorUnitario = new NumericUpDown();
            label16 = new Label();
            numQuantidade = new NumericUpDown();
            label15 = new Label();
            label14 = new Label();
            cmbServicoPermitido = new ComboBox();
            txtDescricaoServico = new TextBox();
            label13 = new Label();
            cmbCategoria = new ComboBox();
            label12 = new Label();
            grpCliente = new GroupBox();
            label5 = new Label();
            txtCidadeEstado = new TextBox();
            label4 = new Label();
            txtBairroCep = new TextBox();
            label3 = new Label();
            txtEndereco = new TextBox();
            label2 = new Label();
            txtCnpj = new TextBox();
            label1 = new Label();
            txtCliente = new TextBox();
            grpOrcamento = new GroupBox();
            numVariacaoNota3 = new NumericUpDown();
            numVariacaoNota2 = new NumericUpDown();
            cmbStatus = new ComboBox();
            dtpDataOrcamento = new DateTimePicker();
            label11 = new Label();
            txtObservacao = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtTitulo = new TextBox();
            grpServicos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServicos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numValorUnitario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).BeginInit();
            grpCliente.SuspendLayout();
            grpOrcamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota2).BeginInit();
            SuspendLayout();
            // 
            // grpServicos
            // 
            grpServicos.Controls.Add(label17);
            grpServicos.Controls.Add(txtObservacaoServico);
            grpServicos.Controls.Add(btnCancelar);
            grpServicos.Controls.Add(btnSalvarOrcamento);
            grpServicos.Controls.Add(btnRemoverServico);
            grpServicos.Controls.Add(btnAdicionarServico);
            grpServicos.Controls.Add(dgvServicos);
            grpServicos.Controls.Add(chkCortesia);
            grpServicos.Controls.Add(numValorUnitario);
            grpServicos.Controls.Add(label16);
            grpServicos.Controls.Add(numQuantidade);
            grpServicos.Controls.Add(label15);
            grpServicos.Controls.Add(label14);
            grpServicos.Controls.Add(cmbServicoPermitido);
            grpServicos.Controls.Add(txtDescricaoServico);
            grpServicos.Controls.Add(label13);
            grpServicos.Controls.Add(cmbCategoria);
            grpServicos.Controls.Add(label12);
            grpServicos.Location = new Point(35, 409);
            grpServicos.Name = "grpServicos";
            grpServicos.Size = new Size(577, 466);
            grpServicos.TabIndex = 0;
            grpServicos.TabStop = false;
            grpServicos.Text = "Serviços do Orçamento";
            grpServicos.Enter += groupBox1_Enter;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(6, 196);
            label17.Name = "label17";
            label17.Size = new Size(110, 15);
            label17.TabIndex = 29;
            label17.Text = "Observação Serviço";
            // 
            // txtObservacaoServico
            // 
            txtObservacaoServico.Location = new Point(145, 192);
            txtObservacaoServico.Name = "txtObservacaoServico";
            txtObservacaoServico.Size = new Size(426, 23);
            txtObservacaoServico.TabIndex = 28;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(135, 427);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 23);
            btnCancelar.TabIndex = 27;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvarOrcamento
            // 
            btnSalvarOrcamento.Location = new Point(9, 427);
            btnSalvarOrcamento.Name = "btnSalvarOrcamento";
            btnSalvarOrcamento.Size = new Size(120, 23);
            btnSalvarOrcamento.TabIndex = 26;
            btnSalvarOrcamento.Text = "Salvar Orçamento";
            btnSalvarOrcamento.UseVisualStyleBackColor = true;
            btnSalvarOrcamento.Click += btnSalvarOrcamento_Click;
            // 
            // btnRemoverServico
            // 
            btnRemoverServico.Location = new Point(135, 276);
            btnRemoverServico.Name = "btnRemoverServico";
            btnRemoverServico.Size = new Size(120, 23);
            btnRemoverServico.TabIndex = 25;
            btnRemoverServico.Text = "Remover Serviço";
            btnRemoverServico.UseVisualStyleBackColor = true;
            btnRemoverServico.Click += btnRemoverServico_Click;
            // 
            // btnAdicionarServico
            // 
            btnAdicionarServico.Location = new Point(9, 276);
            btnAdicionarServico.Name = "btnAdicionarServico";
            btnAdicionarServico.Size = new Size(120, 23);
            btnAdicionarServico.TabIndex = 24;
            btnAdicionarServico.Text = "Adicionar Serviço";
            btnAdicionarServico.UseVisualStyleBackColor = true;
            btnAdicionarServico.Click += btnAdicionarServico_Click;
            // 
            // dgvServicos
            // 
            dgvServicos.AllowUserToAddRows = false;
            dgvServicos.AllowUserToDeleteRows = false;
            dgvServicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServicos.Location = new Point(6, 305);
            dgvServicos.MultiSelect = false;
            dgvServicos.Name = "dgvServicos";
            dgvServicos.ReadOnly = true;
            dgvServicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicos.Size = new Size(564, 116);
            dgvServicos.TabIndex = 23;
            // 
            // chkCortesia
            // 
            chkCortesia.AutoSize = true;
            chkCortesia.Location = new Point(145, 167);
            chkCortesia.Name = "chkCortesia";
            chkCortesia.Size = new Size(69, 19);
            chkCortesia.TabIndex = 22;
            chkCortesia.Text = "Cortesia";
            chkCortesia.UseVisualStyleBackColor = true;
            // 
            // numValorUnitario
            // 
            numValorUnitario.DecimalPlaces = 2;
            numValorUnitario.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numValorUnitario.Location = new Point(145, 138);
            numValorUnitario.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numValorUnitario.Name = "numValorUnitario";
            numValorUnitario.Size = new Size(426, 23);
            numValorUnitario.TabIndex = 21;
            numValorUnitario.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(7, 140);
            label16.Name = "label16";
            label16.Size = new Size(78, 15);
            label16.TabIndex = 20;
            label16.Text = "Valor Unitário";
            // 
            // numQuantidade
            // 
            numQuantidade.DecimalPlaces = 2;
            numQuantidade.Location = new Point(145, 109);
            numQuantidade.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numQuantidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantidade.Name = "numQuantidade";
            numQuantidade.Size = new Size(426, 23);
            numQuantidade.TabIndex = 17;
            numQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(7, 111);
            label15.Name = "label15";
            label15.Size = new Size(69, 15);
            label15.TabIndex = 16;
            label15.Text = "Quantidade";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 84);
            label14.Name = "label14";
            label14.Size = new Size(138, 15);
            label14.TabIndex = 11;
            label14.Text = "Descrição no Orçamento";
            // 
            // cmbServicoPermitido
            // 
            cmbServicoPermitido.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicoPermitido.FormattingEnabled = true;
            cmbServicoPermitido.Items.AddRange(new object[] { "INSTALAÇÃO DE LUMINÁRIA", "INSTALAÇÃO DE REFLETOR", "INSTALAÇÃO OU TROCA DE LÂMPADAS", "REPARO DE LUMINÁRIA", "DESENTUPIMENTO DE VASO SANITÁRIO", "REPARO DE REDE HIDRÁULICA" });
            cmbServicoPermitido.Location = new Point(145, 51);
            cmbServicoPermitido.Name = "cmbServicoPermitido";
            cmbServicoPermitido.Size = new Size(426, 23);
            cmbServicoPermitido.TabIndex = 19;
            // 
            // txtDescricaoServico
            // 
            txtDescricaoServico.Location = new Point(145, 80);
            txtDescricaoServico.Name = "txtDescricaoServico";
            txtDescricaoServico.Size = new Size(426, 23);
            txtDescricaoServico.TabIndex = 10;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(7, 54);
            label13.Name = "label13";
            label13.Size = new Size(100, 15);
            label13.TabIndex = 18;
            label13.Text = "Serviço Permitido";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Items.AddRange(new object[] { "Pendente", "Pago", "Parcial", "Concluído", "Cancelado" });
            cmbCategoria.Location = new Point(145, 22);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(426, 23);
            cmbCategoria.TabIndex = 17;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(7, 25);
            label12.Name = "label12";
            label12.Size = new Size(58, 15);
            label12.TabIndex = 16;
            label12.Text = "Categoria";
            // 
            // grpCliente
            // 
            grpCliente.Controls.Add(label5);
            grpCliente.Controls.Add(txtCidadeEstado);
            grpCliente.Controls.Add(label4);
            grpCliente.Controls.Add(txtBairroCep);
            grpCliente.Controls.Add(label3);
            grpCliente.Controls.Add(txtEndereco);
            grpCliente.Controls.Add(label2);
            grpCliente.Controls.Add(txtCnpj);
            grpCliente.Controls.Add(label1);
            grpCliente.Controls.Add(txtCliente);
            grpCliente.Location = new Point(35, 12);
            grpCliente.Name = "grpCliente";
            grpCliente.Size = new Size(577, 177);
            grpCliente.TabIndex = 1;
            grpCliente.TabStop = false;
            grpCliente.Text = "Dados do Cliente";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 141);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 9;
            label5.Text = "Cidade / Estado";
            // 
            // txtCidadeEstado
            // 
            txtCidadeEstado.Location = new Point(145, 141);
            txtCidadeEstado.Name = "txtCidadeEstado";
            txtCidadeEstado.Size = new Size(426, 23);
            txtCidadeEstado.TabIndex = 8;
            txtCidadeEstado.Text = "CURITIBA- PARANÁ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 112);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 7;
            label4.Text = "Bairro / CEP";
            // 
            // txtBairroCep
            // 
            txtBairroCep.Location = new Point(145, 112);
            txtBairroCep.Name = "txtBairroCep";
            txtBairroCep.Size = new Size(426, 23);
            txtBairroCep.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 83);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 5;
            label3.Text = "Endereço";
            // 
            // txtEndereco
            // 
            txtEndereco.Location = new Point(145, 83);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(426, 23);
            txtEndereco.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 54);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 3;
            label2.Text = "CNPJ";
            label2.Click += label2_Click;
            // 
            // txtCnpj
            // 
            txtCnpj.Location = new Point(145, 54);
            txtCnpj.Name = "txtCnpj";
            txtCnpj.Size = new Size(426, 23);
            txtCnpj.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 1;
            label1.Text = "Cliente / Escola";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(145, 25);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(426, 23);
            txtCliente.TabIndex = 0;
            // 
            // grpOrcamento
            // 
            grpOrcamento.Controls.Add(numVariacaoNota3);
            grpOrcamento.Controls.Add(numVariacaoNota2);
            grpOrcamento.Controls.Add(cmbStatus);
            grpOrcamento.Controls.Add(dtpDataOrcamento);
            grpOrcamento.Controls.Add(label11);
            grpOrcamento.Controls.Add(txtObservacao);
            grpOrcamento.Controls.Add(label6);
            grpOrcamento.Controls.Add(label7);
            grpOrcamento.Controls.Add(label8);
            grpOrcamento.Controls.Add(label9);
            grpOrcamento.Controls.Add(label10);
            grpOrcamento.Controls.Add(txtTitulo);
            grpOrcamento.Location = new Point(35, 195);
            grpOrcamento.Name = "grpOrcamento";
            grpOrcamento.Size = new Size(577, 208);
            grpOrcamento.TabIndex = 10;
            grpOrcamento.TabStop = false;
            grpOrcamento.Text = "Dados do Orçamento";
            // 
            // numVariacaoNota3
            // 
            numVariacaoNota3.DecimalPlaces = 2;
            numVariacaoNota3.Location = new Point(145, 141);
            numVariacaoNota3.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numVariacaoNota3.Name = "numVariacaoNota3";
            numVariacaoNota3.Size = new Size(426, 23);
            numVariacaoNota3.TabIndex = 15;
            numVariacaoNota3.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numVariacaoNota2
            // 
            numVariacaoNota2.DecimalPlaces = 2;
            numVariacaoNota2.Location = new Point(145, 112);
            numVariacaoNota2.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numVariacaoNota2.Name = "numVariacaoNota2";
            numVariacaoNota2.Size = new Size(426, 23);
            numVariacaoNota2.TabIndex = 14;
            numVariacaoNota2.Value = new decimal(new int[] { 5, 0, 0, int.MinValue });
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Pendente", "Pago", "Parcial", "Concluído", "Cancelado" });
            cmbStatus.Location = new Point(145, 83);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(426, 23);
            cmbStatus.TabIndex = 13;
            // 
            // dtpDataOrcamento
            // 
            dtpDataOrcamento.Location = new Point(145, 54);
            dtpDataOrcamento.Name = "dtpDataOrcamento";
            dtpDataOrcamento.Size = new Size(426, 23);
            dtpDataOrcamento.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 170);
            label11.Name = "label11";
            label11.Size = new Size(69, 15);
            label11.TabIndex = 11;
            label11.Text = "Observação";
            // 
            // txtObservacao
            // 
            txtObservacao.Location = new Point(145, 170);
            txtObservacao.Name = "txtObservacao";
            txtObservacao.Size = new Size(426, 23);
            txtObservacao.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 143);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 9;
            label6.Text = "Variação Nota 3";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 112);
            label7.Name = "label7";
            label7.Size = new Size(89, 15);
            label7.TabIndex = 7;
            label7.Text = "Variação Nota 2";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 83);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 5;
            label8.Text = "Status";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 54);
            label9.Name = "label9";
            label9.Size = new Size(31, 15);
            label9.TabIndex = 3;
            label9.Text = "Data";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 25);
            label10.Name = "label10";
            label10.Size = new Size(38, 15);
            label10.TabIndex = 1;
            label10.Text = "Título";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(145, 25);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(426, 23);
            txtTitulo.TabIndex = 0;
            // 
            // FrmNovoOrcamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 905);
            Controls.Add(grpOrcamento);
            Controls.Add(grpCliente);
            Controls.Add(grpServicos);
            Name = "FrmNovoOrcamento";
            Text = "FrmNovoOrcamento";
            Load += FrmNovoOrcamento_Load;
            grpServicos.ResumeLayout(false);
            grpServicos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServicos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numValorUnitario).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).EndInit();
            grpCliente.ResumeLayout(false);
            grpCliente.PerformLayout();
            grpOrcamento.ResumeLayout(false);
            grpOrcamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpServicos;
        private GroupBox grpCliente;
        private Label label2;
        private TextBox txtCnpj;
        private Label label1;
        private TextBox txtCliente;
        private Label label5;
        private TextBox txtCidadeEstado;
        private Label label4;
        private TextBox txtBairroCep;
        private Label label3;
        private TextBox txtEndereco;
        private GroupBox grpOrcamento;
        private DateTimePicker dtpDataOrcamento;
        private Label label11;
        private TextBox txtObservacao;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox txtTitulo;
        private NumericUpDown numVariacaoNota3;
        private NumericUpDown numVariacaoNota2;
        private ComboBox cmbStatus;
        private ComboBox cmbCategoria;
        private Label label12;
        private Label label16;
        private NumericUpDown numQuantidade;
        private Label label15;
        private Label label14;
        private ComboBox cmbServicoPermitido;
        private TextBox txtDescricaoServico;
        private Label label13;
        private NumericUpDown numValorUnitario;
        private CheckBox chkCortesia;
        private DataGridView dgvServicos;
        private Button btnCancelar;
        private Button btnSalvarOrcamento;
        private Button btnRemoverServico;
        private Button btnAdicionarServico;
        private Label label17;
        private TextBox txtObservacaoServico;
    }
}