using VarejoSimplesModa.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Model
{
    public class Crediario
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdPedido { get; set; }
        public DescricaoCrediario DescricaoCrediario { get; set; }
        public double Debito { get; set; }
        public double Credito { get; set; }

        public Crediario()
        {

        }

        public Crediario(int IdCliente, int IdPedido, DescricaoCrediario Descricao, double Debito, double Credito)
        {
            this.IdCliente = IdCliente;
            this.IdPedido = IdPedido;
            this.Debito = Debito;
            this.Credito = Credito;
            this.DescricaoCrediario = Descricao;
        }
    }
}
