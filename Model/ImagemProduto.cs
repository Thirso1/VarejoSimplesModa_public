using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Model
{
    public class ImagemProduto
    {
        [Key()]
        public int Id { get; set; }
        public string CaminhoImagem { get; set; }
        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }
    }
}
