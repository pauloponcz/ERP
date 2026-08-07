namespace ComodoroERP.Models
{
    public class Orcamento
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public DateTime DataOrcamento { get; set; } = DateTime.Today;

        public string Status { get; set; } = "Pendente";

        public decimal VariacaoNota2 { get; set; } = -5;

        public decimal VariacaoNota3 { get; set; } = 1;

        public string Observacao { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}