var MenuIcon = function(settings) {
    var sender, active, src, altSrc;

    // grab id and create jQuery object
    if ("sender" in settings) {
        sender = $("#" + settings.sender);
    } else {
        throw "An Id is required for a MenuIcon object.";
    }

    // by default, the icon is inactive when
    // being created unless specified 
    if ("active" in settings) {
        active = settings.active;
    } else {
        active = false;
    }

    if ("src" in settings) {
        src = settings.src;
    } else {
        throw "A source is required for a MenuIcon object.";
    }

    if ("alt" in settings) {
        altSrc = settings.alt;
    } else {
        throw "An alternative source is required for a MenuIcon object.";
    }

    // modifies the image based on the status parameter
    function activate(status) {
        if (status) {
            sender.attr("src", src);
        } else {
            sender.attr("src", altSrc);
        }
    }

    // if active sets src, otherwise sets altSrc
    this.Init = function() {
        activate(active);
    }

    // public active method
    this.Activate = function(status) {
        activate(status);
    }

    // assign callback parameter to the click event 
    // of the sender object
    this.Click = function(callback) {
        sender.click(callback);
    }
};