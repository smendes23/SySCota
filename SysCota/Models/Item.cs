using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SysCota.Models
{
    public class Item
    {
        public int Id { get; set; }

        [DisplayName("Nº do Item")]
        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        public long NumeroItem { get; set; }

        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        public int Quantidade { get; set; }

        public Cotacao Cotar { get; set; }

        public int CotarId { get; set; }

        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }
        //Colocar Preço

    }
}
