var listaCategorias;

async function getCategorias2(){
    await fetch("https://localhost:7254/api/Categorias")
    .then(data => data.json())
    .then(item => listaCategorias = item);
}

async function getProdutos(){
    document.getElementsByTagName("tbody")[1].innerHTML = "";

    await fetch("https://localhost:7254/api/Produtos/Get")
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
    getCategorias2();

    var update = {
        nome: document.getElementById("inputNome").value,
        preco: document.getElementById("inputPreco").value,
        estoque: document.getElementById("inputEstoque").value,
        categoriaId: document.getElementById("inputCategoriaId").value
    }

    const options = {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(update)
    }

    await fetch("https://localhost:7254/api/Produtos/Post", options)
    .then(data => {
        return data.json();
    })
    .then(produto => {
        nome: update.nome;
        preco: update.preco;
        estoque: update.estoque;
        category: {
            id: update.categoriaId;
        }
    })
    .catch(e => 
        console.log(e))

        getProdutos();
}

async function deletarProdutos(id){
    await fetch(`https://localhost:7254/api/Produtos/Delete${id}`, {
        method: "delete"
    });

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
        categoriaId: document.getElementById("inputCategoriaIdE")
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

    await fetch(`https://localhost:7254/api/Produtos/Put${id2}`, {
        method: "put",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(update)
    })
    .then(data => {
        return data.json();
    })
    .then(produto => {
        {
            id: update.id;
            nome: update.nome;
            preco: update.preco;
            estoque: update.estoque;
            category: {
                id: update.category.id;
            }
        }
    })

    getProdutos();
}