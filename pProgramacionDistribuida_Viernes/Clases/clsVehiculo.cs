using libComunes.CapaDatos;
using pProgramacionDistribuida_Viernes.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pProgramacionDistribuida_Viernes.Clases
{
    public class clsVehiculo
    {
        public Vehiculo _vehiculo { get; set; }
        public string Error { get; set; }
        // public GridView grdCliente { get; set; }
        public bool Consultar()
        {
            string SQL = "SELECT     MarcaVehiculo, Modelo, Placa " +
                                "FROM         tblTipoVehiculo " +
                                "WHERE        IdVehiculo  = @prIdVehiculo ; ";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prIdVehiculo ", _vehiculo.IdVehiculo);

            //Se hace la consulta a la base de datos
            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    //Se inicia el proceso de lectura
                    oConexion.Reader.Read();
                    //Se lee los datos en el orden de la consulta
                    _vehiculo.Marca = oConexion.Reader.GetString(0);                    
                    _vehiculo.Modelo = oConexion.Reader.GetInt32(1);
                    _vehiculo.Placa = oConexion.Reader.GetString(2);

                    return true;
                }
                else
                {
                    //No hay datos, es un error para el usuario
                    Error = "No hay datos para el id del vehiculo: " + _vehiculo.IdVehiculo;
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
            string SQL = "INSERT INTO tblTipoVehiculo (IdVehiculo, MarcaVehiculo, Modelo,Placa) " +
                         "VALUES (@prIdVehiculo, @prMarca, @prModelo, @prPlaca )";

            //Se crea la instancia de la clase clsConexion (de la librería libcomunes), la cual permite conectarse a una base de datos SQL Server que está definida
            //en un archivo .xml con las indicaciones del servidor, base de datos, modo de conexión (Seguridad integrada o no) y usuario
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prIdVehiculo", _vehiculo.IdVehiculo);
            oConexion.AgregarParametro("@prMarca", _vehiculo.Marca);
            oConexion.AgregarParametro("@prModelo", _vehiculo.Modelo);
            oConexion.AgregarParametro("@prPlaca", _vehiculo.Placa);

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
            string SQL = "UPDATE   tblTipoVehiculo SET  IdVehiculo = @prIdVehiculo,  MarcaVehiculo = @prMarca, Modelo = @prModelo , Placa = @prPlaca " +
                                                 "WHERE        IdVehiculo = @prIdVehiculo; ";

            //Se crea la instancia de la clase clsConexion (de la librería libcomunes), la cual permite conectarse a una base de datos SQL Server que está definida
            //en un archivo .xml con las indicaciones del servidor, base de datos, modo de conexión (Seguridad integrada o no) y usuario
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prIdVehiculo", _vehiculo.IdVehiculo);
            oConexion.AgregarParametro("@prMarca", _vehiculo.Marca);
            oConexion.AgregarParametro("@prModelo", _vehiculo.Modelo);
            oConexion.AgregarParametro("@prPlaca", _vehiculo.Placa);

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
            string SQL = "DELETE FROM        tblTipoVehiculo " +
                         "WHERE             IdVehiculo = @prIdVehiculo; ";

            //Se crea la instancia de la clase clsConexion (de la librería libcomunes), la cual permite conectarse a una base de datos SQL Server que está definida
            //en un archivo .xml con las indicaciones del servidor, base de datos, modo de conexión (Seguridad integrada o no) y usuario
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prIdVehiculo", _vehiculo.IdVehiculo);
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