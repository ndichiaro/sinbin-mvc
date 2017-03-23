var Feed = (function(settings) {
    var container, warning, toggle;

    if ("container" in settings) {
        container = $(settings.container);
    }

    if ("warning" in settings) {
        warning = $(settings.warning);
    }

    if ("toggle" in settings) {
        toggle = $(settings.toggle);
    }

    function build(data) {
        if (data != undefined) {
            // clear existing dom elements
            var containerElement = container[0];
            while (containerElement.firstChild) {
                containerElement.removeChild(containerElement.firstChild);
            }

            if (toggle.prop("checked") && data.length == 0) {
                warning.show()
                $(warning.children()[0]).text("There is no one currently in your area.");
                return;
            }

            for (var i = 0; i < data.length; i++) {
                // create image container
                var imgContainer = document.createElement("div");
                imgContainer.className += " image-container";
                // create user tile
                var user = document.createElement("div");
                user.className += " user";
                // grab tile
                var tile = data[i];
                // set user availability class/image url from tile
                user.style.backgroundImage = "url('" + tile.Image + "')";
                if (tile.Active) {
                    user.className += " user-available";
                } else {
                    user.className += " user-unavailable";
                }
                // add user to image container
                imgContainer.appendChild(user);
                // add image container to feed container
                containerElement.appendChild(imgContainer);
            }
        }
    }

    function get() {
        $.ajax({
            url: "/Feed/Feed",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            error: function (xhr) {
                console.log("Error: " + xhr.responseText);
            },
            success: function (result) {
                build(result);
            }
        });
    }
    
    this.Init = function() {
        setInterval(get, 1000);
    }
});