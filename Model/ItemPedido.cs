using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Model
{
    public class ItemPedido
    {
        [Key()]
        public int Id { get; set; }

        public string Nome { get; set; }

        public double Preco { get; set; }

        public double Desconto { get; set; }

        public double Qtde { get; set; }

        public double SubTotal { get; set; }

        public int PedidoId { get; set; }

        public int ProdutoId { get; set; }

        public ItemPedido(int pedidoId, int produtoId, string Nome, double Preco, double qtde, double desconto)
        {
            this.PedidoId = pedidoId;
            this.ProdutoId = produtoId;
            this.Nome = Nome;
            this.Preco = Preco;
            this.Qtde = qtde;
            this.Desconto = desconto;
            this.SubTotal = qtde * Preco;
        }
    }
}
