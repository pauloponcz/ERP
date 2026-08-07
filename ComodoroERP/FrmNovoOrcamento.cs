using ComodoroERP.Models;
using ComodoroERP.Services;
using System.Data;

namespace ComodoroERP
{
    public partial class FrmNovoOrcamento : Form
    {
        private readonly List<OrcamentoItem> _itens = new();
        private readonly ServicoPermitidoService _servicoPermitidoService = new();
        private void CarregarCategoriasPermitidas()
        {
            cmbCategoria.Items.Clear();
            cmbServicoPermitido.Items.Clear();

            var categorias = _servicoPermitidoService.ListarCategorias();

            foreach (var categoria in categorias)
            {
                cmbCategoria.Items.Add(categoria);
            }

            if (cmbCategoria.Items.Count > 0)
            {
                cmbCategoria.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Nenhum serviço permitido cadastrado. Importe a lista na tela Serviços Permitidos antes de criar um orçamento.");
            }
        }
        private void CarregarServicosPorCategoria()
        {
            cmbServicoPermitido.Items.Clear();

            if (cmbCategoria.SelectedItem == null)
                return;

            string categoria = cmbCategoria.Text;

            var servicos = _servicoPermitidoService.ListarServicosPorCategoria(categoria);

            foreach (var servico in servicos)
            {
                cmbServicoPermitido.Items.Add(servico);
            }

            if (cmbServicoPermitido.Items.Count > 0)
            {
                cmbServicoPermitido.SelectedIndex = 0;
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarServicosPorCategoria();
        }
        public FrmNovoOrcamento()
        {
            InitializeComponent();
            ConfigurarTela();
            ConfigurarGridServicos();
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

            CarregarCategoriasPermitidas();
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

            decimal quantidade = numQuantidade.Value;
            decimal valorUnitario = numValorUnitario.Value;
            bool cortesia = chkCortesia.Checked;

            decimal total = cortesia ? 0 : quantidade * valorUnitario;

            var item = new OrcamentoItem
            {
                Categoria = cmbCategoria.Text.Trim(),
                ServicoPermitido = cmbServicoPermitido.Text.Trim(),
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void FrmNovoOrcamento_Load(object sender, EventArgs e)
        {
        }
    }
}