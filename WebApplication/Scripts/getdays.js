$('.showDayShow').click(function (e) {

    var category = this.getAttribute("value");
    $.ajax({
        type: "GET",
        url: "/home/Shows",
        data: { id: category },
        success: function (data) {
            $(".showContainer").html(data);
        },
        error: function () {
            alert("Funkar inte!");
        }
    });
});