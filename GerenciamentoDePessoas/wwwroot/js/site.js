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
