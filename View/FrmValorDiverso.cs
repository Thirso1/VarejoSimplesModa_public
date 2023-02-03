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
    public partial class FrmValorDiverso : Form
    {
        private Pdv pdv;
        public FrmValorDiverso()
        {
            InitializeComponent();
        }
        private void FrmValorDiverso_Load(object sender, EventArgs e)
        {
            pdv = Pdv.Instance;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text.Length > 2)
            {
                try
                {
                    string valor = MascaraDecimal.mascara(textBox1.Text);
                    textBox1.Text = valor.ToString();
                    textBox1.SelectionStart = textBox1.Text.Length + 1;
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.ToString());
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                textBox1.Text = "";
            }
            //ao clicar na tecla ENTER
            if (e.KeyChar == 13)
            {
                if (textBox1.Text != "" && textBox1.Text != "0" && textBox1.Text != "0,00")
                {
                    double valor = Convert.ToDouble(textBox1.Text);
                    Produto produto = new Produto();
                    produto.Id = 9999999;
                    produto.Nome = "Diversos";
                    produto.PrecoVenda = valor;
                    pdv.montaItemPedido(produto, produto.PrecoVenda, 1);
                    this.Close();
                }
            }
        }

        private void FrmValorDiverso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }
        }
    }
}
