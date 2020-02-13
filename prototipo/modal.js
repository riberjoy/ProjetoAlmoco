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
