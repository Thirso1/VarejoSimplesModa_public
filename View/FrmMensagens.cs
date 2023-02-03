using VarejoSimplesModa.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VarejoSimplesModa.View
{
    public partial class FrmMensagens : Form
    {
        private string _msg1;
        private string _msg2;
        private TiposMensagens _tiposMensagens;
        private TiposForms _tiposForm;

        public FrmMensagens(TiposMensagens tiposMensagens, string msg1, string msg2, TiposForms tiposForm)
        {
            InitializeComponent();
            _tiposMensagens = tiposMensagens;
            _tiposForm = tiposForm;
            _msg1 = msg1;
            _msg2 = msg2;
        }

        private void FrmMensagens_Load(object sender, EventArgs e)
        {
            textBox1.Text = _msg1;
            textBox2.Text = _msg2;

            switch (_tiposMensagens)
            {
                case TiposMensagens.Ok:
                    btnSim.Text = "Ok";
                    btnSim.Visible = true;
                    btnNao.Visible = false;
                    btnSim.Location = new System.Drawing.Point(296, 256);
                    btnSim.Select();
                    break;
                case TiposMensagens.SimNao:
                case TiposMensagens.CancelarPedido:
                case TiposMensagens.FinalizarPedido:
                    btnSim.Visible = true;
                    btnNao.Visible = true;
                    btnSim.Select();
                    break;
            }
            if (_msg2 == "")
            {
                textBox1.Location = new System.Drawing.Point(12, 137);
            }
        }

        private void btnSim_Click(object sender, EventArgs e)
        {
            ProcessaDecisao(true);
            this.Close();
        }

        private void btnNão_Click(object sender, EventArgs e)
        {
            ProcessaDecisao(false);
            this.Close();
        }

        private void ProcessaDecisao(bool decisao)
        {
            if (decisao == true)
            {
                switch (_tiposForm)
                {
                    //significa que esta tela de mensagens foi chamada pelo PDV(pode ser uma confirmação de pagamento)
                    case TiposForms.Pdv:
                        Pdv pdv = Pdv.Instance;
                        pdv.ConfirmacaoMensagem = true;
                        break;
                    case TiposForms.Principal:
                        //significa que esta tela de mensagens foi chamada pelo Form1(pode ser de abertura de caixa)
                        Principal.ConfirmacaoMensagem = true;
                        break;
                    case TiposForms.BuscaCliente:
                        //significa que esta tela de mensagens foi chamada pelo busca cliente
                        FrmConsultaCliente.ConfirmacaoMensagem = true;
                        break;
                    case TiposForms.Crediario:
                        //significa que esta tela de mensagens foi chamada pelo Crediario
                        FrmCrediarioCliente.ConfirmacaoMensagem = true;
                        break;
                    case TiposForms.Fechamento:
                        //significa que esta tela de mensagens foi chamada pelo Fechamento de caixa
                        FrmFechamentoCaixa.ConfirmacaoMensagem = true;
                        break;
                    case TiposForms.FrmDetalhesFluxoCaixa:
                        //significa que esta tela de mensagens foi chamada pelo Fechamento de caixa
                        FrmDetalhesFluxoCaixa.ConfirmacaoMensagem = true;
                        break;
                    case TiposForms.FrmDetalhesRelatorioVendas:
                        //significa que esta tela de mensagens foi chamada pelo Fechamento de caixa
                        FrmDetalhesRelatorioVendas.ConfirmacaoMensagem = true;
                        break;
                }
            }

            if (decisao == false)
            {
                switch (_tiposForm)
                {
                    case TiposForms.Pdv:
                        Pdv pdv = Pdv.Instance;
                        pdv.ConfirmacaoMensagem = false;
                        break;
                    case TiposForms.Principal:
                        Principal.ConfirmacaoMensagem = false;
                        break;
                    case TiposForms.BuscaCliente:
                        //significa que esta tela de mensagens foi chamada pelo Form1(pode ser de abertura de caixa)
                        FrmConsultaCliente.ConfirmacaoMensagem = false;
                        break;
                    case TiposForms.Crediario:
                        //significa que esta tela de mensagens foi chamada pelo Form1(pode ser de abertura de caixa)
                        FrmCrediarioCliente.ConfirmacaoMensagem = false;
                        break;
                }
            }
        }
    }
}
