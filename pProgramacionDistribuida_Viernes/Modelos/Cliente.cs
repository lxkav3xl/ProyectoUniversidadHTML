using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pProgramacionDistribuida_Viernes.Modelos
{
    public class Cliente
    {
        public string TipoDoc { get; set; }
        public string Documento { get; set; }
        public string NombreCliente    { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Comando { get; set; }
        public string Error { get; set; }
        public string Mensaje { get; set; }
    }
}