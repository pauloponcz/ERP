using ComodoroERP.Models;
using ComodoroERP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComodoroERP
{
    public partial class FrmAdicionarItemOrcamento : Form
    {

        private void FrmAdicionarItemOrcamento_Load(object sender, EventArgs e)
        {

        }

        private readonly int _orcamentoId;
        private readonly OrcamentoService _orcamentoService = new();
        private readonly ServicoPermitidoService _servicoPermitidoService = new();

        public FrmAdicionarItemOrcamento(int orcamentoId)
        {
            InitializeComponent();

            _orcamentoId = orcamentoId;

            ConfigurarTela();
            CarregarCategorias();
        }

        private void ConfigurarTela()
        {
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicoPermitido.DropDownStyle = ComboBoxStyle.DropDownList;

            numQuantidade.Minimum = 1;
            numQuantidade.Maximum = 100000;
            numQuantidade.DecimalPlaces = 2;
            numQuantidade.Value = 1;

            numValorUnitario.Minimum = 0;
            numValorUnitario.Maximum = 1000000;
            numValorUnitario.DecimalPlaces = 2;
            numValorUnitario.Value = 0;
        }

        private void CarregarCategorias()
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
        }

        private void CarregarServicosPorCategoria()
        {
            cmbServicoPermitido.Items.Clear();

            if (cmbCategoria.SelectedItem == null)
                return;

            var servicos = _servicoPermitidoService.ListarServicosPorCategoria(cmbCategoria.Text);

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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            decimal quantidade = numQuantidade.Value;
            decimal valorUnitario = numValorUnitario.Value;
            bool cortesia = chkCortesia.Checked;

            decimal valorTotal = cortesia ? 0 : quantidade * valorUnitario;

            var item = new OrcamentoItem
            {
                Categoria = cmbCategoria.Text.Trim(),
                ServicoPermitido = cmbServicoPermitido.Text.Trim(),
                DescricaoOrcamento = txtDescricaoServico.Text.Trim().ToUpper(),
                Quantidade = quantidade,
                ValorUnitario = valorUnitario,
                Cortesia = cortesia,
                ValorTotal = valorTotal,
                Observacao = txtObservacaoServico.Text.Trim()
            };

            try
            {
                _orcamentoService.AdicionarItemOrcamento(_orcamentoId, item);

                MessageBox.Show("Item adicionado com sucesso.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar item: " + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            if (cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Selecione a categoria.");
                cmbCategoria.Focus();
                return false;
            }

            if (cmbServicoPermitido.SelectedItem == null)
            {
                MessageBox.Show("Selecione o serviço permitido.");
                cmbServicoPermitido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescricaoServico.Text))
            {
                MessageBox.Show("Informe a descrição do serviço.");
                txtDescricaoServico.Focus();
                return false;
            }

            if (numQuantidade.Value <= 0)
            {
                MessageBox.Show("Informe uma quantidade válida.");
                numQuantidade.Focus();
                return false;
            }

            if (!chkCortesia.Checked && numValorUnitario.Value <= 0)
            {
                MessageBox.Show("Informe um valor unitário válido.");
                numValorUnitario.Focus();
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
