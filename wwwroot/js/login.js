document.getElementById("loginForm").addEventListener("submit", async function (e) {
    e.preventDefault();

    const email = document.getElementById("email").value;
    const cpf = document.getElementById("cpf").value;

    const resposta = await fetch("/controller/cliente/LoginCliente", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ email, cpf })
    });

    const resultado = document.getElementById("resultado");
    if (resposta.ok) {
        const cliente = await resposta.json();
          localStorage.setItem("Id", cliente.id);
          localStorage.setItem("Nome", cliente.nome);
        resultado.innerText = "Login realizado com sucesso!";
        window.location.href = "principal.html";
    } else {
        resultado.innerText = "Cliente não encontrado.";
    }

    
   
});