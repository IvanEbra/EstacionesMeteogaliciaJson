using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaJson4
{
    class Json
    {
        public List<ClaseEstacions> listaEstacionsMeteo;
    }

    public class ClaseEstacions
    {
        public double altitude { get; set; }
        public String concello { get; set; }
        public String estacion { get; set; }
        public int idEstacion { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public String provincia { get; set; }
        public double utmx { get; set; }
        public double utmy { get; set; }
    }
}
