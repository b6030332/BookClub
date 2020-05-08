$(document).ready(function () {

    //Result then gets put into tableDiv

    $.ajax({
        url: '/Post/BuildPostTable',
        success: function (result) {
            $('#allPostDiv').html(result);
        }
    });
});