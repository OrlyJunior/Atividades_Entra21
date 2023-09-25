var sinal = "";
var valorUm = 0;
var valorDois = 0;
var display = document.getElementById("resultado");
var result = document.getElementById("r");
var conta = `${valorUm}`;

function add(n) {
    var numero = 0;
    var numero = parseFloat(n.innerHTML);

    if (sinal != "") {
        valorDois = valorDois * 10;
        valorDois += numero;

        conta = `${valorUm} ${sinal} ${valorDois}`;
    } else {
        valorUm = valorUm * 10;
        valorUm += numero;

        conta = `${valorUm}`;
    }

    display.innerHTML = `${conta}`
}

function operacao(operacao) {
    sinal = operacao.innerHTML;

    conta = `${valorUm} ${sinal}`;

    display.innerHTML = `${conta}`;
}

function subtracao() {
    sinal = "-";

    var conta = `${valorUm} ${sinal}`;

    display.innerHTML = `${conta}`;
}

function multiplicacao() {
    sinal = "x";

    var conta = `${valorUm} ${sinal}`;

    display.innerHTML = `${conta}`;
}

function divisao() {
    sinal = "/";

    var conta = `${valorUm} ${sinal}`;

    display.innerHTML = `${conta}`;
}

function realizarOperação() {
    if (sinal == "+") {
        var resultado = valorUm + valorDois;
    }

    if (sinal == "-") {
        var resultado = valorUm - valorDois;
    }

    if (sinal == "x") {
        var resultado = valorUm * valorDois;
    }

    if (sinal == "/") {
        var resultado = valorUm / valorDois;
    }

    if (resultado == undefined) {
        var resultado = 0;
    }

    sinal = "";
    valorUm = resultado;
    valorDois = 0;
    resultado = 0;

    var conta = `${valorUm}`;

    display.innerHTML = `${conta}`;
}

function limpar() {
    valorUm = 0;
    valorDois = 0;
    sinal = "";

    var conta = `${valorUm}`;

    display.innerHTML = `${valorUm}`
}