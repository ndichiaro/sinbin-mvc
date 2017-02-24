var NavBar = (function () {

    var linkLogOff = {}
    var form = {}
    var toggle = {}
    var content = {}

    var post = function () {
        form.submit();
    };

    var successfulToggle = function(status) {
        if (status === toggle.prop("checked")) {
            if (status) {
                content.show();
            } else {
                content.hide();
            }
        }
    }

    var init = function () {
        linkLogOff.click(function () {
            post();
        });

        toggle.change(function() {
            var data = {
                available: $(this).prop("checked")
            };

            $.ajax({
                url: "/Account/UpdateAvailability",
                type: "POST",
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                error: function (xhr) {
                    alert("Error: " + xhr.statusText);
                },
                success: function (result) {
                    successfulToggle(result);
                }
            });
        });
    };

    // constructor
    var module = function (settings) {
        if ("logoff" in settings) {
            linkLogOff = $(settings.logoff);
        }

        if ("form" in settings) {
            form = $(settings.form);
        }

        if ("toggle" in settings) {
            toggle = $(settings.toggle);
        }

        if ("content" in settings) {
            content = $(settings.content);
        }
    }
    module.prototype.Init = init;
    return module;
})();

$(function () {
    var navBar = new NavBar({
        logoff: "#linkLogOff",
        form: "#logoutForm",
        toggle: "#statusToggle",
        content: ".feed"
    });
    navBar.Init();
});