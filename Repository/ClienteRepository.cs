using MySql.Data.MySqlClient;
using VarejoSimplesModa.Banco;
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
    class ClienteRepository:IClienteRepository
    {


        public void Atualizar(Cliente cliente)
        {
            try
            {
                string sql = "UPDATE `clientes` SET cpf=@cpf,nome=@nome,sobrenome=@sobrenome, telefone=@telefone, telefone_2=@telefone_2," +
               " rua=@rua, numero=@numero, bairro=@bairro, cidade=@cidade, cep=@cep WHERE idclientes =" + cliente.Id;
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcmd = new MySqlCommand(sql, conn);

                //string de inserção na tabela 
                objcmd.Parameters.Add("@cpf", MySqlDbType.VarChar, 20).Value = cliente.cpf;
                objcmd.Parameters.Add("@nome", MySqlDbType.VarChar, 20).Value = cliente.nome;
                //objcmd.Parameters.Add("@sobrenome", MySqlDbType.VarChar, 50).Value = cliente.sobrenome;
                objcmd.Parameters.Add("@telefone", MySqlDbType.VarChar, 20).Value = cliente.telefone;
                objcmd.Parameters.Add("@telefone_2", MySqlDbType.VarChar, 20).Value = cliente.telefone_2;
                objcmd.Parameters.Add("@rua", MySqlDbType.VarChar, 100).Value = cliente.rua;
                objcmd.Parameters.Add("@numero", MySqlDbType.VarChar, 10).Value = cliente.numero;
                objcmd.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = cliente.bairro;
                objcmd.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = cliente.cidade;
                objcmd.Parameters.Add("@cep", MySqlDbType.VarChar, 20).Value = cliente.cep;
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

        public void Cadastrar(Cliente cliente)
        {
            try
            {               
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("insert into clientes(cpf,nome,telefone,telefone_2,rua, numero,bairro,cidade,cep) values(?, ?, ?, ?, ?, ?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@nm_cpf", MySqlDbType.VarChar, 20).Value = cliente.cpf;
                objcmd.Parameters.Add("@nm_nome", MySqlDbType.VarChar, 20).Value = cliente.nome;
                //objcmd.Parameters.Add("@nm_sobrenome", MySqlDbType.VarChar, 50).Value = cliente.sobrenome;
                objcmd.Parameters.Add("@nm_telefone", MySqlDbType.VarChar, 20).Value = cliente.telefone;
                objcmd.Parameters.Add("@nm_telefone_2", MySqlDbType.VarChar, 20).Value = cliente.telefone_2;
                objcmd.Parameters.Add("@nm_rua", MySqlDbType.VarChar, 100).Value = cliente.rua;
                objcmd.Parameters.Add("@nm_numero", MySqlDbType.VarChar, 10).Value = cliente.numero;
                objcmd.Parameters.Add("@nm_bairro", MySqlDbType.VarChar, 50).Value = cliente.bairro;
                objcmd.Parameters.Add("@nm_cidade", MySqlDbType.VarChar, 50).Value = cliente.cidade;
                objcmd.Parameters.Add("@nm_cep", MySqlDbType.VarChar, 20).Value = cliente.cep;
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

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterCliente(int Id)
        {
            Cliente cliente = new Cliente();
            MySqlDataReader rdr = null;
            string sql = "SELECT * FROM `clientes` WHERE idclientes =" + Id;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                rdr = objcomand.ExecuteReader();
                //define o total de registros como zero
                //int nuReg = 0;
                //percorre o leitor 
                while (rdr.Read())
                {
                    cliente.Id = Convert.ToInt32(rdr["idclientes"]);
                    cliente.cpf = rdr["cpf"].ToString();
                    cliente.nome = rdr["nome"].ToString();
                    //cliente.sobrenome = rdr["sobrenome"].ToString();
                    cliente.telefone = rdr["telefone"].ToString();
                    cliente.telefone_2 = rdr["telefone_2"].ToString();
                    cliente.rua = rdr["rua"].ToString();
                    cliente.numero = rdr["numero"].ToString();
                    cliente.bairro = rdr["bairro"].ToString();
                    cliente.cidade = rdr["cidade"].ToString();
                    cliente.cep = rdr["cep"].ToString();
                }
                return cliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return cliente;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }
        public DataTable ObterClientes(string pesquisa)
        {
            DataTable dtClientes = new DataTable();
            string sqlItens = "SELECT * FROM `consultarapidaclientes` WHERE `nome` LIKE '" + pesquisa + "%'";

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlItens, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtClientes);
                return dtClientes;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtClientes;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public int QuantidadeTotalClientes()
        {
            throw new NotImplementedException();
        }
    }
}
