var ativo = false;

// Get the modal
var modall = document.getElementById("myModal");

// Get the button that opens the modal
var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks anywhere outside of the modal, close it

function atualizaEstado() {
    $("#cardapioDisponivel").css("display", "none");
    $("#cardapioIndisponivel").css("display", "flex");
}


function CadastroModal(tipoOperacao, caminho, nomeBtn, id) {
    
    $("<div></div>", { id: 'myModal', class: 'modal' }).appendTo("body");
    $("<div></div>", { class: 'modal-content ' }).appendTo("body div.modal");
    $("<span></span>", { class: 'close' }).appendTo("body div.modal div.modal-content");
    $("span.close").html("&times;");
    
    $("<h1></h1>", { class: 'nomeCategoria' }).appendTo("body div.modal div.modal-content");
    $("h1.nomeCategoria").html(tipoOperacao.toString());
    var margem = parseInt($("div.modal-content").width()) - parseInt($("h1.nomeCategoria").width())
    margem = margem / 2;
    $("h1.nomeCategoria").css({
        "margin-left": margem+"px"
    });


    //<form method="post" novalidate="novalidate">
    $("<form></form>", { class: "formCategoria", method: 'post', action: caminho }).appendTo("body div.modal div.modal-content ");

    if (tipoOperacao.includes('Alimento')) {
        $("<input>", { class: "admin__cadAlimentoID", type: "text", name: "CategoriaID", id: "CategoriaID" }).appendTo("body div.modal div.modal-content form.formCategoria");
        $("input.admin__cadAlimentoID").css({
            "display": "none",
        });
        //$("input.admin__cadAlimentoID").value = id.toString();
        document.querySelector("input.admin__cadAlimentoID").value = id;
    }

    //<input autocomplete="off" class="login__input text-box single-line" data-val="true"  id="Senha" name="Senha" placeholder="SENHA" type="password" value>
    $("<input>", { id: "inputCadastroModal", class: "admin__cadCategoria", type: "text", name: "Nome", id: "Nome", autocomplete: "off" }).appendTo("body div.modal div.modal-content form.formCategoria");
    

    if (tipoOperacao.includes("Cliente")) {
        $("<input>", { class: "admin__cadCategoria", type: "text", name: "Usuario", id: "Usuario", autocomplete: "off" }).appendTo("body div.modal div.modal-content form.formCategoria");

        $("<input>", { class: "admin__cadCategoria", type: "text", name: "Senha", id: "Senha", autocomplete: "off" }).appendTo("body div.modal div.modal-content form.formCategoria");
       
    }

    $("input.admin__cadCategoria").css({
        "margin-top": "0px",
        "margin-left": "5%",
        "width": "75%",
        "height": "20px",
        "background-color": "white",
        "border-bottom": " 1px solid black",
        "border-radius": " 0px 0px 0px 0px",
        "padding": " 10%",
        "font-size": " 15pt",
        "color": " black",
        "padding-left": " 3%",
        "padding-bottom": " 2%",
        "transition": " none",
        "outline": " none"
    });

    //<input class="login__link" type="submit" value="LOGAR">
    $("<input>", { id: "btnCadastroModal", class: "admnCadCategoria__link modalInput_Btn", type: "submit", value: nomeBtn, disabled: "disabled"}).appendTo("body div.modal div.modal-content form.formCategoria");
    $('#btnCadastroModal').css("background-color", "#707070");

    ativo = true;

    $("input[type='text'][name='Nome']").keyup(function () {

        if ($("input[type='text'][name='Nome']").val() == "") {
            $('#btnCadastroModal').prop("disabled", "disabled");
            $('#btnCadastroModal').css("background-color", "#707070");
        } else {
            $('#btnCadastroModal').removeAttr("disabled");
            $('#btnCadastroModal').css("background-color", "#00E866");

        }
    });

    $("span").click(function () {
        $("div.modal").remove();
        ativo = false;
    });
}


//----------------------------------------------------------------------------------------------------------------------------

function CadastroCliente(tipoOperacao, caminho, nomeBtn, id, nome, user) {
    $("<div></div>", { id: 'myModal', class: 'modal' }).appendTo("body");
    $("<div></div>", { class: 'modal-content ' }).appendTo("body div.modal");
    $("<span></span>", { class: 'close' }).appendTo("body div.modal div.modal-content");
    $("span.close").html("&times;");

    $("<h1></h1>", { class: 'nomeCategoria' }).appendTo("body div.modal div.modal-content");
    $("h1.nomeCategoria").html(tipoOperacao.toString());
    var margem = parseInt($("div.modal-content").width()) - parseInt($("h1.nomeCategoria").width())
    margem = margem / 2;
    $("h1.nomeCategoria").css({
        "margin-left": margem + "px"
    });

    //<form method="post" novalidate="novalidate">
    $("<form></form>", { class: "formCategoria", method: 'post', action: caminho }).appendTo("body div.modal div.modal-content ");

    $("<input>", { id: "inputCadastroModal", class: "admin__cadCategoria", type: "text", name: "Id", id: "Id", autocomplete: "off" }).appendTo("body div.modal div.modal-content form.formCategoria");
    document.querySelector("input[type='text'][name='Id']").value = id;
    //<input autocomplete="off" class="login__input text-box single-line" data-val="true"  id="Senha" name="Senha" placeholder="SENHA" type="password" value>
    $("<input>", { id: "inputCadastroModal", class: "admin__cadCategoria", type: "text", name: "Nome", id: "Nome", autocomplete: "off" }).appendTo("body div.modal div.modal-content form.formCategoria");
    document.querySelector("input[type='text'][name='Nome']").value = nome;

    $("<input>", { id: "inputCadastroModal", class: "admin__cadCategoria", type: "text", name: "Usuario", id: "Usuario", autocomplete: "off" }).appendTo("body div.modal div.modal-content form.formCategoria");
    document.querySelector("input[type='text'][name='Usuario']").value = user;

    $("input.admin__cadCategoria").css({
        "margin-top": "0px",
        "margin-left": "5%",
        "width": "75%",
        "height": "20px",
        "background-color": "white",
        "border-bottom": " 1px solid black",
        "border-radius": " 0px 0px 0px 0px",
        "padding": " 10%",
        "font-size": " 15pt",
        "color": " black",
        "padding-left": " 3%",
        "padding-bottom": " 2%",
        "transition": " none",
        "outline": " none"
    });

    $("input[type='text'][name='Nome']").keyup(function () {

        if ($("input[type='text'][name='Nome']").val() == "" || $("input[type='text'][name='Usuario']").val() == "") {
            $('#btnCadastroModal').prop("disabled", "disabled");
            $('#btnCadastroModal').css("background-color", "#707070");
        } else {
            $('#btnCadastroModal').removeAttr("disabled");
            $('#btnCadastroModal').css("background-color", "#00E866");

        }
    });

    $("input[type='text'][name='Usuario']").keyup(function () {

        if ($("input[type='text'][name='Nome']").val() == "" || $("input[type='text'][name='Usuario']").val() == "") {
            $('#btnCadastroModal').prop("disabled", "disabled");
            $('#btnCadastroModal').css("background-color", "#707070");
        } else {
            $('#btnCadastroModal').removeAttr("disabled");
            $('#btnCadastroModal').css("background-color", "#00E866");

        }
    });

    //<input class="login__link" type="submit" value="LOGAR">
    $("<input>", { id: "btnCadastroModal", class: "admnCadCategoria__link modalInput_Btn", type: "submit", value: nomeBtn}).appendTo("body div.modal div.modal-content form.formCategoria");
   

    ativo = true;

    $("span").click(function () {
        $("div.modal").remove();
        ativo = false;
    });
}



//----------------------------------------------------------------------------------------------------------------------------

function DeleteModal(tipoOperacao, caminho, nomeBtn, aviso,id, nome) {

    $("<div></div>", { id: 'myModal', class: 'modal' }).appendTo("body");
    $("<div></div>", { class: 'modal-content ' }).appendTo("body div.modal");
    $("<span></span>", { class: 'close' }).appendTo("body div.modal div.modal-content");
    $("span.close").html("&times;");

    $("<h1></h1>", { class: 'nomeCategoria' }).appendTo("body div.modal div.modal-content");
    $("h1.nomeCategoria").html(tipoOperacao.toString());
    var margem = parseInt($("div.modal-content").width()) - parseInt($("h1.nomeCategoria").width())
    margem = margem / 2;
    $("h1.nomeCategoria").css({
        "margin-left": margem + "px",
    });

    //<form method="post" novalidate="novalidate">
    $("<form></form>", { class: "formCategoria", method: 'post', action: caminho }).appendTo("body div.modal div.modal-content ");
    
    $("<h3></h3>", { class: 'avisoCategoria' }).appendTo("body div.modal div.modal-content form.formCategoria");
    $("h3.avisoCategoria").html(aviso.toString());


    //<input class="login__link" type="submit" value="LOGAR">
    $("<input>", { class: "admnCadCategoria__link modalInput_Btn", type: "submit", value: nomeBtn }).appendTo("body div.modal div.modal-content form.formCategoria");

    ativo = true;

    $("span").click(function () {
        $("div.modal").remove();
        ativo = false;
    });

    $("input.admnCadCategoria__link").click(function () {
        $.post(urlsCadastrar.abrirModalObservacaoItem, { idItem: idItem, editar: false })
        $("div.modal").remove();
        ativo = false;
    });
}

window.onclick = function (event) {
    console.log(event.target.id)
    if (ativo ==  true) {        
        if (event.target == myModal) {
            $("div.modal").remove();
            ativo = false;
        }
    }
}