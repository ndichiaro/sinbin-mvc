$(function () {
    var navBar = new NavBar({
        toggle: "#statusToggle",
        content: ".feed"
    });
    navBar.Init();

    var location = new LocationManager();
    location.Watch();
});