$('#btn-aceptar').on('click', {}, function () {
    let campoValue = $('#campo').val();
    if (campoValue === '') {
        alert("Por favor, ingresa el monto antes de continuar.")
        return;
    }
    $.post("/Operaciones/ValidateMontoDinero", { monto_retiro: campoValue }
    ).done(function (response) {
        
    }).fail(function (xhr, status, error) {
        alert('Ha excedido el saldo que tiene en su cuenta, su saldo es: $' + error);
        return;
    });

    $.post("/Operaciones/RetiroDinero", { monto_retiro: campoValue }
    ).done(function (response) {
        window.location.href = "/Operaciones/RetiroExitoso";
    }).fail(function (xhr, status, error) {
        window.location.href = "/Home/Error";
    });
});