var usuarios = [];

var nome = "";
var email = "";
var senha = "";

function cadastrar() {
    nome = document.getElementById("user").value;
    email = document.getElementById("email").value;
    senha = document.getElementById("senha").value;

    var obj = { nome: nome, email: email, senha: senha };

    if (!email.includes("@")) {
        alert("O e-mail é inválido!");
        return;
    }
    
    localStorage.setItem("obj", JSON.stringify(obj));

    usuario = JSON.parse(localStorage.getItem("obj"));

    usuarios.unshift(usuario)

    console.log(usuarios)
}

function login() {
    for (let i = 0; i < usuarios.length; i++) {
        if (usuarios[i].nome == nome && usuarios[i].senha == senha && usuarios[i].email == email) {
            window.location.href = "cadastrado.html"
            return;
        }
    }

    console.log(usuarios.nome)

    alert("O cadastro não é válido!");
}