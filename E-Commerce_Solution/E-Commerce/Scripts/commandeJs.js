$(document).ready(function () {
    $(function () {

        $("#selectedCategorie").change(function () {
            $.get("/Commandes/GetArticlesByCategorie", { ID: $("#selectedCategorie").val() }, function (data) {
                $("#articlesContent").empty();
                $("#articlesContent").append("<option>Selectionner un article</option>");
                $.each(data, function (index, ligne) {
                    $("#articlesContent").append("<option value='" + ligne.NumArticle + "'>" + ligne.Designation + "</option >")
                });
            });
        });

        $("#articlesContent").change(function () {
            $.get("/Commandes/GetStockByArticle", { ID: $("#articlesContent").val() }, function (data) {
                $("#stock").empty();
                $.each(data, function (index, ligne) {
                    $("#stock").val(ligne.Stock);
                    $("#stock").prop("disabled", true);
                });
            });
        });

        $("#btnSubmit").click(function (e) {
            if ($("#stock").val() < $("#qte").val()) {
                e.preventDefault();
                swal("desolé", "La quantité que vous demandez dépasse la quantité du stock", "info");
            }
            //else {
            //    $.get("/Commandes/UpdateList", function (data) {
            //        $("#listcmd").empty();
            //        $("#listcmd").append("<tr><th>Designation</th><th>QteArticle</th><th>Photo</th></th>");
            //        $.each(data, function (index, ligne) {
            //            $("#listcmd").append("<tr><td>" + ligne.NumArticle + "</td><td>" + ligne.QteArticle + "</td><td></td></tr>");
            //        });
            //    });
            //}
        });

        $("#montant").keyup(function () {
            GetConvertion();
        });

        $("#cur1").change(function () {
            GetConvertion();
        });

        $("#cur2").change(function () {
            GetConvertion();
        });

        function GetConvertion() {
            $.get("/CurrencyConverter/Convert", { cur1: $("#cur1").val(), cur2: $("#cur2").val(), montant: $("#montant").val() }, function (data) {
                $("#mc").empty();
                $("#mc").prop("disabled", true);
                $("#mc").val(data);
            });
        }
    });
});