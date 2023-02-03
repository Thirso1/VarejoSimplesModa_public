using MySql.Data.MySqlClient;
using VarejoSimplesModa.Pagamento;
using VarejoSimplesModa.Banco;
using VarejoSimplesModa.Enums;
using VarejoSimplesModa.Library;
using VarejoSimplesModa.Model;
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
    public partial class FrmTroco : Form
    {
        private TiposForms tiposForm;
        private double valor;
        private double dinheiro;
        private double desconto = 0;
        private double valorComDesconto;
        private double troco;

        public FrmTroco(Double valor, TiposForms tiposForm)
        {
            InitializeComponent();
            this.texdinheiro.Focus();
            this.texdinheiro.Select();
            this.valor = valor;
            this.tiposForm = tiposForm;
        }

        private void FrmTroco_Load(object sender, EventArgs e)
        {
            //total = Total_Itens.valorPedido(idPedido);
            textTotal.Text = valor.ToString("N2");
            textDesconto.Text = "0,00";
        }

   


        private void texdinheiro_KeyUp(object sender, KeyEventArgs e)
        {
            if (texdinheiro.Text.Length > 2)
            {
                try
                {
                    string valor = MascaraDecimal.mascara(texdinheiro.Text);
                    texdinheiro.Text = valor.ToString();
                    texdinheiro.SelectionStart = texdinheiro.Text.Length + 1;
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.ToString());
                }
            }
        }

        private void FrmTroco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27)) //ESC
            {
                this.Close();
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private bool valicacaoDinheiro()
        {
            if (texdinheiro.Text == "" || texdinheiro.Text == "0" || texdinheiro.Text == "0,00")
            {
                MessageBox.Show("Preencha o campo dinheiro!");
                return false;
            }
            else
            {
                dinheiro = Convert.ToDouble(texdinheiro.Text);
                return true;
            }
        }

        private void valicacaoDesconto()
        {
            if (textDesconto.Text == "")
            {
                desconto = 0;
            }
            else if (textDesconto.Text != "")
            {
                desconto = Convert.ToDouble(textDesconto.Text);
            }
        }


        private void texdinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!valicacaoDinheiro())
                {
                    MessageBox.Show("Preencha o valor");
                }
                else
                {
                    troco = dinheiro - valor;

                    if (troco >= 0)
                    {
                        textDesconto.Text = "0,00";
                        textroco.Text = troco.ToString("N2");
                        btnConfirma.Select();
                    }
                    else if (troco < 0)
                    {
                        DialogResult result1 = MessageBox.Show("DESEJA CONCEDER DESCONT DE " + troco.ToString("N2") + "?", "Cancela", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                        if (result1.Equals(DialogResult.Yes))
                        {
                            desconto = Math.Abs(troco); ;
                            textroco.Text = "0,00";
                            textDesconto.Text = troco.ToString("N2");
                            btnConfirma.Select();
                        }
                    }
                }
            }              
        }
   


        private void textDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }

            if (e.KeyChar == 13)
                if (valicacaoDinheiro())
                {
                    valicacaoDesconto();

                    btnConfirma.Select();
                }
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if (valicacaoDinheiro())
            {
                try
                {
                    switch (tiposForm)
                    {
                        //significa que esta tela de mensagens foi chamada pelo PDV(pode ser uma confirmação de pagamento)
                        case TiposForms.Pdv:
                            Pdv pdv = Pdv.Instance;
                            pdv.PagamentoConfirmado = true;
                            pdv.desconto = desconto;
                            break;
                        case TiposForms.Crediario:
                            //significa que esta tela de mensagens foi chamada pelo FrmCrediarioCliente()
                            FrmCrediarioCliente.pagamentoConfirmado = true;
                            break;
                    }

                    this.Close();
                }

                catch (Exception erro)
                {
                    MessageBox.Show(erro.ToString());
                }
            }
        }

        private void texdinheiro_Enter(object sender, EventArgs e)
        {
            texdinheiro.BackColor = Color.Yellow;
        }

        private void texdinheiro_Leave(object sender, EventArgs e)
        {
            texdinheiro.BackColor = Color.White;
        }
    }
}