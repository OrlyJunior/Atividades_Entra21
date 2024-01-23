var token = localStorage.getItem("item")

var lista;

async function getCategorias(){
    document.getElementsByTagName("tbody")[0].innerHTML = "";

    let token = localStorage.getItem("token") && "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFzZCIsInJvbGUiOiJGdW5jaW9uw6FyaW8iLCJuYmYiOjE3MDYwMzk2ODcsImV4cCI6MTcwNjA0Njg4NywiaWF0IjoxNzA2MDM5Njg3fQ.vXjQSybBX9SRHJ8L85g78osGp82Gaz5W0pjxvuIdz9I";

    const options = {
        headers: {
            'Authorization': 'Bearer' + token
        }
    }

    await fetch("https://localhost:7254/api/Categorias", options)
    .then(data => data.json())
    .then(item => item.forEach(element =>
        document.getElementsByTagName("tbody")[0].insertAdjacentHTML("beforeend", `<tr>
                                                                              <td>${element.id}</td>  
                                                                              <td>${element.nome}<td>
                                                                              <td><button value=${element.id} onclick="deletarCategorias(this.value)">Deletar</button></td>
                                                                              <td><button value=${element.id} onclick="editarCategorias(this.value)">Editar</button></td>
                                                                           </tr>`))
    );
}

async function postCategorias(){
var update = {
    nome: document.getElementById("input1").value
}

const options = {
    method: 'post',
    headers: {
        'Authorization': 'Bearer' + token,
        'Content-Type': 'application/json'
    },
    body: JSON.stringify(update)
}

    await fetch("https://localhost:7254/api/Categorias", options)
    .then(data => {
        if(!data.ok){
            throw Error("Erro");
        }
        
        return data.json()
    })
        .then(categoria => {
            nome: update;
        }).catch(e => 
        
            console.log(e));

    getCategorias();
}

async function deletarCategorias(id){
    const options = {
        method: "delete",
        headers: {
            'Authorization': 'Bearer' + token
        }
    }

    await fetch(`https://localhost:7254/api/Categorias/${id}`, options);

    getCategorias();
}

async function editarCategorias(id){
    document.getElementById("confirma").value = id;
    
    document.getElementById("editado").removeAttribute("disabled");
}

async function editCategorias(id2){
var editado = document.getElementById("editado").value;

    var update = {
        id: id2,
        nome: editado
    }

    await fetch(`https://localhost:7254/api/Categorias/${id2}`, {
        method: "put",
        headers: {
            'Authorization': 'Bearer' + token,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(update)
    })
    .then(data => {
        if(!data.ok){
        throw Error("Erro")
    }

    return data.json();
})
.then(categoria => {
    id: update.id;
    nome: update.nome;
}).catch(e => 
    console.log(e));

getCategorias();
}

