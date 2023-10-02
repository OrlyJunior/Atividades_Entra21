function login() {
    var nome = document.getElementById("user2").value;
    var email = document.getElementById("email2").value;
    var senha = document.getElementById("senha2").value;

    var tamanho = JSON.parse(localStorage.getItem("nome").length);

    for (i = 0; i < tamanho; i++) {
        if(localStorage.getItem("nome")[i].indexOf(nome) && localStorage.getItem("senha")[i].indexOf(senha) && localStorage.getItem("email")[i].indexOf(email)) {
            window.location.href = "cadastrado.html";
            return;
        }
        console.log(tamanho)
    }

    if (!email.includes("@")) {
        alert("O e-mail é inválido!");
        return;
    }

    alert("O cadastro é inválido!");
}