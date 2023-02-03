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
    class ItemPedidoRepository : IItemPedidoRepository
    {
        public void Atualizar(ItemPedido itemPedido)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ItemPedido itemPedido)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "INSERT INTO `itempedido` (`PedidoId`, `ProdutoId`, `Nome`,`Preco`,`Qtde`, `Desconto`, `SubTotal`) values(?, ?, ?, ?, ?, ?, ?)";
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand(sql, conn);
                //objcmd.Parameters.Add("@Id", MySqlDbType.Int32, 11).Value = itemPedido;
                objcmd.Parameters.Add("@PedidoId", MySqlDbType.Int32, 11).Value = itemPedido.PedidoId;
                objcmd.Parameters.Add("@ProdutoId", MySqlDbType.Int32, 11).Value = itemPedido.ProdutoId;
                objcmd.Parameters.Add("@Nome", MySqlDbType.VarChar, 80).Value = itemPedido.Nome;
                objcmd.Parameters.Add("@Preco", MySqlDbType.Double, 8).Value = itemPedido.Preco;
                objcmd.Parameters.Add("@Qtde", MySqlDbType.Double, 6).Value = itemPedido.Qtde;
                objcmd.Parameters.Add("@Desconto", MySqlDbType.Double, 8).Value = itemPedido.Desconto;
                objcmd.Parameters.Add("@SubTotal", MySqlDbType.Double, 8).Value = itemPedido.SubTotal;

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

        public void CadastrarTodos(List<ItemPedido> itens)
        {
            foreach (ItemPedido item in itens)
            {                
                Cadastrar(item);
            }

        }

        public DataTable ConsultaTodos(int pedidoId)
        {
            string sqlItens = "SELECT * FROM `itempedido` WHERE PedidoId =" + pedidoId;

            DataTable ReturItens = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlItens, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(ReturItens);
                return ReturItens;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return ReturItens;
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

        public void ExcluirTodos(int PedidoId)
        {
            string sql = "DELETE FROM `itempedido` WHERE PedidoId = " + PedidoId;
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

        public ItemPedido ObterItemPedido(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
