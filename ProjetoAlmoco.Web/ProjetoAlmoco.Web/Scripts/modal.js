// Get the modal
var modall = document.getElementById("myModal");

// Get the button that opens the modal
var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on the button, open the modal
//btn.onclick = function () {
//    modal.style.display = "block";
//}

// When the user clicks on <span> (x), close the modal


// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modall) {
        modall.style.display = "none";
    }
}

function insModal(tipo) {
    $("<div></div>", { id: 'myModal', class: 'modal' }).appendTo("div div.conteudo__titulo");
    $("<div></div>", { class: 'modal-content' }).appendTo("div div div.modal");
    $("<span></span>", { class: 'close' }).appendTo("div div div.modal div.modal-content");
    $("span.close").html("&times;");
    $("<p>Some text in the Modal..</p>").appendTo("div div div.modal div.modal-content");


    $("<button></button>", { class: 'login__cadastro', value:'cadasrtar' }).appendTo("div div div.modal div.modal-content");




    $("span").click(function () {
        $("div.modal").remove();
        $("div.modal-content").remove();
        $("span.close").remove();
        $("p").remove();
       // modall.style.display = "none";
    });
}


  //  < !--The Modal-- >
   //     <div id="myModal" class="modal">

  //           <!-- Modal content -->
   //          <div class="modal-content">
   //              <span class="close">&times;</span>
  //               <p>Some text in the Modal..</p>
   //          </div>

  //       </div>