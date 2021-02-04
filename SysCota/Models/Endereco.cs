using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SysCota.Models
{
    public class Endereco
    {
        public int Id { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        public string Cep { get; set; }

        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }

        [DisplayName("Complemento")]
        public string Complemento { get; set; }

        [DisplayName("Bairro")]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [DisplayName("Uf")]
        public string Uf { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }

        public Empresa Empresa { get; set; }

        public int EmpresaId { get; set; }
    }
}
