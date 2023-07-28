//Código para garantizar que se ejecute el código cuando termine de cargar la página
$(document).ready(function () {
    //Defino la funcionalidad de la página
    //Funcionalidad del botón "Registrar"
    $("#btnRegistrar").click(function () {
        ProcesarComando("Insertar");
        LlenarGridVehiculo();
    });
    $("#btnActualizar").click(function () {
        ProcesarComando("Actualizar");
        LlenarGridVehiculo();
    });
    $("#btnEliminar").click(function () {
        ProcesarComando("Eliminar");
        LlenarGridVehiculo();
    });
    $("#btnConsultar").click(function () {
        ProcesarComando("Consultar");
    });
    LlenarGridVehiculo();
    //Comando = "GET";

    //Llena el texto de fecha, con la fecha del computador

    // LlenarComboTipos();
});

function LlenarGridVehiculo() {
    let sURL = "../Controladores/Comunes/ControladorGrids.ashx";
    //Invoca el URL del llenado de combos
    LlenarGridControlador(sURL, "Vehiculo", null, "#tblTipoVehiculo");
}

function ProcesarComando(Comando) {


    var IdVehiculo = $("#txtIdVehiculo").val();
    var Marca = $("#txtMarca").val();
    var Modelo = $("#txtModelo").val();
    var Placa = $("#txtPlaca").val();


    //Se hacen las validaciones requeridas por el cliente (Contratante)
    if (IdVehiculo === null || IdVehiculo === '' || IdVehiculo === 'undefined') {
        $("#dvMensaje").addClass("alert alert-danger");
        $("#dvMensaje").html("Debe ingresar el ID del vehiculo");
        return;
    }
    else {
        $("#dvMensaje").removeClass("alert alert-danger");
        $("#dvMensaje").html("");
    }


    if (Comando != "Eliminar" && Comando != "Consultar") {
        if (Placa === null || Placa === '' || Placa === 'undefined') {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Debe ingresar la placa del vehiculo");
            return;
        }
        else {
            $("#dvMensaje").removeClass("alert alert-danger");
            $("#dvMensaje").html("");
        }
        if (Marca === null || Marca === '' || Marca === 'undefined') {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Debe ingresar la marca del vehiculo");
            return;
        }
        else {
            $("#dvMensaje").removeClass("alert alert-danger");
            $("#dvMensaje").html("");
        }
        if (Modelo === null || Modelo === '' || Modelo === 'undefined') {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html("Debe ingresar el modelo del vehiculo");
            return;
        }
        else {
            $("#dvMensaje").removeClass("alert alert-danger");
            $("#dvMensaje").html("");
        }

    }
    else {
        Modelo = 0;
        Marca = " ";
        Placa = " ";
    }

    var DatosVehiculo = {
        IdVehiculo: IdVehiculo,
        Marca: Marca,
        Modelo: Modelo,
        Placa: Placa,
        Comando: Comando
    }


    //Inicia el proceso de invocación de  la página del servidor con ajax
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorVehiculo.ashx",
        contentType: "json",
        data: JSON.stringify(DatosVehiculo),
        success: function (RptaVehiculo) {
            //Creo una variable con la respuesta de cliente, y la paso como 
            //objeto json
            var Vehiculo = JSON.parse(RptaVehiculo);
            if (Vehiculo.Mensaje == "SI") {
                $("#dvMensaje").addClass("alert alert-success");
                $("#dvMensaje").html(Vehiculo.Error);
                if (Comando == "Eliminar") {
                    $("#txtPlaca").val("");
                    $("#txtModelo").val("");
                    $("#txtMarca").val("");
                    $("#txtIdVehiculo").val("");
                }
                if (Comando == "Consultar") {
                    //Se presenta en los campos del cliente la información consultada
                    $("#txtPlaca").val(Vehiculo.Placa);
                    $("#txtModelo").val(Vehiculo.Modelo);
                    $("#txtMarca").val(Vehiculo.Marca);


                }
            }
            else {
                $("#dvMensaje").addClass("alert alert-danger");
                $("#dvMensaje").html(Vehiculo.Error);
            }

        },
        error: function (RptaError) {
            alert("Error: " + RptaError);
        }
    });
}
