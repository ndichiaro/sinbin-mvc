$(function () {
    // build footbar based on the current page
    // by default feedIcon is active
    var feedActive = true;
    var meActive = false;
    var settingsActive = false;

    if (window.location.pathname === "/Profile/Picture") {
        feedActive = false;
        meActive = true;
        settingsActive = false;
    }else if (window.location.pathname === "/Settings/Menu") {
        feedActive = false;
        meActive = false;
        settingsActive = true;
    }

    var feedIcon = new MenuIcon({
        sender: "FeedIcon",
        active: feedActive,
        src: "../../Images/home-active.png",
        alt: "../../Images/home-inactive.png"
    });
    feedIcon.Init();

    var meIcon = new MenuIcon({
        sender: "MeIcon",
        active: meActive,
        src: "../../Images/camera-active.png",
        alt: "../../Images/camera-inactive.png"
    });
    meIcon.Init();

    var settingsIcon = new MenuIcon({
        sender: "SettingsIcon",
        active: settingsActive,
        src: "../../Images/settings-active.png",
        alt: "../../Images/settings-inactive.png"
    });
    settingsIcon.Init();
});