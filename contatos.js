var contatos = [];

function adicionar() {
    var nomeI = document.getElementById("nome");
    var emailI = document.getElementById("email");
    var numeroI = document.getElementById("numero");

    var nome = document.getElementById("nome").value;
    var email = document.getElementById("email").value;
    var numero = document.getElementById("numero").value;

    if (nome == "" || email == "" || numero == "") {
        alert("Todos os campos devem ser preenchidos!");
        return;
    }

    if (!email.includes("@")) {
        alert("Você não inseriu um email!");
        return;
    }

    var contato = { nome: nome, email: email, numero: numero };

    var add = `<tr class="table-light"><td>${contato.nome}</td><td>${contato.email}</td><td>${contato.numero}</td></tr>`

    document.getElementsByTagName("tr")[0].insertAdjacentHTML("afterend", add);

    contatos.unshift(contato);

    console.log(contatos);

    nomeI.value = ``;
    emailI.value = ``;
    numeroI.value = ``;
}

function deletar() {
    var html = `<div id="divAlt" class="mt-2 d-flex flex-column">
                        <label>Qual linha você deseja deletar?</label>
                        <input class="form-control mb-2 rounded w-25" id="delete" type="number">
                        <button class="btn btn-danger" style="width: 10%" id="del2" onclick="deletar2()">Deletar</button>
                        </div>`;

    var ref = document.getElementById("alt");
    ref.insertAdjacentHTML("afterend", html);

    var btnAlt = document.getElementById("alt");
    btnAlt.disabled = "true";

    var btn = document.getElementById("del");
    btn.disabled = "true";
}

function deletar2() {
    var linha = document.getElementById("delete").value;

    if (linha == "") {
        alert("Você deve informar a linha para remover!");
        return;
    }

    document.getElementsByTagName("tr")[linha].remove();

    var btnAlt = document.getElementById("alt");
    btnAlt.removeAttribute("disabled");

    var btn = document.getElementById("del");
    btn.removeAttribute("disabled");
    
    document.getElementById("divAlt").remove();
}

function alterar() {
    var btnAlt = document.getElementById("alt");
    btnAlt.disabled = "true";

    var btn = document.getElementById("del");
    btn.disabled = "true";

    var html = `<div id="divAlt" class="mt-2 d-flex flex-column">
                        <label>Qual linha você deseja alterar?</label>
                        <input class="form-control rounded w-25" id="alter" type="number">

                        <label class="mt-2" for="nome">Insira o nome do contato: </label>
                        <input class=" mb-2 form-control rounded w-25" id="nome2" type="text">

                        <label class="mt-2" for="email">Insira o email do contato: </label>
                        <input class="mb-2 form-control rounded input-group-email w-25" id="email2" type="email">

                        <label class="mt-2" for="numero">Insira o número do contato: </label>
                        <input class="mb-2 form-control rounded w-25" id="numero2" type="number">
                        
                        <button class="btn btn-warning" style="width: 10%;" onclick="alterar3()" id="alt3">Alterar</button>
                        </div>`;

    var ref = document.getElementById("alt");
    ref.insertAdjacentHTML("afterend", html);
}

function alterar3() {
    var linha = document.getElementById("alter").value;

    if (linha == "") {
        alert("Você deve informar a linha!");
        return;
    }

    var btnAlt = document.getElementById("alt");
    btnAlt.removeAttribute("disabled");

    var btn = document.getElementById("del");
    btn.removeAttribute("disabled");

    var nome = document.getElementById("nome2").value;
    var email = document.getElementById("email2").value;
    var numero = document.getElementById("numero2").value;

    var contato = { nome: nome, email: email, numero: numero };

    contatos.splice(linha - 1, 1, contato);

    document.getElementsByTagName("tr")[linha].innerHTML = `<td>${contato.nome}</td><td>${contato.email}
                                                                        </td><td>${contato.numero}</td>`

    document.getElementById("divAlt").remove();
}