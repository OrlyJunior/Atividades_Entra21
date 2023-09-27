var lista = [];
var listaO = [];

var btnAlt = document.getElementById("alt");
var btnRem = document.getElementById("rem");

var html = ``;
var achado = document.getElementById("achado");

var editado = 0;

function add() {
    var num = document.getElementById("numero").value;

    num = parseFloat(num);

    if (isNaN(num)) {
        alert("Você deve inserir um número!");
        return;
    }

    lista.unshift(num);
    listaO.unshift(num);
}

function acharNumero() {
    var achar = document.getElementById("achar").value;


    for (var i = 0; i < lista.length; i++) {
        if (lista[i] == achar) {
            achado.innerHTML = `<p class="mt-2">O número ${achar} está na posição ${i + 1} do array`;
        }
    }
}

function ordenar(m) {
    achado.innerHTML = ``;

    document.getElementById("list").innerHTML = ``;

    var maneira = m.innerHTML;
    if (maneira == "Crescente") {
        for (var i = 0; i < lista.length; i++) {
            for (var x = 0; x < lista.length - i; x++) {
                if (lista[x] > lista[x + 1]) {
                    var mudar = lista[x];
                    lista[x] = lista[x + 1];
                    lista[x + 1] = mudar;
                }
            }
        }

        for (var i = 0; i < lista.length; i++) {
            document.getElementById("list").innerHTML += `<li class="w-25 list-group-item list-group-item-action">${lista[i]}</li>`;
        }
    }

    if (maneira == "Decrescente") {
        for (var i = 0; i < lista.length; i++) {
            for (var x = 0; x < lista.length - i; x++) {
                if (lista[x] < lista[x + 1]) {
                    var mudar = lista[x];
                    lista[x] = lista[x + 1];
                    lista[x + 1] = mudar;
                }
            }
        }

        for (var i = 0; i < lista.length; i++) {
            document.getElementById("list").innerHTML += `<li class="w-25 list-group-item list-group-item-action">${lista[i]}</li>`;
        }
    }

    if (maneira == "Original") {
        for (var i = 0; i < listaO.length; i++) {
            document.getElementById("list").innerHTML += `<li class="w-25 list-group-item list-group-item-action">${listaO[i]}</li>`;
        }
    }
}

function remover() {
    var numero = document.getElementById("remover").value;

    if (numero == "") {
        alert("Você deve escolher um número para remover!");
        return;
    }
    for (var i = 0; i < lista.length; i++) {
        if (lista[i] == numero) {
            lista.splice(i, 1);
        }
    }

    for (var i = 0; i < listaO.length; i++) {
        if (listaO[i] == numero) {
            listaO.splice(i, 1);
        }
    }
}

function editar() {
    var edit = document.getElementById("editar").value;

    if (edit == "") {
        alert("Você deve escolher um número para alterar!");
        return;
    }
    btnAlt.disabled = "true";
    btnRem.disabled = "true";

    editado = edit;

    var input = `<div id="clear1" class="mt-2">
                 <label for="alterar">Altere o número: </label>
                 <input class="w-25 mb-2 form-control" id="alterar" type="number">
                 <button class="btn btn-outline-warning" onclick="alterar()" id="btnAlterar">Alterar</button>
                 </div>`

    for (var i = 0; i < lista.length; i++) {
        if (lista[i] == edit) {
            var ref = document.getElementById("div");
            ref.insertAdjacentHTML("afterend", input);
        }
    }
}

function alterar() {
    btnAlt.removeAttribute("disabled");
    btnRem.removeAttribute("disabled");

    document.getElementById("clear1").innerHTML = ``;

    var novoN = document.getElementById("alterar").value;

    for (var i = 0; i < lista.length; i++) {
        if (lista[i] == editado) {
            lista.splice(i, 1, novoN);
        }
    }

    for (var i = 0; i < listaO.length; i++) {
        if (listaO[i] == editado) {
            listaO.splice(i, 1, novoN);
        }
    }
}