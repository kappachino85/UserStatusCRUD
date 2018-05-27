$(document).ready(function () {
    console.log('hi');
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

    function getAllSuccess(data) {
        $.each(data, function () {
            console.log(this.Status);
            var uName = this.UserName;
            if (this.Status == "online") {
                $('.online').append('<div class="onTemplate">' + uName + ' is currently online.</div>');
            }
            else if (this.Status == "offline") {
                $('.offline').append('<div class="offTemplate">' + uName + ' is currently offline.</div>');
            }
        });
    }

    function getAllError() {
        console.log("error");
    }

});

