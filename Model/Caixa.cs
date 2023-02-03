using VarejoSimplesModa.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Model
{
    public class Caixa
    {
        public int Id { get; set; }
        public DateTime DataHoraAbertura { get; set; }
        public DateTime DataHoraFechamento { get; set; }
        public bool Aberto { get; set; }
        public Usuario gerente{ get; set; }
        public Usuario operador { get; set; }
        public double fundoCaixa { get; set; }


        //public double VendasDinheiro { get; set; }
        //public double VendasCartao { get; set; }
        //public double VendasPrazo { get; set; }
        //public double VendasPix { get; set; }
        //public double TotalDescontos { get; set; }
        //public double TotalEntradas { get; set; }
        //public double TotalSaidas { get; set; }
        //public double TotalGaveta { get; set; }


        //public Caixa(int Id, DateTime DataHoraAbertura, DateTime DataHoraFechamento, bool Aberto)
        //{
        //    this.Id = Id;
        //    this.DataHoraAbertura = DataHoraAbertura;
        //    this.DataHoraFechamento = DataHoraFechamento;
        //    this.Aberto = Aberto;
        //}

    }
}
