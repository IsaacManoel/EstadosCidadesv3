using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadosCidades.Models
{
    public class Clima
    {
        public DateTime Data { get; set; }
        public string Condicao { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double IndiceUV { get; set; }
        public string CondicaoDesc { get; set; }
    }
}
