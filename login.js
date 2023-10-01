function login() {
    var nome = document.getElementById("user2").value;
    var email = document.getElementById("email2").value;
    var senha = document.getElementById("senha2").value;

    for (i = 0; i < JSON.parse(localStorage.getItem("cadastros")).length; i++) {
        if (JSON.parse(localStorage.getItem("cadastros"))[i].nome == nome && JSON.parse(localStorage.getItem("cadastros"))[i].senha == senha && JSON.parse(localStorage.getItem("cadastros"))[i].email == email) {
            window.location.href = "cadastrado.html";
            return;
        }
    }

    if (!email.includes("@")) {
        alert("O e-mail é inválido!");
        return;
    }

    alert("O cadastro é inválido!");
}