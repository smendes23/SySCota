using SysCota.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SysCota.ViewModel
{
    public class ProdutoViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório!")]

        [DisplayName("Produto")]
        public string Descricao { get; set; }

        [DisplayName("Preço")]
        public decimal Preco { get; set; }
        public  Marca MarcaNavigator { get; set; }
        public  Unidade UnidadeNavigator { get; set; }
    }
}
