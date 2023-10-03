$(document).ready(() => {
    $("#conf").click(() => {
        var cadeiras = $("input").val();

        for (i = 0 + 1; i <= cadeiras; i++) {
            $('<button style="width: 5%" id="cadeira" class="border-0 m-2 bg-success">' + i + '</button>').prependTo($('#cadeiras'));
        }

        $('#cDisp').html("Cadeiras disponíveis: " + cadeiras);


        $('button').click((item) => {
            if ($(item.target).hasClass("bg-success")) {
                $(item.target).removeClass("bg-success");
                $(item.target).addClass("bg-danger");

                cadeiras = cadeiras - 1;

                $('#cDisp').html("Cadeiras disponíveis: " + cadeiras);
            }

            else {
                $(item.target).removeClass("bg-danger");
                $(item.target).addClass("bg-success");

                cadeiras = cadeiras + 1;

                $('#cDisp').html("Cadeiras disponíveis: " + cadeiras);
            }
        })
    })
})
