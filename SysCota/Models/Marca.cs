using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SysCota.Models
{
    public class Marca
    {
        public int Id { get; set; }
        [DisplayName("Marca")]
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
