$(document).ready(function () {
    var channelName = ["svt1.svt", "tv3", "tv4"];

    $.each(channelName, function (index, value) {
        var $d = $("<div class='col-md-4 number'>").load('Home/Shows', { channel: value });
        $('.containerChannel').append($d);
    });

    var channelName = ["kanal5", "tv6", "tv8"];

    $.each(channelName, function (index, value) {
        var $d = $("<div class='col-md-4 number'>").load('Home/Shows', { channel: value });
        $('.containerChannel2').append($d);
    });

});
