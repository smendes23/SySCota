
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace SysCota.Models
{
    public class Cotacao
    {
        public int Id { get; set; }

        [DisplayName("Nº da Cotação")]
        public int NumeroDaCotacao { get; set; }

        [DisplayName("Data da Cotação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataCotacao { get; set; }

        [DisplayName("Data Entrega da Cotação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataEntregaCotacao { get; set; }

        public ICollection<Item> Itens { get; set; }

        public Cliente Cliente { get; set; }
        public int ClienteId { get; set;}

        public Fornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }

    }
}
