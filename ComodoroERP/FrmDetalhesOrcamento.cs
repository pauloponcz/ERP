using ComodoroERP.Models;
using ComodoroERP.Reports;
using ComodoroERP.Services;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Drawing;

namespace ComodoroERP
{
    public partial class FrmDetalhesOrcamento : Form
    {
        private readonly int _orcamentoId;
        private readonly OrcamentoService _orcamentoService = new();

        public FrmDetalhesOrcamento(int orcamentoId)
        {
            InitializeComponent();

            _orcamentoId = orcamentoId;

            ConfigurarGrid();
            AplicarEstiloVisual();
            CarregarDados();
        }

        private void AplicarEstiloVisual()
        {
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10);

            AplicarEstiloPainel(pnlDados);
            AplicarEstiloPainel(pnlItens);

            AplicarEstiloBotaoPrincipal(btnAdicionarItem);
            AplicarEstiloBotaoPrincipal(btnEditarItem);
            AplicarEstiloBotaoPrincipal(btnEditarOrcamento);
            AplicarEstiloBotaoPrincipal(btnGerarPdfs);
            AplicarEstiloBotaoPrincipal(btnAbrirPastaPdfs);

            AplicarEstiloBotaoExcluir(btnRemoverItem);
            AplicarEstiloBotaoCancelar(btnFechar);

            AplicarEstiloGrid(dgvItens);

            AplicarEstiloCampos(this);
            AplicarEstiloLabelsDados();

            pnlTopo.BackColor = Color.SteelBlue;

            lblTituloTela.ForeColor = Color.White;
            lblTituloTela.Font = new Font("Segoe UI Semibold", 15);

            lblSubtituloTela.ForeColor = Color.WhiteSmoke;
            lblSubtituloTela.Font = new Font("Segoe UI", 9);
        }

        private void AplicarEstiloLabelsDados()
        {
            Color corTextoPrincipal = Color.FromArgb(35, 35, 35);
            Color corTextoSecundario = Color.FromArgb(70, 70, 70);
            Color corValorFinanceiro = Color.SteelBlue;

            Font fonteNormal = new Font("Segoe UI", 9.5f);
            Font fonteDestaque = new Font("Segoe UI Semibold", 9.5f);
            Font fonteValor = new Font("Segoe UI Semibold", 10);

            lblDadosOrcamento.ForeColor = corTextoPrincipal;
            lblDadosOrcamento.Font = new Font("Segoe UI Semibold", 11);

            lblId.ForeColor = corTextoPrincipal;
            lblId.Font = fonteDestaque;

            lblStatus.ForeColor = corTextoPrincipal;
            lblStatus.Font = fonteDestaque;

            lblData.ForeColor = corTextoPrincipal;
            lblData.Font = fonteDestaque;

            lblCliente.ForeColor = corTextoPrincipal;
            lblCliente.Font = fonteDestaque;

            lblCnpj.ForeColor = corTextoPrincipal;
            lblCnpj.Font = fonteDestaque;

            lblEndereco.ForeColor = corTextoSecundario;
            lblEndereco.Font = fonteNormal;

            lblTitulo.ForeColor = corTextoPrincipal;
            lblTitulo.Font = fonteDestaque;

            lblValorNota1.ForeColor = corValorFinanceiro;
            lblValorNota1.Font = fonteValor;

            lblValorNota2.ForeColor = corValorFinanceiro;
            lblValorNota2.Font = fonteValor;

            lblValorNota3.ForeColor = corValorFinanceiro;
            lblValorNota3.Font = fonteValor;

            lblItensOrcamento.ForeColor = corTextoPrincipal;
            lblItensOrcamento.Font = new Font("Segoe UI Semibold", 11);
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

        private void AplicarEstiloBotaoExcluir(Button botao)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.BackColor = Color.IndianRed;
            botao.ForeColor = Color.White;
            botao.Font = new Font("Segoe UI Semibold", 10);
            botao.Cursor = Cursors.Hand;

            botao.FlatAppearance.BorderSize = 0;

            botao.MouseEnter += (s, e) =>
            {
                botao.BackColor = Color.Firebrick;
            };

            botao.MouseLeave += (s, e) =>
            {
                botao.BackColor = Color.IndianRed;
            };
        }

        private void AplicarEstiloGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = Color.Gainsboro;

            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            grid.DefaultCellStyle.SelectionBackColor = Color.AliceBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
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

                if (controle.HasChildren)
                {
                    AplicarEstiloCampos(controle);
                }
            }
        }

        private void ConfigurarGrid()
        {
            dgvItens.DataSource = null;
            dgvItens.Columns.Clear();
            dgvItens.AutoGenerateColumns = true;

            dgvItens.AllowUserToAddRows = false;
            dgvItens.AllowUserToDeleteRows = false;
            dgvItens.ReadOnly = true;
            dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItens.MultiSelect = false;
            dgvItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvItens.DataError += dgvItens_DataError;
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
            DataTable itens = dados.Tables["Itens"]!;

            decimal valorNota1 = CalcularTotal(itens, 0);
            decimal variacaoNota2 = ConverterDecimal(cabecalho["VariacaoNota2"]);
            decimal variacaoNota3 = ConverterDecimal(cabecalho["VariacaoNota3"]);
            decimal valorNota2 = CalcularTotal(itens, variacaoNota2);
            decimal valorNota3 = CalcularTotal(itens, variacaoNota3);

            lblId.Text = $"ID: {cabecalho["Id"]}";
            lblCliente.Text = $"Cliente: {cabecalho["Cliente"]}";
            lblCnpj.Text = $"CNPJ: {cabecalho["Cnpj"]}";
            lblEndereco.Text = $"Endereço: {cabecalho["Endereco"]} - {cabecalho["BairroCep"]} - {cabecalho["CidadeEstado"]}";
            lblData.Text = $"Data: {Convert.ToDateTime(cabecalho["DataOrcamento"]):dd/MM/yyyy}";
            lblTitulo.Text = $"Título: {cabecalho["Titulo"]}";
            lblStatus.Text = $"Status: {cabecalho["Status"]}";

            lblValorNota1.Text = $"Nota 1: {FormatarMoeda(valorNota1)}";
            lblValorNota2.Text = $"Nota 2 ({variacaoNota2}%): {FormatarMoeda(valorNota2)}";
            lblValorNota3.Text = $"Nota 3 ({variacaoNota3}%): {FormatarMoeda(valorNota3)}";

            dgvItens.DataSource = itens;

            FormatarGrid();
        }

        private void FormatarGrid()
        {
            if (dgvItens.Columns.Count == 0)
                return;

            if (dgvItens.Columns.Contains("Id"))
                dgvItens.Columns["Id"].Visible = false;

            if (dgvItens.Columns.Contains("Categoria"))
                dgvItens.Columns["Categoria"].HeaderText = "Categoria";

            if (dgvItens.Columns.Contains("ServicoPermitido"))
                dgvItens.Columns["ServicoPermitido"].HeaderText = "Serviço Permitido";

            if (dgvItens.Columns.Contains("DescricaoOrcamento"))
                dgvItens.Columns["DescricaoOrcamento"].HeaderText = "Descrição";

            if (dgvItens.Columns.Contains("Quantidade"))
                dgvItens.Columns["Quantidade"].HeaderText = "Qtd";

            if (dgvItens.Columns.Contains("ValorUnitario"))
            {
                dgvItens.Columns["ValorUnitario"].HeaderText = "Valor Unitário";
                dgvItens.Columns["ValorUnitario"].DefaultCellStyle.Format = "C2";
            }

            if (dgvItens.Columns.Contains("Cortesia"))
                dgvItens.Columns["Cortesia"].HeaderText = "Cortesia";

            if (dgvItens.Columns.Contains("ValorTotal"))
            {
                dgvItens.Columns["ValorTotal"].HeaderText = "Total";
                dgvItens.Columns["ValorTotal"].DefaultCellStyle.Format = "C2";
            }

            if (dgvItens.Columns.Contains("Observacao"))
                dgvItens.Columns["Observacao"].HeaderText = "Observação";
        }

        private decimal CalcularTotal(DataTable itens, decimal variacaoPercentual)
        {
            decimal total = 0;

            foreach (DataRow item in itens.Rows)
            {
                bool cortesia = Convert.ToInt32(item["Cortesia"]) == 1;

                if (cortesia)
                    continue;

                decimal valorOriginal = ConverterDecimal(item["ValorTotal"]);

                decimal valorGerado = valorOriginal * (1 + (variacaoPercentual / 100));

                total += valorGerado;
            }

            return total;
        }

        private decimal ConverterDecimal(object valor)
        {
            if (valor == null || valor == DBNull.Value)
                return 0;

            return Convert.ToDecimal(valor);
        }

        private string FormatarMoeda(decimal valor)
        {
            return valor.ToString("C2", new CultureInfo("pt-BR"));
        }

        private void btnGerarPdfs_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new ExcelModeloPdfService();

                var arquivosPdf = service.GerarPdfsPorModeloExcel(_orcamentoId);

                MessageBox.Show($"PDFs gerados com sucesso: {arquivosPdf.Count}");

                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar PDFs: " + ex.Message);
            }
        }

        private void btnAbrirPastaPdfs_Click(object sender, EventArgs e)
        {
            var configuracaoService = new ConfiguracaoService();

            string pastaPdfs = configuracaoService.ObterPastaPdfs();

            if (!Directory.Exists(pastaPdfs))
            {
                MessageBox.Show("A pasta de PDFs ainda não existe.");
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = pastaPdfs,
                UseShellExecute = true
            });
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvItens_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnEditarOrcamento_Click(object sender, EventArgs e)
        {
            using var tela = new FrmEditarOrcamento(_orcamentoId);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarDados();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            using var tela = new FrmAdicionarItemOrcamento(_orcamentoId);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarDados();
            }
        }

        private void btnRemoverItem_Click(object sender, EventArgs e)
        {
            if (dgvItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para remover.");
                return;
            }

            object valorId = dgvItens.SelectedRows[0].Cells["Id"].Value;

            if (valorId == null)
            {
                MessageBox.Show("Não foi possível identificar o item selecionado.");
                return;
            }

            int itemId = Convert.ToInt32(valorId);

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente remover este item?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta != DialogResult.Yes)
                return;

            try
            {
                _orcamentoService.RemoverItemOrcamento(itemId);

                MessageBox.Show("Item removido com sucesso.");

                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover item: " + ex.Message);
            }
        }

        private void btnEditarItem_Click(object sender, EventArgs e)
        {
            if (dgvItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para editar.");
                return;
            }

            DataGridViewRow row = dgvItens.SelectedRows[0];

            var item = new OrcamentoItem
            {
                Id = Convert.ToInt32(row.Cells["Id"].Value),
                OrcamentoId = _orcamentoId,
                Categoria = row.Cells["Categoria"].Value?.ToString() ?? "",
                ServicoPermitido = row.Cells["ServicoPermitido"].Value?.ToString() ?? "",
                DescricaoOrcamento = row.Cells["DescricaoOrcamento"].Value?.ToString() ?? "",
                Quantidade = Convert.ToDecimal(row.Cells["Quantidade"].Value),
                ValorUnitario = Convert.ToDecimal(row.Cells["ValorUnitario"].Value),
                Cortesia = Convert.ToInt32(row.Cells["Cortesia"].Value) == 1,
                ValorTotal = Convert.ToDecimal(row.Cells["ValorTotal"].Value),
                Observacao = row.Cells["Observacao"].Value?.ToString() ?? ""
            };

            using var tela = new FrmEditarItemOrcamento(item);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarDados();
            }
        }


    }
}