var Register = (function () {

    var fileInput = {}
    var fileImage = {}

    // constructor
    var module = function (settings) {
        if ("input" in settings) {
            fileInput = $(settings.input);
        }

        if ("image" in settings) {
            fileImage = $(settings.image);
        }

        init();
    }

    var init = function () {
        fileInput.change(function () {
            setImage(this);
        });
    }

    var setImage = function (input) {
        if (input.files && input.files[0] && fileImage.length > 0) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $(fileImage)
                    .css('background-image', "url(" + e.target.result + ")");
            };

            reader.readAsDataURL(input.files[0]);
        }
    }

    return module;
})();

$(function () {
    var register = new Register({
        input: "#file-input",
        image: "#file-image"
    });
});