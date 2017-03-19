var PhotoUpload = function (settings) {
    var fileInput, fileImage, initImage;

    if ("input" in settings) {
        fileInput = $(settings.input);
    }

    if ("image" in settings) {
        fileImage = $(settings.image);
    }

    // build img tag from source, fix
    // orientation for mobile image capture
    function buildImage(src) {
        var image = loadImage(
            src,
            function (img) {
                // add styles to img
                img.className = "file-image";
                // empty all children in fileImage
                fileImage.empty();
                // append new img 
                fileImage.append(img);
            },
            {
                orientation: true,
                canvas: true,
                cover: true
            }
        );
        return image;
    }

    function setImage(input) {
        if (input.files && input.files[0] && fileImage.length > 0) {
            buildImage(input.files[0]);
        }
    }

    this.Init = function () {
        fileInput.change(function () {
            setImage(this);
        });
    }
};