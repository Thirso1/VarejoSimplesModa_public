using VarejoSimplesModa.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Model
{
    public class FluxoCaixa
    {
        public int Id { get; set; }
        public int Num_referencia { get; set; }

        public TiposMovimentacao TiposMovimentacao { get; set; }

        public string Descricao { get; set; }

        public FormaPagamento FormaPagamento { get; set; }

        public double Entrada { get; set; }

        public double Saida { get; set; }

        public string Gerente { get; set; }
        public string Operador { get; set; }

        public FluxoCaixa(int num_referencia, TiposMovimentacao tiposMovimentacao, string descricao, FormaPagamento formaPagamento, double entrada, double saida, string usuario, string operador)
        {
            this.Num_referencia = num_referencia;
            this.TiposMovimentacao = tiposMovimentacao;
            this.Descricao = descricao;
            this.FormaPagamento = formaPagamento;
            this.Entrada = entrada;
            this.Saida = saida;
            this.Gerente = usuario;
            this.Operador = operador;
        }
    }
}
