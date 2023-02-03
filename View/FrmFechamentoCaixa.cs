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
    public partial class FrmFechamentoCaixa : Form
    {
        private IFluxoCaixaRepository _fluxoCaixaRepository = new FluxoCaixaRepository();
        private IUsuarioRepository _usuarioRepository = new UsuarioRepository();
        private ICaixaRepository caixaRepository = new CaixaRepository();
        private Caixa caixa = new Caixa();
        private Login login = null;
        private List<double> valores = new List<double>();
        private double saldoDinheiro = 0;
        public static bool ConfirmacaoMensagem = false;

        public FrmFechamentoCaixa()
        {
            InitializeComponent();
        }

        private void FrmFechamentoCaixa_Load(object sender, EventArgs e)
        {
            login = Login.Instance;
            if (!login.Logado)
            {
                Application.Exit();
            }
            caixa = caixaRepository.ObterCaixa();

            txtUsuario.Text = login.Usuario.Nome;
            //txtRecolherDinheiro.Select();
            txtRecolherDinheiro.SelectionStart = txtRecolherDinheiro.Text.Length + 1;

            txtOperadorCaixa.Text = caixa.operador.Nome.ToString();

            valores = _fluxoCaixaRepository.ObterValoresParciais();

            //gaveta
            double saldoAbertura = valores[0];
            double entradasDinheiro = valores[14];
            double saidasDinheiro = valores[8];
            double cartao = valores[2];
            double pix = valores[4];
            saldoDinheiro = valores[21] - valores[8];


            txtEntradaDinheiro.Text = entradasDinheiro.ToString("C2");
            txtEntradaCartao.Text = cartao.ToString("C2");
            txtEntradaPix.Text = pix.ToString("C2");
            txtEntradaCheque.Text = "R$0,00";


            txtSaidaDinheiro.Text = saidasDinheiro.ToString("C2");
            txtSaidaCheques.Text = "R$0,00";


            txtSaldoCheque.Text = "R$0,00";
            txtSaldoDinheiro.Text = saldoDinheiro.ToString("C2");
            txtRecolherCheques.Text = "0,00";
            txtRecolherDinheiro.Text = saldoDinheiro.ToString("N2");


        }

        private void txtRecolherDinheiro_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtRecolherDinheiro.Text.Length > 2)
            {
                string valor = MascaraDecimal.mascara(txtRecolherDinheiro.Text);
                txtRecolherDinheiro.Text = valor.ToString();
                txtRecolherDinheiro.SelectionStart = txtRecolherDinheiro.Text.Length + 1;
            }
        }

        private void txtRecolherDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //too nao permitir digitar nos campos dinheiro e desconto e troco
            //evita duas virgulas no campo
            if ((Char.IsLetter(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                txtRecolherDinheiro.Text = "";
            }

            if (e.KeyChar == 13)
            {
                DialogResult result0 = MessageBox.Show("Confirma Fechamento?", "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result0.Equals(DialogResult.OK))
                {
                    fechar();
                }
            }
        }

        private void fechar()
        {
            if (txtRecolherDinheiro.Text == "")
            {
                MessageBox.Show("Preencha um Valor!");
                txtRecolherDinheiro.Select();
            }
            else
            {
                double recolher = Convert.ToDouble(txtRecolherDinheiro.Text);

                if (recolher > saldoDinheiro)
                {
                    MessageBox.Show("Valor maior que o Saldo!");
                    txtRecolherDinheiro.Text = saldoDinheiro.ToString("N2");
                }
                else if (recolher == saldoDinheiro)
                {
                    //lançar no fluxo de caixa
                    FluxoCaixa fluxoCaixa = new FluxoCaixa(0, Enums.TiposMovimentacao.FechamentoCaixa, "Fechamento de Caixa", Enums.FormaPagamento.Dinheiro, 0, recolher, caixa.gerente.Nome, caixa.operador.Nome);
                    _fluxoCaixaRepository.Cadastrar(fluxoCaixa);

                    //atualizar o status do caixa para fechado 
                    caixa.Aberto = false;
                    caixa.DataHoraFechamento = DateTime.Now;
                    caixa.fundoCaixa = 0;

                    caixaRepository.Atualizar(caixa);
                    MessageBox.Show("Caixa fechado com Sucesso!");
                    this.Close();
                }
                else if (recolher < saldoDinheiro)
                {
                    string msg1 = "Fundo de caixa: "+ (saldoDinheiro - recolher).ToString("N2");
                    string msg2 = "Deseja manter?";
                    FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.Fechamento);
                    frmMensagens.ShowDialog();
                    if (ConfirmacaoMensagem)
                    {
                        //lançar no fluxo de caixa
                        FluxoCaixa fluxoCaixa = new FluxoCaixa(0, Enums.TiposMovimentacao.FechamentoCaixa, "Fechamento de Caixa", Enums.FormaPagamento.Dinheiro, 0, recolher, caixa.gerente.Nome, caixa.operador.Nome);
                        _fluxoCaixaRepository.Cadastrar(fluxoCaixa);

                        //atualizar o status do caixa para fechado 
                        caixa.Aberto = false;
                        caixa.DataHoraFechamento = DateTime.Now;
                        caixa.fundoCaixa = saldoDinheiro - recolher;

                        caixaRepository.Atualizar(caixa);
                        MessageBox.Show("Caixa fechado com Sucesso!");
                        this.Close();
                    }

                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult result0 = MessageBox.Show("Confirma Fechamento?", "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result0.Equals(DialogResult.OK))
            {
                fechar();
            }
        }

        private void FrmFechamentoCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }
        }
    }
}
