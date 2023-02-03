using VarejoSimplesModa.Enums;
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
    public partial class FrmRelatorioVendas : Form
    {
        private static IFluxoCaixaRepository _fluxoCaixaRepository = new FluxoCaixaRepository();
        private List<double> valores = new List<double>();

        public FrmRelatorioVendas()
        {
            InitializeComponent();
        }

        private void FrmRelatorioVendas_Load(object sender, EventArgs e)
        {
            preencheValores();
            sobrepoe();
            grafico();
            panel14.Select();
        }

        private void grafico()
        {
            double total = valores[1] + valores[2] + valores[3] + valores[4] +valores[15] + valores[22];
            Console.WriteLine(total.ToString());
            double dinheiroPercent = ((valores[1]-valores[17]) * 100) / total;
            double cartaoPercent = ((valores[2] - valores[18]) * 100) / total;
            double pixPercent = ((valores[4] - valores[20]) * 100) / total;
            double prazoPercent = ((valores[3] - valores[19]) * 100) / total;
            double estornosPercent = (valores[15] * 100) / total;
            double canceladasPercent = (valores[22] * 100) / total;

            int heightDinheiro = (int)dinheiroPercent * 3;
            int heightCartao= (int)cartaoPercent * 3;
            int heightPix= (int)pixPercent * 3;
            int heightPrazo= (int)prazoPercent * 3;
            int heightEstornos= (int)estornosPercent * 3;
            int heightCanceladas= (int)canceladasPercent * 3;

            if(System.Double.IsNaN(dinheiroPercent))
            {
                dinheiroPercent = 0;
            }
            if (System.Double.IsNaN(cartaoPercent))
            {
                cartaoPercent = 0;
            }
            if (System.Double.IsNaN(pixPercent))
            {
                pixPercent = 0;
            }
            if (System.Double.IsNaN(prazoPercent))
            {
                prazoPercent = 0;
            }
            if (System.Double.IsNaN(estornosPercent))
            {
                estornosPercent = 0;
            }
            if (System.Double.IsNaN(canceladasPercent))
            {
                canceladasPercent = 0;
            }



            if (heightDinheiro < 1)
            {
                heightDinheiro = 1;
            }
            if (heightCartao < 1)
            {
                heightCartao = 1;
            }
            if (heightPix < 1)
            {
                heightPix = 1;
            }
            if (heightPrazo < 1)
            {
                heightPrazo = 1;
            }
            if (heightEstornos < 1)
            {
                heightEstornos = 1;
            }
            if (heightCanceladas < 1)
            {
                heightCanceladas = 1;
            }

            pnDinheiro.Height = heightDinheiro;
            pnCartao.Height = heightCartao;
            pnPix.Height = heightPix;
            pnPrazo.Height = heightPrazo;
            pnEstornos.Height = heightEstornos;
            pnCanceladas.Height = heightCanceladas;

            pnDinheiro.Location = new System.Drawing.Point(20, 350 - heightDinheiro);
            pnCartao.Location = new System.Drawing.Point(74, 350 - heightCartao);
            pnPix.Location = new System.Drawing.Point(131, 350 - heightPix);
            pnPrazo.Location = new System.Drawing.Point(188, 350 - heightPrazo);
            pnEstornos.Location = new System.Drawing.Point(245, 350 - heightEstornos);
            pnCanceladas.Location = new System.Drawing.Point(302, 350 - heightCanceladas);

            lblDinheiroPercent.Text = dinheiroPercent.ToString("N2")+"%";
            lblCartaoPercent.Text = cartaoPercent.ToString("N2") + "%";
            lblPixPercent.Text = pixPercent.ToString("N2") + "%";
            lblPrazoPercent.Text = prazoPercent.ToString("N2") + "%";
            lblEstornosPercent.Text = estornosPercent.ToString("N2") + "%";
            lblCanceladasPercent.Text = canceladasPercent.ToString("N2") + "%";

            lblDinheiroPercent.Location = new System.Drawing.Point(20, 330 - heightDinheiro);
            lblCartaoPercent.Location = new System.Drawing.Point(74, 330 - heightCartao);
            lblPixPercent.Location = new System.Drawing.Point(131, 330 - heightPix);
            
            lblPrazoPercent.Location = new System.Drawing.Point(188, 330 - heightPrazo);
            lblEstornosPercent.Location = new System.Drawing.Point(245, 330 - heightEstornos);
            lblCanceladasPercent.Location = new System.Drawing.Point(302, 330 - heightCanceladas);

            //lblDinheiroPercent.BackColor = Color.Navy;
            //lblCartaoPercent.BackColor = Color.DarkViolet;
            //lblPixPercent.BackColor = Color.Green;
            //lblPrazoPercent.BackColor = Color.Orange;
            //lblEstornosPercent.BackColor = Color.Red;
            //lblCanceladasPercent.BackColor = Color.Maroon;
        }

        public void preencheValores()
        {
            valores.Clear();

            valores = _fluxoCaixaRepository.ObterValoresTotais();

            textVendasDinheiro.Text = (valores[1] - valores[17]).ToString("N2");
            textVendasCartao.Text = (valores[2] - valores[18]).ToString("N2");
            textVendasPrazo.Text = (valores[3] - valores[19]).ToString("N2");
            textVendasPix.Text = (valores[4] - valores[20]).ToString("N2");
            textTotalEstornos.Text = valores[15].ToString("N2");
            textTotalCanceladas.Text = valores[22].ToString("N2");

            //vendas
            double vendas = (valores[1] + valores[2] + valores[3] + valores[4]) - valores[15];
            textTotalVendas.Text = vendas.ToString("N2");
        }


        private void sobrepoe()
        {
            foreach (Control control in this.Controls)
            {
                if ((control is TextBox) || (control is Label))
                {
                    control.BringToFront();
                }
            }
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void iconDinheiro_Click(object sender, EventArgs e)
        {
            if (textVendasDinheiro.Text != "0,00")
            {
                FrmDetalhesRelatorioVendas frmDetalhes = new FrmDetalhesRelatorioVendas(this, TipoConsultaFluxoCaixa.VendasDinheiro);
                frmDetalhes.ShowDialog();
            }
        }

        private void iconCartao_Click(object sender, EventArgs e)
        {
            if (textVendasCartao.Text != "0,00")
            {
                FrmDetalhesRelatorioVendas frmDetalhes = new FrmDetalhesRelatorioVendas(this, TipoConsultaFluxoCaixa.VendasCartao);
                frmDetalhes.ShowDialog();
            }
        }

        private void iconEstornos_Click(object sender, EventArgs e)
        {
            if (textTotalEstornos.Text != "0,00")
            {
                FrmDetalhesRelatorioVendas frmDetalhes = new FrmDetalhesRelatorioVendas(this, TipoConsultaFluxoCaixa.TotalEstornos);
                frmDetalhes.ShowDialog();
            }
        }

        private void iconPix_Click(object sender, EventArgs e)
        {
            if (textVendasPix.Text != "0,00")
            {
                FrmDetalhesRelatorioVendas frmDetalhes = new FrmDetalhesRelatorioVendas(this, TipoConsultaFluxoCaixa.VendasPix);
                frmDetalhes.ShowDialog();
            }
        }

        private void iconPrazo_Click(object sender, EventArgs e)
        {            
            if (textVendasPrazo.Text != "0,00")
            {
                FrmDetalhesRelatorioVendas frmDetalhes = new FrmDetalhesRelatorioVendas(this, TipoConsultaFluxoCaixa.VendasPrazo);
                frmDetalhes.ShowDialog();
            }
        }
    }
}
