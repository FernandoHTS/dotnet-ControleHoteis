$(document).ready(function () {

    $('.cnpj').mask('00.000.000/0000-00', { reverse: true });

});

function AjaxModal() {

    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click",
                function (e) {
                    $('#myModalContent').load(this.href,
                        function () {
                            $('#myModal').modal({
                                keyboard: true
                            },
                                'show');                            
                        });
                    return false;
                });
        });
    });

    
}


function CadastrarFoto() {

    var descricao = $("#DescricaoFoto").val();
    var foto = $("#ImagemUploads").val();

    if (descricao == "" || foto == "") {
        SweetAlertToast("Insira as informações!");
    }
    else {
        document.getElementById('cadFoto').submit();
    }
    
}
