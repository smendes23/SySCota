using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SysCota.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [DisplayName("CNPJ")]
        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        public string CNPJ { get; set; }

        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; }

        [DisplayName("Fornecedor?")]
        public Boolean IsFornecedor { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
