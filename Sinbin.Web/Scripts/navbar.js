﻿var NavBar = (function () {

    var linkLogOff, form, toggle, content,
        feedIcon;

    function post() {
        form.submit();
    };

    function successfulToggle(status) {
        if (status === toggle.prop("checked")) {
            if (status) {
                content.show();
            } else {
                content.hide();
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
        linkLogOff.click(function () {
            post();
        });

        initToggleHandlers();
        onLoad();
    };

    // constructor
    function module(settings) {
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