namespace ComodoroERP.Models
{
    public class OrcamentoItem
    {
        public int Id { get; set; }

        public int OrcamentoId { get; set; }

        public string Categoria { get; set; } = string.Empty;

        public string ServicoPermitido { get; set; } = string.Empty;

        public string DescricaoOrcamento { get; set; } = string.Empty;

        public decimal Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public bool Cortesia { get; set; }

        public decimal ValorTotal { get; set; }

        public string Observacao { get; set; } = string.Empty;
    }
}