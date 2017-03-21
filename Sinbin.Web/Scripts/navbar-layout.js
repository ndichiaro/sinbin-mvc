$(function () {
    var navBar = new NavBar({
        toggle: "#statusToggle",
        content: ".feed",
        warning: ".avail-warning"
    });
    navBar.Init();

    var location = new LocationManager();
    location.Watch();
});