//Código para garantizar que se ejecute el código cuando termine de cargar la página
$(document).ready(function () {
    //Defino la funcionalidad de la página
    //Funcionalidad del botón "Registrar"
    $("#btnRegistrar").click(function () {
        ProcesarComando("Insertar");
        ConsultarFecha();
        LlenarGridDevolucion();
        
    });
    $("#btnActualizar").click(function () {
        ProcesarComando("Actualizar");
        ConsultarFecha();
        LlenarGridDevolucion();
    });
    $("#btnEliminar").click(function () {
        ProcesarComando("Eliminar");
        LlenarGridDevolucion();
    });
    $("#btnConsultar").click(function () {
        ProcesarComando("Consultar");
    });
    ConsultarFecha();
    LlenarComboTipo();
    LlenarGridDevolucion();
    //Comando = "GET";

    //Llena el texto de fecha, con la fecha del computador

    // LlenarComboTipos();
});

function LlenarGridDevolucion() {
    let sURL = "../Controladores/Comunes/ControladorGrids.ashx";
    //Invoca el URL del llenado de combos
    LlenarGridControlador(sURL, "Devolucion", null, "#tblDevolucion");
}

function LlenarComboTipo() {
    let sUrl = "../Controladores/Comunes/ControladorCombos.ashx";
    LlenarComboControlador(sUrl, "Vehiculo", null, "#cboTipo");
}

function ProcesarComando(Comando) {


    var CodigoDevolucion = $("#txtCodigoDevolucion").val();
    var FechaDevolucion = $("#txtFechaDevolucion").val();
    var TipoVehiculo = $("#cboTipo").val();
    var DocumentoCliente = $("#txtDocumentoCliente").val();
    var NombreCliente = $("#txtNombreCliente").val();


    //Se hacen las validaciones requeridas por el cliente (Contratante)
    if (CodigoDevolucion === null || CodigoDevolucion === '' || CodigoDevolucion === 'undefined') {
        $("#dvMensaje").addClass("alert alert-danger");
        $("#dvMensaje").html("Debe ingresar el código de la devolución");
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
        if (FechaDevolucion === null || FechaDevolucion === '' || FechaDevolucion === 'undefined') {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Debe ingresar una fecha");
            return;
        }
        else {
            $("#dvMensaje").removeClass("alert alert-danger");
            $("#dvMensaje").html("");
        }
        if (TipoVehiculo === null || TipoVehiculo === '' || TipoVehiculo === 'undefined') {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Debe seleccionar un tipo de vehículo a devolver");
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
        
    }
    else {
        DocumentoCliente = 0;
        TipoVehiculo = 0;
        NombreCliente = " ";
        NombreProducto = " ";
    }

    var DatosDevolucion = {
        CodigoDevolucion: CodigoDevolucion,
        FechaDevolucion: FechaDevolucion,
        TipoVehiculo: TipoVehiculo,
        DocumentoCliente: DocumentoCliente,
        NombreCliente: NombreCliente,
        Comando: Comando
    }


    //Inicia el proceso de invocación de  la página del servidor con ajax
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorDevolucion.ashx",
        contentType: "json",
        data: JSON.stringify(DatosDevolucion),
        success: function (RptaDevolucion) {
            //Creo una variable con la respuesta de cliente, y la paso como 
            //objeto json
            var Devolucion = JSON.parse(RptaDevolucion);
            if (Devolucion.Mensaje == "SI") {
                $("#dvMensaje").addClass("alert alert-success");
                $("#dvMensaje").html(Devolucion.Error);
                if (Comando == "Eliminar") {
                    $("#txtDocumentoCliente").val("");
                    $("#txtNombreCliente").val("");
                    $("#cboTipo").val("");
                }
                if (Comando == "Consultar") {
                    //Se presenta en los campos del cliente la información consultada
                    $("#txtDocumentoCliente").val(Devolucion.DocumentoCliente);
                    $("#txtNombreCliente").val(Devolucion.NombreCliente);
                    $("#cboTipo").val(Devolucion.TipoVehiculo);
                    $("#txtFechaDevolucion").val(Devolucion.FechaDevolucion);


                }
            }
            else {
                $("#dvMensaje").addClass("alert alert-danger");
                $("#dvMensaje").html(Devolucion.Error);
            }

        },
        error: function (RptaError) {
            alert("Error: " + RptaError);
        }
    });
}
function ConsultarFecha() {
    var f = new Date();

    $("#txtFechaDevolucion").val(f.getDate() + "-" + (f.getMonth() + 1) + "-" + f.getFullYear());
}