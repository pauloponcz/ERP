using ComodoroERP.Services;
using System.Data;

namespace ComodoroERP
{
    public partial class FrmServicosPermitidos : Form
    {
        private readonly ServicoPermitidoService _service = new();

        public FrmServicosPermitidos()
        {
            InitializeComponent();

            ConfigurarGrid();
            CarregarCategorias();
            CarregarServicos();
        }
        private void dgvServicosPermitidos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void ConfigurarGrid()
        {
            dgvServicosPermitidos.AutoGenerateColumns = true;
            dgvServicosPermitidos.Columns.Clear();

            dgvServicosPermitidos.AllowUserToAddRows = false;
            dgvServicosPermitidos.AllowUserToDeleteRows = false;
            dgvServicosPermitidos.ReadOnly = true;
            dgvServicosPermitidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicosPermitidos.MultiSelect = false;
            dgvServicosPermitidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvServicosPermitidos.DataError += dgvServicosPermitidos_DataError;
        }


        private void CarregarCategorias()
        {
            cmbFiltroCategoria.Items.Clear();
            cmbFiltroCategoria.Items.Add("Todas");

            var categorias = _service.ListarCategorias();

            foreach (var categoria in categorias)
            {
                cmbFiltroCategoria.Items.Add(categoria);
            }

            cmbFiltroCategoria.SelectedIndex = 0;
        }

        private void CarregarServicos()
        {
            string categoriaFiltro = "";
            string servicoFiltro = txtFiltroServico.Text.Trim();

            if (cmbFiltroCategoria.SelectedItem != null && cmbFiltroCategoria.Text != "Todas")
            {
                categoriaFiltro = cmbFiltroCategoria.Text;
            }

            DataTable tabela = _service.ListarServicos(categoriaFiltro, servicoFiltro);

            dgvServicosPermitidos.DataSource = null;
            dgvServicosPermitidos.Columns.Clear();
            dgvServicosPermitidos.AutoGenerateColumns = true;
            dgvServicosPermitidos.DataSource = tabela;

            FormatarGrid();
        }

        private void FormatarGrid()
        {
            if (dgvServicosPermitidos.Columns.Count == 0)
                return;

            if (dgvServicosPermitidos.Columns.Contains("Id"))
                dgvServicosPermitidos.Columns["Id"].HeaderText = "ID";

            if (dgvServicosPermitidos.Columns.Contains("Categoria"))
                dgvServicosPermitidos.Columns["Categoria"].HeaderText = "Categoria";

            if (dgvServicosPermitidos.Columns.Contains("Descricao"))
                dgvServicosPermitidos.Columns["Descricao"].HeaderText = "Serviço Permitido";

            if (dgvServicosPermitidos.Columns.Contains("Ativo"))
                dgvServicosPermitidos.Columns["Ativo"].HeaderText = "Ativo";
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarServicos();
        }

        private void btnLimparFiltros_Click(object sender, EventArgs e)
        {
            txtFiltroServico.Clear();
            cmbFiltroCategoria.SelectedIndex = 0;
            CarregarServicos();
        }

        private void btnImportarLista_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Selecione o arquivo CSV de serviços permitidos";
            dialog.Filter = "Arquivos CSV (*.csv)|*.csv|Todos os arquivos (*.*)|*.*";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                int quantidade = _service.ImportarCsv(dialog.FileName);

                MessageBox.Show($"Importação concluída com sucesso. Serviços novos importados: {quantidade}");

                CarregarCategorias();
                CarregarServicos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao importar CSV: " + ex.Message);
            }
        }
        private void ImportarListaPadrao()
        {
            try
            {
                // Por enquanto vamos inserir alguns exemplos.
                // Depois trocamos por importação de CSV/Excel completa.

                _service.InserirServicoSeNaoExistir("SERVIÇO DE MANUTENÇÃO ELÉTRICA", "INSTALAÇÃO DE LUMINÁRIA");
                _service.InserirServicoSeNaoExistir("SERVIÇO DE MANUTENÇÃO ELÉTRICA", "INSTALAÇÃO DE REFLETOR");
                _service.InserirServicoSeNaoExistir("SERVIÇO DE MANUTENÇÃO ELÉTRICA", "INSTALAÇÃO OU TROCA DE LÂMPADAS");
                _service.InserirServicoSeNaoExistir("SERVIÇO DE MANUTENÇÃO ELÉTRICA", "REPARO DE LUMINÁRIA");

                _service.InserirServicoSeNaoExistir("SERVIÇO DE MANUTENÇÃO HIDRÁULICA", "DESENTUPIMENTO DE VASO SANITÁRIO");
                _service.InserirServicoSeNaoExistir("SERVIÇO DE MANUTENÇÃO HIDRÁULICA", "REPARO DE REDE HIDRÁULICA");
                _service.InserirServicoSeNaoExistir("SERVIÇO DE MANUTENÇÃO HIDRÁULICA", "SUBSTITUIÇÃO DE ASSENTO SANITÁRIO");

                _service.InserirServicoSeNaoExistir("SERVIÇO DE MANUTENÇÃO DE PINTURA, TELHADO E PISO", "REPARO DE TELHADO COM AUTORIZAÇÃO DA SME");
                _service.InserirServicoSeNaoExistir("SERVIÇO DE MANUTENÇÃO DE PINTURA, TELHADO E PISO", "PINTURA INTERNA E EXTERNA MANTENDO PADRAO E COR");
                _service.InserirServicoSeNaoExistir("SERVIÇO DE MANUTENÇÃO DE PINTURA, TELHADO E PISO", "REPARO DE PISO");

                MessageBox.Show("Lista padrão importada com sucesso.");

                CarregarCategorias();
                CarregarServicos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao importar lista: " + ex.Message);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}