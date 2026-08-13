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
    public partial class FrmEditarItemOrcamento : Form
    {
        public FrmEditarItemOrcamento()
        {
            InitializeComponent();
        }

        private void txtObservacaoServico_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private readonly OrcamentoItem _item;
        private readonly OrcamentoService _orcamentoService = new();
        private readonly ServicoPermitidoService _servicoPermitidoService = new();

        public FrmEditarItemOrcamento(OrcamentoItem item)
        {
            InitializeComponent();

            _item = item;

            ConfigurarTela();
            CarregarCategorias();
            CarregarDadosItem();
        }

        private void ConfigurarTela()
        {
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicoPermitido.DropDownStyle = ComboBoxStyle.DropDownList;

            numQuantidade.Minimum = 1;
            numQuantidade.Maximum = 100000;
            numQuantidade.DecimalPlaces = 2;

            numValorUnitario.Minimum = 0;
            numValorUnitario.Maximum = 1000000;
            numValorUnitario.DecimalPlaces = 2;
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
        }

        private void CarregarDadosItem()
        {
            cmbCategoria.Text = _item.Categoria;

            CarregarServicosPorCategoria();

            cmbServicoPermitido.Text = _item.ServicoPermitido;
            txtDescricaoServico.Text = _item.DescricaoOrcamento;
            numQuantidade.Value = _item.Quantidade;
            numValorUnitario.Value = _item.ValorUnitario;
            chkCortesia.Checked = _item.Cortesia;
            txtObservacaoServico.Text = _item.Observacao;
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarServicosPorCategoria();

            if (cmbServicoPermitido.Items.Count > 0)
            {
                cmbServicoPermitido.SelectedIndex = 0;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            decimal quantidade = numQuantidade.Value;
            decimal valorUnitario = numValorUnitario.Value;
            bool cortesia = chkCortesia.Checked;

            decimal valorTotal = cortesia ? 0 : quantidade * valorUnitario;

            _item.Categoria = cmbCategoria.Text.Trim();
            _item.ServicoPermitido = cmbServicoPermitido.Text.Trim();
            _item.DescricaoOrcamento = txtDescricaoServico.Text.Trim().ToUpper();
            _item.Quantidade = quantidade;
            _item.ValorUnitario = valorUnitario;
            _item.Cortesia = cortesia;
            _item.ValorTotal = valorTotal;
            _item.Observacao = txtObservacaoServico.Text.Trim();

            try
            {
                _orcamentoService.AtualizarItemOrcamento(_item);

                MessageBox.Show("Item atualizado com sucesso.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar item: " + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            if (cmbCategoria.SelectedItem == null && string.IsNullOrWhiteSpace(cmbCategoria.Text))
            {
                MessageBox.Show("Selecione a categoria.");
                cmbCategoria.Focus();
                return false;
            }

            if (cmbServicoPermitido.SelectedItem == null && string.IsNullOrWhiteSpace(cmbServicoPermitido.Text))
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
