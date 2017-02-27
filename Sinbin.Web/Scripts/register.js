var Register = (function () {

    var fileInput, fileImage;

    // constructor
    function module(settings) {
        if ("input" in settings) {
            fileInput = $(settings.input);
        }

        if ("image" in settings) {
            fileImage = $(settings.image);
        }
    }

    function setImage(input) {
        if (input.files && input.files[0] && fileImage.length > 0) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $(fileImage)
                    .css('background-image', "url(" + e.target.result + ")");
            };

            reader.readAsDataURL(input.files[0]);
        }
    }

    module.prototype.Init = function () {
        fileInput.change(function () {
            setImage(this);
        });
    }

    return module;
})();

$(function () {
    var register = new Register({
        input: "#file-input",
        image: "#file-image"
    });
    register.Init();
});