using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VarejoSimplesModa.Enums;
using VarejoSimplesModa.Library;
using VarejoSimplesModa.Model;
using VarejoSimplesModa.Repository;
using VarejoSimplesModa.Repository.RepositoryInterfaces;

namespace VarejoSimplesModa.View
{
    public partial class FrmAberturaCaixa : Form
    {
        private IFluxoCaixaRepository _fluxoCaixaRepository = new FluxoCaixaRepository();
        private ICaixaRepository _caixaRepository = new CaixaRepository();
        private IUsuarioRepository _usuarioRepository = new UsuarioRepository();
        private double fundoCaixa = 0;
        private Login login;

        public FrmAberturaCaixa(double fundoCaixa)
        {
            InitializeComponent();
            this.fundoCaixa = fundoCaixa;
        }

        private void FrmAberturaCaixa_Load(object sender, EventArgs e)
        {
            pnSenhaOperador.Visible = false;
            Inicial.Select();
            login = Login.Instance;
            if (!login.Logado)
            {
                Application.Exit();
            }

            txtGerente.Text = login.Usuario.Nome;
            loadOperadorCaixa();
            txtFundoCaixa.Text = fundoCaixa.ToString("N2");
            txtTotalAbertura.Text = fundoCaixa.ToString("N2");
            if (fundoCaixa > 0)
            {
                FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.Ok, "Existe Fundo de Caixa.", "Valor: " + fundoCaixa.ToString("N2"), TiposForms.Abertura);
                frmMensagens.ShowDialog();
            }
            cbOperadorCaixa.SelectedIndex = 0;
        }

        private void loadOperadorCaixa()
        {
            DataTable dtUsuarios;
            dtUsuarios = _usuarioRepository.ObterUsuarios();
            if (dtUsuarios != null)
            {
                //Carrrega itens do DataTable para a ComboBox
                for (int i = 0; i < dtUsuarios.Rows.Count; i++)
                {
                    cbOperadorCaixa.Items.Add(dtUsuarios.Rows[i]["nome"].ToString());
                }
            }
            //cbOperadorCaixa.SelectedIndex = 0;
        }

        private void Inicial_KeyUp(object sender, KeyEventArgs e)
        {
            if (Inicial.Text.Length > 2)
            {
                string valor = MascaraDecimal.mascara(Inicial.Text);
                Inicial.Text = valor.ToString();
                Inicial.SelectionStart = Inicial.Text.Length + 1;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnConfirma_Click(object sender, EventArgs e)
        {
            double totalInicial = 0;
            var texto = Inicial.Text;
            if (texto != "")
            {
                double valorDouble = double.Parse(Inicial.Text);
                totalInicial = valorDouble + fundoCaixa;
                txtTotalAbertura.Text = totalInicial.ToString("N2");
            }

            //no evento change do combobox, alterar o nome do operador no campo do painel 
            //

            if (txtTotalAbertura.Text != "0,00")
            {
                DialogResult result = MessageBox.Show("Confirma Valor de: " + txtTotalAbertura.Text, "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    //solicitar para operador de caixa digitar a senha 
                    //pnSenhaOperador.Visible = true;

                    if (totalInicial > 0)
                    {

                        //todo mudar usuario
                        //todo impedir campo vazio
                        Caixa caixa = new Caixa();
                        caixa.Aberto = true;
                        caixa.DataHoraAbertura = DateTime.Now;
                        caixa.gerente = Login.Instance.Usuario;
                        caixa.operador = _usuarioRepository.ObterUsuarioPorNome(cbOperadorCaixa.Text);
                        caixa.fundoCaixa = 0;
                        _caixaRepository.Cadastrar(caixa);
                        pnSenhaOperador.Visible = true;
                        for (int i = 0; i < 4; i++)
                        {
                            Thread.Sleep(500);
                        }
                        FluxoCaixa fluxoCaixa = new FluxoCaixa(0, TiposMovimentacao.AberturaCaixa, "AberturaCaixa", FormaPagamento.Dinheiro, totalInicial, 0, caixa.gerente.Nome, caixa.operador.Nome);
                        _fluxoCaixaRepository.Cadastrar(fluxoCaixa);
                        MessageBox.Show("Abertura do Caixa Realizada com Sucesso!");
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("O Valor de abertura deve ser maior que 0,00");
            }
        }

        private void Inicial_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                var texto = Inicial.Text;
                if (texto != "")
                {
                    double valorDouble = double.Parse(Inicial.Text);
                    double totalInicial = valorDouble + fundoCaixa;
                    txtTotalAbertura.Text = totalInicial.ToString("N2");
                    btnConfirma.Select();
                }
            }
        }

        private void FrmAberturaCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
