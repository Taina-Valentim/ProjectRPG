const botaoAlterarTema = document.getElementById("botao-alterar-tema");
const body = document.querySelector("body");
const imagemBotaoTrocaDeTema = document.querySelector(".imagem-botao");
const cartaoTopo = document.querySelector(".cartao-topo");
const cartaoConteudo = document.querySelector(".cartao-conteudo");
const checkLembrar = document.querySelector(".check-lembrar");
const botaoSubmit = document.querySelector(".botao-submit");
const msgForaCard = document.querySelector(".msg-fora-card");

let temaEscuroAtivo;

// Verifica se há um valor armazenado para temaEscuroAtivo no localStorage
const temaEscuroArmazenado = localStorage.getItem("temaEscuroAtivo");
if (temaEscuroArmazenado !== null) {
    temaEscuroAtivo = temaEscuroArmazenado === "true";
} else {
    // Se não houver valor armazenado, defina o padrão como falso
    temaEscuroAtivo = false;
}

// Função para definir o tema escuro
function definirTemaEscuro() {
    if (elementoExiste(body)) body.classList.add("modo-escuro");
    if (elementoExiste(cartaoTopo)) cartaoTopo.classList.add("modo-escuro");
    if (elementoExiste(cartaoConteudo)) cartaoConteudo.classList.add("modo-escuro");
    if (elementoExiste(checkLembrar)) checkLembrar.classList.add("modo-escuro");
    if (elementoExiste(botaoSubmit)) botaoSubmit.classList.add("modo-escuro");
    if (elementoExiste(msgForaCard)) msgForaCard.classList.add("modo-escuro");

    imagemBotaoTrocaDeTema.setAttribute("src", "/images/server/moon.png");
}

// Função para definir o tema claro
function definirTemaClaro() {
    if (elementoExiste(body)) body.classList.remove("modo-escuro");
    if (elementoExiste(cartaoTopo)) cartaoTopo.classList.remove("modo-escuro");
    if (elementoExiste(cartaoConteudo)) cartaoConteudo.classList.remove("modo-escuro");
    if (elementoExiste(checkLembrar)) checkLembrar.classList.remove("modo-escuro");
    if (elementoExiste(botaoSubmit)) botaoSubmit.classList.remove("modo-escuro");
    if (elementoExiste(msgForaCard)) msgForaCard.classList.remove("modo-escuro");

    imagemBotaoTrocaDeTema.setAttribute("src", "/images/server/sun.png");
}

// Verifica o estado inicial do tema
if (temaEscuroAtivo) {
    definirTemaEscuro();
} else {
    definirTemaClaro();
}

// Evento de clique no botão para alternar o tema
botaoAlterarTema.addEventListener("click", () => {
    temaEscuroAtivo = !temaEscuroAtivo; // Alterna entre true e false
    if (temaEscuroAtivo) {
        definirTemaEscuro();
    } else {
        definirTemaClaro();
    }

    // Armazena o estado atual do tema no localStorage
    localStorage.setItem("temaEscuroAtivo", temaEscuroAtivo);
});

function elementoExiste(elemento) {
    if (elemento === null) return false;
    else return true;
}





/*
const botaoAlterarTema = document.getElementById("botao-alterar-tema");
const body = document.querySelector("body");
const imagemBotaoTrocaDeTema = document.querySelector(".imagem-botao");
const cartaoTopo = document.querySelector(".cartao-topo");
const cartaoConteudo = document.querySelector(".cartao-conteudo");
const checkLembrar = document.querySelector(".check-lembrar");
const botaoSubmit = document.querySelector(".botao-submit");
const msgCadastrar = document.querySelector(".msg-cadastrar");

let temaEscuroAtivo;

botaoAlterarTema.addEventListener("click", () => {
    if (temaEscuroAtivo) {
        desativarTemaEscuro();
    } else {
        ativarTemaEscuro();
    }
});
function ativarTemaEscuro() {
    if (elementoExiste(body)) body.classList.add("modo-escuro");
    if (elementoExiste(cartaoTopo)) cartaoTopo.classList.add("modo-escuro");
    if (elementoExiste(cartaoConteudo)) cartaoConteudo.classList.add("modo-escuro");
    if (elementoExiste(checkLembrar)) checkLembrar.classList.add("modo-escuro");
    if (elementoExiste(botaoSubmit)) botaoSubmit.classList.add("modo-escuro");
    if (elementoExiste(msgCadastrar)) msgCadastrar.classList.add("modo-escuro");

    imagemBotaoTrocaDeTema.setAttribute("src", "/images/server/moon.png");
    temaEscuroAtivo = true;
    console.log("Tema escuro ativado")
}

function desativarTemaEscuro() {
    if (elementoExiste(body)) body.classList.remove("modo-escuro");
    if (elementoExiste(cartaoTopo)) cartaoTopo.classList.remove("modo-escuro");
    if (elementoExiste(cartaoConteudo)) cartaoConteudo.classList.remove("modo-escuro");
    if (elementoExiste(checkLembrar)) checkLembrar.classList.remove("modo-escuro");
    if (elementoExiste(botaoSubmit)) botaoSubmit.classList.remove("modo-escuro");
    if (elementoExiste(msgCadastrar)) msgCadastrar.classList.remove("modo-escuro");

    imagemBotaoTrocaDeTema.setAttribute("src", "/images/server/sun.png");
    temaEscuroAtivo = false;
    console.log("Tema escuro desativado")
}

function elementoExiste(elemento) {
    if (elemento === null) return false;
    else return true;
}








*/