
//When this page loads, ajax navigates to method in the controller (BuildChallengeTable)

$(document).ready(function () {
    
    //Result then gets put into tableDiv
    
    $.ajax({
        url: '/Challenge/BuildChallengeTable',
        success: function (result) {
            $('#tableDiv').html(result);
        }
    });
});