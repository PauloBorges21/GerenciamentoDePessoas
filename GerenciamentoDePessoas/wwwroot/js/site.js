$(document).ready(function () {
    $("#buscarTotalPessoas").click(function () {
        // Exibe mensagem com efeito de fadeIn e formatação
        $("#resultado")
            .html("<span style='color: #666; font-style: italic;'>Carregando...</span>")
            .fadeIn(200); // Efeito de aparecer suavemente

        // Delay de 2s antes da chamada AJAX (opcional)
        setTimeout(function () {
            $.ajax({
                url: "Pessoa/TotalPessoas",
                type: "GET",
                dataType: "text",
                success: function (data) {
                    // Sucesso: exibe o resultado com efeito
                    $("#resultado")
                        .html(`<strong>Total de pessoas:</strong> ${data}`)
                        .css({ color: "#2c3e50", fontWeight: "bold" })
                        .fadeIn(300);
                },
                error: function (erro) {
                    // Erro: exibe mensagem em vermelho com efeito
                    $("#resultado")
                        .html("<span style='color: #e74c3c;'>Erro ao carregar dados!</span>")
                        .fadeIn(300);
                    console.error("Erro na requisição:", erro);
                }
            });
        }, 2000); // Delay de 2 segundos (2000ms)
    });
});


(function ($) {
    $(document).ready(function () {
        $('.tabela-pessoa').DataTable(
            {
                language: {
                    url: '//cdn.datatables.net/plug-ins/2.2.2/i18n/pt-BR.json',
                },
                //"pagingType": "bootstrap_input",
            }

        );
    });
})(jQuery);

