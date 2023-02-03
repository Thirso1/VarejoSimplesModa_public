using MySql.Data.MySqlClient;
using VarejoSimplesModa.Banco;
using VarejoSimplesModa.Enums;
using VarejoSimplesModa.Model;
using VarejoSimplesModa.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VarejoSimplesModa.Repository
{
    class UsuarioRepository : IUsuarioRepository
    {
        public void Atualizar(Usuario usuario)
        {
            try
            {
                string sql = "UPDATE `usuarios` SET `nome`=@nome,`senha`=@senha,`telefone`=@telefone,`tipoUsuario`=@tipoUsuario WHERE `id_usuario` = " + usuario.Id;
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcmd = new MySqlCommand(sql, conn);

                //string de inserção na tabela 
                objcmd.Parameters.Add("@nome", MySqlDbType.VarChar, 20).Value = usuario.Nome;
                objcmd.Parameters.Add("@senha", MySqlDbType.VarChar, 50).Value = usuario.Senha;
                objcmd.Parameters.Add("@telefone", MySqlDbType.VarChar, 20).Value = usuario.Telefone;
                objcmd.Parameters.Add("@tipoUsuario", MySqlDbType.VarChar, 100).Value = usuario.TipoUsuario.ToString(); ;
       
                //executa a inserção
                objcmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `usuarios` (`nome`, `senha`, `telefone`, `tipoUsuario`) values(?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@nome", MySqlDbType.VarChar, 255).Value = usuario.Nome;
                objcmd.Parameters.Add("@senha", MySqlDbType.VarChar, 255).Value = usuario.Senha;
                objcmd.Parameters.Add("@telefone", MySqlDbType.VarChar, 255).Value = usuario.Telefone;
                objcmd.Parameters.Add("@tipoUsuario", MySqlDbType.VarChar, 255).Value = usuario.TipoUsuario;

                //executa a inserção
                objcmd.ExecuteNonQuery();
                MessageBox.Show("Usuário cadastrado com sucesso!");

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void Excluir(int Id)
        {
            string sql = "DELETE FROM `usuarios` WHERE id_usuario = " + Id;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //executa a romoção
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                objcomand.ExecuteNonQuery();
            }
            catch (MySqlException erro)
            {
                MessageBox.Show(erro.ToString());
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public Usuario ObterUsuarioPorNomeSenha(string nome, string senha)
        {
            Usuario usuario = new Usuario();

            string select = "SELECT * FROM `usuarios` WHERE `nome`='" + nome + "' AND `senha`='" + senha + "'";

            MySqlConnection conn = Conect.obterConexao();
            MySqlCommand cmd = new MySqlCommand(select, conn);

            MySqlDataReader dados = cmd.ExecuteReader();
            if (dados.HasRows)
            {
                while (dados.Read())
                {
                    usuario.Id = Convert.ToInt32(dados["id_usuario"]);
                    usuario.Nome = dados["nome"].ToString();
                    usuario.Senha = dados["senha"].ToString();
                    usuario.Telefone = dados["telefone"].ToString();
                    usuario.TipoUsuario = (TipoUsuario)Enum.Parse(typeof(TipoUsuario), dados["tipoUsuario"].ToString());
                }
                Conect.fecharConexao();
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public Usuario ObterUsuario(int id)
        {
            Usuario usuario = new Usuario();

            string select = "SELECT * FROM `usuarios` WHERE `id_usuario`='" + id + "'";

            MySqlConnection conn = Conect.obterConexao();
            MySqlCommand cmd = new MySqlCommand(select, conn);

            MySqlDataReader dados = cmd.ExecuteReader();
            if (dados.HasRows)
            {
                while (dados.Read())
                {
                    usuario.Id = Convert.ToInt32(dados["id_usuario"]);
                    usuario.Nome = dados["nome"].ToString();
                    usuario.Senha = dados["senha"].ToString();
                    usuario.Telefone = dados["telefone"].ToString();
                    usuario.TipoUsuario = (TipoUsuario)Enum.Parse(typeof(TipoUsuario), dados["tipoUsuario"].ToString());
                }
                Conect.fecharConexao();
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public Usuario ObterUsuarioPorNome(string nome)
        {
            Usuario usuario = new Usuario();

            string select = "SELECT * FROM `usuarios` WHERE `nome`='" + nome + "'";

            MySqlConnection conn = Conect.obterConexao();
            MySqlCommand cmd = new MySqlCommand(select, conn);

            MySqlDataReader dados = cmd.ExecuteReader();
            if (dados.HasRows)
            {
                while (dados.Read())
                {
                    usuario.Id = Convert.ToInt32(dados["id_usuario"]);
                    usuario.Nome = dados["nome"].ToString();
                    usuario.Senha = dados["senha"].ToString();
                    usuario.Telefone = dados["telefone"].ToString();
                    usuario.TipoUsuario = (TipoUsuario)Enum.Parse(typeof(TipoUsuario), dados["tipoUsuario"].ToString());
                }
                Conect.fecharConexao();
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public DataTable ObterUsuarios()
        {
            string sql = "SELECT * FROM `usuarios`";

            DataTable Usuarios = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(Usuarios);
                return Usuarios;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return Usuarios;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }


        private bool VerificaLogin(string nome, string senha)
        {
            bool result = false;

            return result;
        }
    }
}
