$(document).ready(function () {
    
    getAllUsers();

    var data = {};

    //gets all the users and status
    function getAllUsers() {
        var url = "/api/users";

        var settings = {
            cache: false,
            dataType: "json",
            type: "GET",
            success: getAllSuccess,
            error: getAllError 
        };

        $.ajax(url, settings);
    }

    function getAllSuccess(rdata) {
        $.each(rdata, function () {
            var uName = this.UserName;
            if (this.Status == 1) {
                $('.online').append('<div class="onTemplate">' + uName + ' is currently online.</div>');
            }
            else if (this.Status == 0) {
                $('.offline').append('<div class="offTemplate">' + uName + ' is currently offline.</div>');
            }
        });
    }

    function getAllError() {
        console.log("error");
    }

});

