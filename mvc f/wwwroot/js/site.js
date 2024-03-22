const box = document.querySelector(".container");
const imagens = document.querySelectorAll(".container-img");

let contador = 0;

function slider() {
    contador++;

    if (contador > imagens.length - 1) {
        contador = 0;
    }

    box.style.transform = `translateX(${-contador * 850}px)`;
}

setInterval(slider, 2000);
function enviarFormulario() {
    var dados = {
        Nome: $('#Nome').val(),
        Email: $('#Email').val(),
        Senha: $('#Senha').val(),
        Loginusuario: $('#Loginusuario').val(),
        Telefone: $('#Telefone').val(),
        Endereco: $('#Endereco').val(),
        SenhaConfirm: $('#Senha-confirm').val()
    };

    $.ajax({
        url: '/api/Registro',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(dados),
        success: function (response) {
            console.log(response);
        },
        error: function (xhr, status, error) {
            $('#mensagem-erro').text("Erro");
        }
    });
}