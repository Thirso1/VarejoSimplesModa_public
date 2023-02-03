using MySql.Data.MySqlClient;
using VarejoSimplesModa.Banco;
using VarejoSimplesModa.Model;
using VarejoSimplesModa.Repository;
using VarejoSimplesModa.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VarejoSimplesModa.View
{
    public partial class FrmLogin : Form
    {
        Usuario usuario = new Usuario();
        IUsuarioRepository usuarioDb = new UsuarioRepository();
        private MySqlConnection conn = null;


        public Principal form1 = new Principal();

        public FrmLogin()
        {
            InitializeComponent();
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            lblCarregando.Visible = true;
            //verifica se o banco esta aberto
            if (loadinDB())
            {
                Conect.fecharConexao();
                lblCarregando.Visible = false;
                panel1.Visible = true;
                textUsuario.Select();
            }
            else
            {
                MessageBox.Show("");
            }
        }


        private bool loadinDB()
        {
            conn = Conect.obterConexao();

            if (conn == null)
            {
                if (File.Exists("C:\\wamp\\wampmanager.exe"))
                {
                    System.Diagnostics.Process.Start("C:\\wamp\\wampmanager.exe");
                }
                else
                {
                    System.Diagnostics.Process.Start("C:\\wamp64\\wampmanager.exe");
                }
                Thread.Sleep(15000);

                int i = 0;

                while (conn == null)
                {
                    conn = Conect.obterConexao();
                    Thread.Sleep(1000);
                    i++;
                    if (i > 20)
                    {
                        break;
                    }
                }
            }            

            //Thread.Sleep(5000);

            if(conn != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Oops! Algo estranho, contate o suporte!");
                Application.Exit();
                return false;
            }

        }





        private void validacao()
        {
            string nome = textUsuario.Text;
            string senha = textSenha.Text;
            usuario = usuarioDb.ObterUsuarioPorNomeSenha(nome, senha);
            if (usuario!= null)
            {
                Login login = Login.Instance;
                login.Usuario = usuario;
                login.Logado = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos!");
                textSenha.Text = "";
                textUsuario.Text = "";
                textUsuario.Select();
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            validacao();
        }

        private void textSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                validacao();
            }
        }

        private void textUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                textSenha.Select();
            }
        }
    }
}