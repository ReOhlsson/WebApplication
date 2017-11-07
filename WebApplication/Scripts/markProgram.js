$(document).ready(function () {
    var date = Math.round((new Date()).getTime() / 1000);
    debugger
    $(".program li a").each(function (key, value) {
        var unix = value.getAttribute("data-start");
        var a = parseInt(unix)

        if (date > a) {
            this.style.background = "pink";
        }
    });
});