$(document).ready(function () {
    $('.programLink').click(function () {

        var clickedId = $(this).attr('id');
        var clickedVal = $(this).attr('value');

        $('#programPopup').load("/Home/Program", { title: clickedId, starttime: clickedVal });
    });

});