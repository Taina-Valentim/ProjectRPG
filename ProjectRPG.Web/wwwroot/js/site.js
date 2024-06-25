const botaoAlterarTema = document.getElementById("botao-alterar-tema");
const body = document.querySelector("body");
const imagemBotaoTrocaDeTema = document.querySelector(".imagem-botao");
const cartaoTopo = document.querySelector(".cartao-topo");
const cartaoConteudo = document.querySelector(".cartao-conteudo");
const checkLembrar = document.querySelector(".check-lembrar");
const botaoSubmit = document.querySelector(".botao-submit");
const msgForaCard = document.querySelector(".msg-fora-card");
const botaoMenor = document.querySelectorAll(".botao-submit.menor")
const itensMenuLateral = document.querySelectorAll('#lista .nav-item.item-menu-lateral');
const personalData = document.querySelector(".personal-data");
const botaoDelete = document.querySelector(".delete-personal-data");
const infos = document.querySelectorAll(".informacoes");
const acoes = document.querySelectorAll(".acoes");
const header = document.querySelector(".header");
const cardArma = document.querySelector('.cartao-dashboard.arma');
const cardAtributo = document.querySelector('.cartao-dashboard.atributo');
const cardCondicao = document.querySelector('.cartao-dashboard.condicao');
const cardEquipamento = document.querySelector('.cartao-dashboard.equipamento');
const cardItem = document.querySelector('.cartao-dashboard.item');
const cardPersonagem = document.querySelector('.cartao-dashboard.personagem');
const botaoGerenciarUsuarios = document.querySelector('.gerenciar-usuarios.btn.btn-outline-dark');
const btnAdicionar = document.querySelector('.btn-adicionar');
const btnEditar = document.querySelectorAll("#btn-editar");
const headerTabela = document.querySelector(".header-tabela");
const tabela = document.querySelector("table");
const th = document.querySelectorAll("th");
const td = document.querySelectorAll("td");
const checkMunicao = document.querySelector(".check-municao");
const btnVoltar = document.getElementById("btn-voltar");

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
    if (elementoExiste(personalData)) personalData.classList.add("modo-escuro");
    if (elementoExiste(botaoDelete)) botaoDelete.classList.add("modo-escuro");
    if (elementoExiste(header)) header.classList.add("modo-escuro");
    if (elementoExiste(headerTabela)) headerTabela.classList.add("modo-escuro");
    if (elementoExiste(tabela)) tabela.classList.add("modo-escuro");
    if (elementoExiste(checkMunicao)) checkMunicao.classList.add("modo-escuro");
    if (elementoExiste(btnVoltar)) btnVoltar.setAttribute("fill", "#00C47D");

    if (elementoExiste(botaoMenor)) {
        for (let item of botaoMenor) {
            if (elementoExiste(item)) item.classList.add("modo-escuro");
        }
    }
    if (elementoExiste(itensMenuLateral)) {
        for (let item of itensMenuLateral) {
            if (elementoExiste(item)) item.classList.add("modo-escuro");
        }
    }
    if (elementoExiste(infos)) {
        for (let item of infos) {
            if (elementoExiste(item)) item.classList.add("modo-escuro");
        }
    }
    if (elementoExiste(th)) {
        for (let item of th) {
            if (elementoExiste(item)) item.classList.add("modo-escuro");
        }
    }
    if (elementoExiste(td)) {
        for (let item of td) {
            if (elementoExiste(item)) item.classList.add("modo-escuro");
        }
    }
    if (elementoExiste(botaoGerenciarUsuarios)) {
        botaoGerenciarUsuarios.classList.remove("btn-outline-dark");
        botaoGerenciarUsuarios.classList.add("btn-outline-secondary");
    }

    if (elementoExiste(btnAdicionar)) {
        btnAdicionar.classList.remove("btn-dark");
        btnAdicionar.classList.add("btn-secondary");
    }

    if (elementoExiste(btnEditar)) {
        for (let item of btnEditar) {
            if (elementoExiste(item)) {
                item.classList.remove("btn-dark");
                item.classList.add("btn-secondary");
            }
        }
    }

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
    if (elementoExiste(personalData)) personalData.classList.remove("modo-escuro");
    if (elementoExiste(botaoDelete)) botaoDelete.classList.remove("modo-escuro");
    if (elementoExiste(header)) header.classList.remove("modo-escuro");
    if (elementoExiste(headerTabela)) headerTabela.classList.remove("modo-escuro");
    if (elementoExiste(tabela)) tabela.classList.remove("modo-escuro");
    if (elementoExiste(checkMunicao)) checkMunicao.classList.remove("modo-escuro");
    if (elementoExiste(btnVoltar)) btnVoltar.setAttribute("fill", "#008C59");

    if (elementoExiste(botaoMenor)) {
        for (let item of botaoMenor) {
            if (elementoExiste(item)) item.classList.remove("modo-escuro");
        }
    }

    if (elementoExiste(itensMenuLateral)) {
        for (let item of itensMenuLateral) {
            if (elementoExiste(item)) item.classList.remove("modo-escuro");
        }
    }

    if (elementoExiste(infos)) {
        for (let item of infos) {
            if (elementoExiste(item)) item.classList.remove("modo-escuro");
        }
    }

    if (elementoExiste(th)) {
        for (let item of th) {
            if (elementoExiste(item)) item.classList.remove("modo-escuro");
        }
    }

    if (elementoExiste(td)) {
        for (let item of td) {
            if (elementoExiste(item)) item.classList.remove("modo-escuro");
        }
    }

    if (elementoExiste(botaoGerenciarUsuarios)) {
        botaoGerenciarUsuarios.classList.remove("btn-outline-secondary");
        botaoGerenciarUsuarios.classList.add("btn-outline-dark");
    }

    if (elementoExiste(btnAdicionar)) {
        btnAdicionar.classList.remove("btn-secondary");
        btnAdicionar.classList.add("btn-dark");
    }

    if (elementoExiste(btnEditar)) {
        for (let item of btnEditar) {
            if (elementoExiste(item)) {
                item.classList.remove("btn-secondary");
                item.classList.add("btn-dark");
            }
        }
    }

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


cardArma.addEventListener('click', function () {
    window.location.href = 'Administrador/Arma/Index';
});

cardAtributo.addEventListener('click', function () {
    window.location.href = 'Administrador/Atributo/Index';
});

cardCondicao.addEventListener('click', function () {
    window.location.href = 'Administrador/Condicao/Index';
});

cardEquipamento.addEventListener('click', function () {
    window.location.href = 'Administrador/Equipamento/Index';
});

cardItem.addEventListener('click', function () {
    window.location.href = 'Administrador/Item/Index';
});

cardPersonagem.addEventListener('click', function () {
    window.location.href = 'Administrador/Personagem/Index';
});
