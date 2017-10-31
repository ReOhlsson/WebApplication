$('.showDayShow').click(function (e) {
    debugger
    var category = this.getAttribute("value");
    $.ajax({
        type: "GET",
        url: "/home/shows",
        data: { id: category },
        success: function (data) {
            $(".showContainer").html(data);
        },
        error: function () {
            alert("Funkar inte!");
        }
    });
});