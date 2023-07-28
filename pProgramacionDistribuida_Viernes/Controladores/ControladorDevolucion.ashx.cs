using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using pProgramacionDistribuida_Viernes.Modelos;
using Newtonsoft.Json;
using pProgramacionDistribuida_Viernes.Clases;

namespace pProgramacionDistribuida_Viernes.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorInyectologia
    /// </summary>
    public class ControladorDevolucion : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string DatosDevolucion;
            StreamReader reader = new StreamReader(context.Request.InputStream);

            DatosDevolucion = reader.ReadToEnd();

            Devolucion _devolucion = JsonConvert.DeserializeObject<Devolucion>(DatosDevolucion);



            switch (_devolucion.Comando.ToUpper())
            {
                case "INSERTAR":
                    context.Response.Write(Insertar(_devolucion));
                    break;
                case "ACTUALIZAR":
                    context.Response.Write(Actualizar(_devolucion));
                    break;
                case "ELIMINAR":
                    context.Response.Write(Eliminar(_devolucion));
                    break;
                case "CONSULTAR":
                    context.Response.Write(Consultar(_devolucion));
                    break;
                    /*case "GET":
                        context.Response.Write(Get());
                        break;*/
            }
        }

        private string Consultar(Devolucion devolucion)
        {

            clsDevolucion oDevolucion = new clsDevolucion();
            oDevolucion._devolucion = devolucion;
            if (oDevolucion.Consultar())
            {
                devolucion = oDevolucion._devolucion;
                devolucion.Mensaje = "SI";
                devolucion.Error = "El registro del devolucion se consultó exitosamente en la base de datos";
            }
            else
            {
                devolucion.Mensaje = "NO";
                devolucion.Error = oDevolucion.Error;
            }
            return JsonConvert.SerializeObject(devolucion);
        }
        private string Insertar(Devolucion devolucion)
        {
            clsDevolucion oDevolucion = new clsDevolucion();
            oDevolucion._devolucion = devolucion;
            if (oDevolucion.Insertar())
            {
                devolucion.Mensaje = "SI";
                devolucion.Error = "El registro del devolucion se realizó exitosamente en la base de datos";
            }
            else
            {
                devolucion.Mensaje = "NO";
                devolucion.Error = oDevolucion.Error;
            }
            return JsonConvert.SerializeObject(devolucion);
        }
        private string Eliminar(Devolucion devolucion)
        {
            clsDevolucion oDevolucion = new clsDevolucion();
            oDevolucion._devolucion = devolucion;
            if (oDevolucion.Eliminar())
            {
                devolucion.Mensaje = "SI";
                devolucion.Error = "El registro del devolucion se eliminó exitosamente en la base de datos";
            }
            else
            {
                devolucion.Mensaje = "NO";
                devolucion.Error = oDevolucion.Error;
            }
            return JsonConvert.SerializeObject(devolucion);
        }
        private string Actualizar(Devolucion devolucion)
        {
            clsDevolucion oDevolucion = new clsDevolucion();
            oDevolucion._devolucion = devolucion;
            if (oDevolucion.Actualizar())
            {
                devolucion.Mensaje = "SI";
                devolucion.Error = "El registro del devolucion se actualizó exitosamente en la base de datos";
            }
            else
            {
                devolucion.Mensaje = "NO";
                devolucion.Error = oDevolucion.Error;
            }
            return JsonConvert.SerializeObject(devolucion);
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