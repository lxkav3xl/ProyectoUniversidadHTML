//Código para garantizar que se ejecute el código cuando termine de cargar la página
$(document).ready(function () {
   // LlenarGridCliente();
    //Defino la funcionalidad de la página
    //Funcionalidad del botón "Registrar"
    $("#btnRegistrar").click(function () {
        ProcesarComando("Insertar");
        LlenarGridCliente();

        //LlenarGridCliente();
    });
    $("#btnActualizar").click(function () {
        ProcesarComando("Actualizar");
        LlenarGridCliente();

       // LlenarGridCliente();
    });
    $("#btnEliminar").click(function () {
        ProcesarComando("Eliminar");
        //LlenarGridCliente();
        LlenarGridCliente();

    });
    $("#btnConsultar").click(function () {
        ProcesarComando("Consultar");
       // LlenarGridCliente();
    });
    //LlenarGridCliente();
    LlenarGridCliente();
});

function LlenarGridCliente() {
    let sURL = "../Controladores/Comunes/ControladorGrids.ashx";
    //Invoca el URL del llenado de combos
    LlenarGridControlador(sURL, "Cliente", null, "#tblCliente");
}

function ProcesarComando(Comando) {

    var TipoDoc = $("#cboTipoDoc").val();
    var Documento = $("#txtDocumento").val();
    var NombreCliente = $("#txtNombre").val();
    var Telefono = $("#txtTelefono").val();
    var Email = $("#txtEmail").val();
    


    //Se hacen las validaciones requeridas por el cliente (Contratante)
    if (Documento === null || Documento === '' || Documento === 'undefined') {
        $("#dvMensaje").addClass("alert alert-danger");
        $("#dvMensaje").html("Debe ingresar el documento del cliente");
        return;
    }
    else {
        $("#dvMensaje").removeClass("alert alert-danger");
        $("#dvMensaje").html("");
    }

    if (Comando != "Eliminar" && Comando != "Consultar") {
        if (NombreCliente === null || NombreCliente === '' || NombreCliente === 'undefined') {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Debe ingresar el Nombre del cliente");
            return;
        }
        else {
            $("#dvMensaje").removeClass("alert alert-danger");
            $("#dvMensaje").html("");
        }
        if (Telefono === null || Telefono === '' || Telefono === 'undefined') {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Debe ingresar el Teléfono del cliente");
            return;
        }
        else {
            $("#dvMensaje").removeClass("alert alert-danger");
            $("#dvMensaje").html("");
        }

        if (TipoDoc === null || TipoDoc === '' || TipoDoc === 'undefined') {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Debe seleccionar el tipo de documento");
            return;
        }
        else {
            $("#dvMensaje").removeClass("alert alert-danger");
            $("#dvMensaje").html("");
        }
    }
    else {
        NombreCliente = " ";
        Telefono = 0;
        Email = " ";
        TipoDoc = " ";
    }

    var DatosCliente = {
        TipoDoc: TipoDoc,
        Documento: Documento,
        NombreCliente: NombreCliente,
        Telefono: Telefono,
        Email: Email,
        Comando: Comando
    }

   
    //Inicia el proceso de invocación de  la página del servidor con ajax
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorCliente.ashx",
        contentType: "json",
        data: JSON.stringify(DatosCliente),
        success: function (RptaCliente) {
            //Creo una variable con la respuesta de cliente, y la paso como 
            //objeto json
            var Cliente = JSON.parse(RptaCliente);
            if (Cliente.Mensaje == "SI") {
                $("#dvMensaje").addClass("alert alert-success");
                $("#dvMensaje").html(Cliente.Error);
                if (Comando == "Eliminar") {
                    $("#txtNombre").val("");
                    $("#txtTelefono").val("");
                    $("#txtEmail").val("");
                    $("#cboTipoDoc").val("");
                   // LlenarGridCliente();
                }
                if (Comando == "Consultar") {
                    //Se presenta en los campos del cliente la información consultada
                    $("#txtNombre").val(Cliente.NombreCliente);
                    $("#txtTelefono").val(Cliente.Telefono);
                    $("#txtEmail").val(Cliente.Email);
                    $("#cboTipoDoc").val(Cliente.TipoDoc);
                   // LlenarGridCliente();
                }
                LlenarGridCliente();
            }
            else {
                $("#dvMensaje").addClass("alert alert-danger");
                $("#dvMensaje").html(Cliente.Error);
            }
            
        },
        error: function (RptaError) {
            alert("Error: " + RptaError);
        }
    });
    LlenarGridCliente();
}

