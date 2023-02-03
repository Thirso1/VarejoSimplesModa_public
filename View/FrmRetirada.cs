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
    public partial class Retirada : Form
    {
        private double gaveta, valorDouble;
        private string descricao, valor;
        private Usuario gerente;
        private Usuario opereador;
        private TiposMovimentacao tiposMovimentacao;
        private IFluxoCaixaRepository _fluxoCaixaRepository = new FluxoCaixaRepository();

        public Retirada(Usuario gerente, Usuario operador)
        {
            this.gerente = gerente;
            this.opereador = operador;
            InitializeComponent();
        }

        private void cmbDescricao_Leave(object sender, EventArgs e)
        {
          
        }

        private void FrmRetirada_Load(object sender, EventArgs e)
        {
            //login usuario = new login();
            //nomeUsuario = usuario.getNome;
            cmbUsuario.Text = gerente.Nome;
            textEspecificar.Enabled = false;
            //
            //
            //Caixa gaveta = new Caixa();
            gaveta = _fluxoCaixaRepository.SaldoGaveta();
            textGaveta.Text = gaveta.ToString("N2");
            textValRetirada.Select();
            
        }

        private void cmbDescricao_SelectedIndexChanged(object sender, EventArgs e)
        {
            processaOpcoes();
        }

        private void textValRetirada_KeyUp(object sender, KeyEventArgs e)
        {
            if (textValRetirada.Text.Length > 2)
            {
                try
                {
                    string valor = MascaraDecimal.mascara(textValRetirada.Text);
                    textValRetirada.Text = valor.ToString();
                    textValRetirada.SelectionStart = textValRetirada.Text.Length + 1;
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.ToString());
                }
            }
        }

        private void FrmRetirada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textValRetirada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void processaOpcoes()
        {
            switch (cmbDescricao.Text)
            {
                case "Fornecedor":
                    tiposMovimentacao = TiposMovimentacao.SaidaFornecedor;
                    textEspecificar.Enabled = true;
                    textEspecificar.Select();
                    break;
                case "Retirada Numerário":
                    tiposMovimentacao = TiposMovimentacao.RetiradaDinheiro;
                    textEspecificar.Enabled = false;
                    descricao = cmbDescricao.Text;
                    break;
                case "outros":
                    tiposMovimentacao = TiposMovimentacao.SaidaOutros;
                    textEspecificar.Enabled = true;
                    textEspecificar.Select();
                    break;
            }
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {

            if (cmbDescricao.Text == "" || textValRetirada.Text == "")
            {
                MessageBox.Show("preencha todos os campos");
            }
            else
            {
                valorDouble = Convert.ToDouble(textValRetirada.Text);
                //CaixaStatus gaveta_form = new CaixaStatus();
                //decimal gaveta_dec = gaveta_form.gaveta;
                //MessageBox.Show("dentro de gaveta "+gaveta_dec.ToString());
                processaOpcoes();



                if (tiposMovimentacao == TiposMovimentacao.RetiradaDinheiro && opereador.TipoUsuario == TipoUsuario.Funcionario)
                {
                    MessageBox.Show("Usuario não autorizado a fazer esse tipo de retirada!");
                }
                else if (tiposMovimentacao == TiposMovimentacao.SaidaOutros && textEspecificar.Text == "")
                {
                    MessageBox.Show("Preencha o campo \"Especificar!\"");
                }
                else if (tiposMovimentacao == TiposMovimentacao.SaidaFornecedor && textEspecificar.Text == "")
                {
                    MessageBox.Show("Preencha o campo \"Especificar!\"");
                }
                else
                {
                    if (gaveta < valorDouble)
                    {
                        MessageBox.Show("Não há saldo disponível na gaveta!");
                    }
                    else
                    {
                          if(tiposMovimentacao == TiposMovimentacao.SaidaOutros || tiposMovimentacao == TiposMovimentacao.SaidaFornecedor)
                        {
                            descricao = textEspecificar.Text;
                        }
                        DialogResult result1 = MessageBox.Show("CONFIRMA RETIRADA DE " + valor, "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result1.Equals(DialogResult.OK))
                        {
                            try
                            {
                                FluxoCaixa fluxoCaixa = new FluxoCaixa(0, tiposMovimentacao, descricao, FormaPagamento.Dinheiro, 0, valorDouble, gerente.Nome, opereador.Nome);
                                _fluxoCaixaRepository.Cadastrar(fluxoCaixa);
                                MessageBox.Show("Retirada concluída!");
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
        }
    }
}
