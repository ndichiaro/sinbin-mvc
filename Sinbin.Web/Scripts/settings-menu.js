$(function () {
    var $logout = $('#lnkLogOut');
    var $logoutForm = $('#logoutForm');

    function post() {
        $logoutForm.submit();
    };

    $logout.click(function () {
        post();
    });
});