//INICIO - CARREGA CEP WEBSEVICE CORREIOS
$(document).ready(function () {
    $("#txtCep").blur(function () {
        console.log("disparou")
        
            $('#errocep').empty();
            $('#loadCep').show();
            $('#blocoTxtCep').hide();
            $.ajax({
                dataType: "json",
                type: "GET",
                url: "/Empresa/ConsultaWebServiceCorreios/?cep=" + $("#txtCep").val(),
                success:
                    function (dados) {
                        
                        if (dados !== null) {
                            for (var i in dados) {
                                console.log(dados[i])
                                $("#txtLogradouro").val(dados[i].end);
                                $("#txtBairro").val(dados[i].bairro);
                                $("#txtUf").val(dados[i].uf);
                                $("#txtCidade").val(dados[i].cidade)
                                $("#txtComplemento").val(dados[i].complemento2)

                            }
                            $("#txtTipoLogradouro").focus();
                        } else {
                            alert("Não foi possivel localizar o CEP.")

                        }

                    }
            });
        
    });
})

 


