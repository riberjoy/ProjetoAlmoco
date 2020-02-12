// $( "input" ).prop( "disabled", true ); //Disable
// $( "input" ).prop( "disabled", false ); //Enable


function MostraModal(modalId){
    const modal = document.getElementById(modalId);
    modal.classList.add("mostrar")
    modal.addEventListener("click", (e)=> {
        if(e.target.id == modalId || e.target.className == "modal__fecha"){
            modal.classList.remove("mostrar")
        }
    });
}

// function Obrigatorio(inputId,modalInputBtn){
//     var input = document.getElementsByClassName("input__addCat").value
//     var botao = document.getElementsByClassName("modal__input__btn")
//     if(input ==""){
//         //rejeitado
    
//         botao.prop( "disabled", true );

//     }else{
        
//         botao.attr( "disabled", false );
//     }
// }

$(document).ready(function () {
    $('.modal__input__btn').attr('disabled', true);
    $('input[type="text"],textarea').on('keyup', function () {
        var textarea_value = $("#texta").val();
        var text_value = $('input[name="textField"]').val();
        if (textarea_value != '' && text_value != '') {
            $('input[type="submit"]').attr('disabled', false);
        } else {
            $('input[type="submit"]').attr('disabled', true);
        }
    });
});