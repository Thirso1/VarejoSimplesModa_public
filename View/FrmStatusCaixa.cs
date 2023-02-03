using VarejoSimplesModa.Enums;
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
    public partial class FrmStatusCaixa : Form
    {
        private IFluxoCaixaRepository _fluxoCaixaRepository = new FluxoCaixaRepository();
        private ICaixaRepository caixaRepository = new CaixaRepository();
        private Caixa caixa = null;
        public List<double> valores = new List<double>();



        public FrmStatusCaixa()
        {
            InitializeComponent();
        }

        public void FrmStatusCaixa_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            caixa = caixaRepository.ObterCaixa();

            if(caixa.Aberto)
            {
                lblStatus.Text = "Aberto";
                lblGerente.Text = caixa.gerente.Nome;
                lblOperador.Text = caixa.operador.Nome;
                lblMovimento.Text = caixa.DataHoraAbertura.ToString().Substring(0, 10);
                lblHora.Text = caixa.DataHoraAbertura.ToString().Substring(11,8);
            }
            else
            {
                lblStatus.Text = "Fechado";
            }

            preencheValoresParciais();
            panel10.Select();

        }

        public void preencheValoresParciais()
        {
            valores.Clear();

            valores = _fluxoCaixaRepository.ObterValoresParciais();

            textSaldoInicial.Text = valores[0].ToString("N2");
            textVendasDinheiro.Text = (valores[1].ToString("N2"));
            //textVendasCartao.Text = (valores[2] - valores[18]).ToString("C2");
            //textVendasPrazo.Text = (valores[3] - valores[19]).ToString("C2");
            //textVendasPix.Text = (valores[4] - valores[20]).ToString("C2");
            textPagFornecedores.Text = valores[5].ToString("N2");
            //textPagFuncionarios.Text = valores[6].ToString("C2");
            textRetiradasDinheito.Text = valores[7].ToString("N2");
            textTotalSaidas.Text = valores[8].ToString("C2");
            textSuprimentosDinheiro.Text = valores[9].ToString("N2");
            textRecCrediario.Text = valores[10].ToString("N2");
            textTotalEntradas.Text = valores[14].ToString("C2");
            textTotalEstornos.Text = valores[17].ToString("N2");
            textSaidaOutros.Text = valores[16].ToString("N2");
            textDescontos.Text = valores[22].ToString("N2");

            //textTudo.Text = (valores[14] - valores[8]).ToString("C2");
            //textTodasEntradas.Text = valores[14].ToString("C2");
            //textTodasSaidas.Text = valores[8].ToString("C2");


            //vendas
            double vendas = (valores[1] + valores[2] + valores[3] + valores[4]) - valores[15];

            //gaveta         inicial      vendas_din   suprim       recebimentos                                              
            double gaveta = (valores[21]) - (valores[8]);// + valores[6] + valores[7] + valores[12]);



            textTotalGaveta.Text = gaveta.ToString("C2");
            //textTotalVendas.Text = vendas.ToString("C2");

        }

        private void iconInicial_Click(object sender, EventArgs e)
        {
            if(textSaldoInicial.Text != "R$0,00")
            {
                FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this,TipoConsultaFluxoCaixa.SaldoInicial);
                frmDetalhes.ShowDialog();
            }
        }

        private void iconDinheiro_Click(object sender, EventArgs e)
        {
            if (textVendasDinheiro.Text != "R$0,00")
            {
                FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.VendasDinheiro);
                frmDetalhes.ShowDialog();
            }
        }

        private void iconSuprimento_Click(object sender, EventArgs e)
        {
            if (textSuprimentosDinheiro.Text != "R$0,00")
            {
                FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.SuprimentosDinheiro);
                frmDetalhes.ShowDialog();
            }
        }

        //private void iconCartao_Click(object sender, EventArgs e)
        //{
        //    if (textVendasCartao.Text != "R$0,00")
        //    {
        //        FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.VendasCartao);
        //        frmDetalhes.ShowDialog();
        //    }
        //}

        //private void iconPix_Click(object sender, EventArgs e)
        //{
        //    if (textVendasPix.Text != "R$0,00")
        //    {
        //        FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.VendasPix);
        //        frmDetalhes.ShowDialog();   
        //    }
        //}

        //private void iconPrazo_Click(object sender, EventArgs e)
        //{
        //    if (textVendasPrazo.Text != "R$0,00")
        //    {
        //        FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.VendasPrazo);
        //        frmDetalhes.ShowDialog();
        //    }
        //}

        private void iconCrediario_Click(object sender, EventArgs e)
        {
            if (textRecCrediario.Text != "R$0,00")
            {
                FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.RecCrediario);
                frmDetalhes.ShowDialog();   
            }
        }

        private void iconRetirada_Click(object sender, EventArgs e)
        {
            if (textRetiradasDinheito.Text != "R$0,00")
            {
                FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.RetiradasDinheito);
                frmDetalhes.ShowDialog();
            }
        }

        private void iconDescontos_Click(object sender, EventArgs e)
        {
            //FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(TipoConsultaFluxoCaixa.des);
            //frmDetalhes.ShowDialog();
        }

        //private void iconFncionarios_Click(object sender, EventArgs e)
        //{
        //    if (textPagFuncionarios.Text != "R$0,00")
        //    {
        //        FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.PagFuncionarios);
        //        frmDetalhes.ShowDialog();
        //    }
        //}

        private void iconFornecedores_Click(object sender, EventArgs e)
        {
            if (textPagFornecedores.Text != "R$0,00")
            {
                FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.PagFornecedores);
                frmDetalhes.ShowDialog();
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (textPagFornecedores.Text != "R$0,00")
            {
                FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.PagOutros);
                frmDetalhes.ShowDialog();
            }
        }

        private void FrmStatusCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }
        }

        private void iconEstornos_Click(object sender, EventArgs e)
        {
            if (textTotalEstornos.Text != "R$0,00")
            {
                FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.TotalEstornos);
                frmDetalhes.ShowDialog();
            }
        }

        private void iconTudo_Click(object sender, EventArgs e)
        {
  
                FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.Tudo);
                frmDetalhes.ShowDialog();
            
        }

        //private void iconTudo_Click(object sender, EventArgs e)
        //{
        //    if (textTudo.Text != "R$0,00")
        //    {
        //        FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.Tudo);
        //        frmDetalhes.ShowDialog();
        //    }
        //}

        //private void iconTodasEntradas_Click(object sender, EventArgs e)
        //{
        //    if (textTodasEntradas.Text != "R$0,00")
        //    {
        //        FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.TodasEntradas);
        //        frmDetalhes.ShowDialog();
        //    }
        //}

        //private void iconTodasSaidas_Click(object sender, EventArgs e)
        //{
        //    if (textTodasSaidas.Text != "R$0,00")
        //    {
        //        FrmDetalhesFluxoCaixa frmDetalhes = new FrmDetalhesFluxoCaixa(this, TipoConsultaFluxoCaixa.TodasSaidas);
        //        frmDetalhes.ShowDialog();
        //    }
        //}
    }
}
