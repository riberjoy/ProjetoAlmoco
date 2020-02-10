var ativo = false;

// Get the modal
var modall = document.getElementById("myModal");

// Get the button that opens the modal
var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks anywhere outside of the modal, close it


function insModal(tipoOperacao, caminho, metodo, nomeBtn, aviso, idCliente, idPedido, idAlimeto, idCategoria) {
    
    $("<div></div>", { id: 'myModal', class: 'modal' }).appendTo("body");
    $("<div></div>", { class: 'modal-content ' }).appendTo("body div.modal");
    $("<span></span>", { class: 'close' }).appendTo("body div.modal div.modal-content");
    $("span.close").html("&times;");
    
    $("<h1></h1>", { class: 'nomeCategoria' }).appendTo("body div.modal div.modal-content");
    $("h1.nomeCategoria").html(tipoOperacao.toString());
    var margem = parseInt($("div.modal-content").width()) - parseInt($("h1.nomeCategoria").width())
    margem = margem / 2;
    $("h1.nomeCategoria").css({
        "margin-left": margem+"px",
    });

    //<form method="post" novalidate="novalidate">
    $("<form></form>", { class: "formCategoria", method: metodo, action: caminho }).appendTo("body div.modal div.modal-content ");

    if (tipoOperacao.includes("Apagar")) {
        $("<h3></h3>", { class: 'nomeCategoria' }).appendTo("body div.modal div.modal-content");
        $("h3.nomeCategoria").html(aviso.toString() + ' - ' + idCategoria);
    } else {
        //<input autocomplete="off" class="login__input text-box single-line" data-val="true"  id="Senha" name="Senha" placeholder="SENHA" type="password" value>
        $("<input>", { class: "admin__cadCategoria", type: "text", name: "Nome", id: "Nome", autocomplete: "off" }).appendTo("body div.modal div.modal-content form.formCategoria");
        $("input.admin__cadCategoria").css({
            "margin-top": " 0px",
            "margin-left": "5%",
            "width": "75%",
            "height": "20px",
            "background-color": "white",
            "border-bottom": "1px solid black",
            "border-radius": "0px 0px 0px 0px",
            "padding": "10%",
            "font-size": " 15pt",
            "color": "black",
            "padding-left": "3%",
            "padding-bottom": "2%",
            "transition": "none",
            "outline": "none",
        });       
    }
    //<input class="login__link" type="submit" value="LOGAR">
    $("<input>", { class: "admnCadCategoria__link", type: "submit", value: nomeBtn }).appendTo("body div.modal div.modal-content form.formCategoria");
    $("input.admnCadCategoria__link").css({
        "margin-top": "25px",
        "margin-left": "25%",
        "margin-bottom": "25px",
        "background-color": "#00E866",
        "color": "white",
        "font-size": "15pt",
        "width": "50%",
        "height": "50px",
        "border": " none",
        "border-radius": "30px",
        "cursor": "pointer",
        "transition": ".4s",
        "outline": "none"
    });

    ativo = true;

    $("span").click(function () {
        $("div.modal").remove();
        $("div.modal-content").remove();
        $("span.close").remove();
        $("h1.nomeCategoria").remove();
        $("form.formCategoria").remove();
        $("input.admin__cadCategoria").remove();
        $("input.admnCadCategoria__link").remove();
        ativo = false;
    });

    $("input.admnCadCategoria__link").click(function () {
        $.post(urlsCadastrar.abrirModalObservacaoItem, { idItem: idItem, editar: false })
        $("div.modal").remove();
        $("div.modal-content").remove();
        $("span.close").remove();
        $("h1.nomeCategoria").remove();
        $("form.formCategoria").remove();
        $("input.admin__cadCategoria").remove();
        $("input.admnCadCategoria__link").remove();
        ativo = false;
    });
}

window.onclick = function (event) {
    console.log(event.target.id)
    if (ativo ==  true) {        
        if (event.target == myModal) {
            $("div.modal").remove();
            $("div.modal-content").remove();
            $("span.close").remove();
            $("h1.nomeCategoria").remove();
            $("form.formCategoria").remove();
            $("input.admin__cadCategoria").remove();
            $("input.admnCadCategoria__link").remove();
            ativo = false;
        }
    }
}