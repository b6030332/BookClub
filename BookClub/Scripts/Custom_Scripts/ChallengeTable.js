$(document).ready(function () {

    $.ajax({
        url: '/Challenge/BuildChallengeTable',
        success: function (result) {
            $('#tableDiv').html(result);
        }
    });
});