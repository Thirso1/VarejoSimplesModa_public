using VarejoSimplesModa.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Model
{
    public class Pedido
    {
        [Key()]
        public int Id { get; set; }
        public int NumVendaDoDia { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public double Valor { get; set; }
        public double Desconto { get; set; }
        public int Comanda { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public StatusPedido StatusPedido { get; set; }
        public DateTime DataHora { get; set; }
    }
}
