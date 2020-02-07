// Get the modal
var modall = document.getElementById("myModal");

// Get the button that opens the modal
var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks anywhere outside of the modal, close it


function insModal(tipo) {
    $("<div></div>", { id: 'myModal', class: 'modal' }).appendTo("div div.conteudo__titulo");
    $("<div></div>", { class: 'modal-content ' }).appendTo("div div div.modal");
    $("<span></span>", { class: 'close' }).appendTo("div div div.modal div.modal-content");
    $("span.close").html("&times;");


    $("<h1></h1>", { class: 'nomeCategoria' }).appendTo("div div div.modal div.modal-content");
    $("h1.nomeCategoria").html(tipo.toString());
    $("h1.nomeCategoria").css({
        "width": "100%",
        "text-aling": "center"
    });
    
    $("<input>", { class: "admin__cadCategoria", type: "text", placeholder:"nome", name:"categoria", id:"", autocomplete:"off" }).appendTo("div div div.modal div.modal-content");
    $("input.admin__cadCategoria").css({
        "margin-top":" 0px",
        "width": "80%",
        "height": "20px",
        "background-color": "white",
        "border-bottom": "1px solid black",
        "border-radius": "0px 0px 0px 0px",
        "padding": "20px",
        "font-size": " 15pt",
        "color": "black",
        "padding-left": "3%",
        "padding-bottom": "2%",
        "transition": "none",
        "outline": "none",
    });

    $("<input>", { class: "admnCadCategoria__link", type: "submit", value: "Adicionar", name: "", id: "" }).appendTo("div div div.modal div.modal-content");
    $("input.admnCadCategoria__link").css({
        "margin-top": "25px",
        "margin-bottom": "25px",
        "background-color": "#00E866",
        "color": "white",
        "font-size": "15pt",
        "width": "80%",
        "height": "50px",
        "border": " none",
        "border-radius": "30px",
        "cursor": "pointer",
        "transition": ".4s",
        "outline": "none"
    });

    $("span").click(function () {
        $("div.modal").remove();
        $("div.modal-content").remove();
        $("span.close").remove();
        $("h1.nomeCategoria").remove();
        $("hr.addCategoria").remove();
        $("input.admin__cadCategoria").remove();
        $("input.admnCadCategoria__link").remove();
    });

    $("input.admnCadCategoria__link").click(function () {
        $("div.modal").remove();
        $("div.modal-content").remove();
        $("span.close").remove();
        $("h1.nomeCategoria").remove();
        $("hr.addCategoria").remove();
        $("input.admin__cadCategoria").remove();
        $("input.admnCadCategoria__link").remove();
    });

    
}

window.onclick = function (event) {
    console.log(event.target.id)
    if (event.target == myModal) {
        $("div.modal").remove();
        $("div.modal-content").remove();
        $("span.close").remove();
        $("h1.nomeCategoria").remove();
        $("hr.addCategoria").remove();
        $("input.admin__cadCategoria").remove();
        $("input.admnCadCategoria__link").remove();
    }
}



//<form method="post">
//    <h1>categoria</h1>
 //  <hr/>
//    @Html.EditorFor(model => model.Senha, new {htmlAttributes = new { @class = "login__input", placeholder = "SENHA", autocomplete = "off", type = "password" } })
 //   <input class="login__link" type="submit" value="LOGAR">
//</form>


  //  < !--The Modal-- >
   //     <div id="myModal" class="modal">

  //           <!-- Modal content -->
   //          <div class="modal-content">
   //              <span class="close">&times;</span>
  //               <p>Some text in the Modal..</p>
   //          </div>

  //       </div>