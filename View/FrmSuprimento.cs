using VarejoSimplesModa.Enums;
using VarejoSimplesModa.Library;
using VarejoSimplesModa.Model;
using VarejoSimplesModa.Repository;
using VarejoSimplesModa.Repository.RepositoryInterfaces;
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
    public partial class FrmSuprimento : Form
    {
        Usuario gerente;
        Usuario operador;
        IFluxoCaixaRepository _fluxoCaixaRepository = new FluxoCaixaRepository();
        public FrmSuprimento(Usuario gerente,Usuario operador)
        {
            this.gerente = gerente;
            this.operador = operador;
            InitializeComponent();
        }

        private void textValRetirada_KeyUp(object sender, KeyEventArgs e)
        {
            if (textValor.Text.Length > 2)
            {
                try
                {
                    string valor = MascaraDecimal.mascara(textValor.Text);
                    textValor.Text = valor.ToString();
                    textValor.SelectionStart = textValor.Text.Length + 1;
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.ToString());
                }
            }
        }

        private void textValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void FrmSuprimento_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            double valorDouble = Convert.ToDouble(textValor.Text);

            DialogResult result1 = MessageBox.Show("CONFIRMA SUPRIMENTO DE " + valorDouble, "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result1.Equals(DialogResult.OK))
            {
                try
                {
                    FluxoCaixa fluxoCaixa = new FluxoCaixa(0, Enums.TiposMovimentacao.SuprimentoDinheiro, Enums.TiposMovimentacao.SuprimentoDinheiro.ToString(), FormaPagamento.Dinheiro, valorDouble, 0, gerente.Nome, operador.Nome);
                    _fluxoCaixaRepository.Cadastrar(fluxoCaixa);
                    MessageBox.Show("Suprimento concluído!");
                    this.Close();
                }

                catch (Exception erro)
                {
                    string teste = erro.ToString();
                    MessageBox.Show(teste);
                }
            }
        }
    }
}
