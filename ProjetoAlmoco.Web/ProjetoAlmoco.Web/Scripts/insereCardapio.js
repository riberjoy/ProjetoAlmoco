var parametros = [];
var id;
var caminho;

//$(document).ready(function () {
//    if ($("#clientes").val() == "") {
//        caminho = "../Admin/ListarPedidos";
//    }else {
//        caminho = "../Admin/PedidoAdd";
//    }
//    console.log(caminho);
//});


function itensSelecionados(actionPedidoAdd) {
    console.log("sadf");
    $("input:checked").each(function () {
        parametros.push($(this).attr("id"));
    });
    if (parametros.length > 0) {
        GravaPedidos(actionPedidoAdd);
    }

};

function GravaPedidos(actionPedidoAdd) {
    if ($("#liberarCardapio").val() == "ENVIAR PEDIDO") {
        $.ajax({
            url: 'Cliente/EnviarPedido',
            datatype: 'json',
            contentType: "application/json; charset=utf-8",
            type: "POST",
            cache: false,
            async: true,
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
            cache: false,
            async: true,
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
        console.log("texto");
        if ($('#clientes').val() != "") {
            id = $('#clientes').val();
            console.log(parametros);
            $.post(actionPedidoAdd, { idAlimentos: parametros, Num_IDCliente: id}).done(function (data) {
                $(".conteudo").html(data);
            });
        }
    }
}

var editarPedido = function (Num_IDCliente, actionEditarPedidos) {
    $.post(actionEditarPedidos, {id: Num_IDCliente}).done(function (data) {
        $("body").html(data);
    });
}