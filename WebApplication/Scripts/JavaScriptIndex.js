
function showPopUp(program) {
    var title = program.getAttribute("data-title")
    var start = program.getAttribute("data-start")
    var stop = program.getAttribute("data-stop")
    var desc = program.getAttribute("data-desc")
    var channel = program.getAttribute("data-channel")
    var category = program.getAttribute("data-category")
    var timeStart = program.getAttribute("data-timeStart")
    var timeStop = program.getAttribute("data-timeEnd")

    $.ajax({
        type: "GET",
        url: "/home/showspop",
        data: { title: title, start: start, stop: stop, desc: desc, channel: channel, category: category, starttime: timeStart, endtime: timeStop },
        async: false,
        success: function (data) {
            document.getElementById("programPopup").innerHTML = data;
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
    var title = program.getAttribute("data-title")
    var start = program.getAttribute("data-start")
    var stop = program.getAttribute("data-stop")
    var desc = program.getAttribute("data-desc")
    var channel = program.getAttribute("data-channel")
    var category = program.getAttribute("data-category")
    var timeStart = program.getAttribute("data-timeStart")
    var timeStop = program.getAttribute("data-timeEnd")

    $.ajax({
        type: "POST",
        url: "/home/createviewlist",
        data: { title: title, start: start, stop: stop, desc: desc, channel: channel, category: category, starttime: timeStart, endtime: timeStop },
        async: false,
        success: function () {
            closePopUp();
        }
    });
}

function GetViewList() {
    $.ajax({
        type: "GET",
        dataType: "html",
        url: "/home/getviewlist",
        success: function (data) {
            $(".popover-content").append(data);
        }
    });
}

function removeProgram(program) {
    var programId = program.getAttribute("data-programId");

    $.ajax({
        type: "POST",
        url: "/home/deleteProgram",
        data: { id: programId },
        success: function (data) {
            $('.popover-content').empty()
            GetViewList();
        }
    });
}

function GetEditorList() {
    $.ajax({
        type: "GET",
        dataType: "html",
        url: "/home/geteditorlist",
        success: function (data) {
            $(".popover-content").append(data);
        }
    });
}


function removeEditorRecommendation(program) {
    var programId = program.getAttribute("data-programId");

    $.ajax({
        type: "POST",
        url: "/home/removeeditorrecommendation",
        data: { id: programId },
        success: function (data) {
            $('.popover-content').empty()
            GetEditorList();
        }
    });
}

function CreateEditorRecommendation(program) {
    var title = program.getAttribute("data-title")
    var start = program.getAttribute("data-start")
    var stop = program.getAttribute("data-stop")
    var desc = program.getAttribute("data-desc")
    var channel = program.getAttribute("data-channel")
    var category = program.getAttribute("data-category")
    var timeStart = program.getAttribute("data-timeStart")
    var timeStop = program.getAttribute("data-timeEnd")

    $.ajax({
        type: "POST",
        url: "/home/createeditorrecommendationlist",
        data: { title: title, start: start, stop: stop, desc: desc, channel: channel, category: category, starttime: timeStart, endtime: timeStop },
        async: false,
        success: function () {
            closePopUp();
        }
    });
}
