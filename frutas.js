var p = [];
        var list = [];
        var table = [];

        function inserir(text) {
            var opcao = text.innerHTML;

            var input2 = document.getElementById("fruta");
            var input = document.getElementById("fruta").value;


            if (opcao == "Lista") {
                var ref = document.getElementsByTagName("li")[0];
                
                if (input == "") {
                    alert("Você deve preencher o campo!");
                    return;
                }

                for (var i = 0; i < list.length; i++) {
                    if (list[i] == input) {
                        alert("Você não pode inserir uma fruta duplicada!");
                        return;
                    }
                }

                list.unshift(input);

                ref.insertAdjacentHTML("afterend", `<li class="list-group-item-action list-group-item">${input}</li>`);
            }

            if (opcao == "Parágrafo") {
                var ref = document.getElementsByTagName("p")[0];

                if (input == "") {
                    alert("Você deve preencher o campo!");
                    return;
                }



                for (var i = 0; i < p.length; i++) {
                    if (p[i] == input) {
                        alert("Você não pode inserir uma fruta duplicada!");
                        return;
                    }
                }

                p.unshift(input);

                if (ref.innerHTML == "Frutas: ") {
                    ref.innerHTML += `${input}`;
                } else {
                    ref.innerHTML += `, ${input}`;
                }

            }

            if (opcao == "Tabela") {
                if (input == "") {
                    alert("Você deve preencher o campo!");
                    return;
                }

                for (var i = 0; i < table.length; i++) {
                    if (table[i] == input) {
                        alert("Você não pode inserir uma fruta duplicada!");
                        return;
                    }
                }

                table.unshift(input);

                var ref = document.getElementsByTagName("tr")[0];
                ref.insertAdjacentHTML("afterend", `<tr><td>${input}</td></tr>`);
            }

            input2.value = "";
            input2.focus();
        }