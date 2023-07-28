using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pProgramacionDistribuida_Viernes.Modelos;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;


namespace pProgramacionDistribuida_Viernes.Clases
{
    public class clsCliente
    {

        public Cliente _cliente { get; set; }
        public string Error { get; set; }
        public GridView grdCliente { get; set; }
        public bool Consultar()
        {
            string SQL = "SELECT       TipoDoc, NombreCliente, Telefono, Email  " +
                                "FROM         tblCliente " +
                                "WHERE        Documento = @prDocumento; ";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", _cliente.Documento);

            //Se hace la consulta a la base de datos
            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    //Se inicia el proceso de lectura
                    oConexion.Reader.Read();
                    //Se lee los datos en el orden de la consulta
                    _cliente.TipoDoc = oConexion.Reader.GetString(0);
                    _cliente.NombreCliente = oConexion.Reader.GetString(1);
                    _cliente.Telefono = oConexion.Reader.GetString(2);
                    _cliente.Email = oConexion.Reader.GetString(3);

                    return true;
                }
                else
                {
                    //No hay datos, es un error para el usuario
                    Error = "El cliente de documento: " + _cliente.Documento + "no está registrado en la base de datos";
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
            string SQL = "INSERT INTO tblCliente (TipoDoc, Documento, NombreCliente, Telefono, Email) " +
                         "VALUES (@prTipoDoc, @prDocumento, @prNombreCliente, @prTelefono, @prEmail)";

            //Se crea la instancia de la clase clsConexion (de la librería libcomunes), la cual permite conectarse a una base de datos SQL Server que está definida
            //en un archivo .xml con las indicaciones del servidor, base de datos, modo de conexión (Seguridad integrada o no) y usuario
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prTipoDoc", _cliente.TipoDoc);
            oConexion.AgregarParametro("@prDocumento", _cliente.Documento);
            oConexion.AgregarParametro("@prNombreCliente", _cliente.NombreCliente);
            oConexion.AgregarParametro("@prTelefono", _cliente.Telefono);
            oConexion.AgregarParametro("@prEmail", _cliente.Email);

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
            string SQL = "UPDATE   tblCliente SET   TipoDoc = @prTipoDoc, NombreCliente = @prNombreCliente, Telefono = @prTelefono, Email = @prEmail " +
                                                 "WHERE        Documento = @prDocumento; ";

            //Se crea la instancia de la clase clsConexion (de la librería libcomunes), la cual permite conectarse a una base de datos SQL Server que está definida
            //en un archivo .xml con las indicaciones del servidor, base de datos, modo de conexión (Seguridad integrada o no) y usuario
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prTipoDoc", _cliente.TipoDoc);
            oConexion.AgregarParametro("@prDocumento", _cliente.Documento);
            oConexion.AgregarParametro("@prNombreCliente", _cliente.NombreCliente);
            oConexion.AgregarParametro("@prTelefono", _cliente.Telefono);
            oConexion.AgregarParametro("@prEmail", _cliente.Email);

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
            string SQL = "DELETE FROM        tblCliente " +
                         "WHERE             Documento = @prDocumento; ";

            //Se crea la instancia de la clase clsConexion (de la librería libcomunes), la cual permite conectarse a una base de datos SQL Server que está definida
            //en un archivo .xml con las indicaciones del servidor, base de datos, modo de conexión (Seguridad integrada o no) y usuario
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", _cliente.Documento);
            if (Consultar()) {
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

        public bool LlenarGrid()
        {
           string SQL = "SELECT        dbo.tblCliente.TipoDoc, dbo.tblCliente.Documento, dbo.tblCliente.NombreCliente, dbo.tblCliente.Telefono, " +
                                "dbo.tblCliente.Email" +
                  "FROM          dbo.tblCliente ";

            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.grdGenerico = grdCliente;
            oGrid.NombreTabla = "dbo.tblCliente";
            if (oGrid.LlenarGridWeb())
            {
                grdCliente = oGrid.grdGenerico;
                oGrid = null;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                oGrid = null;
                return false;
            }
        }

    }
}