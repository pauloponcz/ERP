namespace ComodoroERP.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Cnpj { get; set; } = string.Empty;

        public string Endereco { get; set; } = string.Empty;

        public string BairroCep { get; set; } = string.Empty;

        public string CidadeEstado { get; set; } = "CURITIBA- PARANÁ";
    }
}