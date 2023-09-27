var lista = [];
var linhaE = 0;

var exc = document.getElementById("excluir");
var alter = document.getElementById("editar");

var nome = document.getElementById("text").value;
var desc = document.getElementById("desc").value;
var valor = document.getElementById("valor").value;
var qtt = document.getElementById("qtt").value;

var produto = { nome: nome, desc: desc, valor: valor, qtt: qtt };

var soma = 0;
function registrar() {
    soma = 0;

    nome = document.getElementById("text").value;
    desc = document.getElementById("desc").value;
    valor = parseFloat(document.getElementById("valor").value);
    qtt = parseFloat(document.getElementById("qtt").value);

    if (nome == "" || desc == "" || isNaN(valor) || isNaN(qtt)) {
        alert("Você deve preencher todos os campos!");
        return;
    }

    produto = { nome: nome, desc: desc, valor: parseFloat(valor.toFixed(2)), qtt: qtt, total: parseFloat((valor * qtt).toFixed(2)) };

    lista.unshift(produto);

    console.log(lista)


    for (i = 0; i < lista.length; i++) {
        soma += lista[i].total;
    }

    document.getElementById("total").innerHTML = `Total: R$${parseFloat(soma).toFixed(2)}`;

    var ref = document.getElementsByTagName("tr")[0];

    ref.insertAdjacentHTML("afterend", `<tr>
                                            <td>${lista[0].nome}</td>
                                            <td>${lista[0].desc}</td>
                                            <td>R$${lista[0].valor}</td>
                                            <td>${lista[0].qtt}</td>
                                            <td>R$${lista[0].total}</td>
                                        </tr>`);
}

function remover() {
    var ref = document.getElementById("editar");

    exc.disabled = true;
    alter.disabled = true;

    ref.insertAdjacentHTML("afterend", `<div id="clear1">
                                        <label>Selecione uma linha para remover: </label>
                                        <input id="linhaR" type="text">
                                        <button class="btn btn-danger" onclick="remover2()">Excluir</button>
                                        </div>`);
}

function remover2() {
    exc.removeAttribute("disabled");
    alter.removeAttribute("disabled");

    var linhaR = document.getElementById("linhaR").value;
    lista.splice(linhaR - 1, 1);

    document.getElementById("clear1").innerHTML = ``;

    document.getElementById("table").innerHTML = `<tr class="table-primary">
                                                    <th>Nome do produto</th>
                                                    <th>Descrição</th>
                                                    <th>Valor</th>
                                                    <th>Quantidade</th>
                                                </tr>`

    for (var i = 0; i < lista.length; i++) {
        var ref = document.getElementsByTagName("tr")[0].insertAdjacentHTML("afterend", `<tr>
                                                                                            <td>${lista[i].nome}</td>
                                                                                            <td>${lista[i].desc}</td>
                                                                                            <td>${lista[i].valor}</td>
                                                                                            <td>${lista[i].qtt}</td>
                                                                                         </tr>`);
    }
}

function editar() {
    exc.disabled = true;
    alter.disabled = true;

    var ref = document.getElementById("editar");
    ref.insertAdjacentHTML("afterend", `<div class="mt-2 input-group-text w-25 flex-column d-flex " id="clear3">
                                        <label for="edit">Qual linha você deseja alterar?</label>
                                        <input class="form-control w-25" id="edit" type="number">
                                        <button onclick="editar2()">Selecionar linha</button>
                                        </div>`);
}

function editar2() {
    linhaE = document.getElementById("edit").value;

    document.getElementById("clear3").innerHTML = ``;
    document.getElementById("clear3").classList.remove("input-group-text");

    if (linhaE - 1 > lista.length) {
        alert("Essa posição não existe na lista!");
        return;
    }

    if (linhaE == "") {
        alert("Você deve informar as linhas que quer alterar!");
        return;
    }

    var ref = document.getElementById("editar");
    ref.insertAdjacentHTML("afterend", `<div class="w-25 input-group-text mt-2 d-flex flex-column" id="clear2">
                                        <label for="text">Nome: </label>
                                        <input class="form-control" id="text2" type="text">

                                        <label for="desc">Descrição: </label>
                                        <input class="form-control" id="desc2" type="text">

                                        <label for="valor">Valor: </label>
                                        <input class="form-control" id="valor2" type="number">

                                        <label for="qtt">Quantidade: </label>
                                        <input class="form-control" id="qtt2" type="text">

                                        <button class="mt-2 btn btn-warning" onclick="editar3()">Finalizar</button>
                                        </div>`);
}

function editar3() {
    soma = 0;

    exc.removeAttribute("disabled");
    alter.removeAttribute("disabled");

    var nome = document.getElementById("text2").value;
    var desc = document.getElementById("desc2").value;
    var valor = document.getElementById("valor2").value;
    var qtt = document.getElementById("qtt2").value;

    produto = { nome: nome, desc: desc, valor: valor, qtt: qtt, total: valor * qtt };

    lista.splice(linhaE - 1, 1, produto);

    document.getElementsByTagName("tr")[linhaE].innerHTML = `<td>${lista[linhaE - 1].nome}</td>
                                                             <td>${lista[linhaE - 1].desc}</td>
                                                             <td>R$${lista[linhaE - 1].valor}</td>
                                                             <td>${lista[linhaE - 1].qtt}</td>
                                                             <td>R$${lista[linhaE - 1].total}</td>`

    for (i = 0; i < lista.length; i++) {
        soma += lista[i].total;
    }

    document.getElementById("clear2").innerHTML = ``;
    document.getElementById("clear2").classList.remove("input-group-text");

    document.getElementById("total").innerHTML = `Total: R$${parseFloat(soma).toFixed(2)}`;
}

