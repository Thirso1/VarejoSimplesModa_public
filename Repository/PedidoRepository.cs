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
    class PedidoRepository : IPedidoRepository
    {
        public void Atualizar(Pedido pedido)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                string sql = "UPDATE `pedido` SET Id=@Id,NumVendaDoDia=@NumVendaDoDia,ClienteId=@ClienteId, UsuarioId=@UsuarioId, Valor=@Valor, Desconto=@Desconto, comanda=@Comanda, FormaPagamento=@FormaPagamento, StatusPedido=@StatusPedido, DataHora=@DataHora WHERE Id =" + pedido.Id;

                MySqlCommand objcmd = new MySqlCommand(sql, conn);
                objcmd.Parameters.Add("@Id", MySqlDbType.Int32, 11).Value = pedido.Id;
                objcmd.Parameters.Add("@NumVendaDoDia", MySqlDbType.Int32, 11).Value = pedido.NumVendaDoDia;
                objcmd.Parameters.Add("@ClienteId", MySqlDbType.Int32, 11).Value = pedido.ClienteId;
                objcmd.Parameters.Add("@UsuarioId", MySqlDbType.Int32, 11).Value = pedido.UsuarioId;
                objcmd.Parameters.Add("@Valor", MySqlDbType.Double, 8).Value = pedido.Valor;
                objcmd.Parameters.Add("@Comanda", MySqlDbType.Double, 8).Value = pedido.Comanda;
                objcmd.Parameters.Add("@Desconto", MySqlDbType.Double, 8).Value = pedido.Desconto;
                objcmd.Parameters.Add("@FormaPagamento", MySqlDbType.VarChar, 50).Value = pedido.FormaPagamento;
                objcmd.Parameters.Add("@StatusPedido", MySqlDbType.VarChar, 50).Value = pedido.StatusPedido;
                objcmd.Parameters.Add("@DataHora", MySqlDbType.DateTime).Value = DateTime.Now;
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

        public int RetornaUltimoId()
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "SELECT max(Id) FROM pedido";
                MySqlCommand obj = new MySqlCommand(sql, conn);
                return Convert.ToInt32(obj.ExecuteScalar());
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return 0;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public int Cadastrar(Pedido pedido)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "INSERT INTO `pedido` (`Id`,`NumVendaDoDia`,`ClienteId`, `UsuarioId`, `Valor`, `Desconto`, `Comanda`, `FormaPagamento`, `StatusPedido`) values(?, ?, ?, ?, ?, ?, ?, ?, ?)";
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand(sql, conn);
                objcmd.Parameters.Add("@Id", MySqlDbType.Int32, 11).Value = pedido.Id;
                objcmd.Parameters.Add("@NumVendaDoDia", MySqlDbType.Int32, 11).Value = pedido.NumVendaDoDia;
                objcmd.Parameters.Add("@ClienteId", MySqlDbType.Int32, 11).Value = pedido.ClienteId;
                objcmd.Parameters.Add("@UsuarioId", MySqlDbType.Int32, 11).Value = pedido.UsuarioId;
                objcmd.Parameters.Add("@Valor", MySqlDbType.Double, 8).Value = pedido.Valor;
                objcmd.Parameters.Add("@Comanda", MySqlDbType.Double, 8).Value = pedido.Comanda;
                objcmd.Parameters.Add("@Desconto", MySqlDbType.Double, 8).Value = pedido.Desconto;
                objcmd.Parameters.Add("@FormaPagamento", MySqlDbType.VarChar, 50).Value = pedido.FormaPagamento;
                objcmd.Parameters.Add("@StatusPedido", MySqlDbType.VarChar, 50).Value = pedido.StatusPedido;
                //objcmd.Parameters.Add("@DataHora", MySqlDbType.DateTime).Value = pedido.DataHora;


                //executa a inserção
                return objcmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return 0;
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

        public Pedido ObterPedido(int Id)
        {
            string sql = "SELECT * FROM `pedido` WHERE id =" + Id;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = objcomand.ExecuteReader();
                //define o total de registros como zero
                //int nuReg = 0;
                //percorre o leitor 
                return MontaPedido(rdr);
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

        public Pedido ObterPedidoPorComanda(string codigoComanda)
        {
            string sql = "SELECT * FROM `pedido` WHERE comanda = '" + codigoComanda + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = objcomand.ExecuteReader();
                //define o total de registros como zero
                //int nuReg = 0;
                //percorre o leitor 
                return MontaPedido(rdr);
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

        private Pedido MontaPedido(MySqlDataReader rdr)
        {
            Pedido pedido = new Pedido();

            while (rdr.Read())
            {
                pedido.Id = Convert.ToInt32(rdr["Id"]);
                pedido.NumVendaDoDia = Convert.ToInt32(rdr["NumVendaDoDia"]);
                pedido.ClienteId = Convert.ToInt32(rdr["ClienteId"]);
                pedido.UsuarioId = Convert.ToInt32(rdr["UsuarioId"]);
                pedido.Valor = Convert.ToDouble(rdr["Valor"]);
                pedido.Desconto = Convert.ToDouble(rdr["Desconto"]);
                pedido.Comanda = Convert.ToInt32(rdr["Comanda"]);
                pedido.FormaPagamento = (FormaPagamento)Enum.Parse(typeof(FormaPagamento), rdr["FormaPagamento"].ToString());
                pedido.StatusPedido = (StatusPedido)Enum.Parse(typeof(StatusPedido), rdr["StatusPedido"].ToString());
                pedido.DataHora = Convert.ToDateTime(rdr["DataHora"]);
            }
            return pedido;
        }

        public Pedido ObterPedidoAbertoPorComanda(string codigoComanda)
        {
            string sql = "SELECT* FROM `pedido` WHERE StatusPedido = 'Suspenso' AND `comanda` = '" + codigoComanda + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = objcomand.ExecuteReader();
                //define o total de registros como zero
                //int nuReg = 0;
                //percorre o leitor 
                return MontaPedido(rdr);
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

        public int ObterPedidosPorDia()
        {
            string queryVendas = "SELECT COUNT(*)FROM pedido WHERE DataHora >'" + DateTime.Today.ToString("yyyy-MM-dd 00:00:00") + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objVendas = new MySqlCommand(queryVendas, conn);
                int num = Convert.ToInt32(objVendas.ExecuteScalar());
                return num;
            }
            catch (MySqlException erro)
            {
                MessageBox.Show(erro.ToString());
                return 0;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public string ObterIdCrediarioUltimoPagamento(int IdCliente)
        {
            string sqlItens = "SELECT max(Id) FROM crediario WHERE `descricao` = '" + DescricaoCrediario.Pagamento + "' AND `idCliente` = " + IdCliente;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objMysql = new MySqlCommand(sqlItens, conn);
                var teste = objMysql.ExecuteScalar();

                if (teste == DBNull.Value)
                {

                    return null;
                }
                else
                {
                    return teste.ToString();
                }
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
        public DataTable ObterPedidoPorCliente(int IdCliente)
        {
            string idUltimoPagamento = ObterIdCrediarioUltimoPagamento(IdCliente);
            DataTable dtPedidos = new DataTable();
            string sqlItens;
            if (idUltimoPagamento == null)
            {
                sqlItens = "SELECT * FROM `crediario` WHERE Id > " + 0 + " AND `idCliente` = " + IdCliente;
            }
            else
            {
                sqlItens = "SELECT * FROM `crediario` WHERE Id > " + idUltimoPagamento + " AND `idCliente` = " + IdCliente;
            }

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlItens, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtPedidos);
                return dtPedidos;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtPedidos;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }
    }
}