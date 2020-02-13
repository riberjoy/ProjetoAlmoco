var parametros = [];
var id;

$("#liberarCardapio").click(function () {
    $("input:checked").each(function () {
        parametros.push($(this).attr("id"));
    });
    if (parametros.length > 0) {
        GravaPedidos();
    }
    
});

function GravaPedidos() {
    if ($("#liberarCardapio").val() == "ENVIAR PEDIDO") {
        $.ajax({
            url: 'Cliente/EnviarPedido',
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
    if ($("#liberarCardapio").val() == "LIBERAR CARDÁPIO") {
        $.ajax({
            url: 'Admin/ListarPedidos',
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
    if ($("#liberarCardapio").val() == "ADICIONAR PEDIDO") {
        if ($('#clientes').val() != "") {
            parametros.push($('#clientes').val());
            id = $('#clientes').val();
            $.ajax({
                url: '../Admin/PedidoAdd',
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
    }
}