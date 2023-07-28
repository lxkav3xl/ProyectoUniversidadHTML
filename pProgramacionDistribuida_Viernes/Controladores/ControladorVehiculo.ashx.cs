using Newtonsoft.Json;
using pProgramacionDistribuida_Viernes.Clases;
using pProgramacionDistribuida_Viernes.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace pProgramacionDistribuida_Viernes.Controllers
{
    /// <summary>
    /// Descripción breve de AdministracionVehiculo
    /// </summary>
    public class ControladorVehiculo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string DatosVehiculo;
            StreamReader reader = new StreamReader(context.Request.InputStream);

            DatosVehiculo = reader.ReadToEnd();

            Vehiculo _vehiculo = JsonConvert.DeserializeObject<Vehiculo>(DatosVehiculo);



            switch (_vehiculo.Comando.ToUpper())
            {
                case "INSERTAR":
                    context.Response.Write(Insertar(_vehiculo));
                    break;
                case "ACTUALIZAR":
                    context.Response.Write(Actualizar(_vehiculo));
                    break;
                case "ELIMINAR":
                    context.Response.Write(Eliminar(_vehiculo));
                    break;
                case "CONSULTAR":
                    context.Response.Write(Consultar(_vehiculo));
                    break;
                    /*case "GET":
                        context.Response.Write(Get());
                        break;*/
            }
        }

        private string Consultar(Vehiculo vehiculo)
        {

            clsVehiculo oVehiculo = new clsVehiculo();
            oVehiculo._vehiculo = vehiculo;
            if (oVehiculo.Consultar())
            {
                vehiculo = oVehiculo._vehiculo;
                vehiculo.Mensaje = "SI";
                vehiculo.Error = "El registro del vehiculo se consultó exitosamente en la base de datos";
            }
            else
            {
                vehiculo.Mensaje = "NO";
                vehiculo.Error = oVehiculo.Error;
            }
            return JsonConvert.SerializeObject(vehiculo);
        }
        private string Insertar(Vehiculo vehiculo)
        {
            clsVehiculo oVehiculo = new clsVehiculo();
            oVehiculo._vehiculo = vehiculo;
            if (oVehiculo.Insertar())
            {
                vehiculo.Mensaje = "SI";
                vehiculo.Error = "El registro del vehiculo se realizó exitosamente en la base de datos";
            }
            else
            {
                vehiculo.Mensaje = "NO";
                vehiculo.Error = oVehiculo.Error;
            }
            return JsonConvert.SerializeObject(vehiculo);
        }
        private string Eliminar(Vehiculo vehiculo)
        {
            clsVehiculo oVehiculo = new clsVehiculo();
            oVehiculo._vehiculo = vehiculo;
            if (oVehiculo.Eliminar())
            {
                vehiculo.Mensaje = "SI";
                vehiculo.Error = "El registro del vehiculo se eliminó exitosamente en la base de datos";
            }
            else
            {
                vehiculo.Mensaje = "NO";
                vehiculo.Error = oVehiculo.Error;
            }
            return JsonConvert.SerializeObject(vehiculo);
        }
        private string Actualizar(Vehiculo vehiculo)
        {
            clsVehiculo oVehiculo = new clsVehiculo();
            oVehiculo._vehiculo = vehiculo;
            if (oVehiculo.Actualizar())
            {
                vehiculo.Mensaje = "SI";
                vehiculo.Error = "El registro del vehiculo se actualizó exitosamente en la base de datos";
            }
            else
            {
                vehiculo.Mensaje = "NO";
                vehiculo.Error = oVehiculo.Error;
            }
            return JsonConvert.SerializeObject(vehiculo);
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