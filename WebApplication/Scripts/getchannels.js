$(document).ready(function () {
    var resultDate = new Date().toISOString().slice(0,10); 
    debugger
    var channelName = ["svt1.svt", "tv3", "tv4"];
    var number = 3;

    $.each(channelName, function (index, value) {
        
        var $d = $("<div class='col-md-4 number" + index + "'>").load('Home/Shows', { channel: value, date : resultDate });
        $('.containerChannel').append($d);
    });

    var channelName = ["kanal5", "tv6", "tv8"];

    $.each(channelName, function (index, value) {

        index += number;
        var $d = $("<div class='col-md-4 number" + index + "'>").load('Home/Shows', { channel: value, date: resultDate });
        $('.containerChannel2').append($d);
    });
});

function changeShowSchedual(days) {
    debugger
    var date = days.getAttribute("data-dateTime");
    var channelName = ["svt1.svt", "tv3", "tv4","kanal5", "tv6", "tv8"];

    $.each(channelName, function (index, value) {
        $.ajax({
            type: "GET",
            url: "Home/Shows",
            data: { channel: value, date : date },
            async: false,
            success: function (data) {
                $('.number' + index).html(data);
            }
        });
    });
}

