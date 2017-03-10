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
    }else if (window.location.pathname === "/Settings/Index") {
        feedActive = false;
        meActive = false;
        settingsActive = true;
    }

    var feedIcon = new MenuIcon({
        sender: "FeedIcon",
        active: feedActive,
        src: "../../Images/activity-feed-green.png",
        alt: "../../Images/activity-feed-grey.png"
    });
    feedIcon.Init();

    var meIcon = new MenuIcon({
        sender: "MeIcon",
        active: meActive,
        src: "../../Images/camera-icon-green.png",
        alt: "../../Images/camera-icon-grey.png"
    });
    meIcon.Init();

    var settingsIcon = new MenuIcon({
        sender: "SettingsIcon",
        active: settingsActive,
        src: "../../Images/settings-green-256.png",
        alt: "../../Images/settings-grey-256.png"
    });
    settingsIcon.Init();
});