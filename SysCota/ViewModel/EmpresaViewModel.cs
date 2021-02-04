using SysCota.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SysCota.ViewModel
{
    public class EmpresaViewModel
    {

        public int Id { get; set; }

        [DisplayName("CNPJ")]
        [DataType(DataType.Text, ErrorMessage = "CNPJ é obrigatório.")]
        public string CNPJ { get; set; }

        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; }

        [DisplayName("Fornecedor?")]
        public Boolean IsFornecedor { get; set; }
        public Endereco EnderecoNavigation { get; set; }
    }
}
