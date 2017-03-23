var LocationManager = (function() {
    var id, options;

    function module(settings) {
        if (settings != undefined) {
            if ("options" in settings) {
                options = settings.options;
            }
        }else {
            options = {
                enableHighAccuracy: true,
                timeout: 5000,
                maximumAge: 0
            }
        }
    }

    function save(lat, long) {
        var data = {
            Latitude: lat,
            Longitude: long
        };

        $.ajax({
            url: "/Account/Location",
            type: "POST",
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            error: function (xhr) {
                console.log("Error: " + xhr.responseText);
            },
            success: function (result) {

            }
        });
    }

    function success(position) {
        var coords = position.coords;
        save(coords.latitude, coords.longitude);
    }

    function error(e) {
        
    }

    function watch() {
        id = navigator.geolocation.watchPosition(success, error, options);
    }

    module.prototype.Watch = watch;

    return module;
})();