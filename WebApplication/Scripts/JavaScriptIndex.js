
function showPopUp(program) {
    var title = program.getAttribute("data-title") // "3"
    var start = program.getAttribute("data-start") // "3"
    var stop = program.getAttribute("data-stop") // "3"
    var desc = program.getAttribute("data-desc") // "3"
    var channel = program.getAttribute("data-channel") // "3"
    var category = program.getAttribute("data-category")

    $.ajax({
        type: "GET",
        url: "/home/showspop",
        data: { title: title, start: start, stop: stop, desc: desc, channel: channel, category :category },
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

$(".toogle-showmore").click(function () {
    debugger
    $(this).next().css( "display", "block" );
});


function CreateViewList(program) {
    var title = program.getAttribute("data-title") // "3"
    var start = program.getAttribute("data-start") // "3"
    var stop = program.getAttribute("data-stop") // "3"
    var desc = program.getAttribute("data-desc") // "3"
    var channel = program.getAttribute("data-channel") // "3"
    var category = program.getAttribute("data-category")

    $.ajax({
        type: "GET",
        url: "/home/createviewlist",
        data: { title: title, start: start, stop: stop, desc: desc, channel: channel, category: category },
        async: false,
        success: function () {
            closePopUp();
        },
        error: function () {
            alert("Funkar inte!");
        }
    });
}

function GetViewList(program) {
    var userName = program.getAttribute("data-name")

    $.ajax({
        type: "GET",
        dataType: "html",
        url: "/home/getviewlist",
        data: { userName: userName },
        success: function (data) {
            $(".popover-content").innerHTML = data;
        }
    });
}

