﻿var Feed = (function () {

    var linkLogOff = {}
    var form = {}

    // constructor
    var module = function (settings) {
        if ("logoff" in settings) {
            linkLogOff = $(settings.logoff);
        }

        if ("form" in settings) {
            form = $(settings.form);
        }

        init();
    }

    var init = function () {
        linkLogOff.click(function () {
            post(this);
        });
    }

    var post = function (input) {
        form.submit();
    }

    return module;
})();

$(function () {
    var logOff = new Feed({
        logoff: "#linkLogOff",
        form: "#logoutForm"
    });
});