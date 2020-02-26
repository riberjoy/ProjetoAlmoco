var parametros = [];
var id;
var caminho;

//$(document).ready(function () {
//    if ($("#clientes").val() == "") {
//        caminho = "../Admin/ListarPedidos";
//    }else {
//        caminho = "../Admin/PedidoAdd";
//    }
//});


function itensSelecionados(actionPedidoAdd) {
    $("input:checked").each(function () {
        parametros.push($(this).attr("id"));
    });
    if (parametros.length > 0) {
        GravaPedidos(actionPedidoAdd);
    }
    else {
        DeleteModal("Selecione algum alimento", "", "Voltar", "É necessário escolher no mínimo um alimento", "", "");
    }
};

function GravaPedidos(actionPedidoAdd) {
    if ($("#liberarCardapio").val() == "ENVIAR PEDIDO") {
        $.post(actionPedidoAdd, { idAlimentos: parametros, Num_IDCliente: id }).done(function (data) {
            $(".conteudo").html(data);
        });
        //$.ajax({
        //    url: 'Cliente/EnviarPedido',
        //    datatype: 'json',
        //    contentType: "application/json; charset=utf-8",
        //    type: "POST",
        //    cache: false,
        //    async: true,
        //    data: JSON.stringify(parametros),
        //    success: function (data) {
        //        $(".conteudo").html(data);
        //        //alert("Dados enviados com sucesso!")
        //    },
        //    error: function (error) {
        //        alert("Erro ao enviar os dados")
        //    }
        //});
    }
    if ($("#liberarCardapio").val() == "LIBERAR CARDÁPIO") {
        $.post(actionPedidoAdd, { ids: parametros }).done(function (data) {
            $(".conteudo").html(data);
        });
        //$.ajax({
        //    url: 'Admin/ListarPedidos',
        //    datatype: 'json',
        //    contentType: "application/json; charset=utf-8",
        //    type: "POST",
        //    cache: false,
        //    async: true,
        //    data: JSON.stringify(parametros),
        //    success: function (data) {
        //        $(".conteudo").html(data);
        //        //alert("Dados enviados com sucesso!")
        //    },
        //    error: function (error) {
        //        alert("Erro ao enviar os dados")
        //    }
        //});
    }
    if ($("#liberarCardapio").val() == "ADICIONAR PEDIDO") {
        if ($('#clientes').val() != "") {
            id = $('#clientes').val();
            $.post(actionPedidoAdd, { idAlimentos: parametros, Num_IDCliente: id }).done(function (data) {
                $(".conteudo").html(data);
            });
        }
    }
}
var editarPedido = function (Num_IDCliente, actionEditarPedidos) {
    $.post(actionEditarPedidos, {id: Num_IDCliente}).done(function (data) {
        $("body").html(data);
    }).progress($(".fundo-loading").css("display", "flex"))
}
var MudarCardapio = function (actionMudarCardapio) {
    $.get(actionMudarCardapio).done(function (data) {
        $("body").html(data)
    }).progress($(".fundo-loading").css("display", "flex"))
}
var Logar = function (actionLogar) {
    $.get(actionLogar).done(function (data) {
        $("body").html(data)
    }).progress($(".fundo-loading").css("display", "flex"))
}
var ListarClientes = function (actionListarClientes) {
    $.get(actionListarClientes).done(function (data) {
        $("body").html(data);
    }).progress($(".fundo-loading").css("display", "flex"))
}
var NovoPedido = function (actionNovoPedido) {
    $.get(actionNovoPedido).done(function (data) {
        $("body").html(data);
    }).progress($(".fundo-loading").css("display", "flex"))
}
var restaurarCardapio = function (actionRestaurar, alimentos) {
    $.post(actionRestaurar, { alimentos: alimentos }).done(function (data) {
        $("body").html(data);
    }).progress($(".fundo-loading").css("display", "flex"))
}