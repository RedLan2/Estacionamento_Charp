document.getElementById("criarContaForm").addEventListener("submit", async function (e) {
    e.preventDefault();

    const email = document.getElementById("email").value;
    const cpf = document.getElementById("cpf").value;
    const nome = document.getElementById("nome").value;
    const telefone = document.getElementById("telefone").value;
    const data_nascimento = document.getElementById("data_nascimento").value;
    const senha = document.getElementById("senha").value;

    const resposta = await fetch("/controller/cliente/CriarCliente", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ email, cpf, nome, telefone, data_nascimento, senha })
    });

    const resultado = document.getElementById("resultado");
    if (resposta.ok) {
        resultado.innerText = "Conta criada com sucesso!";
        window.location.href = "login.html";
    } else {
      const erroTexto = await resposta.text();
      console.log("Resposta de erro:", erroTexto);
    }
});