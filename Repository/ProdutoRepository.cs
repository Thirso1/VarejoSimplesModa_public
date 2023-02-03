using MySql.Data.MySqlClient;
using VarejoSimplesModa.Banco;
using VarejoSimplesModa.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VarejoSimplesModa.Repository.RepositoryInterfaces
{
    class ProdutoRepository : IProdutoRepository
    {
        //IConfiguration _conf;
        //LojaVirtualContext _banco;

        public ProdutoRepository()//LojaVirtualContext banco, IConfiguration configuration
        {
            //_banco = banco;
            //_conf = configuration;
        }

        public void Atualizar(Produto produto)
        {
            string sql = "UPDATE `produtos` SET CodigoBarras=@CodigoBarras, CodigoBarrasBalanca=@CodigoBarrasBalanca, Nome=@Nome,Descricao=@Descricao, " +
                "PrecoCusto=@PrecoCusto, PrecoVenda = @PrecoVenda, MargemLucro=@MargemLucro,Desconto=@Desconto, Imagem = @Imagem," +
                " EstoqueAtual=@EstoqueAtual,EstoqueMin=@EstoqueMin,EstoqueMax=@EstoqueMax, UnidVenda=@UnidVenda, CategoriaId=@CategoriaId" +
                " WHERE Id =" + produto.Id;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcmd = new MySqlCommand(sql, conn);
                //objcmd.Parameters.Add("@Id", MySqlDbType.Int32, 11).Value = itemPedido;
                objcmd.Parameters.Add("@CodigoBarras", MySqlDbType.VarChar, 50).Value = produto.CodigoBarras;
                objcmd.Parameters.Add("@CodigoBarrasBalanca", MySqlDbType.Int32, 11).Value = produto.CodigoBarrasBalanca;
                objcmd.Parameters.Add("@Nome", MySqlDbType.VarChar, 50).Value = produto.Nome;
                objcmd.Parameters.Add("@Descricao", MySqlDbType.VarChar, 255).Value = produto.Descricao;
                objcmd.Parameters.Add("@PrecoCusto", MySqlDbType.Double, 8).Value = produto.PrecoCusto;
                objcmd.Parameters.Add("@PrecoVenda", MySqlDbType.Double, 8).Value = produto.PrecoVenda;
                objcmd.Parameters.Add("@MargemLucro", MySqlDbType.Double, 8).Value = produto.MargemLucro;
                objcmd.Parameters.Add("@Desconto", MySqlDbType.Double, 8).Value = produto.Desconto;
                objcmd.Parameters.Add("@Imagem", MySqlDbType.VarChar, 50).Value = produto.Imagem;
                objcmd.Parameters.Add("@EstoqueAtual", MySqlDbType.Int32, 11).Value = produto.EstoqueAtual;
                objcmd.Parameters.Add("@EstoqueMin", MySqlDbType.Int32, 11).Value = produto.EstoqueMin;
                objcmd.Parameters.Add("@EstoqueMax", MySqlDbType.Int32, 11).Value = produto.EstoqueMax;
                objcmd.Parameters.Add("@UnidVenda", MySqlDbType.VarChar, 20).Value = produto.UnidVenda;
                objcmd.Parameters.Add("@CategoriaId", MySqlDbType.Int32, 11).Value = produto.CategoriaId;
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

        public void Cadastrar(Produto produto)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "INSERT INTO `produtos` (`CodigoBarras`,`CodigoBarrasBalanca`, `Nome`, `Descricao`, `PrecoCusto`,`PrecoVenda`,`MargeMlucro`," +
                    "`Desconto`,  `Imagem`,`EstoqueAtual`,`EstoqueMin`,`EstoqueMax`,`UnidVenda`, `CategoriaId`) values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand(sql, conn);
                //objcmd.Parameters.Add("@Id", MySqlDbType.Int32, 11).Value = itemPedido;
                objcmd.Parameters.Add("@CodigoBarras", MySqlDbType.VarChar, 50).Value = produto.CodigoBarras;
                objcmd.Parameters.Add("@CodigoBarrasBalanca", MySqlDbType.Int32, 11).Value = produto.CodigoBarrasBalanca;
                objcmd.Parameters.Add("@Nome", MySqlDbType.VarChar, 50).Value = produto.Nome;
                objcmd.Parameters.Add("@Descricao", MySqlDbType.VarChar, 255).Value = produto.Descricao;
                objcmd.Parameters.Add("@PrecoCusto", MySqlDbType.Double, 8).Value = produto.PrecoCusto;
                objcmd.Parameters.Add("@PrecoVenda", MySqlDbType.Double, 8).Value = produto.PrecoVenda;
                objcmd.Parameters.Add("@MargemLucro", MySqlDbType.Double, 8).Value = produto.MargemLucro;
                objcmd.Parameters.Add("@Desconto", MySqlDbType.Double, 8).Value = produto.Desconto;
                objcmd.Parameters.Add("@Imagem", MySqlDbType.VarChar, 50).Value = produto.Imagem;
                objcmd.Parameters.Add("@EstoqueAtual", MySqlDbType.Int32, 11).Value = produto.EstoqueAtual;
                objcmd.Parameters.Add("@EstoqueMin", MySqlDbType.Int32, 11).Value = produto.EstoqueMin;
                objcmd.Parameters.Add("@EstoqueMax", MySqlDbType.Int32, 11).Value = produto.EstoqueMax;
                objcmd.Parameters.Add("@UnidVenda", MySqlDbType.VarChar, 20).Value = produto.UnidVenda;
                objcmd.Parameters.Add("@CategoriaId", MySqlDbType.Int32, 11).Value = produto.CategoriaId;


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

        public void DevolverProdutoAoEstoque(Pedido pedido)
        {
            //List<ProdutoItem> produtos = JsonConvert.DeserializeObject<List<ProdutoItem>>(pedido.DadosProdutos, new JsonSerializerSettings() { ContractResolver = new ProdutoItemResolver<List<ProdutoItem>>() });

            //foreach (var produto in produtos)
            //{
            //    Produto produtoDB = ObterProduto(produto.Id);
            //    produtoDB.Estoque += produto.UnidadesPedidas;

            //    Atualizar(produtoDB);
            //}
        }

        public void Excluir(int Id)
        {
            string sql = "DELETE FROM `produtos` WHERE Id = " + Id;
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

        public Produto ObterProduto(int Id)
        {
            Produto produto = new Produto();
            MySqlDataReader rdr;
            string sql = "SELECT * FROM `produtos` WHERE Id =" + Id;
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
                    produto.Id = Convert.ToInt32(rdr["Id"]);
                    produto.CodigoBarras = rdr["CodigoBarras"].ToString();
                    produto.CodigoBarrasBalanca = Convert.ToInt32(rdr["CodigoBarrasBalanca"]);
                    produto.Nome = rdr["Nome"].ToString();
                    produto.Descricao = rdr["Descricao"].ToString();
                    produto.PrecoCusto = Convert.ToDouble(rdr["PrecoCusto"]);
                    produto.PrecoVenda = Convert.ToDouble(rdr["PrecoVenda"]);
                    produto.MargemLucro = Convert.ToDouble(rdr["MargemLucro"]);
                    produto.Desconto = Convert.ToDouble(rdr["Desconto"]);
                    produto.Imagem = rdr["Imagem"].ToString();
                    produto.EstoqueAtual = Convert.ToInt32(rdr["EstoqueAtual"]);
                    produto.EstoqueMin = Convert.ToInt32(rdr["EstoqueMin"]);
                    produto.EstoqueMax = Convert.ToInt32(rdr["EstoqueMax"]);
                    produto.UnidVenda = rdr["UnidVenda"].ToString();
                    produto.CategoriaId = Convert.ToInt32(rdr["CategoriaId"]);
                }
                return produto;
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

        public Produto ObterProdutoPorCodigoBarras(string CodigoBarras)
        {
            Produto produto = new Produto();
            MySqlDataReader rdr;
            string sql = "SELECT * FROM `produtos` WHERE CodigoBarras = " + CodigoBarras;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                rdr = objcomand.ExecuteReader();
                //percorre o leitor 
                while (rdr.Read())
                {
                    produto.Id = Convert.ToInt32(rdr["Id"]);
                    produto.CodigoBarras = rdr["CodigoBarras"].ToString();
                    produto.CodigoBarrasBalanca = Convert.ToInt32(rdr["CodigoBarrasBalanca"]);
                    produto.Nome = rdr["Nome"].ToString();
                    produto.Descricao = rdr["Descricao"].ToString();
                    produto.PrecoCusto = Convert.ToDouble(rdr["PrecoCusto"]);
                    produto.PrecoVenda = Convert.ToDouble(rdr["PrecoVenda"]);
                    produto.MargemLucro = Convert.ToDouble(rdr["MargemLucro"]);
                    produto.Desconto = Convert.ToDouble(rdr["Desconto"]);
                    produto.Imagem = rdr["Imagem"].ToString();
                    produto.EstoqueAtual = Convert.ToInt32(rdr["EstoqueAtual"]);
                    produto.EstoqueMin = Convert.ToInt32(rdr["EstoqueMin"]);
                    produto.EstoqueMax = Convert.ToInt32(rdr["EstoqueMax"]);
                    produto.UnidVenda = rdr["UnidVenda"].ToString();
                    produto.CategoriaId = Convert.ToInt32(rdr["CategoriaId"]);
                }
                return produto;
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

        public Produto ObterProdutoPorCodigoBarrasBalanca(string CodigoBarrasBalanca)
        {
            Produto produto = new Produto();
            MySqlDataReader rdr;
            string sql = "SELECT * FROM `produtos_balanca` WHERE CodigoBarrasBalanca = " + CodigoBarrasBalanca;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                rdr = objcomand.ExecuteReader();
                //percorre o leitor 
                while (rdr.Read())
                {
                    produto.Id = Convert.ToInt32(rdr["Id"]);
                    produto.CodigoBarras = rdr["CodigoBarras"].ToString();
                    produto.CodigoBarrasBalanca = Convert.ToInt32(rdr["CodigoBarrasBalanca"]);
                    produto.Nome = rdr["Nome"].ToString();
                    produto.Descricao = rdr["Descricao"].ToString();
                    produto.PrecoCusto = Convert.ToDouble(rdr["PrecoCusto"]);
                    produto.PrecoVenda = Convert.ToDouble(rdr["PrecoVenda"]);
                    produto.MargemLucro = Convert.ToDouble(rdr["MargemLucro"]);
                    produto.Desconto = Convert.ToDouble(rdr["Desconto"]);
                    produto.Imagem = rdr["Imagem"].ToString();
                    produto.EstoqueAtual = Convert.ToInt32(rdr["EstoqueAtual"]);
                    produto.EstoqueMin = Convert.ToInt32(rdr["EstoqueMin"]);
                    produto.EstoqueMax = Convert.ToInt32(rdr["EstoqueMax"]);
                    produto.UnidVenda = rdr["UnidVenda"].ToString();
                    produto.CategoriaId = Convert.ToInt32(rdr["CategoriaId"]);
                }
                return produto;
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

        public List<Produto> ObterProdutoPorCategoria(int id)
        {
            throw new NotImplementedException();

            //return _banco.Produtos.OrderBy(a => a.Nome).Where(a => a.CategoriaId == id).ToList();
        }

        public DataTable ObterProdutos(string pesquisa)
        {
            DataTable returClientes = new DataTable();
            string sqlCliente = "SELECT * FROM `produtos` WHERE nome LIKE '" + pesquisa + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returClientes);
                return returClientes;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returClientes;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable ObterProdutosSimplificado(string pesquisa)
        {
            DataTable returClientes = new DataTable();
            string sqlCliente = "SELECT * FROM `busca_produtos_simplificada` WHERE nome LIKE '" + pesquisa + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returClientes);
                return returClientes;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returClientes;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable ObterProdutosSimplificadoBalanca(string pesquisa)
        {
            DataTable returClientes = new DataTable();
            string sqlCliente = "SELECT * FROM `busca_produtos_simplificada` WHERE `Codigo Barras` = 'NOT' AND nome LIKE '" + pesquisa + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returClientes);
                return returClientes;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returClientes;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable ObterTodosProdutos()
        {
            DataTable produtos = new DataTable();
            string sql = "SELECT * FROM `produtos`";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(produtos);
                return produtos;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return produtos;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public int QuantidadeTotalProdutos()
        {
            throw new NotImplementedException();
        }

        public int CalculaCodigoBalanca()
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "SELECT max(`CodigoBarrasBalanca`) FROM `produtos`";
                MySqlCommand obj = new MySqlCommand(sql, conn);
                int num = Convert.ToInt32(obj.ExecuteScalar());
                return num + 1;
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


        public List<Produto> ObterTodosProdutoDeBalanca()
        {
            List<Produto> produtos = new List<Produto>();

            MySqlDataReader rdr;
            string sql = "SELECT * FROM `produtos` WHERE CodigoBarras = 'NOT' ORDER BY `produtos`.`CodigoBarrasBalanca` ASC";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                rdr = objcomand.ExecuteReader();
                //percorre o leitor 
                while (rdr.Read())
                {
                    Produto produto = new Produto();
                    produto.Id = Convert.ToInt32(rdr["Id"]);
                    produto.CodigoBarras = rdr["CodigoBarras"].ToString();
                    produto.CodigoBarrasBalanca = Convert.ToInt32(rdr["CodigoBarrasBalanca"]);
                    produto.Nome = rdr["Nome"].ToString();
                    produto.Descricao = rdr["Descricao"].ToString();
                    produto.PrecoCusto = Convert.ToDouble(rdr["PrecoCusto"]);
                    produto.PrecoVenda = Convert.ToDouble(rdr["PrecoVenda"]);
                    produto.MargemLucro = Convert.ToDouble(rdr["MargemLucro"]);
                    produto.Desconto = Convert.ToDouble(rdr["Desconto"]);
                    produto.Imagem = rdr["Imagem"].ToString();
                    produto.EstoqueAtual = Convert.ToInt32(rdr["EstoqueAtual"]);
                    produto.EstoqueMin = Convert.ToInt32(rdr["EstoqueMin"]);
                    produto.EstoqueMax = Convert.ToInt32(rdr["EstoqueMax"]);
                    produto.UnidVenda = rdr["UnidVenda"].ToString();
                    produto.CategoriaId = Convert.ToInt32(rdr["CategoriaId"]);

                    produtos.Add(produto);

                }
                return produtos;
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









        //public Produto[] ObterProdutoDeBalanca()
        //{
        //    Produto produto = new Produto();
        //    DataTable dtProdutos = new DataTable();
        //    string sql = "SELECT * FROM `produtos` WHERE CodigoBarrasBalanca > 0 " ;
        //    try
        //    {
        //        MySqlConnection conn = Conect.obterConexao();
        //        MySqlCommand objcomand = new MySqlCommand(sql, conn);

        //        MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
        //        objadp.Fill(dtProdutos);
        //        Produto[] produtos = new Produto[dtProdutos.Rows.Count];
        //        //percorre o leitor 



        //            for (int i=0; i < dtProdutos.Rows.Count;i++)
        //            {
        //                produto.Id = Convert.ToInt32(dtProdutos.Rows[i]["Id"]);
        //                produto.CodigoBarras = dtProdutos.Rows[i]["CodigoBarras"].ToString();
        //                produto.CodigoBarrasBalanca = Convert.ToInt32(dtProdutos.Rows[i]["CodigoBarrasBalanca"]);
        //                produto.Nome = dtProdutos.Rows[i]["Nome"].ToString();
        //                produto.Descricao = dtProdutos.Rows[i]["Descricao"].ToString();
        //                produto.PrecoCusto = Convert.ToDouble(dtProdutos.Rows[i]["PrecoCusto"]);
        //                produto.PrecoVenda = Convert.ToDouble(dtProdutos.Rows[i]["PrecoVenda"]);
        //                produto.MargemLucro = Convert.ToDouble(dtProdutos.Rows[i]["MargemLucro"]);
        //                produto.Desconto = Convert.ToDouble(dtProdutos.Rows[i]["Desconto"]);
        //                produto.Imagem = dtProdutos.Rows[i]["Imagem"].ToString();
        //                produto.EstoqueAtual = Convert.ToInt32(dtProdutos.Rows[i]["EstoqueAtual"]);
        //                produto.EstoqueMin = Convert.ToInt32(dtProdutos.Rows[i]["EstoqueMin"]);
        //                produto.EstoqueMax = Convert.ToInt32(dtProdutos.Rows[i]["EstoqueMax"]);
        //                produto.UnidVenda = dtProdutos.Rows[i]["UnidVenda"].ToString();
        //                produto.CategoriaId = Convert.ToInt32(dtProdutos.Rows[i]["CategoriaId"]);

        //               Console.WriteLine(i.ToString());
        //                produtos[i] = produto;
        //            }

        //        for (int i = 0; i < dtProdutos.Rows.Count; i++)
        //        {

        //        }


        //            return produtos;
        //    }
        //    catch (Exception erro)
        //    {
        //        MessageBox.Show(erro.ToString());
        //        return null;
        //    }
        //    finally
        //    {
        //        Conect.fecharConexao();
        //    }

        //}
    }
}
