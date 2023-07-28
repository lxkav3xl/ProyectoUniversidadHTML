using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pProgramacionDistribuida_Viernes.Modelos;
using libComunes.CapaDatos;

namespace pProgramacionDistribuida_Viernes.Clases
{
    public class clsDevolucion
    {
        public Devolucion _devolucion { get; set; }
        public string Error { get; set; }
        // public GridView grdCliente { get; set; }
        public bool Consultar()
        {
            string SQL = "SELECT     FechaDevolucion, TipoVehiculo, DocumentoCliente, NombreCliente " +
                                "FROM         tblDevolucion " +
                                "WHERE        CodigoDevolucion  = @prCodigoDevolucion ; ";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoDevolucion ", _devolucion.CodigoDevolucion);

            //Se hace la consulta a la base de datos
            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    //Se inicia el proceso de lectura
                    oConexion.Reader.Read();
                    //Se lee los datos en el orden de la consulta
                    _devolucion.FechaDevolucion = oConexion.Reader.GetString(0);
                    _devolucion.TipoVehiculo = oConexion.Reader.GetString(1);
                    _devolucion.DocumentoCliente = oConexion.Reader.GetString(2);
                    _devolucion.NombreCliente = oConexion.Reader.GetString(3);

 

                    return true;
                }
                else
                {
                    //No hay datos, es un error para el usuario
                    Error = "No hay datos para el código de la devolución: " + _devolucion.CodigoDevolucion;
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool Insertar()
        {
            string SQL = "INSERT INTO tblDevolucion (CodigoDevolucion,FechaDevolucion, TipoVehiculo, DocumentoCliente, NombreCliente) " +
                         "VALUES (@prCodigoDevolucion, @prFechaDevolucion, @prTipoVehiculo, @prDocumentoCliente, @prNombreCliente)";

            //Se crea la instancia de la clase clsConexion (de la librería libcomunes), la cual permite conectarse a una base de datos SQL Server que está definida
            //en un archivo .xml con las indicaciones del servidor, base de datos, modo de conexión (Seguridad integrada o no) y usuario
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoDevolucion", _devolucion.CodigoDevolucion);
            oConexion.AgregarParametro("@prDocumentoCliente", _devolucion.DocumentoCliente);
            oConexion.AgregarParametro("@prNombreCliente", _devolucion.NombreCliente);
            oConexion.AgregarParametro("@prTipoVehiculo", _devolucion.TipoVehiculo);
            oConexion.AgregarParametro("@prFechaDevolucion", _devolucion.FechaDevolucion);

            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool Actualizar()
        {
            string SQL = "UPDATE   tblDevolucion SET    DocumentoCliente = @prDocumentoCliente, NombreCliente = @prNombreCliente, TipoVehiculo = @prTipoVehiculo, FechaDevolucion = @prFechaDevolucion " +
                                                 "WHERE        CodigoDevolucion = @prCodigoDevolucion; ";

            //Se crea la instancia de la clase clsConexion (de la librería libcomunes), la cual permite conectarse a una base de datos SQL Server que está definida
            //en un archivo .xml con las indicaciones del servidor, base de datos, modo de conexión (Seguridad integrada o no) y usuario
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoDevolucion", _devolucion.CodigoDevolucion);
            oConexion.AgregarParametro("@prDocumentoCliente", _devolucion.DocumentoCliente);
            oConexion.AgregarParametro("@prNombreCliente", _devolucion.NombreCliente);
            oConexion.AgregarParametro("@prTipoVehiculo", _devolucion.TipoVehiculo);
            oConexion.AgregarParametro("@prFechaDevolucion", _devolucion.FechaDevolucion);

            if (Consultar())
            {
                if (oConexion.EjecutarSentencia())
                {
                    return true;
                }
                else
                {
                    Error = oConexion.Error;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Eliminar()
        {
            //Invocar el método para los cálculos
            string SQL = "DELETE FROM        tblDevolucion " +
                         "WHERE             CodigoDevolucion = @prCodigoDevolucion; ";

            //Se crea la instancia de la clase clsConexion (de la librería libcomunes), la cual permite conectarse a una base de datos SQL Server que está definida
            //en un archivo .xml con las indicaciones del servidor, base de datos, modo de conexión (Seguridad integrada o no) y usuario
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoDevolucion", _devolucion.CodigoDevolucion);
            if (Consultar())
            {
                if (oConexion.EjecutarSentencia())
                {
                    return true;
                }
                else
                {
                    Error = oConexion.Error;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}