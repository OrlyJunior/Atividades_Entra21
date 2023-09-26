var lista = [];
var linhaE = 0;

var nome = document.getElementById("text").value;
var desc = document.getElementById("desc").value;
var valor = document.getElementById("valor").value;
var qtt = document.getElementById("qtt").value;

var produto = { nome: nome, desc: desc, valor: valor, qtt: qtt };

function registrar() {
    nome = document.getElementById("text").value;
    desc = document.getElementById("desc").value;
    valor = document.getElementById("valor").value;
    qtt = document.getElementById("qtt").value;

    produto = { nome: nome, desc: desc, valor: valor, qtt: qtt };

    lista.unshift(produto);

    var ref = document.getElementsByTagName("tr")[0];

    ref.insertAdjacentHTML("afterend", `<tr>
                                            <td>${lista[0].nome}</td>
                                            <td>${lista[0].desc}</td>
                                            <td>${lista[0].valor}</td>
                                            <td>${lista[0].qtt}</td>
                                        </tr>`);
}

function remover() {
    var ref = document.getElementById("editar");

    ref.insertAdjacentHTML("afterend", `<label>Selecione uma linha para remover: </label>
                                        <input id="linhaR" type="text">
                                        <button onclick="remover2()">Excluir</button>`);
}

function remover2() {
    var linhaR = document.getElementById("linhaR").value;
    lista.splice(linhaR - 1, 1);

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
    linhaE = document.getElementById("edit").value;

    var ref = document.getElementById("editar");
    ref.insertAdjacentHTML("afterend", `<label for="text">Nome: </label>
                                        <input id="text2" type="text">

                                        <label for="desc">Descrição: </label>
                                        <input id="desc2" type="text">

                                        <label for="valor">Valor: </label>
                                        <input id="valor2" type="number">

                                        <label for="qtt">Quantidade: </label>
                                        <input id="qtt2" type="text">

                                        <button onclick="editar3()">Finalizar</button>
                                        `);
}

function editar3() {
    var novoN = document.getElementById("text2").value;
    var novoD = document.getElementById("desc2").value;
    var novoV = document.getElementById("valor2").value;
    var novoQ = document.getElementById("qtt2").value;

    document.getElementsByTagName("tr")[linhaE].innerHTML = `<td>${novoN}</td>
    <td>${novoD}</td>
    <td>${novoV}</td>
    <td>${novoQ}</td>`
}