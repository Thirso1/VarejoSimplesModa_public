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
    public partial class FrmCadastroUsuarios : Form
    {
        Usuario usuario = new Usuario();
        IUsuarioRepository _usuarioRepository = new UsuarioRepository();
        DataTable usuariosCadastrados = new DataTable();
        //private bool novo = true;


        public FrmCadastroUsuarios()
        {
            InitializeComponent();
        }

        private void FrmCadastroUsuarios_Load(object sender, EventArgs e)
        {
            dgUsuarios.DataSource = _usuarioRepository.ObterUsuarios();
            dgUsuarios.ClearSelection();
        }

        private bool existeLogin()
        {
            string login = txtLogin.Text;
            bool existe = false;
            foreach(DataGridViewRow row in dgUsuarios.Rows)
            {
                if(row.Cells[1].Value.ToString() == login)
                {
                    existe = true;
                    MessageBox.Show("Usuario já existe!");
                }
            }
            return existe;
        }

        private bool validaCampos()
        {
            if (txtLogin.Text == "")
            {
                MessageBox.Show("Preencha o campo Login");
                txtLogin.Select();
                return false;
            }
            else if (txtSenha.Text == "")
            {
                MessageBox.Show("Preencha o campo Senha");
                txtSenha.Select();
                return false;
            }
            else if (txtSenha.Text != txtConfirmaSenha.Text)
            {
                MessageBox.Show("Senhas diferentes");
                txtSenha.Text = string.Empty;
                txtConfirmaSenha.Text = string.Empty;
                txtSenha.Select();
                return false;
            }
            else if (cbPerfil.Text == "")
            {
                MessageBox.Show("Selecione o Perfil");
                return false;
            }
            else
            {
                return true;
            }
        }


        private void limpaCampos()
        {            
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtConfirmaSenha.Text = "";
            txtConfirmaSenha.Text = "";
            cbPerfil.Text = "";
            cbStatus.Text = "";
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (validaCampos() == true && existeLogin() == false)
            {
                usuario.Nome = txtLogin.Text;
                usuario.Senha = txtSenha.Text;
                usuario.Senha = txtSenha.Text;
                if(cbPerfil.SelectedIndex == 0)
                {
                    usuario.TipoUsuario = Enums.TipoUsuario.Gerente;
                }
                else
                {
                    usuario.TipoUsuario = Enums.TipoUsuario.Funcionario;

                }


                _usuarioRepository.Cadastrar(usuario);
                this.Close();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                usuario.Nome = txtLogin.Text;
                usuario.Senha = txtSenha.Text;
                usuario.Senha = txtSenha.Text;
                if (cbPerfil.SelectedIndex == 0)
                {
                    usuario.TipoUsuario = Enums.TipoUsuario.Gerente;
                }
                else
                {
                    usuario.TipoUsuario = Enums.TipoUsuario.Funcionario;

                }
                _usuarioRepository.Atualizar(usuario);
                this.Close();
            }
        }

        private void dgUsuarios_Click(object sender, EventArgs e)
        {
            DataGridViewRow linhaAtual = dgUsuarios.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;

            //deleta a linha na datatable
            int id = Convert.ToInt32(dgUsuarios.Rows[indice].Cells[0].Value);

            usuario = _usuarioRepository.ObterUsuario(id);
            txtLogin.Text = usuario.Nome;
            cbPerfil.Text = usuario.TipoUsuario.ToString();
            btnAtualizar.BringToFront();
            btnExcluir.Enabled = true;
            
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            btnSalvar.BringToFront();
            btnExcluir.Enabled = true;
            limpaCampos();
            txtLogin.Select();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            _usuarioRepository.Excluir(usuario.Id);
            dgUsuarios.DataSource = _usuarioRepository.ObterUsuarios();
            dgUsuarios.ClearSelection();
        }

        private void FrmCadastroUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
