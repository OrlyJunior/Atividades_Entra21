var token = localStorage.getItem("token");

async function getProdutos(){
    document.getElementsByTagName("tbody")[1].innerHTML = "";

    const options = {
        headers: {
            'Authorization': 'Bearer' + token
        }
    }

    await fetch("https://localhost:7254/api/Produtos", options)
    .then(data => data.json())
    .then(item => item.forEach(element =>
        document.getElementsByTagName("tbody")[1].insertAdjacentHTML("beforeend", `<tr>
                                                                              <td>${element.id}</td>  
                                                                              <td>${element.nome}</td>
                                                                              <td>${element.preco}</td>
                                                                              <td>${element.estoque}</td>
                                                                              <td>${element.category.nome}</td>
                                                                              <td><button value=${element.id} onclick="deletarProdutos(this.value)">Deletar</button></td>
                                                                              <td><button value=${element.id} onclick="editarProdutos(this.value)">Editar</button></td>
                                                                           </tr>`))
    );
}

async function postProdutos(){
    var update = {
        nome: document.getElementById("inputNome").value,
        preco: document.getElementById("inputPreco").value,
        estoque: document.getElementById("inputEstoque").value,
        category: {
            id: document.getElementById("inputCategoriaId").value
        }
    }

    const options = {
        method: 'post',
        headers: {
            'Authorization': 'Bearer' + token,
            'content-type': 'application/json'
        },
        body: JSON.stringify(update)
    }

    await fetch("https://localhost:7254/api/Produtos", options)

    getProdutos();
}

async function deletarProdutos(id){
    const options = {
        method: 'delete',
        headers: {
            'Authorization': 'Bearer' + token,
        }
    }

    await fetch(`https://localhost:7254/api/Produtos/${id}`, options);

    getProdutos();
}

async function editarProdutos(id){
    document.getElementById("confirmaP").value = id;

    document.getElementById("inputNomeE").removeAttribute("disabled");
    document.getElementById("inputPrecoE").removeAttribute("disabled");
    document.getElementById("inputEstoqueE").removeAttribute("disabled");
    document.getElementById("inputCategoriaIdE").removeAttribute("disabled");
}

async function editProdutos(id2){
    var editado = {
        nome: document.getElementById("inputNomeE").value,
        preco: document.getElementById("inputPrecoE").value,
        estoque: document.getElementById("inputEstoqueE").value,
        categoriaId: document.getElementById("inputCategoriaIdE").value
    }

    var update = {
        id: id2,
        nome: editado.nome,
        preco: editado.preco,
        estoque: editado.estoque,
        category: {
            id: editado.categoriaId
        }
    }

    await fetch(`https://localhost:7254/api/Produtos/${id2}`, {
        method: "put",
        headers: {
            'Authorization': 'Bearer' + token,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(update)
    })
    getProdutos();
}