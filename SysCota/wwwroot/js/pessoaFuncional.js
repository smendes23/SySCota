
$('#txtDataAdmissao').mask("99/99/9999");
$('#txtDataDemissao').mask("99/99/9999");
$('#txtOrgaoCnpj').mask("99.999.999/9999-99");

//Torna determinados campos em minusculo
$('#txtEmpresaOrgao').keyup(function () {
    $(this).val($(this).val().toUpperCase());
});

//ADICIONA ITENS AVERBAÇÃO NA NA DATATABLE
$('#btnAddAverbacao').click(function () {
    //Adiciona itens na table
    $("#tb_Averbacao tbody").append(
        "<tr>" +
        "<tr class=\"itemAverbacao\">" +
        "<td>" + $('#txtTipoAverbacao :selected').text() + "</td>" +
        "<td>" + $('#txtDataAdmissao').val() + "</td>" +
        "<td>" + $('#txtDataDemissao').val() + "</td>" +
        "<td>" + $('#txtOrgaoCnpj').val() + "</td>" +
        "<td>" + $('#txtEmpresaOrgao').val() + "</td>" +
        "<td style=\"text-align:center\"><button class=\"btn btn-danger delete\"data-toggle=\"tooltip\" data-placement=\"top\" title=\"Clique para remover arquivo\"><span class=\"glyphicon glyphicon-trash\"></span></button></td>"
    );

    //limpa campos
    $('#txtDataAdmissao').val("");
    $('#txtDataDemissao').val("");
    $('#txtOrgaoCnpj').val("");
    $('#txtEmpresaOrgao').val("");
    $('#txtTipoAverbacao').val("");

    //foca no campo
    $('#txtTipoAverbacao').focus();
});

//ADICIONA ITENS AFASTAMENTO LICENÇA NA NA DATATABLE
$('#btnAddAfastamentoLicenca').click(function () {
    //Adiciona itens na table
    $("#tb_AfastamentoLicenca tbody").append(
        "<tr>" +
        "<tr class=\"itemAfastamentoLicenca\">" +
        "<td>" + $('#txtNumeroProcesso').val() + "</td>" +
        "<td>" + $('#txtTipoLicenca :selected').text() + "</td>" +
        "<td>" + $('#txtDescDoe').val() + "</td>" +
        "<td>" + $('#txtDataInicioLicenca').val() + "</td>" +
        "<td>" + $('#txtDataFimLicenca').val() + "</td>" +
        "<td>" + $('#txtDataPublicacaoDoeLicenca').val() + "</td>" +
        "<td>" + $('#txtDataRevogacao').val() + "</td>" +
        "<td>" + $('#radioContribuicaoSIM').val() + "</td>" +
        "<td style=\"text-align:center\"><button class=\"btn btn-danger delete\"data-toggle=\"tooltip\" data-placement=\"top\" title=\"Clique para remover arquivo\"><span class=\"glyphicon glyphicon-trash\"></span></button></td>"
    );

    //foca no campo
    $('#txtNumeroProcesso').focus();
});

//ADICIONA ITENS AFASTAMENTO LICENÇA NA NA DATATABLE
$('#btnAddAfastamentoCendencia').click(function () {
    //Adiciona itens na table
    $("#tb_AfastamentoCedencia tbody").append(
        "<tr>" +
        "<tr class=\"itemAfastamentoCedencia\">" +
        "<td>" + $('#txtOrgaoRequisitante :selected').text() + "</td>" +
        "<td>" + $('#txtFuncao').val() + "</td>" +
        "<td>" + $('#txtEnumTipoOnus :selected').text() + "</td>" +
        "<td>" + $('#txtDescDoe').val() + "</td>" +
        "<td>" + $('#txtDataPublicacaoDoeDisposicao').val() + "</td>" +
        "<td>" + $('#txtDataDataRevogacao').val() + "</td>" +
        "<td>" + $('#txtDataDataRetorno').val() + "</td>" +
        "<td style=\"text-align:center\"><button class=\"btn btn-danger delete\"data-toggle=\"tooltip\" data-placement=\"top\" title=\"Clique para remover arquivo\"><span class=\"glyphicon glyphicon-trash\"></span></button></td>"
    );

    //foca no campo
    $('#txtNumeroProcesso').focus();
});

//ADICIONA ITENS AVERBACAO EM UM LISTA PARA DEPOIS ENVIAR PARA BASE DE DADOS
$('#btnSalvarGeral').click(function () {
    //Armazena  valores
    var dadosAverbacao;
    var dadosCedencia;
    var dadosLicenca;

    //Informações gerais de averbação
    var tipoAverbacao;
    var dataAdmissao;
    var dataDemissao;
    var cnpj;
    var orgao;

    //Informações afastamento licenca
    var numeroProcesso;
    var tipoLicenca;
    var doeLicenca;
    var dataInicioLicenca;
    var dataFimLicenca;
    var dataPublicacaoDoeLicenca;
    var dataRevogacaoLicenca;
    var contribuicao;

    //Informações afastamento
    var orgaoRequisitante;
    var nomeFuncao;
    var onus;
    var doeCedencia;
    var dataPublicacaoDoeCedencia;
    var dataRevogacaoCedencia;
    var dataRetornoCedencia;

    // Varrendo itens averbação
    $('.itemAverbacao').each(function () {
        tipoAverbacao = $(this).children()[0].innerText;
        dataAdmissao = $(this).children()[1].innerText;
        dataDemissao = $(this).children()[2].innerText;
        cnpj = $(this).children()[3].innerText;
        orgao = $(this).children()[4].innerText;

        if (dadosAverbacao === null) {
            dadosAverbacao = tipoAverbacao + ";" + dataAdmissao + ";"
                + dataDemissao + ";"
                + cnpj + ";"
                + orgao;
        }
        else {
            //var juntaDadosAverbacao = ";" + tipoAverbacao + ";" + dataAdmissao + ";" + dataDemissao + ";" + cnpj + ";" + orgao
            //dadosAverbacao = dadosAverbacao(juntaDadosAverbacao);
        }
    });

    // Varrendo itens licenca
    $('.itemAfastamentoLicenca').each(function () {
        numeroProcesso = $(this).children()[0].innerText;
        tipoLicenca = $(this).children()[1].innerText;
        doeLicenca = $(this).children()[2].innerText;
        dataInicioLicenca = $(this).children()[3].innerText;
        dataFimLicenca = $(this).children()[4].innerText;
        dataPublicacaoDoeLicenca = $(this).children()[5].innerText;
        dataRevogacaoLicenca = $(this).children()[6].innerText;
        contribuicao = $(this).children()[7].innerText;

        if (dadosLicenca === null) {

            dadosLicenca = numeroProcesso + ";"
                + tipoLicenca
                + ";" + doeLicenca
                + ";" + dataInicioLicenca
                + ";" + dataFimLicenca
                + ";" + dataPublicacaoDoeLicenca
                + ";" + dataRevogacaoLicenca
                + ";" + contribuicao;
        }
        else {
            dadosLicenca = dadosLicenca.concat(";" + numeroProcesso + ";"
                + tipoLicenca
                + ";" + doeLicenca
                + ";" + dataInicioLicenca
                + ";" + dataFimLicenca
                + ";" + dataPublicacaoDoeLicenca
                + ";" + dataRevogacaoLicenca
                + ";" + contribuicao);
        }
    });

    // Varrendo itens cedencia
    $('.itemAfastamentoCedencia').each(function () {
        orgaoRequisitante = $(this).children()[0].innerText;
        nomeFuncao = $(this).children()[1].innerText;
        onus = $(this).children()[2].innerText;

        if (dadosCedencia === null) {
            dadosCedencia = orgaoRequisitante + ";"
                + nomeFuncao + ";"
                + onus + ";"
                + doeCedencia + ";"
                + dataPublicacaoDoeCedencia + ";"
                + dataRevogacaoCedencia + ";"
                + dataRetornoCedencia;
        }
        else {
            dadosCedencia = dadosCedencia.concat(";" + orgaoRequisitante + ";"
                + nomeFuncao + ";"
                + onus + ";"
                + doeCedencia + ";"
                + dataPublicacaoDoeCedencia + ";"
                + dataRevogacaoCedencia + ";"
                + dataRetornoCedencia);
        }
    });

    var dataPosse = $('#txtDataPosse').val();
    var dataEfetivoExercicio = $('#txtDataEfetivoExercicio').val();
    var descMatricula = $('#txtDescMatricula').val();
    var numrIdDoObjetoCargoNumgIdDoObjeto = $('#txtCargo :selected').val();
    var numrFundoPrevidenciarioNumgIdDoObjeto = $('#txtFundoPrevidenciario :selected').val();
    var numrIdDoObjetoOrgaosNumgIdDoObjeto = $('#txtOrgao :selected').val();
    var numrSituacaoFuncionalNumgIdDoObjeto = $('#txtSituacaoFuncional :selected').val();
    var numrSituacaoPrevidenciariaNumgIdDoObjeto = $('#txtNmrSituacaoPrevidenciaria').val();
    var numrVinculoPrevidenciarioNumgIdDoObjeto = $('#txtVinculoPrevidenciario :selected').val();

    //Função ajax para enviar dados para persistir
    $.ajax({
        url: "/PessoaFuncional/Ativo/",
        type: "POST",
        dataType: "json",
        data: {
            DataPosse: dataPosse,
            DataEfetivoExercicio: dataEfetivoExercicio,
            DescMatricula: descMatricula,
            NumrIdDoObjetoCargoNumgIdDoObjeto: numrIdDoObjetoCargoNumgIdDoObjeto,
            NumrFundoPrevidenciarioNumgIdDoObjeto: numrFundoPrevidenciarioNumgIdDoObjeto,
            NumrIdDoObjetoOrgaosNumgIdDoObjeto: numrIdDoObjetoOrgaosNumgIdDoObjeto,
            NumrSituacaoFuncionalNumgIdDoObjeto: numrSituacaoFuncionalNumgIdDoObjeto,
            NumrSituacaoPrevidenciariaNumgIdDoObjeto: numrSituacaoPrevidenciariaNumgIdDoObjeto,
            NumrVinculoPrevidenciarioNumgIdDoObjeto: numrVinculoPrevidenciarioNumgIdDoObjeto,
            DadosAverbacao: dadosAverbacao,
            DadosCedencia: dadosCedencia,
            DadosLicenca: dadosLicenca
        },
        success: function (data) {
            if (data.resultado > 0) {
                window.location.replace("/PessoaFuncional/index");
            }
        },
        error: function (e) {
            alert("Ocorreu uma falha no processo: " + e);
        }
    });
});

//EXIBE INFORMAÇÕES COMPLETAS NA ULTIMA ETAPA APOS CLICAR NO AVANÇAR CEDENCIA
$('#btnAvancarCedencia').click(function () {
    //Funcional
    $('#txtExibirMatricula').text($('#txtDescMatricula').val());
    $('#txtExibirDataPosse').text($('#txtDataPosse').val());
    $('#txtExibirDataEfetivoExercicio').text($('#txtDataEfetivoExercicio').val());
    $('#txtExibirDataExoneracao').text($('#txtDataExoneracao').val());
    $('#txtExibirNomeCargo').text($('#txtCargo :selected').text());
    $('#txtExibirNomeOrgao').text($('#txtOrgao :selected').text());
    $('#txtExibirVinculoPrevidenciario').text($('#txtVinculoPrevidenciario :selected').text());
    $('#txtExibirSituacaoFuncional').text($('#txtSituacaoFuncional :selected').text());
    $('#txtExibirFundoPrevidenciario').text($('#txtFundoPrevidenciario :selected').text());

    //Afastamento
    $('#txtExibirNumeroProcesso').text($('#txtNumeroProcesso').val());
    $('#txtExibirTipoLicenca').text($('#txtTipoLicenca :selected').text());
    $('#txtExibirDoe').text($('#txtDescDoe').val());
    $('#txtExibirDataInicioLicenca').text($('#txtDataInicioLicenca').val());
    $('#txtExibirDataFimLicenca').text($('#txtDataFimLicenca').val());
    $('#txtExibirDataPublicacao').text($('#txtDataPublicacaoDoeLicenca').val());
    $('#txtExibirDataRevogacao').text($('#txtDataDataRevogacao').val());
    $('#txtExibirOptanteporContribuicao').text($('#txtOptanteporContribuicao').val());

    //Cedências
    $('#txtExibirOrgaoRequisitante').text($('#txtOrgaoRequisitante :selected').text());
    $('#txtExibirFuncao').text($('#txtFuncao').val());
    $('#txtExibirTipoOnus').text($('#txtEnumTipoOnus :selected').text());
    $('#txtExibirDoeCedencia').text($('#txtDescDoe').val());
    $('#txtExibirDataPublicacaoCedencia').text($('#txtDataPublicacaoDoeDisposicao').val());
    $('#txtExibirDataRevogacaoCedencia').text($('#txtDataDataRevogacao').val());
    $('#txtExibirDataRetornoCedencia').text($('#txtDataDataRetorno').val());
});

//AUTO COMPLETE ORGÃOS
$(function () {
    $("#txtOrgao,#txtOrgaoRequisitante").customselect({
        "search": true, // É pesquisavel?
        "searchblank": false,// pesquisar opções de valor em branco?
        "showblank": false, // Mostrar opções de valor em branco?
        "hoveropen": false,// Caneta a seleção ao passar o mouse?
        "showdisabled": true,// Mostrar opções desativadas?
    });
});

$('#radioAbonoSIM').click(function () {
    $('#txtDataAbono').prop('disabled', false);
    $('#txtDataAbono').focus();
});

$('#radioAbonoNAO').click(function () {
    $('#txtDataAbono').prop('disabled', true);
});

//CARREGA CARGO DE ACORDO COM O ORGÃO SELECIONADO
$(function () {
    $("#txtOrgao").change(function () {
        $.ajax({
            dataType: "json",
            type: "GET",
            url: "/PessoaFuncional/ObterCargosPorOrgaoID/?id=" + $("#txtOrgao").val(),
            success:
                function (dados) {
                    $("#txtCargo").empty().append("<option> -- Selecione opção -- </option>");
                    $("#txtCargo").focus();
                    $(dados).each(function (i) {
                        $("#txtCargo").append('<option value="' + dados[i].value + '">' + dados[i].text + '</option>');
                    });
                }
        });
    });
});


//Initialize tooltips
$('.nav-tabs > li a[title]').tooltip();

//Wizard
$('a[data-toggle="tab"]').on('show.bs.tab', function (e) {

    var $target = $(e.target);

    if ($target.parent().hasClass('disabled')) {
        return false;
    }
});

$(".next-step").click(function (e) {

    var $active = $('.wizard .nav-tabs li.active');
    $active.next().removeClass('disabled');
    nextTab($active);

});
$(".prev-step").click(function (e) {

    var $active = $('.wizard .nav-tabs li.active');
    prevTab($active);

});

function nextTab(elem) {
    $(elem).next().find('a[data-toggle="tab"]').click();
}

function prevTab(elem) {
    $(elem).prev().find('a[data-toggle="tab"]').click();
}