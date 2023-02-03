using VarejoSimplesModa.Enums;
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
    public partial class FrmDetalhesFluxoCaixa : Form
    {
        static string hoje = DateTime.Today.ToString("yyyy-MM-dd 00:00:00");

        private TipoConsultaFluxoCaixa _tipoConsultaFluxoCaixa;
        IFluxoCaixaRepository _fluxoCaixaRepository = new FluxoCaixaRepository();
        private ICaixaRepository _caixa = new CaixaRepository();
        private Caixa caixa = new Caixa();
        string dataHora = "";
        IPedidoRepository _pedidoRepository = new PedidoRepository();
        private DataTable dtDetalhes = new DataTable();
        private bool dgDetalhesFluxoCaixaClicado = false;
        private int idVenda;
        public static bool ConfirmacaoMensagem = false;
        private FrmStatusCaixa _frmStatusCaixa;



        private string sql_inicial, sql_vendas_dinheiro, sql_vendas_cartao, sql_vendas_prazo, sql_vendas_pix, sql_fornecedores, sql_outros, sql_funcionarios, sql_retiradas,sql_saidas, sql_suprimentos, sql_recebimentos, sql_estornos, sql_entradas, sql_tudo;

        public FrmDetalhesFluxoCaixa(FrmStatusCaixa frmStatusCaixa, TipoConsultaFluxoCaixa tipoConsultaFluxoCaixa)
        {
            InitializeComponent();
            _frmStatusCaixa = frmStatusCaixa;
            _tipoConsultaFluxoCaixa = tipoConsultaFluxoCaixa;
            caixa = _caixa.ObterCaixa();
            dataHora = caixa.DataHoraAbertura.ToString("yyyy-MM-dd HH:mm:ss");
         sql_inicial = "SELECT * FROM `fluxocaixa` WHERE `TiposMovimentacao`='" + TiposMovimentacao.AberturaCaixa + "' AND `DataHora` >= '" + dataHora + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
         sql_vendas_dinheiro = "SELECT * FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Dinheiro + "' AND DataHora > '" + dataHora + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
         sql_vendas_cartao = "SELECT * FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Cartao + "' AND DataHora > '" + dataHora + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
         sql_vendas_prazo = "SELECT * FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Prazo + "' AND DataHora > '" + dataHora + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
         sql_vendas_pix = "SELECT * FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Pix + "' AND DataHora > '" + dataHora + "' ORDER BY `fluxocaixa`.`DataHora` ASC";

         sql_fornecedores = "SELECT * FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SaidaFornecedor + "' AND DataHora > '" + dataHora + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
         sql_outros = "SELECT * FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SaidaOutros + "' AND DataHora > '" + dataHora + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
         sql_funcionarios = "SELECT * FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SaidaFuncionario + "' AND DataHora > '" + dataHora + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
         sql_retiradas = "SELECT * FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.RetiradaDinheiro + "' AND DataHora > '" + dataHora + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
         sql_saidas = "SELECT * FROM `fluxocaixa` WHERE `Saida` != 0 AND DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
         sql_suprimentos = "SELECT * FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SuprimentoDinheiro + "' AND DataHora > '" + dataHora + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
         sql_recebimentos = "SELECT * FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.RecebimentoCrediario + "' AND DataHora > '" + dataHora + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
         sql_estornos = "SELECT * FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.Estorno + "' AND DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
         sql_entradas = "SELECT * FROM `fluxocaixa` WHERE `Entrada` != 0 AND DataHora > '" + dataHora + "'";
         sql_tudo = "SELECT * FROM `fluxocaixa` WHERE  DataHora > '" + dataHora + "' ORDER BY `fluxocaixa`.`DataHora` ASC";

    }

    private void ColoreLinhaEstornoVendas()        {

            for (int i = 0; i < dgDetalhesFluxoCaixa.Rows.Count; i++)
            {
                Pedido pedido = _pedidoRepository.ObterPedido(Convert.ToInt32(dgDetalhesFluxoCaixa.Rows[i].Cells[1].Value));
                if (pedido.StatusPedido == StatusPedido.Estornado)
                {
                    dtDetalhes.Rows[i][3] = "Venda Estornada";
                    dgDetalhesFluxoCaixa.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        private void ColoreLinhaVermelhas()
        {

            for (int i = 0; i < dgDetalhesFluxoCaixa.Rows.Count; i++)
            {
                if (dgDetalhesFluxoCaixa.Rows[i].Cells[6].Value.ToString() != "0")
                {
                    dgDetalhesFluxoCaixa.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        public void FrmDetalhesFluxoCaixa_Load(object sender, EventArgs e)
        {
            switch (_tipoConsultaFluxoCaixa)
            {
                case TipoConsultaFluxoCaixa.SaldoInicial:
                    dtDetalhes =  _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_inicial);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    break;
                case TipoConsultaFluxoCaixa.VendasDinheiro:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_vendas_dinheiro);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaEstornoVendas();
                    break;
                case TipoConsultaFluxoCaixa.VendasCartao:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_vendas_cartao);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaEstornoVendas();
                    break;
                case TipoConsultaFluxoCaixa.VendasPrazo:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_vendas_prazo);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaEstornoVendas();
                    break;
                case TipoConsultaFluxoCaixa.VendasPix:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_vendas_pix);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaEstornoVendas();
                    break;
                case TipoConsultaFluxoCaixa.PagFornecedores:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_fornecedores);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaVermelhas();
                    break;
                case TipoConsultaFluxoCaixa.PagFuncionarios:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_funcionarios);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaVermelhas();
                    break;
                case TipoConsultaFluxoCaixa.RetiradasDinheito:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_retiradas);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaVermelhas();
                    break;
                case TipoConsultaFluxoCaixa.TodasSaidas:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_saidas);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaVermelhas();
                    break;
                case TipoConsultaFluxoCaixa.SuprimentosDinheiro:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_suprimentos);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    break;
                case TipoConsultaFluxoCaixa.RecCrediario:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_recebimentos);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    break;
                case TipoConsultaFluxoCaixa.PagOutros:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_outros);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaVermelhas();
                    break;
                case TipoConsultaFluxoCaixa.TotalEstornos:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_estornos);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaVermelhas();
                    break;
                case TipoConsultaFluxoCaixa.Tudo:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_tudo);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaVermelhas();
                    break;
                case TipoConsultaFluxoCaixa.TodasEntradas:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_entradas);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    break;

            }
            disableBotoes();
        }

        private void disableBotoes()
        {
            btnDetalhar.Enabled = false;
            btnEstornar.Enabled = false;
            btnReimprimir.Enabled = false;
        }

        private void enableBotoes()
        {
            switch (_tipoConsultaFluxoCaixa)
            {
                case TipoConsultaFluxoCaixa.VendasDinheiro:
                case TipoConsultaFluxoCaixa.VendasCartao:
                case TipoConsultaFluxoCaixa.VendasPrazo:
                case TipoConsultaFluxoCaixa.VendasPix:
                btnDetalhar.Enabled = true;
                btnEstornar.Enabled = true;
                btnReimprimir.Enabled = true;
                    break;
                case TipoConsultaFluxoCaixa.Tudo:
                    btnDetalhar.Enabled = true;
                    break;
             }

        }

        private void FrmDetalhesFluxoCaixa_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyValue == 27)
                {
                    this.Close();
                }
            
        }

        private void dgDetalhesFluxoCaixa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgDetalhesFluxoCaixaClicado = true;
            enableBotoes();
            int indice = dgDetalhesFluxoCaixa.CurrentRow.Index;
            idVenda = Convert.ToInt32(dgDetalhesFluxoCaixa.Rows[indice].Cells[1].Value);

        }

        private void dgDetalhesFluxoCaixa_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgDetalhesFluxoCaixaClicado == false)
            {
                dgDetalhesFluxoCaixa.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgDetalhesFluxoCaixa.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void btnEstornar_Click(object sender, EventArgs e)
        {
            Pedido pedido = _pedidoRepository.ObterPedido(idVenda);

            if(pedido.StatusPedido != StatusPedido.Estornado)
            {
                pedido.StatusPedido = StatusPedido.Estornado;

                string msg1 = "Deseja Estornar essa Venda? ";
                string msg2 = "";
                FrmMensagens frmMensagens3 = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.FrmDetalhesFluxoCaixa);
                frmMensagens3.ShowDialog();

                if (ConfirmacaoMensagem)
                {
                    _pedidoRepository.Atualizar(pedido);

                    FluxoCaixa fluxoCaixa = new FluxoCaixa(idVenda, TiposMovimentacao.Estorno, "", pedido.FormaPagamento, 0, pedido.Valor, caixa.gerente.Nome,caixa.operador.Nome);

                    _fluxoCaixaRepository.Cadastrar(fluxoCaixa);
                    _frmStatusCaixa.preencheValoresParciais();
                    ConfirmacaoMensagem = false;
                }
            }
            else
            {
                MessageBox.Show("Essa Venda já foi estornada!");
            }
        }

        private void btnDetalhar_Click(object sender, EventArgs e)
        {
            FrmDetalhesVenda frm = new FrmDetalhesVenda(idVenda);
            frm.ShowDialog();
        }
    }
}
