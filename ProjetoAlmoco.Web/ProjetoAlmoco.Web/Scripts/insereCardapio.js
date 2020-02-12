var parametros = [];

$("#liberarCardapio").click(function () {
    $("input:checked").each(function () {
        parametros.push($(this).attr("id"));
    });
    GravaPainelPesquisa();
});


function GravaPainelPesquisa() {
    $.ajax({
        url: 'Admin/LiberarCardapio',
        datatype: 'json',
        contentType: "application/json; charset=utf-8",
        type: "POST",
        data: JSON.stringify(parametros),
        success: function (data) {
            alert("Dados enviados com sucesso!")
        },
        error: function (error) {
            alert("Erro ao enviar os dados: "+error)
        }
    });
}