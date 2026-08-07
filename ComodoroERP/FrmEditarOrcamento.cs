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
    public partial class FrmEditarOrcamento : Form
    {
        public FrmEditarOrcamento()
        {
            InitializeComponent();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private readonly int _orcamentoId;
        private readonly OrcamentoService _orcamentoService = new();

        public FrmEditarOrcamento(int orcamentoId)
        {
            InitializeComponent();

            _orcamentoId = orcamentoId;

            ConfigurarTela();
            CarregarDados();
        }

        private void ConfigurarTela()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Pendente");
            cmbStatus.Items.Add("Pago");
            cmbStatus.Items.Add("Parcial");
            cmbStatus.Items.Add("Concluído");
            cmbStatus.Items.Add("Cancelado");

            numVariacaoNota2.Minimum = -100;
            numVariacaoNota2.Maximum = 100;
            numVariacaoNota2.DecimalPlaces = 2;

            numVariacaoNota3.Minimum = -100;
            numVariacaoNota3.Maximum = 100;
            numVariacaoNota3.DecimalPlaces = 2;
        }

        private void CarregarDados()
        {
            DataSet dados = _orcamentoService.ObterOrcamentoCompleto(_orcamentoId);

            if (dados.Tables["Cabecalho"] == null || dados.Tables["Cabecalho"]!.Rows.Count == 0)
            {
                MessageBox.Show("Orçamento não encontrado.");
                Close();
                return;
            }

            DataRow cabecalho = dados.Tables["Cabecalho"]!.Rows[0];

            txtTitulo.Text = cabecalho["Titulo"].ToString();
            cmbStatus.Text = cabecalho["Status"].ToString();
            numVariacaoNota2.Value = Convert.ToDecimal(cabecalho["VariacaoNota2"]);
            numVariacaoNota3.Value = Convert.ToDecimal(cabecalho["VariacaoNota3"]);
            txtObservacao.Text = cabecalho["Observacao"].ToString();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Informe o título do orçamento.");
                txtTitulo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Selecione o status.");
                cmbStatus.Focus();
                return;
            }

            try
            {
                _orcamentoService.AtualizarDadosOrcamento(
                    _orcamentoId,
                    txtTitulo.Text,
                    cmbStatus.Text,
                    numVariacaoNota2.Value,
                    numVariacaoNota3.Value,
                    txtObservacao.Text
                );

                MessageBox.Show("Orçamento atualizado com sucesso.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar orçamento: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
