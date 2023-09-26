function registrar() {
    var lista = [];

    var nome = document.getElementById("text").value;
    var desc = document.getElementById("desc").value;
    var valor = document.getElementById("valor").value;
    var qtt = document.getElementById("qtt").value;

    var produto = { nome: nome, desc: desc, valor: valor, qtt: qtt };

    lista.unshift(produto);

    var ref = document.getElementsByTagName("tr")[0];
    ref.insertAdjacentHTML("afterend", `<tr>
                                            <td>${lista[0].nome}</td>
                                            <td>${lista[0].desc}</td>
                                            <td>${lista[0].valor}</td>
                                            <td>${lista[0].qtt}</td>
                                        </tr>`);

    console.log(lista)
}
