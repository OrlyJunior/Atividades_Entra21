var listaN = JSON.parse(localStorage.getItem("nome"));
var listaS = JSON.parse(localStorage.getItem("senha"));
var listaE = JSON.parse(localStorage.getItem("email"));

console.log(listaN)

var nome = "";
var email = "";
var senha = "";

function login() {
    nome = document.getElementById("user2").value;
    email = document.getElementById("email2").value;
    senha = document.getElementById("senha2").value;

    if (!email.includes("@")) {
        alert("O e-mail é inválido!");
        return;
    }

    var nomeV = listaN.find((nome) => nome == nome);
    var senhaV = listaS.find((senha) => senha);
    var senhaE = listaE.find((email) => email);

    console.log(nomeV)

    if (nomeV == nome && senhaV == senha && senhaE == email) { window.location.href = "cadastrado.html" 
    }

    alert("O cadastro não é válido!");
}