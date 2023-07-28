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
    public class ControladorAlquiler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string DatosAlquiler;
            StreamReader reader = new StreamReader(context.Request.InputStream);

            DatosAlquiler = reader.ReadToEnd();

            Alquiler _alquiler = JsonConvert.DeserializeObject<Alquiler>(DatosAlquiler);



            switch (_alquiler.Comando.ToUpper())
            {
                case "INSERTAR":
                    context.Response.Write(Insertar(_alquiler));
                    break;
                case "ACTUALIZAR":
                    context.Response.Write(Actualizar(_alquiler));
                    break;
                case "ELIMINAR":
                    context.Response.Write(Eliminar(_alquiler));
                    break;
                case "CONSULTAR":
                    context.Response.Write(Consultar(_alquiler));
                    break;
                    /*case "GET":
                        context.Response.Write(Get());
                        break;*/
            }
        }

        private string Consultar(Alquiler alquiler)
        {

            clsAlquiler oAlquiler = new clsAlquiler();
            oAlquiler._alquiler = alquiler;
            if (oAlquiler.Consultar())
            {
                alquiler = oAlquiler._alquiler;
                alquiler.Mensaje = "SI";
                alquiler.Error = "El registro del alquiler se consultó exitosamente en la base de datos";
            }
            else
            {
                alquiler.Mensaje = "NO";
                alquiler.Error = oAlquiler.Error;
            }
            return JsonConvert.SerializeObject(alquiler);
        }
        private string Insertar(Alquiler alquiler)
        {
            clsAlquiler oAlquiler = new clsAlquiler();
            oAlquiler._alquiler = alquiler;
            if (oAlquiler.Insertar())
            {
                alquiler.Mensaje = "SI";
                alquiler.Error = "El registro del alquiler se realizó exitosamente en la base de datos";
            }
            else
            {
                alquiler.Mensaje = "NO";
                alquiler.Error = oAlquiler.Error;
            }
            return JsonConvert.SerializeObject(alquiler);
        }
        private string Eliminar(Alquiler alquiler)
        {
            clsAlquiler oAlquiler = new clsAlquiler();
            oAlquiler._alquiler = alquiler;
            if (oAlquiler.Eliminar())
            {
                alquiler.Mensaje = "SI";
                alquiler.Error = "El registro del alquiler se eliminó exitosamente en la base de datos";
            }
            else
            {
                alquiler.Mensaje = "NO";
                alquiler.Error = oAlquiler.Error;
            }
            return JsonConvert.SerializeObject(alquiler);
        }
        private string Actualizar(Alquiler alquiler)
        {
            clsAlquiler oAlquiler = new clsAlquiler();
            oAlquiler._alquiler = alquiler;
            if (oAlquiler.Actualizar())
            {
                alquiler.Mensaje = "SI";
                alquiler.Error = "El registro del alquiler se actualizó exitosamente en la base de datos";
            }
            else
            {
                alquiler.Mensaje = "NO";
                alquiler.Error = oAlquiler.Error;
            }
            return JsonConvert.SerializeObject(alquiler);
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