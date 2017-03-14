var PhotoUpload = function (settings) {
    var fileInput, fileImage;

    if ("input" in settings) {
        fileInput = $(settings.input);
    }

    if ("image" in settings) {
        fileImage = $(settings.image);
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

    this.Init = function () {
        fileInput.change(function () {
            setImage(this);
        });
    }
};