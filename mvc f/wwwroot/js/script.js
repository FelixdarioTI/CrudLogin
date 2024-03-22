function fazerLogin() {
    var credenciais = {
        Usuario: $('#usuario').val(),
        Senha: $('#senha').val()
    };

    $.ajax({
        url: '/api/Login',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(credenciais),
        success: function (response) {
            // Se o login for bem-sucedido, redirecionamos o usuário para outra página ou mostramos uma mensagem de sucesso
            console.log(response);
            // Exemplo de redirecionamento para uma página de dashboard após o login
            window.location.href = '/Loja';
        },
        error: function (xhr, status, error) {
            // Se houver um erro, mostramos a mensagem de erro ao usuário
            $('#mensagem-erro').text(Unauthorized);
        }
    });
}