//$(document).ready(function () {
//    $('.programLink').click(function () {
        
//        var string = $(this).attr('value');
//        var res = string.split('/');

//        $('.popularShows').load("/Home/ShowsPop", { array: res });
//    });
//});
function showPopUp(program) {
    //var program = document.getElementsByClassName('programLink');
    debugger
    var title = program.getAttribute("data-title") // "3"
    var start = program.getAttribute("data-start") // "3"
    var stop = program.getAttribute("data-stop") // "3"
    var desc = program.getAttribute("data-desc") // "3"
    var channel = program.getAttribute("data-channel") // "3"

    $.ajax({
        type: "GET",
        url: "/home/showspop",
        data: { title: title, start: start, stop: stop, desc: desc, channel: channel },
        async: false,
        success: function (data) {
            document.getElementById("programPopup").innerHTML = data;
        },
        error: function () {
            alert("Funkar inte!");
        }
    });
}

function closePopUp() {
    document.getElementById('popupMovie').style.display = "none";
}
//$(".programLink").click(function () {
//    debugger
//    var program = document.getElementsByClassName('programLink');
//    var title = program.getAttribute("data-title") // "3"
//    var start = program.getAttribute("data-start") // "3"
//    var stop = program.getAttribute("data-stop") // "3"
//    var desc = program.getAttribute("data-desc") // "3"
//    var channel = program.getAttribute("data-channel") // "3"

//    var animalType = animal.getAttribute("data-animal-type");


//    $.ajax({
//        type: "GET",
//        url: "/home/showspop",
//        data: { title:title , start :start, stop:stop, desc :desc, channel: channel },
//        async: false,
//        success: function (data) {
//            $('#programPopup' + index).html(data);
//        }
//    });
//});

