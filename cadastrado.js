var local = localStorage.getItem("cadastros");

nome.innerHTML = local[0].nome;

function mostrar() {
    var hidden = document.getElementById("hidden");
    var nome = document.getElementById("nome");
    
    hidden.classList.remove("d-none");
}