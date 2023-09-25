
var lista = [];
var html = ``;

function add() {
    var num = document.getElementById("numero").value;

    num = parseInt(num);

    lista.unshift(num);

    for (var i = 0; i < lista.length; i++) {
        for (var x = 0; x < lista.length - i; x++) {
            if (lista[x] > lista[x + 1]) {
                var mudar = lista[x];
                lista[x] = lista[x + 1];
                lista[x + 1] = mudar;
            }
        }
    }
}

function mostrar() {
    for (var i = 0; i < lista.length; i++) {
        html += `<li>${lista[i]}</li>`;
        var list = document.getElementById("list");
        list.innerHTML = html;
    }
}