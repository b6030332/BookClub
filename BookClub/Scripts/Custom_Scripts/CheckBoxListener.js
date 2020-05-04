$(document).ready(function () {

    //Finds the Html Attribute set in '_ChallengeTable' View for the Completed checkbox

    $('.ActiveCheck').change(function () {
        var self = $(this);
        var id = self.attr('id');
        var value = self.prop('checked');

        //Sends an Ajax request which calls the Method setup in the Challenge Controller

        $.ajax({
            url: '/Challenge/AJAXEditChallenge',
            data: {
                id: id,
                value: value
            },
            type: 'POST',
            success: function (result) {
                $('#tableDiv').html(result);
            }
        });

    });
})