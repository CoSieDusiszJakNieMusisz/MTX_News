function PokazUkryjFormularzKomentarza(IdWierszaFormularza) {

    var wierszId = IdWierszaFormularza;

    $(function () {
        if ($("input#textbox-komentarz-" + wierszId).is(":hidden")) {
            $(function () {
                $("td span#komentarz-" + wierszId).fadeOut("fast");
                $("td span#ileDni-" + wierszId).fadeOut("fast");
                $("td span#ktoWprowadzil-" + wierszId).fadeOut("fast");

                $(function () {
                    $("input#textbox-komentarz-" + wierszId).fadeIn(1500);
                    $("input#number-ileDni-" + wierszId).fadeIn(1500);
                    $("input#textbox-ktoWprowadzil-" + wierszId).fadeIn(1500);

                });
            });
        }

        if ($("input#textbox-komentarz-" + wierszId).is(":visible")) {
            $(function () {

                $("input#textbox-komentarz-" + wierszId).fadeOut("fast");
                $("input#number-ileDni-" + wierszId).fadeOut("fast");
                $("input#textbox-ktoWprowadzil-" + wierszId).fadeOut("fast");

                $(function () {
                    $("span#komentarz-" + wierszId).fadeIn(1500);
                    $("span#ileDni-" + wierszId).fadeIn(1500);
                    $("span#ktoWprowadzil-" + wierszId).fadeIn(1500);

                });
            });
        };
    });
};

$(function () {
    $(".edytuj").click(function (e) {
        e.preventDefault();
        var wierszId = $(this).attr("data-id");

        $(PokazUkryjFormularzKomentarza(wierszId));

    });

    $(".zapisz").click(function (e) {
        e.preventDefault();
        var zapisywanyWiersz = $(this).attr("data-id");

        var KomentarzViewModel = {
            Kod: $("span#kod-" + zapisywanyWiersz).text(),
            Nazwa: $("span#nazwa-" + zapisywanyWiersz).text(),
            Komentarz: $("td input[type=text]#textbox-komentarz-" + zapisywanyWiersz).val(),
            PozostalaLiczbaDniDoKoncaWaznosci: $("td input[type=number]#number-ileDni-" + zapisywanyWiersz).val(),
            KtoWprowadzil: $("td input[type=text]#textbox-ktoWprowadzil-" + zapisywanyWiersz).val(),
        };

        $.post("/Komentarz/ZapiszKomentarz", { "komentarz": KomentarzViewModel },
            function (response) {
                if (response == false) {
                    alert("Uzupełnij wszystkie pola !");
                } else {
                    $("span#komentarz-" + zapisywanyWiersz).text(response.Komentarz);
                    $("span#ileDni-" + zapisywanyWiersz).text(response.PozostalaLiczbaDniDoKoncaWaznosci + " dni");
                    $("span#ktoWprowadzil-" + zapisywanyWiersz).text(response.KtoWprowadzil);

                    $(PokazUkryjFormularzKomentarza(zapisywanyWiersz));
                };
            });
    });

    $(".usun").click(function (e) {
        e.preventDefault();
        var usuwanyWiersz = $(this).attr("data-id");
        if (confirm("Czy na pewno chcesz usunąć ten wpis ?")) {
            $("tr.wiersz#" + usuwanyWiersz).fadeOut(1000, function () {
                $.post("/Komentarz/UsunKomentarz", { "produktId": usuwanyWiersz });
            });
        };
    });
});   