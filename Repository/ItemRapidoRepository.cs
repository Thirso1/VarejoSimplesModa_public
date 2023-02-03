using MySql.Data.MySqlClient;
using VarejoSimplesModa.Banco;
using VarejoSimplesModa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VarejoSimplesModa.Repository.RepositoryInterfaces
{
    class ItemRapidoRepository : IItemRapidoRepository
    {
        public ItemRapido[] buscaItemRapidos()
        {
             ItemRapido[] itemRapidos = new ItemRapido[16];

            string sql = "SELECT* FROM `itensrapidos` ORDER BY `itensrapidos`.`posicao` ASC";

            MySqlConnection conn = Conect.obterConexao();
            MySqlCommand objcomand = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = objcomand.ExecuteReader();
            int i = 0;
            while (rdr.Read())
                {
                    ItemRapido itemRapido = new ItemRapido();
                    itemRapido.Id = Convert.ToInt32(rdr["Id"]);
                    itemRapido.CodigoBarras = rdr["codigoBarras"].ToString();
                    itemRapido.CodigoBarrasBalanca = Convert.ToInt32(rdr["codigoBarrasBalanca"]);
                    itemRapido.Nome = rdr["nome"].ToString();
                    itemRapido.CorFundo = rdr["corFundo"].ToString();
                    itemRapido.CorFonte = rdr["corFonte"].ToString();
                    itemRapido.Posicao = Convert.ToInt32(rdr["posicao"]);

                    itemRapidos[i] = itemRapido;
                    i++;
                }
            return itemRapidos;
        }


        public void ExcluirTodos()
        {
            string sql = "DELETE FROM `itensrapidos` WHERE `Id` > 0 ";
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

        public void cadastrar(ItemRapido[] itemRapidos)
        {
            //string de inserção na tabela 
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                foreach(ItemRapido item in itemRapidos)
                {
                    string sql = "INSERT INTO `itensRapidos` ( `codigoBarras`, `codigoBarrasBalanca`,`nome`, `corFundo`, `corFonte`, `posicao`) values(?, ?, ?, ?, ?, ?)";
                    MySqlCommand objcmd = new MySqlCommand(sql, conn);
                    //objcmd.Parameters.Add("@Id", MySqlDbType.Int32, 11).Value = itemPedido;
                    objcmd.Parameters.Add("@CodigoBarras", MySqlDbType.VarChar, 20).Value = item.CodigoBarras;
                    objcmd.Parameters.Add("@CodigoBarraBalancas", MySqlDbType.Int32, 11).Value = item.CodigoBarrasBalanca;
                    objcmd.Parameters.Add("@Nome", MySqlDbType.VarChar, 20).Value = item.Nome;
                    objcmd.Parameters.Add("@CorFundo", MySqlDbType.VarChar, 20).Value = item.CorFundo;
                    objcmd.Parameters.Add("@CorFonte", MySqlDbType.VarChar, 20).Value = item.CorFonte;
                    objcmd.Parameters.Add("@Posicao", MySqlDbType.Int32, 11).Value = item.Posicao;

                    objcmd.ExecuteNonQuery();

                }
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

        
    }
}
