var empr = 0,
    empl = 0;

(function ($) {
    var xhrRequests = [];

    // Cada vez que se hace una peticion, la agregamos al arreglo
    $(document).ajaxSend(function (e, jqXHR, options) {
        xhrRequests.push(jqXHR);
    });

    // Y al completarse la peticion la eliminamos del arreglo, de lo contrario se quedara para ser cancelada
    $(document).ajaxComplete(function (e, jqXHR, options) {
        xhrRequests = $.grep(xhrRequests, function (x) {
            return x != jqXHR;
        });
    });

    // Recorrer cada peticion y cancelarla
    var abandonarTodasLasPeticiones = function () {
        $.each(xhrRequests, function (idx, jqXHR) {
            jqXHR.abort();
        });
    };
})(jQuery);

$(document).ready(function (e) {
    $.ajax({
        async: false,
        type: "POST",
        url: "/Home/Data",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "JSON",
        success: function (request) {
            console.log(request);

            if (request.Mensaje != "Nada pendiente") {
                empr = request.IdEmpresa_Real;
                empl = request.Legajo;

                $("#idEmpresa").val(request.IdEmpresa)
                $("#password").val(request.password)
                $("#idSector").val(request.IdSector)
                $("#Nombre").val(request.Nombre)
                $("#Apellido").val(request.Apellido)
                $("#Documento").val(request.Documento)
                $("#Legajo").val(request.Legajo)
                $("#Email").val(request.Email)
                $("#Telefono").val(request.Telefono)
                $("#Direccion").val(request.Direccion)
                $("#FotoUsuario").val(request.FotoUsuario)
                $("#Obsevaciones").val(request.Observaciones)
                $("#Habilitado").val(request.Habilitado);

                $("form").submit();
                Update_Empleado();

            } else {
                exit();
            }
        },
        error: function(jqXHR, textStatus, errorThrown) {
            console.log("Ha ocurrido un error al conectar: " + jqXHR + textStatus + errorThrown);
        }
    }); 
});

function Update_Empleado() {

    var data = {
        empresa: empr,
        nomina: empl
    }

    $.ajax({
        async: false,
        type: "POST",
        url: "/Home/Update",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "JSON",
        success: function (request) {
            console.log(request);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Ha ocurrido un error al conectar: " + jqXHR + textStatus + errorThrown);
        }
    });

    exit();
}

function exit() {
    window.open('', '_parent', '');
    window.close();
}