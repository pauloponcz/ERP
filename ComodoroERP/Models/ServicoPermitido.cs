namespace ComodoroERP.Models
{
    public class ServicoPermitido
    {
        public int Id { get; set; }

        public string Categoria { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public bool Ativo { get; set; } = true;
    }
}