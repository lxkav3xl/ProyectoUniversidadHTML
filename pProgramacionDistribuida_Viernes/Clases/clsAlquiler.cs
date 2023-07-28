using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pProgramacionDistribuida_Viernes.Modelos;
using libComunes.CapaDatos;

namespace pProgramacionDistribuida_Viernes.Clases
{
    public class clsAlquiler
    {
        public Alquiler _alquiler { get; set; }
        public string Error { get; set; }
        // public GridView grdCliente { get; set; }
        public bool Consultar()
        {
            string SQL = "SELECT      DocumentoCliente, NombreCliente, TipoVehiculo, FechaAlquiler, DiasAlquiler " +
                                "FROM         tblAlquiler " +
                                "WHERE        CodigoAlquiler  = @prCodigoAlquiler ; ";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoAlquiler ", _alquiler.CodigoAlquiler);

            //Se hace la consulta a la base de datos
            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    //Se inicia el proceso de lectura
                    oConexion.Reader.Read();
                    //Se lee los datos en el orden de la consulta
                    _alquiler.DocumentoCliente = oConexion.Reader.GetString(0);
                    _alquiler.NombreCliente = oConexion.Reader.GetString(1);
                    _alquiler.TipoVehiculo = oConexion.Reader.GetString(2);
                    _alquiler.FechaAlquiler = oConexion.Reader.GetString(3);
                    _alquiler.DiasAlquiler = oConexion.Reader.GetInt32(4);

                    return true;
                }
                else
                {
                    //No hay datos, es un error para el usuario
                    Error = "No hay datos para el código de alquiler: " + _alquiler.CodigoAlquiler;
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
            string SQL = "INSERT INTO tblAlquiler (CodigoAlquiler, DocumentoCliente, NombreCliente, TipoVehiculo, FechaAlquiler, DiasAlquiler) " +
                         "VALUES (@prCodigoAlquiler, @prDocumentoCliente, @prNombreCliente, @prTipoVehiculo, @prFechaAlquiler, @prDiasAlquiler)";

            //Se crea la instancia de la clase clsConexion (de la librería libcomunes), la cual permite conectarse a una base de datos SQL Server que está definida
            //en un archivo .xml con las indicaciones del servidor, base de datos, modo de conexión (Seguridad integrada o no) y usuario
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoAlquiler", _alquiler.CodigoAlquiler);
            oConexion.AgregarParametro("@prDocumentoCliente", _alquiler.DocumentoCliente);
            oConexion.AgregarParametro("@prNombreCliente", _alquiler.NombreCliente);
            oConexion.AgregarParametro("@prTipoVehiculo", _alquiler.TipoVehiculo);
            oConexion.AgregarParametro("@prFechaAlquiler", _alquiler.FechaAlquiler);
            oConexion.AgregarParametro("@prDiasAlquiler", _alquiler.DiasAlquiler);

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
            string SQL = "UPDATE   tblAlquiler SET    DocumentoCliente = @prDocumentoCliente, NombreCliente = @prNombreCliente, TipoVehiculo = @prTipoVehiculo, FechaAlquiler = @prFechaAlquiler, DiasAlquiler = @prDiasAlquiler " +
                                                 "WHERE        CodigoAlquiler = @prCodigoAlquiler; ";

            //Se crea la instancia de la clase clsConexion (de la librería libcomunes), la cual permite conectarse a una base de datos SQL Server que está definida
            //en un archivo .xml con las indicaciones del servidor, base de datos, modo de conexión (Seguridad integrada o no) y usuario
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoAlquiler", _alquiler.CodigoAlquiler);
            oConexion.AgregarParametro("@prDocumentoCliente", _alquiler.DocumentoCliente);
            oConexion.AgregarParametro("@prNombreCliente", _alquiler.NombreCliente);
            oConexion.AgregarParametro("@prTipoVehiculo", _alquiler.TipoVehiculo);
            oConexion.AgregarParametro("@prFechaAlquiler", _alquiler.FechaAlquiler);
            oConexion.AgregarParametro("@prDiasAlquiler", _alquiler.DiasAlquiler);

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
            string SQL = "DELETE FROM        tblAlquiler " +
                         "WHERE             CodigoAlquiler = @prCodigoAlquiler; ";

            //Se crea la instancia de la clase clsConexion (de la librería libcomunes), la cual permite conectarse a una base de datos SQL Server que está definida
            //en un archivo .xml con las indicaciones del servidor, base de datos, modo de conexión (Seguridad integrada o no) y usuario
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoAlquiler", _alquiler.CodigoAlquiler);
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