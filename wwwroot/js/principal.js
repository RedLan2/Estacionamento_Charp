document.addEventListener("DOMContentLoaded", async function () {
    const nome = localStorage.getItem("Nome");
    const clienteId =   localStorage.getItem("Id");

    if (nome) {
        document.getElementById("boasVindas").innerText = `Bem-vindo, ${nome}!`;
    }

    if (!clienteId) {
        alert("Cliente não identificado. Faça login novamente.");
        window.location.href = "login.html";
        return;
    }

    // Listar veículos
    try {
         const resposta = await fetch(`/Veiculo/ListarVeiculo/${clienteId}`);
        const lista = document.getElementById("listaVeiculos");

        if (resposta.ok) {
            const veiculos = await resposta.json();
            if (veiculos.length == 0) {
                lista.innerHTML = "<li>Você ainda não cadastrou nenhum veículo.</li>";
            } else {
                //lista.innerHTML = ""; // Limpa a lista antes de adicionar novos itens
                veiculos.forEach(v => {
                    const li = document.createElement("li");
                    li.innerText = `Modelo: ${v.modelo}, Placa: ${v.placa}`;
                    lista.appendChild(li);
                });
            }
        } else {
            lista.innerHTML = "<li>Erro ao carregar veículos.</li>";
        }
    } catch (erro) {
        console.error("Erro ao buscar veículos:", erro);
    }

    // Cadastro de novo veículo
    document.getElementById("formCadastroVeiculo").addEventListener("submit", async function (e) {
        e.preventDefault();

        const modelo = document.getElementById("modelo").value;
        const placa = document.getElementById("placa").value;

        const resposta = await fetch("/Veiculo/CriarVeiculo", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                modelo,
                placa,
                clienteId: parseInt(clienteId)
            })
        });

        if (resposta.ok) {
            alert("Veículo cadastrado com sucesso!");
            window.location.reload(); // Atualiza a página para recarregar a lista
        } else {
            alert("Erro ao cadastrar veículo.");
        }
    });
});
