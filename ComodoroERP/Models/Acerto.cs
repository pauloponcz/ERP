using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComodoroERP.Models
{
    public class Acerto
    {
        public int Id { get; set; }

        public string NomeEscola { get; set; } = string.Empty;

        public string Servico { get; set; } = string.Empty;

        public decimal Valor { get; set; }

        public string StatusPagamento { get; set; } = "Pendente";

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public DateTime? DataPagamento { get; set; }
    }
}