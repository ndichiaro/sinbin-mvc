var NavBar = (function (settings) {
    var toggle, content, feedIcon, warning;

    if ("toggle" in settings) {
        toggle = $(settings.toggle);
    }

    if ("content" in settings) {
        content = $(settings.content);
    }

    if ("warning" in settings) {
        warning = $(settings.warning);
    }

    function successfulToggle(status) {
        if (status === toggle.prop("checked")) {
            if (status) {
                content.show();
                warning.hide();
            } else {
                content.hide();
                warning.show();
            }
        }
    }
    
    function setStatus(status) {
        if (status) {
            toggle.bootstrapToggle("on");
        } else {
            toggle.bootstrapToggle("off");
        }
        successfulToggle(status);
    }

    function initToggleHandlers() {
        toggle.change(function () {
            var data = {
                available: $(this).prop("checked")
            };

            $.ajax({
                url: "/Account/Availability",
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
    }

    function onLoad() {
        $.ajax({
            url: "/Account/Availability",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            error: function (xhr) {
                alert("Error: " + xhr.statusText);
            },
            success: function (result) {
                setStatus(result);
            }
        });
    }

    function init() {
        initToggleHandlers();
        onLoad();
    };

    this.Init = init;
});