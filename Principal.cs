using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VarejoSimplesModa.Banco;
using VarejoSimplesModa.Enums;
using VarejoSimplesModa.Library;
using VarejoSimplesModa.Model;
using VarejoSimplesModa.Repository;
using VarejoSimplesModa.Repository.RepositoryInterfaces;
using VarejoSimplesModa.View;

namespace VarejoSimplesModa
{
    public partial class Principal : Form
    {
        private ICaixaRepository caixaRepository = new CaixaRepository();
        private IProdutoRepository produtoRepository = new ProdutoRepository();
        private Caixa caixa = new Caixa();
        public static bool ConfirmacaoMensagem = false;
        Login login;

        public Principal()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //ação necessaria para configurar a porta COM da impressora termica
            //devido a perda das configurações qdo reinicia o windows
            ConfiguraPortaCom portaCom = new ConfiguraPortaCom();
            portaCom.configuraPortaCom();

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();

            login = Login.Instance;
            if (!login.Logado)
            {
                Application.Exit();
            }
            else
            {
                lblUsuario.Text = login.Usuario.Nome;
                caixa = caixaRepository.ObterCaixa();
                controleUsuario(login.Usuario);
                this.Text = "        Adilson  -  (35) 93300-7724  -  (35) 99973-1174";
            }
        }

        void controleUsuario(Usuario usuario)
        {
            switch (usuario.TipoUsuario)
            {
                case TipoUsuario.Funcionario:
                    menuStrip1.Items[1].Enabled = false;
                    menuStrip1.Items[2].Enabled = false;
                    menuStrip1.Items[3].Enabled = false;
                    menuStrip1.Items[4].Enabled = false;
                    //iconPictureBox12.ForeColor = Color.Gray;
                    //iconPictureBox6.ForeColor = Color.Gray;
                    //iconPictureBox4.ForeColor = Color.Gray;
                    //iconPictureBox10.ForeColor = Color.Gray;

                    break;
                case TipoUsuario.Gerente:

                    break;
            }
        }

        private bool VerificaCaixaAberto()
        {
            caixa = caixaRepository.ObterCaixa();
            return caixa.Aberto;
        }

        private void chamaPDV()
        {
            if (VerificaCaixaAberto())
            {
                Pdv pdv = Pdv.Instance;
                pdv.maximizaTela();
                pdv.Show();

                pdv.BringToFront();
                //todo resolver o problema da instancia singleton            
            }
            else
            {
                string msg1 = "Caixa Fechado!";
                string msg2 = "Deseja Abrir?";
                FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.Principal);
                frmMensagens.ShowDialog();
                if (ConfirmacaoMensagem)
                {
                    FrmAberturaCaixa frmAberturaCaixa = new FrmAberturaCaixa(caixa.fundoCaixa);
                    frmAberturaCaixa.ShowDialog();
                    caixa = caixaRepository.ObterCaixa();

                    if (VerificaCaixaAberto())
                    {
                        Pdv pdv = Pdv.Instance;
                        pdv.Show();
                        pdv.BringToFront();

                    }
                    ConfirmacaoMensagem = false;
                }
            }
        }

        private void btnPdv_Click(object sender, EventArgs e)
        {
            chamaPDV();
        }

        private void novaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chamaPDV();
        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStatusCaixa frmStatusCaixa = new FrmStatusCaixa();
            frmStatusCaixa.ShowDialog();
        }

        private void retiradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Retirada frmRetirada = new Retirada(login.Usuario, caixa.operador);
            frmRetirada.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FrmStatusCaixa frmStatusCaixa = new FrmStatusCaixa())
            {
                frmStatusCaixa.ShowDialog();
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VerificaCaixaAberto())
            {
                string msg1 = "O caixa já está aberto!";
                string msg2 = "";
                FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.Ok, msg1, msg2, TiposForms.Principal);
                frmMensagens.ShowDialog();
                ConfirmacaoMensagem = false;
            }
            else
            {
                FrmAberturaCaixa frmAberturaCaixa = new FrmAberturaCaixa(caixa.fundoCaixa);
                frmAberturaCaixa.ShowDialog();
                caixa.Aberto = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            caixa = caixaRepository.ObterCaixa();

            Retirada frmRetirada = new Retirada(login.Usuario, caixa.operador);
            frmRetirada.ShowDialog();
        }

        private void crediarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCrediarioCliente frm = new FrmCrediarioCliente(login.Usuario, caixa.operador);
            frm.ShowDialog();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCadastroUsuarios frm = new FrmCadastroUsuarios();
            frm.ShowDialog();
        }

        private void btnCrediario_Click(object sender, EventArgs e)
        {
            FrmCrediarioCliente frm = new FrmCrediarioCliente(login.Usuario, caixa.operador);
            frm.ShowDialog();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroCliente frm = new FrmCadastroCliente(0);
            frm.ShowDialog();
        }

        private void cadastrarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FrmCadastroProdutos frm = new FrmCadastroProdutos(0);
            frm.ShowDialog();
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            //ConsultaProdutoBalanca frm = new ConsultaProdutoBalanca();
            //frm.ShowDialog();
        }


        private void consultarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmConsultaProduto frm = new FrmConsultaProduto();
            frm.ShowDialog();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VerificaCaixaAberto())
            {
                FrmFechamentoCaixa frm = new FrmFechamentoCaixa();
                frm.ShowDialog();
            }
            else
            {
                string msg1 = "Caixa se encontra fechado!";
                string msg2 = "";
                FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.Ok, msg1, msg2, TiposForms.Principal);
                frmMensagens.ShowDialog();
                ConfirmacaoMensagem = false;
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FrmCadastroProdutos frm = new FrmCadastroProdutos(0);
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //FormataTxtProdutos test = new FormataTxtProdutos();
            //test.formataCodigo("1234");
            //test.formataNome("queijo canastra");


        }

        private void button5_Click(object sender, EventArgs e)
        {
            //ConsultaProdutoBalanca consultaProdutoBalanca = new ConsultaProdutoBalanca();
            //consultaProdutoBalanca.ShowDialog();
        }

        private void itensRápidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmConfigItensRapidos frm = new FrmConfigItensRapidos();
            //frm.ShowDialog();
        }

        private void códigoBarrasBalançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ConsultaProdutoBalanca frm = new ConsultaProdutoBalanca();
            //frm.ShowDialog();
        }

        private void exportarParaBalançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteAllLines write = new WriteAllLines();
            write.CriaCadTxt();
            write.CriaSetorTxt();
            MessageBox.Show("Dados exportados com sucesso!");

        }

        private void relatóriosToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmRelatorioVendas frmRelatorioVendas = new FrmRelatorioVendas();
            frmRelatorioVendas.ShowDialog();
        }

        private void suprimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSuprimento frmSuprimento = new FrmSuprimento(login.Usuario, caixa.operador);
            frmSuprimento.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string local = "C:\\Backup";


            //// define o nome do arquivo de backup de acordo com a data e hora.
            //string dia = DateTime.Now.Day.ToString();
            //string mes = DateTime.Now.Month.ToString();
            //string ano = DateTime.Now.Year.ToString();
            //string hora = DateTime.Now.ToLongTimeString().Replace(":", "");

            //string nomeDoArquivo = ano + mes + dia + "_" + hora;

            //string constring = "server = localhost;port=3307;user id=root;database=varejo_simples;password=";//wiUsRU0cMo6ZVsip;
            //string arquivo = local + "\\" + nomeDoArquivo + ".sql";

            //using (MySqlConnection conn = new MySqlConnection(constring))
            //{
            //    using (MySqlCommand cmd = new MySqlCommand())
            //    {
            //        using (MySqlBackup mb = new MySqlBackup(cmd))
            //        {
            //            cmd.Connection = conn;
            //            conn.Open();
            //            mb.ExportToFile(arquivo);
            //            conn.Close();
            //        }
            //    }
            //}
            MessageBox.Show("Backup realizado com Sucesso!");
        }

        DataTable ObterProdutosQueijo()
        {
            DataTable dtProdutos = new DataTable();
            string sqlItens = "SELECT * FROM `produtos`";


            try
            {
                MySqlConnection conn = Conect.obterConexaoPadaria();
                MySqlCommand objcomand = new MySqlCommand(sqlItens, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtProdutos);
                return dtProdutos;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtProdutos;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {

            DataTable dt = ObterProdutosQueijo();

            foreach (DataRow row in dt.Rows)
            {
                Produto produto = new Produto();

                produto.CodigoBarras = row[1].ToString();
                produto.CodigoBarrasBalanca = Convert.ToInt32(row[2]);
                produto.Nome = row[3].ToString();
                produto.Descricao = row[4].ToString();
                produto.PrecoVenda = Convert.ToDouble(row[5]);
                produto.PrecoCusto = Convert.ToDouble(row[6]);
                produto.MargemLucro = Convert.ToDouble(row[7]);
                produto.Desconto = 0;
                produto.Imagem = "C:\\padaria\\img\\logo.png";

                produto.CategoriaId = 1;
                produto.UnidVenda = row[13].ToString();
                produto.EstoqueMin = 1;
                produto.EstoqueMax = 1;
                produto.EstoqueAtual = 1;


                produtoRepository.Cadastrar(produto);
            }
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroEmpresa frmCadastroEmpresa = new FrmCadastroEmpresa();
            frmCadastroEmpresa.ShowDialog();
        }
    }
} 

