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
    public class FluxoCaixaRepository : IFluxoCaixaRepository
    {
       
        private List<double> listaValoresParciais = new List<double>();
        private List<double> listaValoresTotais = new List<double>();
        static string hoje = DateTime.Today.ToString("yyyy-MM-dd 00:00:00");
        private ICaixaRepository _caixaRepository = new CaixaRepository();
        private List<string> listaSQL = new List<string>();
        Caixa caixa;
        string sql_inicial_parcial, sql_vendas_dinheiro_parcial, sql_vendas_cartao_parcial, sql_vendas_prazo_parcial, sql_vendas_pix_parcial, sql_fornecedores_parcial, sql_funcionarios_parcial, sql_retiradas_parcial, sql_saidas_parcial;
        string sql_suprimentos_parcial, sql_recebimentos_parcial, sql_recebimentos_dinheiro_parcial, sql_recebimentos_cartao_parcial, sql_recebimentos_pix_parcial, sql_entradas_parcial, sql_outros_parcial;
        string sql_estornos_parcial, sql_gaveta_parcial, sql_estorno_vendas_dinheiro_parcial, sql_estorno_vendas_cartao_parcial, sql_estorno_vendas_prazo_parcial, sql_estorno_vendas_pix_parcial, sql_descontos_parcial;

        string sql_inicial_total, sql_vendas_dinheiro_total, sql_vendas_cartao_total, sql_vendas_prazo_total, sql_vendas_pix_total, sql_fornecedores_total, sql_funcionarios_total, sql_retiradas_total, sql_saidas_total;
        string sql_suprimentos_total, sql_recebimentos_total, sql_recebimentos_dinheiro_total, sql_recebimentos_cartao_total, sql_recebimentos_pix_total, sql_entradas_total, sql_outros_total;
        string sql_estornos_total, sql_gaveta_total, sql_estorno_vendas_dinheiro_total, sql_estorno_vendas_cartao_total, sql_estorno_vendas_prazo_total, sql_estorno_vendas_pix_total, sql_vendas_canceladas_total;

        public FluxoCaixaRepository()
        {
            caixa = _caixaRepository.ObterCaixa();
            string dataHora = caixa.DataHoraAbertura.ToString("yyyy-MM-dd HH:mm:ss");
            if (caixa.Aberto)
            {
                sql_inicial_parcial = "SELECT SUM(`Entrada`) FROM `FluxoCaixa` WHERE `TiposMovimentacao`='" + TiposMovimentacao.AberturaCaixa + "' AND `DataHora` >= '" + dataHora + "'";

                sql_vendas_dinheiro_parcial = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Dinheiro + "' AND DataHora > '" + dataHora + "'";
                sql_vendas_cartao_parcial = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Cartao + "' AND DataHora > '" + dataHora + "'";
                sql_vendas_prazo_parcial = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Prazo + "' AND DataHora > '" + dataHora + "'";
                sql_vendas_pix_parcial = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Pix + "' AND DataHora > '" + dataHora + "'";
                sql_fornecedores_parcial = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SaidaFornecedor + "' AND DataHora > '" + dataHora + "'";
                sql_funcionarios_parcial = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SaidaFuncionario + "' AND DataHora > '" + dataHora + "'";
                sql_retiradas_parcial = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.RetiradaDinheiro + "' AND DataHora > '" + dataHora + "'";
                sql_saidas_parcial = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE DataHora > '" + dataHora + "'";
                sql_suprimentos_parcial = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SuprimentoDinheiro + "' AND DataHora > '" + dataHora + "'";
                sql_recebimentos_parcial = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.RecebimentoCrediario + "' AND DataHora > '" + dataHora + "'";
                sql_recebimentos_dinheiro_parcial = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.RecebimentoCrediario + "' AND `FormaPagamento`= '" + FormaPagamento.Dinheiro + "' AND DataHora > '" + dataHora + "'";
                sql_recebimentos_cartao_parcial = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.RecebimentoCrediario + "' AND `FormaPagamento`= '" + FormaPagamento.Cartao + "' AND DataHora > '" + dataHora + "'";
                sql_recebimentos_pix_parcial = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.RecebimentoCrediario + "' AND `FormaPagamento`= '" + FormaPagamento.Pix + "' AND DataHora > '" + dataHora + "'";
                sql_entradas_parcial = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE FormaPagamento = '" + FormaPagamento.Dinheiro + "' AND DataHora > '" + dataHora + "'";
                sql_outros_parcial = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SaidaOutros + "' AND DataHora > '" + dataHora + "'";
                sql_estornos_parcial = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.Estorno + "' AND DataHora > '" + dataHora + "'";
                sql_gaveta_parcial = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE `FormaPagamento`= '" + FormaPagamento.Dinheiro + "' AND `DataHora` >= '" + dataHora + "'"; ;

                sql_estorno_vendas_dinheiro_parcial = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.Estorno + "' AND `FormaPagamento`= '" + FormaPagamento.Dinheiro + "' AND DataHora > '" + dataHora + "'";
                sql_estorno_vendas_cartao_parcial = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.Estorno + "' AND `FormaPagamento`= '" + FormaPagamento.Cartao + "' AND DataHora > '" + dataHora + "'";
                sql_estorno_vendas_prazo_parcial = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.Estorno + "' AND `FormaPagamento`= '" + FormaPagamento.Prazo + "' AND DataHora > '" + dataHora + "'";
                sql_estorno_vendas_pix_parcial = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.Estorno + "' AND `FormaPagamento`= '" + FormaPagamento.Pix + "' AND DataHora > '" + dataHora + "'";

                sql_descontos_parcial = "SELECT SUM(`Desconto`) FROM `pedido` WHERE DataHora > '" + dataHora + "'";
            }


            sql_inicial_total = "SELECT SUM(`Entrada`) FROM `FluxoCaixa` WHERE `TiposMovimentacao`='" + TiposMovimentacao.AberturaCaixa + "' AND `DataHora` >= '" + hoje + "'";
            sql_vendas_dinheiro_total = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Dinheiro + "' AND DataHora > '" + hoje + "'";
            sql_vendas_cartao_total = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Cartao + "' AND DataHora > '" + hoje + "'";
            sql_vendas_prazo_total = "SELECT sum(`debito`) FROM `crediario` WHERE DataHora > '" + hoje + "'";
            sql_vendas_pix_total = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Pix + "' AND DataHora > '" + hoje + "'";
            sql_fornecedores_total = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SaidaFornecedor + "' AND DataHora > '" + hoje + "'";
            sql_funcionarios_total = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SaidaFuncionario + "' AND DataHora > '" + hoje + "'";
            sql_retiradas_total = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.RetiradaDinheiro + "' AND DataHora > '" + hoje + "'";
            sql_suprimentos_total = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SuprimentoDinheiro + "' AND DataHora > '" + hoje + "'";
            sql_recebimentos_total = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.RecebimentoCrediario + "' AND DataHora > '" + hoje + "'";
            sql_recebimentos_dinheiro_total = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.RecebimentoCrediario + "' AND `FormaPagamento`= '" + FormaPagamento.Dinheiro + "' AND DataHora > '" + hoje + "'";
            sql_recebimentos_cartao_total = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.RecebimentoCrediario + "' AND `FormaPagamento`= '" + FormaPagamento.Cartao + "' AND DataHora > '" + hoje + "'";
            sql_recebimentos_pix_total = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.RecebimentoCrediario + "' AND `FormaPagamento`= '" + FormaPagamento.Pix + "' AND DataHora > '" + hoje + "'";
            sql_saidas_total = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE DataHora > '" + hoje + "'";
            sql_entradas_total = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE DataHora > '" + hoje + "'";
            sql_outros_total = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SaidaOutros + "' AND DataHora > '" + hoje + "'";
            sql_estornos_total = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.Estorno + "' AND DataHora > '" + hoje + "'";
            sql_gaveta_total = "SELECT SUM(`Entrada`) FROM `fluxocaixa` WHERE `FormaPagamento`= '" + FormaPagamento.Dinheiro + "' AND `DataHora` >= '" + hoje + "'"; ;
            sql_estorno_vendas_dinheiro_total = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.Estorno + "' AND `FormaPagamento`= '" + FormaPagamento.Dinheiro + "' AND DataHora > '" + hoje + "'";
            sql_estorno_vendas_cartao_total = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.Estorno + "' AND `FormaPagamento`= '" + FormaPagamento.Cartao + "' AND DataHora > '" + hoje + "'";
            sql_estorno_vendas_prazo_total = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.Estorno + "' AND `FormaPagamento`= '" + FormaPagamento.Prazo + "' AND DataHora > '" + hoje + "'";
            sql_estorno_vendas_pix_total = "SELECT SUM(`Saida`) FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.Estorno + "' AND `FormaPagamento`= '" + FormaPagamento.Pix + "' AND DataHora > '" + hoje + "'";
            sql_vendas_canceladas_total = "SELECT sum(`Valor`) FROM `pedido` WHERE `FormaPagamento` = '" + FormaPagamento.Nenhum + "' AND DataHora > '" + hoje + "'";

        }


        private DateTime ultimaAbertura()
        {
            
            return caixa.DataHoraAbertura;
        }

        public void Cadastrar(FluxoCaixa FluxoCaixa)
        {        
                try
                {
                    MySqlConnection conn = Conect.obterConexao();
                    string sql = "INSERT INTO `FluxoCaixa` (`Num_referencia`, `TiposMovimentacao`, `Descricao`, `FormaPagamento`, `Entrada`, `Saida`, `Gerente`,`Operador`) values(?, ?, ?, ?, ?, ?, ?, ?)";
                    //string de inserção na tabela 
                    MySqlCommand objcmd = new MySqlCommand(sql, conn);
                    objcmd.Parameters.Add("@Num_referencia", MySqlDbType.Int32, 11).Value = FluxoCaixa.Num_referencia;
                    objcmd.Parameters.Add("@Movimentacao", MySqlDbType.VarChar, 50).Value = FluxoCaixa.TiposMovimentacao;
                    objcmd.Parameters.Add("@Descricao", MySqlDbType.VarChar, 50).Value = FluxoCaixa.Descricao;
                    objcmd.Parameters.Add("@FormaPagamento", MySqlDbType.VarChar, 50).Value = FluxoCaixa.FormaPagamento;
                    objcmd.Parameters.Add("@Entrada", MySqlDbType.Double, 8).Value = FluxoCaixa.Entrada;
                    objcmd.Parameters.Add("@Saida", MySqlDbType.Double, 8).Value = FluxoCaixa.Saida;
                    objcmd.Parameters.Add("@Gerente", MySqlDbType.VarChar, 20).Value = FluxoCaixa.Gerente;
                    objcmd.Parameters.Add("@Operador", MySqlDbType.VarChar, 20).Value = FluxoCaixa.Operador;


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

        public void Estornar(FluxoCaixa FluxoCaixa)
        {
            throw new NotImplementedException();
        }

        public double ObterDescontos(Caixa caixa)
        {
            throw new NotImplementedException();
        }

        public List<double> ObterValoresParciais()
        {
            listaValoresParciais.Clear();
            listaSQL.Clear();

            MySqlConnection conn = Conect.obterConexao();

            //cria uma lista de string para guardar os SQLs  
            listaSQL.Add(sql_inicial_parcial);                  //0     1 9 11 
            listaSQL.Add(sql_vendas_dinheiro_parcial);          //1
            listaSQL.Add(sql_vendas_cartao_parcial);            //2   
            listaSQL.Add(sql_vendas_prazo_parcial);             //3
            listaSQL.Add(sql_vendas_pix_parcial);               //4
            listaSQL.Add(sql_fornecedores_parcial);             //5
            listaSQL.Add(sql_funcionarios_parcial);             //6
            listaSQL.Add(sql_retiradas_parcial);                //7
            listaSQL.Add(sql_saidas_parcial);                   //8
            listaSQL.Add(sql_suprimentos_parcial);              //9
            listaSQL.Add(sql_recebimentos_parcial);             //10
            listaSQL.Add(sql_recebimentos_dinheiro_parcial);    //11
            listaSQL.Add(sql_recebimentos_cartao_parcial);      //12
            listaSQL.Add(sql_recebimentos_pix_parcial);         //13
            listaSQL.Add(sql_entradas_parcial);                 //14
            listaSQL.Add(sql_estornos_parcial);                 //15
            listaSQL.Add(sql_outros_parcial);                   //16

            listaSQL.Add(sql_estorno_vendas_dinheiro_parcial);  //17
            listaSQL.Add(sql_estorno_vendas_cartao_parcial);    //18
            listaSQL.Add(sql_estorno_vendas_prazo_parcial);     //19
            listaSQL.Add(sql_estorno_vendas_pix_parcial);       //20 
            
            listaSQL.Add(sql_gaveta_parcial);                 //21 
            listaSQL.Add(sql_descontos_parcial);                 //22


            if (caixa.Aberto)
            {
                //percorre a lista SQLs realizando consultas e guardando os resultados em outra list de "doubles"
                for (int i = 0; i < 23; i++)
                {
                    MySqlCommand objMysql = new MySqlCommand(listaSQL[i], conn);
                    var result = objMysql.ExecuteScalar();

                    if (result == DBNull.Value)
                    {

                        listaValoresParciais.Add(0);
                    }
                    else
                    {
                        listaValoresParciais.Add(Convert.ToDouble(result));
                    }

                }
            }
            else
            {
                for (int i = 0; i < 23; i++)
                {listaValoresParciais.Add(0);
                }
                listaValoresParciais[21] = caixa.fundoCaixa;
            }

      

            return listaValoresParciais;
        }

        public List<double> ObterValoresTotais()
        {
            listaValoresTotais.Clear();
            listaSQL.Clear();
            MySqlConnection conn = Conect.obterConexao();

            //cria uma lista de string para guardar os SQLs  
            listaSQL.Add(sql_inicial_total);                  //0
            listaSQL.Add(sql_vendas_dinheiro_total);          //1
            listaSQL.Add(sql_vendas_cartao_total);            //2   
            listaSQL.Add(sql_vendas_prazo_total);             //3
            listaSQL.Add(sql_vendas_pix_total);               //4
            listaSQL.Add(sql_fornecedores_total);             //5
            listaSQL.Add(sql_funcionarios_total);             //6
            listaSQL.Add(sql_retiradas_total);                //7
            listaSQL.Add(sql_saidas_total);                   //8
            listaSQL.Add(sql_suprimentos_total);              //9
            listaSQL.Add(sql_recebimentos_total);             //10
            listaSQL.Add(sql_recebimentos_dinheiro_total);    //11
            listaSQL.Add(sql_recebimentos_cartao_total);      //12
            listaSQL.Add(sql_recebimentos_pix_total);         //13
            listaSQL.Add(sql_entradas_total);                 //14
            listaSQL.Add(sql_estornos_total);                 //15
            listaSQL.Add(sql_outros_total);                   //16

            listaSQL.Add(sql_estorno_vendas_dinheiro_total);  //17
            listaSQL.Add(sql_estorno_vendas_cartao_total);    //18
            listaSQL.Add(sql_estorno_vendas_prazo_total);     //19
            listaSQL.Add(sql_estorno_vendas_pix_total);       //20 

            listaSQL.Add(sql_gaveta_total);                 //21 
            listaSQL.Add(sql_vendas_canceladas_total);                 //22



            //percorre a lista SQLs realizando consultas e guardando os resultados em outra list de "doubles"
            for (int i = 0; i < 23; i++)
            {
                MySqlCommand objMysql = new MySqlCommand(listaSQL[i], conn);
                var result = objMysql.ExecuteScalar();

                if (result == DBNull.Value)
                {

                    listaValoresTotais.Add(0);
                }
                else
                {
                    listaValoresTotais.Add(Convert.ToDouble(result));
                }

            }

            return listaValoresTotais;
        }


        public double SaldoGaveta()
        {
            List<double> ValoresParciais = ObterValoresParciais();
            return ValoresParciais[21] - (ValoresParciais[5] + ValoresParciais[6] + ValoresParciais[7] + ValoresParciais[17]);

            //21 - 5 6 7 15

        }


        public FluxoCaixa ObterFluxoCaixa(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable ObterFluxoCaixaPorMovimentacao(string sql)
        {
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

        public double ObterUltimoSaldoInicial()
        {
            double valor = 0;
            string SQL = "SELECT `Entrada` FROM `fluxocaixa` WHERE `TiposMovimentacao`='AberturaCaixa' ORDER BY Id DESC LIMIT 1";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objMysql = new MySqlCommand(SQL, conn);
                valor = Convert.ToDouble(objMysql.ExecuteScalar());
                return valor;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return valor;
            }
        }
    }
}
