async function getUsuarios() {
    document.getElementsByTagName("tbody")[0].innerHTML = "";

    await fetch("https://localhost:7254/api/Users")
        .then(data =>
            data.json())
        .then(item => item.forEach(element =>
            document.getElementsByTagName("tbody")[0].insertAdjacentHTML("beforeend", `<tr>
                                                                              <td>${element.id}</td>  
                                                                              <td>${element.nome}</td>
                                                                              <td>${element.role}</td>
                                                                              <td><button value=${element.id} class="btn btn-primary" onclick="deletarUsuarios(this.value)">Deletar</button></td>
                                                                              <td><button value=${element.id} class="btn btn-primary" onclick="editarUsuarios(this.value)">Editar</button></td>
                                                                           </tr>`)))
}

async function postUsuarios() {
    var update = {
        nome: document.getElementById("inputNomeU").value,
        role: document.getElementById("inputRole").value,
        senha: document.getElementById("inputSenha").value
    }

    const options = {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(update)
    }

    await fetch("https://localhost:7254/api/Users", options)
        .then(data => {
            if (!data.ok) {
                throw Error("Erro");
            }

            return data.json()
        })
        .then(user => {
            nome: update.nome;
            role: update.role;
            senha: update.senha;
        }).catch(e =>

            console.log(e));

    getUsuarios();
}

async function deletarUsuarios(id) {
    var token = localStorage.getItem("token");

    var options = {
        method: "delete",
        headers: {
            'Authorization': 'Bearer ' + token
        }
    }

    await fetch(`https://localhost:7254/api/Users/${id}`, options)

    getUsuarios();
}

async function login() {
    var update = {
        nome: document.getElementById("nomeLogin").value,
        senha: document.getElementById("senhaLogin").value
    }

    const options = {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(update)
    }

    fetch("https://localhost:7254/api/Users/Login", options)
        .then(data =>

            data.json())
        .then(token =>

            localStorage.setItem("token", token.token))
}

async function editarUsuarios(id) {
    console.log(id)
    document.getElementById("confirmaU").value = id;

    document.getElementById("confirmaU").removeAttribute("disabled");
    document.getElementById("inputNomeUE").removeAttribute("disabled");
    document.getElementById("inputRoleUE").removeAttribute("disabled");
    document.getElementById("inputSenhaUE").removeAttribute("disabled");
}

async function editUsuarios(id2) {
    var token = localStorage.getItem("token");

    var editado = {
        nome: document.getElementById("inputNomeUE").value,
        role: document.getElementById("inputRoleUE").value,
        senha: document.getElementById("inputSenhaUE").value
    }

    var update = {
        id: id2,
        nome: editado.nome,
        role: editado.role,
        senha: editado.senha
    }

    await fetch(`https://localhost:7254/api/Users/${id2}`, {
        method: "put",
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(update)
    })

    document.getElementById("confirmaU").setAttribute("disabled", "true");
    document.getElementById("inputNomeUE").setAttribute("disabled", "true");
    document.getElementById("inputRoleUE").setAttribute("disabled", "true");
    document.getElementById("inputSenhaUE").setAttribute("disabled", "true");

    getUsuarios();


}