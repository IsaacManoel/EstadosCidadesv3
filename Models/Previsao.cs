using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadosCidades.Models
{
    public class Previsao
    {
        public Cidade Cidade { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public List<Clima> ClimaProximosDias { get; set; }
    }
}
