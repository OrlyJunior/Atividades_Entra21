var lista = [];
var listaO = [];
var html = ``;

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
    var position = document.getElementById("remover").value;

}