//Código para garantizar que se ejecute el código cuando termine de cargar la página
$(document).ready(function () {
    //Defino la funcionalidad de la página
    //Funcionalidad del botón "Registrar"
    $("#btnRegistrar").click(function () {
        ProcesarComando("Insertar");
        ConsultarFecha();
        LlenarGridAlquiler();
        
    });
    $("#btnActualizar").click(function () {
        ProcesarComando("Actualizar");
        ConsultarFecha();
        LlenarGridAlquiler();
    });
    $("#btnEliminar").click(function () {
        ProcesarComando("Eliminar");
        LlenarGridAlquiler();
    });
    $("#btnConsultar").click(function () {
        ProcesarComando("Consultar");
    });
    ConsultarFecha();
    LlenarComboTipo();
    LlenarGridAlquiler();
    //Comando = "GET";

    //Llena el texto de fecha, con la fecha del computador
    
   // LlenarComboTipos();
});

function LlenarGridAlquiler() {
    let sURL = "../Controladores/Comunes/ControladorGrids.ashx";
    //Invoca el URL del llenado de combos
    LlenarGridControlador(sURL, "Alquiler", null, "#tblAlquiler");
}

function LlenarComboTipo() {
    let sUrl = "../Controladores/Comunes/ControladorCombos.ashx";
    LlenarComboControlador(sUrl, "Vehiculo", null,"#cboTipo");
}

function ProcesarComando(Comando) {


    var CodigoAlquiler = $("#txtCodigoAlquiler").val();
    var FechaAlquiler = $("#txtFechaAlquiler").val();
    var TipoVehiculo = $("#cboTipo").val();
    var DocumentoCliente = $("#txtDocumentoCliente").val();
    var NombreCliente = $("#txtNombreCliente").val();
    var DiasAlquiler = $("#txtDiasAlquiler").val();

    //Se hacen las validaciones requeridas por el cliente (Contratante)
    if (CodigoAlquiler === null || CodigoAlquiler === '' || CodigoAlquiler === 'undefined') {
        $("#dvMensaje").addClass("alert alert-danger");
        $("#dvMensaje").html("Debe ingresar el código del alquiler");
        return;
    }
    else {
        $("#dvMensaje").removeClass("alert alert-danger");
        $("#dvMensaje").html("");
    }


    if (Comando != "Eliminar" && Comando != "Consultar") {
        if (DocumentoCliente === null || DocumentoCliente === '' || DocumentoCliente === 'undefined') {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Debe ingresar el documento del cliente");
            return;
        }
        else {
            $("#dvMensaje").removeClass("alert alert-danger");
            $("#dvMensaje").html("");
        }
        if (FechaAlquiler === null || FechaAlquiler === '' || FechaAlquiler === 'undefined') {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Debe ingresar la fecha");
            return;
        }
        else {
            $("#dvMensaje").removeClass("alert alert-danger");
            $("#dvMensaje").html("");
        }
        if (TipoVehiculo === null || TipoVehiculo === '' || TipoVehiculo === 'undefined') {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Debe seleccionar un tipo de vehículo");
            return;
        }
        else {
            $("#dvMensaje").removeClass("alert alert-danger");
            $("#dvMensaje").html("");
        }
        if (NombreCliente === null || NombreCliente === '' || NombreCliente === 'undefined') {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Debe ingresar el nombre del cliente");
            return;
        }
        else {
            $("#dvMensaje").removeClass("alert alert-danger");
            $("#dvMensaje").html("");
        }       
        if (DiasAlquiler === null || DiasAlquiler === '' || DiasAlquiler === 'undefined') {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Debe ingresar cantidad de dias del alquiler");
            return;
        }
        else {
            $("#dvMensaje").removeClass("alert alert-danger");
            $("#dvMensaje").html("");
        }
    }
    else {
        DocumentoCliente = 0;
        TipoVehiculo = 0;
        NombreCliente = " ";
        NombreProducto = " ";
        DiasAlquiler = 0;
    }

    var DatosAlquiler = {
        CodigoAlquiler: CodigoAlquiler,
        FechaAlquiler: FechaAlquiler,
        TipoVehiculo: TipoVehiculo,
        DocumentoCliente: DocumentoCliente,
        NombreCliente: NombreCliente,
        DiasAlquiler: DiasAlquiler,
        Comando: Comando
    }


    //Inicia el proceso de invocación de  la página del servidor con ajax
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorAlquiler.ashx",
        contentType: "json",
        data: JSON.stringify(DatosAlquiler),
        success: function (RptaAlquiler) {
            //Creo una variable con la respuesta de cliente, y la paso como 
            //objeto json
            var Alquiler = JSON.parse(RptaAlquiler);
            if (Alquiler.Mensaje == "SI") {
                $("#dvMensaje").addClass("alert alert-success");
                $("#dvMensaje").html(Alquiler.Error);
                if (Comando == "Eliminar") {
                    $("#txtDocumentoCliente").val("");
                    $("#txtNombreCliente").val("");
                    $("#cboTipo").val("");
                    $("#txtDiasAlquiler").val("");
                }
                if (Comando == "Consultar") {
                    //Se presenta en los campos del cliente la información consultada
                    $("#txtDocumentoCliente").val(Alquiler.DocumentoCliente);
                    $("#txtNombreCliente").val(Alquiler.NombreCliente);
                    $("#cboTipo").val(Alquiler.TipoVehiculo);
                    $("#txtFechaAlquiler").val(Alquiler.FechaAlquiler);
                    $("#txtDiasAlquiler").val(Alquiler.DiasAlquiler);

                }
            }
            else {
                $("#dvMensaje").addClass("alert alert-danger");
                $("#dvMensaje").html(Alquiler.Error);
            }

        },
        error: function (RptaError) {
            alert("Error: " + RptaError);
        }
    });
}
function ConsultarFecha() {
    var f = new Date();

    $("#txtFechaAlquiler").val(f.getDate() + "-" + (f.getMonth() + 1) + "-" + f.getFullYear());
}
