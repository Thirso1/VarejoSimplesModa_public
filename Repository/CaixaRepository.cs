using MySql.Data.MySqlClient;
using VarejoSimplesModa.Banco;
using VarejoSimplesModa.Model;
using VarejoSimplesModa.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VarejoSimplesModa.Repository
{
    class CaixaRepository : ICaixaRepository
    {
        IUsuarioRepository _usuarioRepository = new UsuarioRepository();
        public void Atualizar(Caixa caixa)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                string sql = "UPDATE `caixa` SET DataHoraAbertura=@DataHoraAbertura, DataHoraFechamento=@DataHoraFechamento, Aberto=@Aberto, fundoCaixa=@fundoCaixa WHERE Id =" + caixa.Id;

                MySqlCommand objcmd = new MySqlCommand(sql, conn);
                objcmd.Parameters.Add("@DataHoraAbertura", MySqlDbType.DateTime).Value = caixa.DataHoraAbertura;
                objcmd.Parameters.Add("@DataHoraFechamento", MySqlDbType.DateTime).Value = caixa.DataHoraFechamento;
                objcmd.Parameters.Add("@Aberto", MySqlDbType.Int32).Value = caixa.Aberto;
                objcmd.Parameters.Add("@fundoCaixa", MySqlDbType.Double, 8).Value = caixa.fundoCaixa;

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

        public void Cadastrar(Caixa caixa)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("insert into caixa(DataHoraAbertura,Aberto,gerente,operador,fundoCaixa) values(?, ?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@DataHoraAbertura", MySqlDbType.DateTime, 20).Value = caixa.DataHoraAbertura;
                objcmd.Parameters.Add("@Aberto", MySqlDbType.Int32, 11).Value = caixa.Aberto;
                objcmd.Parameters.Add("@gerente", MySqlDbType.VarChar, 20).Value = caixa.gerente.Nome;
                objcmd.Parameters.Add("@operador", MySqlDbType.VarChar, 20).Value = caixa.operador.Nome;
                objcmd.Parameters.Add("@fundoCaixa", MySqlDbType.Double, 8).Value = caixa.fundoCaixa;
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

        public Caixa ObterCaixa()
        {
            Caixa caixa = new Caixa();
            string sql = "SELECT * FROM caixa ORDER BY id DESC limit 1";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = objcomand.ExecuteReader();               

                while (rdr.Read())
                {
                    caixa.Id = Convert.ToInt32(rdr["Id"]);
                    caixa.Aberto = Convert.ToBoolean(rdr["Aberto"]);
                    caixa.DataHoraAbertura = Convert.ToDateTime(rdr["DataHoraAbertura"]);
                    if (!DBNull.Value.Equals(rdr["DataHoraFechamento"]))
                        {
                            caixa.DataHoraFechamento = Convert.ToDateTime(rdr["DataHoraFechamento"]);
                        }
                    caixa.gerente = _usuarioRepository.ObterUsuarioPorNome(rdr["gerente"].ToString());
                    caixa.operador = _usuarioRepository.ObterUsuarioPorNome(rdr["operador"].ToString());
                    caixa.fundoCaixa = Convert.ToDouble(rdr["fundoCaixa"]);
                }

                return caixa;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return null;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }
    }
}
