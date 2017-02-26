$(function () {
    var navBar = new NavBar({
        logoff: "#linkLogOff",
        form: "#logoutForm",
        toggle: "#statusToggle",
        content: ".feed"
    });
    navBar.Init();

    var location = new LocationManager();
    location.Watch();
});