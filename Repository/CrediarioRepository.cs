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
    public class CrediarioRepository : ICrediarioRepository
    {
        public void Cadastrar(Crediario crediario)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "INSERT INTO `crediario` (`idCliente`, `idPedido`,`descricao`, `debito`, `credito`) values(?, ?, ?, ?, ?)";
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand(sql, conn);
                objcmd.Parameters.Add("@idCliente", MySqlDbType.Int32, 11).Value = crediario.IdCliente;
                objcmd.Parameters.Add("@idPedido", MySqlDbType.Int32, 11).Value = crediario.IdPedido;
                objcmd.Parameters.Add("@descricao", MySqlDbType.VarChar, 100).Value = crediario.DescricaoCrediario;
                objcmd.Parameters.Add("@debito", MySqlDbType.Double, 6).Value = crediario.Debito;
                objcmd.Parameters.Add("@credito", MySqlDbType.Double, 6).Value = crediario.Credito;


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

        public void Estornar(Crediario crediario)
        {
            throw new NotImplementedException();
        }

        public DataTable ObterCrediarioPorCliente(int idCliente)
        {
            string sql = "SELECT * FROM `crediario` WHERE `idCliente` = "+ idCliente;
            DataTable dataTable = new DataTable();

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dataTable);
                return dataTable;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dataTable;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public Crediario ObterCrediario(int Id)
        {
            throw new NotImplementedException();
        }

        public Crediario ObterCrediarioPorPedido(int IdPedido)
        {
            Crediario crediario = new Crediario();
            string sql = "SELECT * FROM `crediario` WHERE `idPedido` = " + IdPedido;
            MySqlDataReader rdr;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                rdr = objcomand.ExecuteReader();

                while (rdr.Read())
                {
                    crediario.Id = Convert.ToInt32(rdr["id"]);
                    crediario.IdCliente = Convert.ToInt32(rdr["idCliente"]);
                    crediario.IdPedido = Convert.ToInt32(rdr["idPedido"]);
                    crediario.DescricaoCrediario = (DescricaoCrediario)Enum.Parse(typeof(DescricaoCrediario), rdr["Descricao"].ToString());
                    crediario.Debito = Convert.ToDouble(rdr["debito"]);
                    crediario.Credito = Convert.ToDouble(rdr["credito"]);
                }
                return crediario;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return crediario;
            }
            finally
            {
                Conect.fecharConexao();
            }


        }
    }
}
