var lista = [];
var listaO = [];

var html = ``;

var editado = 0;

function add() {
    var num = document.getElementById("numero").value;

    num = parseInt(num);

    lista.unshift(num);
    listaO.unshift(num);
}

function acharNumero() {
    var achar = document.getElementById("achar").value;

    for (var i = 0; i < lista.length; i++) {
        if (lista[i] == achar) {
            document.getElementById("achado").innerHTML = `<p>O número ${achar} está na posição ${i + 1} do array`;
        }
    }
}

function ordenar(m) {
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
            document.getElementById("list").innerHTML += `<li>${lista[i]}</li>`;
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
            document.getElementById("list").innerHTML += `<li>${lista[i]}</li>`;
        }
    }

    if (maneira == "Original") {
        for (var i = 0; i < listaO.length; i++) {
            document.getElementById("list").innerHTML += `<li>${listaO[i]}</li>`;
        }
    }
}

function remover() {
    var numero = document.getElementById("remover").value;

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
    editado = edit;

    var input = `<label for="alterar">Altere o número: </label>
                 <input id="alterar" type="number">
                 <button onclick="alterar()" id="btnAlterar">Alterar</button>`

    for (var i = 0; i < lista.length; i++) {
        if (lista[i] == edit) {
            var ref = document.getElementById("div");
            ref.insertAdjacentHTML("afterend", input);
        }
    }
}

function alterar() {
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