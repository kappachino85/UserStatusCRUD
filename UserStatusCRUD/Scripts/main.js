$(document).ready(function () {

    getAllUsers();
    $("#submitButton").click(function () {
        console.log('clickedSubmit');
    });

    //because the templates are created dynamically, a regular click handler will not work. it must be done like this:
    $('body').on('click', 'a.nameLink', function () {
        console.log(this);
        console.log('clicked2');
    });

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
            var id = this.Id;
            if (this.Status == "online") {
                $('.online').append('<div class="onTemplate">' + id + '<a class="nameLink"> ' + uName + '</a> is currently online.</div>');
            }
            else if (this.Status == "offline") {
                $('.offline').append('<div class="offTemplate">' + id + '<a class="nameLink"> ' + uName + '</a> is currently offline.</div>');
            }
        });
    }

    function getAllError() {
        console.log("error");
    }

});