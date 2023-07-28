using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pProgramacionDistribuida_Viernes.Modelos
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string Placa { get; set; }
        public int Modelo { get; set; }
        public string Marca { get; set; }
        public string Comando { get; set; }
        public string Error { get; set; }
        public string Mensaje { get; set; }
    }
}