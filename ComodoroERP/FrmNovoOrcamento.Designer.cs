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
            label17 = new Label();
            txtObservacaoServico = new TextBox();
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
            lblServicoPermitido = new Label();
            cmbCategoria = new ComboBox();
            lblCategoria = new Label();
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
            numVariacaoNota3 = new NumericUpDown();
            numVariacaoNota2 = new NumericUpDown();
            cmbStatus = new ComboBox();
            dtpDataOrcamento = new DateTimePicker();
            lblObservacao = new Label();
            txtObservacao = new TextBox();
            lblVariacaoNota3 = new Label();
            lblVariacaoNota2 = new Label();
            lblStatus = new Label();
            lblDataOrcamento = new Label();
            lblTituloOrcamento = new Label();
            txtTitulo = new TextBox();
            pnlTopo = new Panel();
            lblSubtituloTela = new Label();
            lblTituloTela = new Label();
            pnlCliente = new Panel();
            lblDadosCliente = new Label();
            pnlOrcamento = new Panel();
            lblDadosOrcamento = new Label();
            pnlServico = new Panel();
            lblServicos = new Label();
            btnSalvarOrcamento = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvServicos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numValorUnitario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota2).BeginInit();
            pnlTopo.SuspendLayout();
            pnlCliente.SuspendLayout();
            pnlOrcamento.SuspendLayout();
            pnlServico.SuspendLayout();
            SuspendLayout();
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(20, 143);
            label17.Name = "label17";
            label17.Size = new Size(131, 19);
            label17.TabIndex = 29;
            label17.Text = "Observação Serviço:";
            // 
            // txtObservacaoServico
            // 
            txtObservacaoServico.Location = new Point(20, 165);
            txtObservacaoServico.Name = "txtObservacaoServico";
            txtObservacaoServico.Size = new Size(370, 25);
            txtObservacaoServico.TabIndex = 28;
            // 
            // btnRemoverServico
            // 
            btnRemoverServico.Location = new Point(850, 174);
            btnRemoverServico.Name = "btnRemoverServico";
            btnRemoverServico.Size = new Size(120, 30);
            btnRemoverServico.TabIndex = 25;
            btnRemoverServico.Text = "Remover Serviço";
            btnRemoverServico.UseVisualStyleBackColor = true;
            btnRemoverServico.Click += btnRemoverServico_Click;
            // 
            // btnAdicionarServico
            // 
            btnAdicionarServico.Location = new Point(720, 174);
            btnAdicionarServico.Name = "btnAdicionarServico";
            btnAdicionarServico.Size = new Size(120, 30);
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
            dgvServicos.Location = new Point(20, 660);
            dgvServicos.MultiSelect = false;
            dgvServicos.Name = "dgvServicos";
            dgvServicos.ReadOnly = true;
            dgvServicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicos.Size = new Size(990, 95);
            dgvServicos.TabIndex = 23;
            // 
            // chkCortesia
            // 
            chkCortesia.AutoSize = true;
            chkCortesia.Location = new Point(640, 106);
            chkCortesia.Name = "chkCortesia";
            chkCortesia.Size = new Size(78, 23);
            chkCortesia.TabIndex = 22;
            chkCortesia.Text = "Cortesia";
            chkCortesia.UseVisualStyleBackColor = true;
            // 
            // numValorUnitario
            // 
            numValorUnitario.DecimalPlaces = 2;
            numValorUnitario.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numValorUnitario.Location = new Point(510, 105);
            numValorUnitario.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numValorUnitario.Name = "numValorUnitario";
            numValorUnitario.Size = new Size(110, 25);
            numValorUnitario.TabIndex = 21;
            numValorUnitario.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(510, 85);
            label16.Name = "label16";
            label16.Size = new Size(96, 19);
            label16.TabIndex = 20;
            label16.Text = "Valor Unitário:";
            // 
            // numQuantidade
            // 
            numQuantidade.DecimalPlaces = 2;
            numQuantidade.Location = new Point(400, 105);
            numQuantidade.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numQuantidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantidade.Name = "numQuantidade";
            numQuantidade.Size = new Size(90, 25);
            numQuantidade.TabIndex = 17;
            numQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(400, 85);
            label15.Name = "label15";
            label15.Size = new Size(36, 19);
            label15.TabIndex = 16;
            label15.Text = "Qtd:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(20, 85);
            label14.Name = "label14";
            label14.Size = new Size(163, 19);
            label14.TabIndex = 11;
            label14.Text = "Descrição no Orçamento:";
            // 
            // cmbServicoPermitido
            // 
            cmbServicoPermitido.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbServicoPermitido.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbServicoPermitido.FormattingEnabled = true;
            cmbServicoPermitido.Items.AddRange(new object[] { "INSTALAÇÃO DE LUMINÁRIA", "INSTALAÇÃO DE REFLETOR", "INSTALAÇÃO OU TROCA DE LÂMPADAS", "REPARO DE LUMINÁRIA", "DESENTUPIMENTO DE VASO SANITÁRIO", "REPARO DE REDE HIDRÁULICA" });
            cmbServicoPermitido.Location = new Point(505, 55);
            cmbServicoPermitido.Name = "cmbServicoPermitido";
            cmbServicoPermitido.Size = new Size(465, 25);
            cmbServicoPermitido.TabIndex = 19;
            // 
            // txtDescricaoServico
            // 
            txtDescricaoServico.Location = new Point(20, 105);
            txtDescricaoServico.Name = "txtDescricaoServico";
            txtDescricaoServico.Size = new Size(360, 25);
            txtDescricaoServico.TabIndex = 10;
            // 
            // lblServicoPermitido
            // 
            lblServicoPermitido.AutoSize = true;
            lblServicoPermitido.Location = new Point(505, 35);
            lblServicoPermitido.Name = "lblServicoPermitido";
            lblServicoPermitido.Size = new Size(117, 19);
            lblServicoPermitido.TabIndex = 18;
            lblServicoPermitido.Text = "Serviço Permitido:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Items.AddRange(new object[] { "Pendente", "Pago", "Parcial", "Concluído", "Cancelado" });
            cmbCategoria.Location = new Point(20, 55);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(465, 25);
            cmbCategoria.TabIndex = 17;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(20, 35);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(71, 19);
            lblCategoria.TabIndex = 16;
            lblCategoria.Text = "Categoria:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(640, 80);
            label5.Name = "label5";
            label5.Size = new Size(105, 19);
            label5.TabIndex = 9;
            label5.Text = "Cidade / Estado";
            // 
            // txtCidadeEstado
            // 
            txtCidadeEstado.Location = new Point(640, 100);
            txtCidadeEstado.Name = "txtCidadeEstado";
            txtCidadeEstado.Size = new Size(250, 25);
            txtCidadeEstado.TabIndex = 8;
            txtCidadeEstado.Text = "CURITIBA- PARANÁ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(400, 80);
            label4.Name = "label4";
            label4.Size = new Size(85, 19);
            label4.TabIndex = 7;
            label4.Text = "Bairro / CEP:";
            // 
            // txtBairroCep
            // 
            txtBairroCep.Location = new Point(400, 100);
            txtBairroCep.Name = "txtBairroCep";
            txtBairroCep.Size = new Size(220, 25);
            txtBairroCep.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 80);
            label3.Name = "label3";
            label3.Size = new Size(68, 19);
            label3.TabIndex = 5;
            label3.Text = "Endereço:";
            // 
            // txtEndereco
            // 
            txtEndereco.Location = new Point(20, 100);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(360, 25);
            txtEndereco.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(340, 35);
            label2.Name = "label2";
            label2.Size = new Size(43, 19);
            label2.TabIndex = 3;
            label2.Text = "CNPJ:";
            // 
            // txtCnpj
            // 
            txtCnpj.Location = new Point(340, 55);
            txtCnpj.Name = "txtCnpj";
            txtCnpj.Size = new Size(180, 25);
            txtCnpj.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 35);
            label1.Name = "label1";
            label1.Size = new Size(104, 19);
            label1.TabIndex = 1;
            label1.Text = "Cliente / Escola:";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(20, 55);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(300, 25);
            txtCliente.TabIndex = 0;
            // 
            // numVariacaoNota3
            // 
            numVariacaoNota3.DecimalPlaces = 2;
            numVariacaoNota3.Location = new Point(810, 55);
            numVariacaoNota3.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numVariacaoNota3.Name = "numVariacaoNota3";
            numVariacaoNota3.Size = new Size(90, 25);
            numVariacaoNota3.TabIndex = 15;
            numVariacaoNota3.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numVariacaoNota2
            // 
            numVariacaoNota2.DecimalPlaces = 2;
            numVariacaoNota2.Location = new Point(700, 55);
            numVariacaoNota2.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numVariacaoNota2.Name = "numVariacaoNota2";
            numVariacaoNota2.Size = new Size(90, 25);
            numVariacaoNota2.TabIndex = 14;
            numVariacaoNota2.Value = new decimal(new int[] { 5, 0, 0, int.MinValue });
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Pendente", "Pago", "Parcial", "Concluído", "Cancelado" });
            cmbStatus.Location = new Point(530, 55);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 25);
            cmbStatus.TabIndex = 13;
            // 
            // dtpDataOrcamento
            // 
            dtpDataOrcamento.Format = DateTimePickerFormat.Short;
            dtpDataOrcamento.Location = new Point(390, 55);
            dtpDataOrcamento.Name = "dtpDataOrcamento";
            dtpDataOrcamento.Size = new Size(120, 25);
            dtpDataOrcamento.TabIndex = 12;
            // 
            // lblObservacao
            // 
            lblObservacao.AutoSize = true;
            lblObservacao.Location = new Point(20, 80);
            lblObservacao.Name = "lblObservacao";
            lblObservacao.Size = new Size(84, 19);
            lblObservacao.TabIndex = 11;
            lblObservacao.Text = "Observação:";
            // 
            // txtObservacao
            // 
            txtObservacao.Location = new Point(20, 100);
            txtObservacao.Name = "txtObservacao";
            txtObservacao.Size = new Size(880, 25);
            txtObservacao.TabIndex = 10;
            // 
            // lblVariacaoNota3
            // 
            lblVariacaoNota3.AutoSize = true;
            lblVariacaoNota3.Location = new Point(810, 35);
            lblVariacaoNota3.Name = "lblVariacaoNota3";
            lblVariacaoNota3.Size = new Size(77, 19);
            lblVariacaoNota3.TabIndex = 9;
            lblVariacaoNota3.Text = "Nota 3 (%):";
            // 
            // lblVariacaoNota2
            // 
            lblVariacaoNota2.AutoSize = true;
            lblVariacaoNota2.Location = new Point(700, 35);
            lblVariacaoNota2.Name = "lblVariacaoNota2";
            lblVariacaoNota2.Size = new Size(77, 19);
            lblVariacaoNota2.TabIndex = 7;
            lblVariacaoNota2.Text = "Nota 2 (%):";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(530, 35);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 19);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status:";
            // 
            // lblDataOrcamento
            // 
            lblDataOrcamento.AutoSize = true;
            lblDataOrcamento.Location = new Point(390, 35);
            lblDataOrcamento.Name = "lblDataOrcamento";
            lblDataOrcamento.Size = new Size(41, 19);
            lblDataOrcamento.TabIndex = 3;
            lblDataOrcamento.Text = "Data:";
            // 
            // lblTituloOrcamento
            // 
            lblTituloOrcamento.AutoSize = true;
            lblTituloOrcamento.Location = new Point(20, 35);
            lblTituloOrcamento.Name = "lblTituloOrcamento";
            lblTituloOrcamento.Size = new Size(46, 19);
            lblTituloOrcamento.TabIndex = 1;
            lblTituloOrcamento.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(20, 55);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(350, 25);
            txtTitulo.TabIndex = 0;
            // 
            // pnlTopo
            // 
            pnlTopo.BackColor = Color.SteelBlue;
            pnlTopo.Controls.Add(lblSubtituloTela);
            pnlTopo.Controls.Add(lblTituloTela);
            pnlTopo.Location = new Point(0, 0);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(1050, 75);
            pnlTopo.TabIndex = 11;
            // 
            // lblSubtituloTela
            // 
            lblSubtituloTela.AutoSize = true;
            lblSubtituloTela.Font = new Font("Segoe UI", 9F);
            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Location = new Point(27, 43);
            lblSubtituloTela.Name = "lblSubtituloTela";
            lblSubtituloTela.Size = new Size(276, 15);
            lblSubtituloTela.TabIndex = 1;
            lblSubtituloTela.Text = "Cadastre o cliente, serviços e valores do orçamento";
            // 
            // lblTituloTela
            // 
            lblTituloTela.AutoSize = true;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15F);
            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Location = new Point(25, 14);
            lblTituloTela.Name = "lblTituloTela";
            lblTituloTela.Size = new Size(196, 28);
            lblTituloTela.TabIndex = 0;
            lblTituloTela.Text = "NOVO ORÇAMENTO";
            // 
            // pnlCliente
            // 
            pnlCliente.BackColor = Color.White;
            pnlCliente.BorderStyle = BorderStyle.FixedSingle;
            pnlCliente.Controls.Add(lblDadosCliente);
            pnlCliente.Controls.Add(label1);
            pnlCliente.Controls.Add(label5);
            pnlCliente.Controls.Add(txtCnpj);
            pnlCliente.Controls.Add(label2);
            pnlCliente.Controls.Add(txtCidadeEstado);
            pnlCliente.Controls.Add(txtEndereco);
            pnlCliente.Controls.Add(txtCliente);
            pnlCliente.Controls.Add(label4);
            pnlCliente.Controls.Add(txtBairroCep);
            pnlCliente.Controls.Add(label3);
            pnlCliente.Location = new Point(20, 90);
            pnlCliente.Name = "pnlCliente";
            pnlCliente.Size = new Size(990, 140);
            pnlCliente.TabIndex = 12;
            // 
            // lblDadosCliente
            // 
            lblDadosCliente.AutoSize = true;
            lblDadosCliente.Font = new Font("Segoe UI", 11F);
            lblDadosCliente.ForeColor = Color.DimGray;
            lblDadosCliente.Location = new Point(15, 12);
            lblDadosCliente.Name = "lblDadosCliente";
            lblDadosCliente.Size = new Size(124, 20);
            lblDadosCliente.TabIndex = 11;
            lblDadosCliente.Text = "Dados do Cliente";
            // 
            // pnlOrcamento
            // 
            pnlOrcamento.BackColor = Color.White;
            pnlOrcamento.BorderStyle = BorderStyle.FixedSingle;
            pnlOrcamento.Controls.Add(txtObservacao);
            pnlOrcamento.Controls.Add(lblObservacao);
            pnlOrcamento.Controls.Add(numVariacaoNota3);
            pnlOrcamento.Controls.Add(lblDadosOrcamento);
            pnlOrcamento.Controls.Add(numVariacaoNota2);
            pnlOrcamento.Controls.Add(lblTituloOrcamento);
            pnlOrcamento.Controls.Add(lblVariacaoNota3);
            pnlOrcamento.Controls.Add(cmbStatus);
            pnlOrcamento.Controls.Add(txtTitulo);
            pnlOrcamento.Controls.Add(dtpDataOrcamento);
            pnlOrcamento.Controls.Add(lblVariacaoNota2);
            pnlOrcamento.Controls.Add(lblDataOrcamento);
            pnlOrcamento.Controls.Add(lblStatus);
            pnlOrcamento.Location = new Point(20, 250);
            pnlOrcamento.Name = "pnlOrcamento";
            pnlOrcamento.Size = new Size(990, 140);
            pnlOrcamento.TabIndex = 13;
            // 
            // lblDadosOrcamento
            // 
            lblDadosOrcamento.AutoSize = true;
            lblDadosOrcamento.Font = new Font("Segoe UI", 11F);
            lblDadosOrcamento.ForeColor = Color.DimGray;
            lblDadosOrcamento.Location = new Point(15, 12);
            lblDadosOrcamento.Name = "lblDadosOrcamento";
            lblDadosOrcamento.Size = new Size(152, 20);
            lblDadosOrcamento.TabIndex = 0;
            lblDadosOrcamento.Text = "Dados do Orçamento";
            // 
            // pnlServico
            // 
            pnlServico.BackColor = Color.White;
            pnlServico.BorderStyle = BorderStyle.FixedSingle;
            pnlServico.Controls.Add(txtObservacaoServico);
            pnlServico.Controls.Add(label17);
            pnlServico.Controls.Add(btnRemoverServico);
            pnlServico.Controls.Add(lblServicos);
            pnlServico.Controls.Add(btnAdicionarServico);
            pnlServico.Controls.Add(txtDescricaoServico);
            pnlServico.Controls.Add(lblCategoria);
            pnlServico.Controls.Add(cmbCategoria);
            pnlServico.Controls.Add(lblServicoPermitido);
            pnlServico.Controls.Add(cmbServicoPermitido);
            pnlServico.Controls.Add(label14);
            pnlServico.Controls.Add(chkCortesia);
            pnlServico.Controls.Add(label15);
            pnlServico.Controls.Add(label16);
            pnlServico.Controls.Add(numValorUnitario);
            pnlServico.Controls.Add(numQuantidade);
            pnlServico.Location = new Point(20, 415);
            pnlServico.Name = "pnlServico";
            pnlServico.Size = new Size(990, 220);
            pnlServico.TabIndex = 14;
            // 
            // lblServicos
            // 
            lblServicos.AutoSize = true;
            lblServicos.Font = new Font("Segoe UI", 11F);
            lblServicos.ForeColor = Color.DimGray;
            lblServicos.Location = new Point(15, 12);
            lblServicos.Name = "lblServicos";
            lblServicos.Size = new Size(63, 20);
            lblServicos.TabIndex = 0;
            lblServicos.Text = "Serviços";
            // 
            // btnSalvarOrcamento
            // 
            btnSalvarOrcamento.Location = new Point(735, 770);
            btnSalvarOrcamento.Name = "btnSalvarOrcamento";
            btnSalvarOrcamento.Size = new Size(140, 35);
            btnSalvarOrcamento.TabIndex = 26;
            btnSalvarOrcamento.Text = "Salvar Orçamento";
            btnSalvarOrcamento.UseVisualStyleBackColor = true;
            btnSalvarOrcamento.Click += btnSalvarOrcamento_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(885, 770);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 35);
            btnCancelar.TabIndex = 27;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmNovoOrcamento
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1034, 832);
            Controls.Add(btnCancelar);
            Controls.Add(pnlServico);
            Controls.Add(btnSalvarOrcamento);
            Controls.Add(pnlOrcamento);
            Controls.Add(dgvServicos);
            Controls.Add(pnlCliente);
            Controls.Add(pnlTopo);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmNovoOrcamento";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Novo Orçamento";
            ((System.ComponentModel.ISupportInitialize)dgvServicos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numValorUnitario).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVariacaoNota2).EndInit();
            pnlTopo.ResumeLayout(false);
            pnlTopo.PerformLayout();
            pnlCliente.ResumeLayout(false);
            pnlCliente.PerformLayout();
            pnlOrcamento.ResumeLayout(false);
            pnlOrcamento.PerformLayout();
            pnlServico.ResumeLayout(false);
            pnlServico.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
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
        private Label lblObservacao;
        private TextBox txtObservacao;
        private Label lblVariacaoNota3;
        private Label lblVariacaoNota2;
        private Label lblStatus;
        private Label lblDataOrcamento;
        private Label lblTituloOrcamento;
        private TextBox txtTitulo;
        private NumericUpDown numVariacaoNota3;
        private NumericUpDown numVariacaoNota2;
        private ComboBox cmbStatus;
        private ComboBox cmbCategoria;
        private Label lblCategoria;
        private Label label16;
        private NumericUpDown numQuantidade;
        private Label label15;
        private Label label14;
        private ComboBox cmbServicoPermitido;
        private TextBox txtDescricaoServico;
        private Label lblServicoPermitido;
        private NumericUpDown numValorUnitario;
        private CheckBox chkCortesia;
        private DataGridView dgvServicos;
        private Button btnRemoverServico;
        private Button btnAdicionarServico;
        private Label label17;
        private TextBox txtObservacaoServico;
        private Panel pnlTopo;
        private Label lblSubtituloTela;
        private Label lblTituloTela;
        private Panel pnlCliente;
        private Label lblDadosCliente;
        private Panel pnlOrcamento;
        private Label lblDadosOrcamento;
        private Panel pnlServico;
        private Label lblServicos;
        private Button btnSalvarOrcamento;
        private Button btnCancelar;
    }
}