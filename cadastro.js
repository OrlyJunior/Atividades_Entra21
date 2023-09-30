var lista = [];
var cadastros = [];
localStorage.setItem("cadastros", JSON.stringify(lista));

function cadastrar() {
    var nome = document.getElementById("user").value;
    var email = document.getElementById("email").value;
    var senha = document.getElementById("senha").value;

    var obj = { nome: nome, email: email, senha: senha };

    for (i = 0; i < JSON.parse(localStorage.getItem("cadastros")).length; i++) {
        if (JSON.parse(localStorage.getItem("cadastros"))[i].nome == nome) {
            alert("Esse nome já está em uso!");
            return;
        }

        if (JSON.parse(localStorage.getItem("cadastros"))[i].senha == senha) {
            alert("Essa senha já está em uso!");
            return;
        }

        if (JSON.parse(localStorage.getItem("cadastros"))[i].email == email) {
            alert("Esse e-mail já está em uso!");
            return;
        }
    }

    if (!email.includes("@")) {
        alert("O e-mail é inválido!");
        return;
    }

    lista.unshift(obj);

    localStorage.setItem("cadastros", JSON.stringify(lista));

    window.location.href = "login.html";
}