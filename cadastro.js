var listaNomes = [localStorage.getItem("nome")];
var listaSenhas = [localStorage.getItem("senha")];
var listaEmail = [localStorage.getItem("email")];

function cadastrar() {
    var nome = document.getElementById("user").value;
    var email = document.getElementById("email").value;
    var senha = document.getElementById("senha").value;

    if (!email.includes("@")) {
        alert("O e-mail é inválido!");
        return;
    }
    listaNomes.unshift(nome);
    listaEmail.unshift(email);
    listaSenhas.unshift(senha);

    localStorage.setItem("email", listaEmail);
    localStorage.setItem("senha", listaSenhas);
    localStorage.setItem("nome", listaNomes);

    window.location.href = "login.html";
}