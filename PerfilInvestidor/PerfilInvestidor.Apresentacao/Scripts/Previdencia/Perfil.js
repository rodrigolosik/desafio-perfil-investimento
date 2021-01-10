var formulario;
var listaRespostas;

class Formulario {
    constructor() {

        if (listaRespostas.length != 0) {
            this.marcarSelecionados();
            this.bloquearSelecao();
        }
    };

    salvar() {
        let itensSelecionados = this.pegarSelecionados();

        let quantidadeSelecionados = itensSelecionados.length;

        let ehValido = this.validarFormulario(quantidadeSelecionados)

        if (ehValido) {
            let dados = this.montarObjetoFormulario(itensSelecionados);
            this.salvarDados(dados);
        }
        else {
            //TODO: Exibir mensagem informando que todos os campos deve ser marcados para que o perfil seja atualizado/gravado;
        }
    };

    salvarDados(dados) {
        $.ajax({
            url: `/Previdencia/SalvarPerfil`,
            method: 'POST',
            data: dados
        })
            .done((dados) => {
                this.bloquearSelecao();

                //TODO: Exibir a mensagem de confirmação de alteração/gravação dos dados do perfil do usuário;

                setTimeout(function () { location.reload() }, 2000);
            })
            .fail(dados => {
                // TODO: Exibir mensagem para o usuário informando que houve um erro ao processar a solicitação;
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

        // TODO: Verificar a necessidade de adicionar novas validações

        if (quantidadeItensSelecionados < 5) {
            return false;
        }
        return true;
    };

    marcarSelecionados() {
        listaRespostas.forEach(function (e) { $(`input[id='${e.RespostaId}']`).prop('checked', true) })
    }

    limparSelecionados() {
        $('input:checked').prop('checked', false);
    }

    bloquearSelecao() {
        $('input').prop('disabled', true);
    }
    desbloquearSelecao() {
        $('input').prop('disabled', false);
    }
    redefinirPerfil() {
        this.limparSelecionados();
        this.desbloquearSelecao();
    }
}

$(document).ready(function () {
    formulario = new Formulario();
});