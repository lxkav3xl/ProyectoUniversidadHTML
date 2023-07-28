using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pProgramacionDistribuida_Viernes.Modelos
{
    public class Devolucion
    {
        public int CodigoDevolucion { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string TipoVehiculo { get; set; }
        public string FechaDevolucion { get; set; }
        public string Comando { get; set; }
        public string Error { get; set; }
        public string Mensaje { get; set; }
    }
}