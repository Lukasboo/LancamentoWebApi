using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentoRepositorio.Model
{
    public class Lancamento
    {
        public int IdLancamento { get; set; }
        public DateTime? DataEvento { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdAcao { get; set; }
        public int? IdConta { get; set; }
        public byte? FG_Pago { get; set; }
    }
}
