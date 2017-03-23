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
        $(warning.children()[0]).text('You must be available to view the feed.');
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
                    console.log("Error: " + xhr.responseText);
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
                console.log("Error: " + xhr.responseText);
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