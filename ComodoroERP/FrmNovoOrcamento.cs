using ComodoroERP.Models;
using ComodoroERP.Services;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace ComodoroERP
{
    public partial class FrmNovoOrcamento : Form
    {

        private List<string> _categoriasOriginais = new();
        private List<string> _servicosOriginais = new();

        private bool _atualizandoComboCategoria = false;
        private bool _atualizandoComboServico = false;

        private readonly List<OrcamentoItem> _itens = new();
        private readonly ServicoPermitidoService _servicoPermitidoService = new();
        private void CarregarCategoriasPermitidas()
        {
            cmbCategoria.Items.Clear();

            _categoriasOriginais = _servicoPermitidoService
                .ListarCategorias()
                .ToList();

            foreach (var categoria in _categoriasOriginais)
            {
                cmbCategoria.Items.Add(categoria);
            }

            cmbCategoria.SelectedIndex = -1;
            cmbCategoria.Text = "";

            cmbServicoPermitido.Items.Clear();
            cmbServicoPermitido.SelectedIndex = -1;
            cmbServicoPermitido.Text = "";

            _servicosOriginais.Clear();
        }
        private void CarregarServicosPorCategoria()
        {
            string categoria = cmbCategoria.Text.Trim();

            cmbServicoPermitido.Items.Clear();
            cmbServicoPermitido.SelectedIndex = -1;
            cmbServicoPermitido.Text = "";

            _servicosOriginais.Clear();

            if (string.IsNullOrWhiteSpace(categoria))
                return;

            bool categoriaExiste = _categoriasOriginais
                .Any(c => NormalizarTexto(c) == NormalizarTexto(categoria));

            if (!categoriaExiste)
                return;

            _servicosOriginais = _servicoPermitidoService
                .ListarServicosPorCategoria(categoria)
                .ToList();

            foreach (var servico in _servicosOriginais)
            {
                cmbServicoPermitido.Items.Add(servico);
            }
        }
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_atualizandoComboCategoria)
                return;

            if (cmbCategoria.SelectedIndex < 0)
                return;

            CarregarServicosPorCategoria();
        }

        public FrmNovoOrcamento()
        {
            InitializeComponent();
            ConfigurarTela();
            ConfigurarGridServicos();

            AplicarEstiloVisual();
        }

        private void ConfigurarTela()
        {
            txtCidadeEstado.Text = "CURITIBA- PARANÁ";

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Pendente");
            cmbStatus.Items.Add("Pago");
            cmbStatus.Items.Add("Parcial");
            cmbStatus.Items.Add("Concluído");
            cmbStatus.Items.Add("Cancelado");
            cmbStatus.SelectedIndex = 0;

            numQuantidade.Value = 1;
            numVariacaoNota2.Value = -5;
            numVariacaoNota3.Value = 1;

            ConfigurarComboPesquisa(cmbCategoria);
            ConfigurarComboPesquisa(cmbServicoPermitido);

            cmbCategoria.TextUpdate -= cmbCategoria_TextUpdate;
            cmbCategoria.TextUpdate += cmbCategoria_TextUpdate;

            cmbServicoPermitido.TextUpdate -= cmbServicoPermitido_TextUpdate;
            cmbServicoPermitido.TextUpdate += cmbServicoPermitido_TextUpdate;

            cmbCategoria.SelectedIndexChanged -= cmbCategoria_SelectedIndexChanged;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;

            cmbCategoria.Leave -= cmbCategoria_Leave;
            cmbCategoria.Leave += cmbCategoria_Leave;

            CarregarCategoriasPermitidas();
        }

        private void ConfigurarComboPesquisa(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;

            // Desliga o autocomplete nativo, porque ele não faz "contains" bem.
            comboBox.AutoCompleteMode = AutoCompleteMode.None;
            comboBox.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cmbCategoria_Leave(object sender, EventArgs e)
        {
            string categoria = cmbCategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(categoria))
            {
                cmbServicoPermitido.Items.Clear();
                cmbServicoPermitido.Text = "";
                _servicosOriginais.Clear();
                return;
            }

            bool categoriaExiste = _categoriasOriginais
                .Any(c => NormalizarTexto(c) == NormalizarTexto(categoria));

            if (!categoriaExiste)
            {
                MessageBox.Show(
                    "Categoria não encontrada na lista de serviços permitidos.",
                    "Categoria inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbCategoria.Text = "";
                cmbServicoPermitido.Items.Clear();
                cmbServicoPermitido.Text = "";
                _servicosOriginais.Clear();

                cmbCategoria.Focus();
                return;
            }

            CarregarServicosPorCategoria();
        }

        private void ConfigurarAutoCompleteComboBox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cmbCategoria_TextUpdate(object sender, EventArgs e)
        {
            if (_atualizandoComboCategoria)
                return;

            string textoDigitado = cmbCategoria.Text;

            if (string.IsNullOrWhiteSpace(textoDigitado))
            {
                try
                {
                    _atualizandoComboCategoria = true;

                    cmbCategoria.DroppedDown = false;
                    cmbCategoria.Items.Clear();

                    foreach (var categoria in _categoriasOriginais)
                    {
                        cmbCategoria.Items.Add(categoria);
                    }

                    cmbCategoria.Text = "";
                    cmbCategoria.SelectionStart = 0;
                }
                finally
                {
                    _atualizandoComboCategoria = false;
                }

                return;
            }

            FiltrarComboBox(
                cmbCategoria,
                _categoriasOriginais,
                textoDigitado,
                ref _atualizandoComboCategoria
            );
        }
        private void cmbServicoPermitido_TextUpdate(object sender, EventArgs e)
        {
            if (_atualizandoComboServico)
                return;

            string textoDigitado = cmbServicoPermitido.Text;

            FiltrarComboBox(
                cmbServicoPermitido,
                _servicosOriginais,
                textoDigitado,
                ref _atualizandoComboServico
            );
        }

        private void FiltrarComboBox(
            ComboBox comboBox,
            List<string> listaOriginal,
            string textoDigitado,
            ref bool atualizando)
        {
            try
            {
                atualizando = true;

                int posicaoCursor = comboBox.SelectionStart;

                string textoNormalizado = NormalizarTexto(textoDigitado);

                var itensFiltrados = listaOriginal
                    .Where(item => NormalizarTexto(item).Contains(textoNormalizado))
                    .ToList();

                // Fecha antes de mexer nos itens para evitar erro quando a lista fica vazia
                comboBox.DroppedDown = false;

                comboBox.BeginUpdate();
                comboBox.Items.Clear();

                foreach (var item in itensFiltrados)
                {
                    comboBox.Items.Add(item);
                }

                comboBox.EndUpdate();

                comboBox.Text = textoDigitado;
                comboBox.SelectionStart = Math.Min(posicaoCursor, comboBox.Text.Length);
                comboBox.SelectionLength = 0;

                // Só abre a lista se existir pelo menos um item
                if (itensFiltrados.Count > 0 && comboBox.Focused)
                {
                    comboBox.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {
                comboBox.DroppedDown = false;
            }
            finally
            {
                atualizando = false;
            }
        }
        private string NormalizarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "";

            string textoNormalizado = texto.Normalize(NormalizationForm.FormD);

            var builder = new StringBuilder();

            foreach (char caractere in textoNormalizado)
            {
                UnicodeCategory categoria = CharUnicodeInfo.GetUnicodeCategory(caractere);

                if (categoria != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(caractere);
                }
            }

            return builder
                .ToString()
                .Normalize(NormalizationForm.FormC)
                .ToUpperInvariant()
                .Trim();
        }

        private void ConfigurarGridServicos()
        {
            dgvServicos.AutoGenerateColumns = false;
            dgvServicos.AllowUserToAddRows = false;
            dgvServicos.AllowUserToDeleteRows = false;
            dgvServicos.ReadOnly = true;
            dgvServicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicos.MultiSelect = false;
            dgvServicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvServicos.Columns.Clear();

            dgvServicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Categoria",
                DataPropertyName = "Categoria"
            });

            dgvServicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Serviço Permitido",
                DataPropertyName = "ServicoPermitido"
            });

            dgvServicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Descrição",
                DataPropertyName = "DescricaoOrcamento"
            });

            dgvServicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Qtd",
                DataPropertyName = "Quantidade"
            });

            dgvServicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Valor Unitário",
                DataPropertyName = "ValorUnitario",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvServicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cortesia",
                DataPropertyName = "Cortesia"
            });

            dgvServicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total",
                DataPropertyName = "ValorTotal",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
        }

        private void AtualizarGridServicos()
        {
            dgvServicos.DataSource = null;
            dgvServicos.DataSource = _itens;
        }

        private void btnAdicionarServico_Click(object sender, EventArgs e)
        {
            if (!ValidarServico())
                return;

            string categoria = cmbCategoria.Text.Trim();
            string servicoPermitido = cmbServicoPermitido.Text.Trim();

            bool categoriaExiste = _categoriasOriginais
                .Any(c => NormalizarTexto(c) == NormalizarTexto(categoria));

            if (!categoriaExiste)
            {
                MessageBox.Show(
                    "Selecione uma categoria válida da lista.",
                    "Categoria inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbCategoria.Focus();
                return;
            }

            bool servicoExiste = _servicosOriginais
                .Any(s => NormalizarTexto(s) == NormalizarTexto(servicoPermitido));

            if (!servicoExiste)
            {
                MessageBox.Show(
                    "Selecione um serviço permitido válido da lista.",
                    "Serviço inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbServicoPermitido.Focus();
                return;
            }

            decimal quantidade = numQuantidade.Value;
            decimal valorUnitario = numValorUnitario.Value;
            bool cortesia = chkCortesia.Checked;

            decimal total = cortesia ? 0 : quantidade * valorUnitario;

            var item = new OrcamentoItem
            {
                Categoria = categoria,
                ServicoPermitido = servicoPermitido,
                DescricaoOrcamento = txtDescricaoServico.Text.Trim().ToUpper(),
                Quantidade = quantidade,
                ValorUnitario = valorUnitario,
                Cortesia = cortesia,
                ValorTotal = total,
                Observacao = txtObservacaoServico.Text.Trim()
            };

            _itens.Add(item);

            AtualizarGridServicos();
            LimparCamposServico();
        }

        private bool ValidarServico()
        {
            if (string.IsNullOrWhiteSpace(cmbCategoria.Text))
            {
                MessageBox.Show("Selecione a categoria do serviço.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbServicoPermitido.Text))
            {
                MessageBox.Show("Selecione o serviço permitido.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescricaoServico.Text))
            {
                MessageBox.Show("Informe a descrição do serviço.");
                return false;
            }

            if (numQuantidade.Value <= 0)
            {
                MessageBox.Show("Informe uma quantidade válida.");
                return false;
            }

            if (!chkCortesia.Checked && numValorUnitario.Value <= 0)
            {
                MessageBox.Show("Informe um valor unitário válido.");
                return false;
            }

            return true;
        }

        private void LimparCamposServico()
        {
            txtDescricaoServico.Clear();
            numQuantidade.Value = 1;
            numValorUnitario.Value = 0;
            chkCortesia.Checked = false;
            txtObservacaoServico.Clear();

            if (cmbCategoria.Items.Count > 0)
            {
                cmbCategoria.SelectedIndex = 0;
            }

            CarregarServicosPorCategoria();
        }

        private void btnRemoverServico_Click(object sender, EventArgs e)
        {
            if (dgvServicos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um serviço para remover.");
                return;
            }

            int indice = dgvServicos.SelectedRows[0].Index;

            if (indice >= 0 && indice < _itens.Count)
            {
                _itens.RemoveAt(indice);
                AtualizarGridServicos();
            }
        }

        private void btnSalvarOrcamento_Click(object sender, EventArgs e)
        {
            if (!ValidarOrcamento())
                return;

            var cliente = new Cliente
            {
                Nome = txtCliente.Text.Trim().ToUpper(),
                Cnpj = txtCnpj.Text.Trim(),
                Endereco = txtEndereco.Text.Trim().ToUpper(),
                BairroCep = txtBairroCep.Text.Trim().ToUpper(),
                CidadeEstado = txtCidadeEstado.Text.Trim().ToUpper()
            };

            var orcamento = new Orcamento
            {
                Titulo = txtTitulo.Text.Trim().ToUpper(),
                DataOrcamento = dtpDataOrcamento.Value.Date,
                Status = cmbStatus.Text,
                VariacaoNota2 = numVariacaoNota2.Value,
                VariacaoNota3 = numVariacaoNota3.Value,
                Observacao = txtObservacao.Text.Trim(),
                DataCriacao = DateTime.Now
            };

            try
            {
                var service = new OrcamentoService();

                int idOrcamento = service.SalvarOrcamento(cliente, orcamento, _itens);

                MessageBox.Show($"Orçamento salvo com sucesso! ID: {idOrcamento}");

                LimparTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar orçamento: " + ex.Message);
            }
        }

        private bool ValidarOrcamento()
        {
            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MessageBox.Show("Informe o cliente/escola.");
                txtCliente.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCnpj.Text))
            {
                MessageBox.Show("Informe o CNPJ.");
                txtCnpj.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEndereco.Text))
            {
                MessageBox.Show("Informe o endereço.");
                txtEndereco.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Informe o título do orçamento.");
                txtTitulo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Informe o status.");
                cmbStatus.Focus();
                return false;
            }

            if (_itens.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um serviço.");
                return false;
            }

            return true;
        }

        private void LimparTela()
        {
            txtCliente.Clear();
            txtCnpj.Clear();
            txtEndereco.Clear();
            txtBairroCep.Clear();
            txtCidadeEstado.Text = "CURITIBA- PARANÁ";
            txtTitulo.Clear();
            txtObservacao.Clear();

            cmbStatus.SelectedIndex = 0;
            numVariacaoNota2.Value = -5;
            numVariacaoNota3.Value = 1;

            _itens.Clear();
            AtualizarGridServicos();

            LimparCamposServico();

            txtCliente.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void AplicarEstiloVisual()
        {
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10);

            AplicarEstiloPainel(pnlCliente);
            AplicarEstiloPainel(pnlOrcamento);
            AplicarEstiloPainel(pnlServico);

            AplicarEstiloBotaoPrincipal(btnAdicionarServico);
            AplicarEstiloBotaoPrincipal(btnRemoverServico);
            AplicarEstiloBotaoPrincipal(btnSalvarOrcamento);

            AplicarEstiloBotaoCancelar(btnCancelar);

            AplicarEstiloGrid(dgvServicos);

            AplicarEstiloCampos(this);

            // Deixe o topo por último para não ser sobrescrito
            pnlTopo.BackColor = Color.SteelBlue;

            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15);

            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Font = new Font("Segoe UI", 9);
        }
        private void AplicarEstiloPainel(Panel painel)
        {
            painel.BackColor = Color.White;
            painel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void AplicarEstiloBotaoPrincipal(Button botao)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.BackColor = Color.White;
            botao.ForeColor = Color.FromArgb(45, 45, 45);
            botao.Font = new Font("Segoe UI Semibold", 10);
            botao.Cursor = Cursors.Hand;

            botao.FlatAppearance.BorderColor = Color.Gainsboro;
            botao.FlatAppearance.BorderSize = 1;

            botao.MouseEnter += (s, e) =>
            {
                botao.BackColor = Color.AliceBlue;
            };

            botao.MouseLeave += (s, e) =>
            {
                botao.BackColor = Color.White;
            };
        }

        private void AplicarEstiloBotaoCancelar(Button botao)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.BackColor = Color.White;
            botao.ForeColor = Color.DimGray;
            botao.Font = new Font("Segoe UI Semibold", 10);
            botao.Cursor = Cursors.Hand;

            botao.FlatAppearance.BorderColor = Color.Silver;
            botao.FlatAppearance.BorderSize = 1;

            botao.MouseEnter += (s, e) =>
            {
                botao.BackColor = Color.Gainsboro;
            };

            botao.MouseLeave += (s, e) =>
            {
                botao.BackColor = Color.White;
            };
        }

        private void AplicarEstiloGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.GridColor = Color.Gainsboro;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9);

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            grid.DefaultCellStyle.SelectionBackColor = Color.AliceBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;

            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AplicarEstiloCampos(Control controlePai)
        {
            foreach (Control controle in controlePai.Controls)
            {
                if (controle is Label label)
                {
                    if (label.Parent == pnlTopo)
                        continue;

                    label.ForeColor = Color.DimGray;
                    label.Font = new Font("Segoe UI", 9);
                }

                if (controle is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.Font = new Font("Segoe UI", 10);
                }

                if (controle is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                    comboBox.Font = new Font("Segoe UI", 10);
                }

                if (controle is NumericUpDown numeric)
                {
                    numeric.BorderStyle = BorderStyle.FixedSingle;
                    numeric.Font = new Font("Segoe UI", 10);
                }

                if (controle.HasChildren)
                {
                    AplicarEstiloCampos(controle);
                }
            }
        }

        private void FrmNovoOrcamento_Load(object sender, EventArgs e)
        {
        }
    }
}