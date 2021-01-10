var formulario;
var listaRespostas;

class Formulario {
    constructor() {
        this.marcarSelecionados();
    };

    salvar() {
        let itensSelecionados = this.pegarSelecionados();

        let quantidadeSelecionados = itensSelecionados.length;

        let ehValido = this.validarFormulario(quantidadeSelecionados)

        if (!ehValido) {
            console.log('sou invalido');
        }

        let dados = this.montarObjetoFormulario(itensSelecionados);
        this.salvarDados(dados);

    };

    salvarDados(dados) {
        $.ajax({
            url: `/Previdencia/SalvarPerfil`,
            method: 'POST',
            data: dados
        })
            .done(function (data) {
                console.log(data);
            })
            .fail(function (erro) {
                console.log(erro);
            });
    }

    montarObjetoFormulario(elementos) {

        return {
            RespostasIds: Array.from(elementos, function (x) { return x.id }),
            RespostasValores: Array.from(elementos, function (x) { return x.value })
        }

    }

    pegarSelecionados() {
        return $("input[type='radio']:checked");
    };

    validarFormulario(quantidadeItensSelecionados) {

        console.log("Quantidade: " + quantidadeItensSelecionados);
        if (quantidadeItensSelecionados < 5) {
            return false;
        }
        return true;
    };

    marcarSelecionados() {
        listaRespostas.forEach(function (e) { $(`input[id='${e.RespostaId}']`).prop('checked', true) })
    }
}

$(document).ready(function () {
    formulario = new Formulario();
});