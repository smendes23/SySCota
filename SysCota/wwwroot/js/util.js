//INICIO - CARREGA CEP WEBSEVICE CORREIOS

$(".deleta").click(function (event) {
    event.preventDefault();
    var id = $(".idObjeto").val();
    alert(id)
    $.ajax({
        type: "POST",
        url: "Empresa/Delete/" + id,
        success:
            function (dados) {
                alert("Dados removidos com sucesso");
            }

    });


})
//FIM - CARREGA CEP WEBSEVICE CORREIOS