using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace TuCanchitaFutbol
{
    public class TuCanchita
    {
        public double DNI { get; set; }
        public string Nombre { get; set; }
        public double Dia { get; set; }
        public double Mes { get; set; }
        public double Año { get; set; }
        public double Precio { get; set; }

        public TuCanchita(double DNI, string Nombre, double Dia, double Mes, double Año, double Precio)
        {
            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Dia = Dia;     
            this.Mes = Mes;
            this.Año = Año;
            this.Precio= Precio;
        }
    }
}
