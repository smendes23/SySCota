using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SysCota.Models
{
    public class Produto
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório!")]

        [DisplayName("Produto")]
        public string Descricao { get; set; }

        [DisplayName("Preço")]
        public decimal Preco { get; set; }
        public virtual Marca Marca { get; set; }
        public int MarcaId { get; set; }
        public virtual Unidade Unidade { get; set; }
        public int UnidadeId { get; set; }

    }
}
