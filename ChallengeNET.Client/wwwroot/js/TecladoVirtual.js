$(document).ready(function () {
    $('.table_teclado tr td').click(function () {
        var number = $(this).text();

        if (number == 'Limpiar') {
            $('#campo').val('');
        }
        else {
            $('#campo').val($('#campo').val() + number).focus();
        }

    });
});