$(document).ready(function () {
    var channelName = ["svt1.svt", "tv3", "tv4"];

    $.each(channelName, function (index, value) {
        var $d = $("<div id='number" + index + "'>").load('Home/Shows', { channel: value });
        $('.containerChannel').append($d);
    });

});