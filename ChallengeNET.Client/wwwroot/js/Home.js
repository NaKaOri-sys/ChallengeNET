$(document).ready(function () {
    $('#campo').inputmask('9999-9999-9999');
    $('#btn-exit').hide();
});
$('#btn-submit').on('click', {}, function () {
    let campoValue = $('#campo').val();
    if (campoValue === '') {
        alert("Por favor, ingresa los dígitos antes de continuar.")
        return;
    }

    $.post("Home/ValidateTarjeta", { nro_tarjeta: campoValue }
    ).done(function (response) {
        window.location.href = "/Home/IngresaPinView";
    }).fail(function (xhr, status, error) {
        window.location.href = "/Home/Error";
    });
});
let intentos = 0;
let intentosMax = 4;
$('#btn-aceptar').on('click', {}, function () {
    let campoValue = $('#campo').val();
    if (campoValue === '') {
        alert("Por favor, ingresa el pin antes de continuar.")
        return;
    }
    if (intentos === 4) {
        $.post("/Home/BloquearTarjeta")
            .done(function (response) {
                window.location.href = "/Home/TarjetaBloqueada";
            }).fail(function (xhr, status, error) {
                window.location.href = "/Home/Error";
            });
        return;
    }

    $.post("/Home/ValidateCVV", { pin_tarjeta: campoValue }
    ).done(function (response) {
        window.location.href = "/Operacion/Operaciones";
    }).fail(function (xhr, status, error) {
        alert('El código ingresado es incorrecto, intentos restantes:' + (intentosMax - intentos));
        intentos++;
    });
});