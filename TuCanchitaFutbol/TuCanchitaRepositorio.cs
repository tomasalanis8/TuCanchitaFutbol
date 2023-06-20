using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuCanchitaFutbol
{
    public class TuCanchitaRepositorio
    {
        public static List<TuCanchita> Turnos { get; set; }

        public static void InicializarRepositorio()
        {
            Turnos = new List<TuCanchita>();
        }

        public static void AñadirTurno(TuCanchita turno)
        {
            Turnos.Add(turno);
        }
    }
}
