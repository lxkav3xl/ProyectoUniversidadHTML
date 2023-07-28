using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pProgramacionDistribuida_Viernes.Modelos
{
    public class Alquiler
    {
        public int CodigoAlquiler { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string TipoVehiculo { get; set; }
        public string FechaAlquiler { get; set; }
        public int DiasAlquiler { get; set; }
        public string Comando { get; set; }
        public string Error { get; set; }
        public string Mensaje { get; set; }
    }
}