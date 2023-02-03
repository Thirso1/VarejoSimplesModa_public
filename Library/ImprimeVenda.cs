using VarejoSimplesModa.Model;
using VarejoSimplesModa.Repository;
using VarejoSimplesModa.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vip.Printer;
using Vip.Printer.Enums;

namespace VarejoSimplesModa.Library
{
    public class ImprimeVenda
    {
        private IPedidoRepository _pedidoRepository = new PedidoRepository();
        private IItemPedidoRepository _itemPedidoRepository = new ItemPedidoRepository();
        private ICaixaRepository _caixa = new CaixaRepository();

        private Caixa caixa;
        private Pedido pedido;
        private int idPedido;

        public ImprimeVenda(int idPedido)
        {
            this.idPedido = idPedido;
        }

        public void imprimeVenda()
        {
            //todo - terminar impressao recibo
            caixa = _caixa.ObterCaixa();
            pedido = _pedidoRepository.ObterPedido(idPedido);
            DataTable itens = _itemPedidoRepository.ConsultaTodos(idPedido);
            FormataTxtProdutos formataProdutos = new FormataTxtProdutos();
            string total = pedido.Valor.ToString("N2");

            //string nomeEmpresa = "Venda N° \r\n";
            Console.WriteLine(pedido.DataHora.ToString());
            string data = pedido.DataHora.ToString().Substring(0, 10);
            string hora = pedido.DataHora.ToString().Substring(11,8);

            string empresa =    "              Panificadora Avenida              \r\n";
            string cnpj =       "CNPJ: 24.725.357/0001-03 \r\n";
            string endereco_1 = "Av. Domingos João Guerra, 102 - Centro\r\n";
            string endereco_2 = "37973-000 - Itamogi - MG\r\n";
            string telefone =   "(35)9 9841-0706\r\n";
            string operador =   "Operador: " + caixa.operador.Nome + "\r\n";
            //linha
            string tituloPedido = "                   Pedido N° "+ pedido.NumVendaDoDia +"\r\n";
            //linha
            string dataHora =    "MOV. "+data+ "                 HORA:"+hora+"\r\n";
            string cliente = "Cliente: Consumidor\r\n";
            var linhaProdutos = "--------------------PRODUTOS--------------------\r\n";       
            var head = "Item Produto                 Valor  Qtde  SubTot\r\n";

            var linhaPagamento = "-------------------PAGAMENTO--------------------\r\n";       
            var linhaTotal =     "Total do Pedido:                     "+total+ "\r\n";
            var formaPagamento = "Forma de Pagamento:           "+pedido.FormaPagamento+"\r\n";

            string quebra = "\r\n";
            var linha =          "------------------------------------------------\r\n";
            string valorFiscal = "   ***Este ticket não é um documento fiscal***  \r\n";
            string agradecimento = "             VOLTE SEMPRE OBRIGADO!             \r\n";


            var itensStr = "";
            for (int i = 0; i < itens.Rows.Count; i++)
            {
                double valor = Convert.ToDouble( itens.Rows[i][4]);
                //double desconto = Convert.ToDouble( itens.Rows[i][6]);
                double totalItem = Convert.ToDouble( itens.Rows[i][7]);

                itensStr +=
                      formataProdutos.formataItem((i + 1).ToString()) + " " 
                    + formataProdutos.formataNomeVenda(itens.Rows[i][3].ToString())+" "
                    + formataProdutos.formataPrecoVenda(valor.ToString("N2")) + " "
                    + formataProdutos.formataQtde(itens.Rows[i][5].ToString()) + " "
                    //+ desconto.ToString("N2") + " "
                    + formataProdutos.formataPrecoVenda(totalItem.ToString("N2")) + "\r\n";
            }
            //passo 1 - criar impressora generica no windows (porta LPT1) com nome de: "Generic"
            //passo 2 - instalar impressora termica na porta COM1
            //passo 3 - direcionar impressora termica da porta COM1 para porta COM2 no gerenciador de dispositivos 
            //passo 4 - comando: MODE LPT1 = COM1 
            var printer = new Printer("GenericLPT2", PrinterType.Daruma);


            MessageBox.Show(empresa + quebra + cnpj + dataHora + endereco_1 + endereco_2 + telefone + operador + linha + tituloPedido + linha + dataHora + cliente + linhaProdutos + head + linha + itensStr + linhaPagamento + linhaTotal + formaPagamento + quebra + valorFiscal + quebra + agradecimento);
            printer.WriteLine(empresa + quebra + cnpj + dataHora + endereco_1 + endereco_2 + telefone + operador + linha + tituloPedido + linha + dataHora + cliente + linhaProdutos + head + linha + itensStr + linhaPagamento + linhaTotal + formaPagamento + quebra + valorFiscal + quebra + agradecimento + quebra + quebra + quebra);
            printer.PartialPaperCut();
            printer.PrintDocument();
        }
    }
}
