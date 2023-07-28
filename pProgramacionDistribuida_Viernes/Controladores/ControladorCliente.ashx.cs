using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using pProgramacionDistribuida_Viernes.Modelos;
using Newtonsoft.Json;
using pProgramacionDistribuida_Viernes.Clases;

namespace pProgramacionDistribuida_Viernes.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorCliente
    /// </summary>
    public class ControladorCliente : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string DatosCliente;
            StreamReader reader = new StreamReader(context.Request.InputStream);

            DatosCliente = reader.ReadToEnd();

            Cliente _cliente = JsonConvert.DeserializeObject<Cliente>(DatosCliente);



            switch (_cliente.Comando.ToUpper())
            {
                case "INSERTAR":
                    context.Response.Write(Insertar(_cliente));
                    break;
                case "ACTUALIZAR":
                    context.Response.Write(Actualizar(_cliente));
                    break;
                case "ELIMINAR":
                    context.Response.Write(Eliminar(_cliente));
                    break;
                case "CONSULTAR":
                    context.Response.Write(Consultar(_cliente));
                    break;
            }
        }

        private string Consultar(Cliente cliente)
        {

            clsCliente oCliente = new clsCliente();
            oCliente._cliente = cliente;
            if (oCliente.Consultar())
            {
                cliente = oCliente._cliente;
                cliente.Mensaje = "SI";
                cliente.Error = "El registro del cliente fue consultado exitosamente en la base de datos";
            }
            else
            {
                cliente.Mensaje = "NO";
                cliente.Error = oCliente.Error;
            }
            return JsonConvert.SerializeObject(cliente);
        }
        private string Insertar(Cliente cliente)
        {
            clsCliente oCliente = new clsCliente();
            oCliente._cliente = cliente;
            if (oCliente.Insertar())
            {
                cliente.Mensaje = "SI";
                cliente.Error = "El registro del cliente se ingresó exitosamente en la base de datos";
            }
            else
            {
                cliente.Mensaje = "NO";
                cliente.Error = oCliente.Error;
            }
            return JsonConvert.SerializeObject(cliente);
        }
        private string Eliminar(Cliente cliente)
        {
            clsCliente oCliente = new clsCliente();
            oCliente._cliente = cliente;
            if (oCliente.Eliminar())
            {
                cliente.Mensaje = "SI";
                cliente.Error = "El registro del cliente fue eliminado exitosamente en la base de datos";
            }
            else
            {
                cliente.Mensaje = "NO";
                cliente.Error = oCliente.Error;
            }
            return JsonConvert.SerializeObject(cliente);
        }
        private string Actualizar(Cliente cliente)
        {
            clsCliente oCliente = new clsCliente();
            oCliente._cliente = cliente;
            if (oCliente.Actualizar())
            {
                cliente.Mensaje = "SI";
                cliente.Error = "El registro del cliente fue actualizado exitosamente en la base de datos";
            }
            else
            {
                cliente.Mensaje = "NO";
                cliente.Error = oCliente.Error;
            }
            return JsonConvert.SerializeObject(cliente);
        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}