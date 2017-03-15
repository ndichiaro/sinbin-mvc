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
        src: "../../Images/activity-feed-darkgrey.png",
        alt: "../../Images/activity-feed-lightgrey.png"
    });
    feedIcon.Init();

    var meIcon = new MenuIcon({
        sender: "MeIcon",
        active: meActive,
        src: "../../Images/camera-icon-darkgrey.png",
        alt: "../../Images/camera-icon-lightgrey.png"
    });
    meIcon.Init();

    var settingsIcon = new MenuIcon({
        sender: "SettingsIcon",
        active: settingsActive,
        src: "../../Images/settings-darkgrey.png",
        alt: "../../Images/settings-lightgrey.png"
    });
    settingsIcon.Init();
});