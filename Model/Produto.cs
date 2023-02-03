using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VarejoSimplesModa.Model
{
    public class Produto
    {
        [Key()]
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public int CodigoBarrasBalanca { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double PrecoCusto { get; set; }
        public double PrecoVenda { get; set; }
        public double MargemLucro { get; set; }
        public double Desconto { get; set; }
        public string Imagem { get; set; }
        public int EstoqueAtual { get; set; }
        public int EstoqueMin { get; set; }
        public int EstoqueMax { get; set; }
        public string UnidVenda { get; set; }
        public int CategoriaId { get; set; }
    }
}