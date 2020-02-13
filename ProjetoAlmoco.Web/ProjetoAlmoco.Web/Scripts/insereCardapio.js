var parametros = [];

$("#liberarCardapio").click(function () {
    $("input:checked").each(function () {
        parametros.push($(this).attr("id"));
    });
    GravaPedidos();
});

function GravaPedidos() {
    var caminho;
    if ($("#liberarCardapio").val() == "ENVIAR PEDIDO") {
        caminho = 'Cliente/EnviarPedido'
    } else {
        caminho = 'Admin/ListarPedidos';
    }

    $.ajax({
        url: caminho,
        datatype: 'json',
        contentType: "application/json; charset=utf-8",
        type: "POST",
        data: JSON.stringify(parametros),
        success: function (data) {
            $(".conteudo").html(data);
            //alert("Dados enviados com sucesso!")
        },
        error: function (error) {
            alert("Erro ao enviar os dados")
        }
    });
}