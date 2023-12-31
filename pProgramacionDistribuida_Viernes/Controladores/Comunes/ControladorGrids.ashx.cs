﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using libComunes.CapaObjetos;

namespace pProgramacionDistribuida_Viernes.Paginas.Scripts.Comunes
{
    /// <summary>
    /// Descripción breve de ControladorGrids
    /// </summary>
    public class ControladorGrids : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String DatosGrid;

            StreamReader reader = new StreamReader(context.Request.InputStream);
            DatosGrid = reader.ReadToEnd();

            viewGrid oGrid = JsonConvert.DeserializeObject<viewGrid>(DatosGrid);

            string Respuesta;

            switch (oGrid.Comando.ToUpper())
            {
                case "ALQUILER":
                    Respuesta = LlenarGrid(oGrid, "SP_Alquiler_LlenarGrid");
                    break;
                case "CLIENTE":
                    Respuesta = LlenarGrid(oGrid, "sp_Cliente_LlenarGrid");
                    break;
                case "DEVOLUCION":
                    Respuesta = LlenarGrid(oGrid, "SP_Devolucion_LlenarGrid");
                    break;
                case "VEHICULO":
                    Respuesta = LlenarGrid(oGrid, "sp_Vehiculo_LlenarGrid");
                    break;
                default:
                    Respuesta = "Sin definir";
                    break;
                    /*
                    case "Comando o grid para llenar":
                        Respuesta = LlenarGrid(Objeto, "Procedimiento almacenado");
                        break;
                    */
                    /*
                    case "Cliente":
                        Respuesta = LlenarGrid(oGrid, "Cliente_Grid");
                        break;
                    case "Supermercado":
                        Respuesta = LlenarGrid(oGrid, "Supermercado_Grid");
                        break;
                    case "Producto":
                        Respuesta = LlenarGrid(oGrid, "Producto_Grid");
                        break;
                    case "Empleados":
                        Respuesta = LlenarGrid(oGrid, "Empleado_Grid");
                        break;
                    default:
                        Respuesta = "Sin definir";
                        break;
                    */
            }
            context.Response.ContentType = "application/json";

            context.Response.Write(Respuesta);
            //JsonConvert.SerializeObject(Cliente);
        }
        private string LlenarGrid(viewGrid oGrid, string SQL)
        {
            oGrid.SQL = SQL;
            clsGridListas oGridListas = new clsGridListas();
            oGridListas.oGrid = oGrid;
            return JsonConvert.SerializeObject(oGridListas.ListarGrid());
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