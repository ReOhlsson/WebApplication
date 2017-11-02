$(document).ready(function () {
    $('.programLink').click(function () {
        
        var string = $(this).attr('value');
        var res = string.split('/');

        $('.popularShows').load("/Home/ShowsPop", { array: res });
    });

});