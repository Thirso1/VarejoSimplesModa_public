using VarejoSimplesModa.Enums;
using VarejoSimplesModa.Library;
using VarejoSimplesModa.Model;
using VarejoSimplesModa.Repository;
using VarejoSimplesModa.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Vip.Printer;
using Vip.Printer.Enums;

namespace VarejoSimplesModa.View
{
    public partial class FrmDetalhesRelatorioVendas : Form
    {
        static string hoje = DateTime.Today.ToString("yyyy-MM-dd 00:00:00");

        private TipoConsultaFluxoCaixa _tipoConsultaFluxoCaixa;
        IFluxoCaixaRepository _fluxoCaixaRepository = new FluxoCaixaRepository();
        IItemPedidoRepository _itemPedidoRepository = new ItemPedidoRepository();
        private ICaixaRepository _caixa = new CaixaRepository();
        private Caixa caixa = new Caixa();

        IPedidoRepository _pedidoRepository = new PedidoRepository();
        private DataTable dtDetalhes = new DataTable();
        private bool dgDetalhesFluxoCaixaClicado = false;
        private int idVenda;
        public static bool ConfirmacaoMensagem = false;
        private FrmRelatorioVendas _frmRelatorioVendas;
        private Pedido pedido;



        private string sql_inicial = "SELECT * FROM `fluxocaixa` WHERE `TiposMovimentacao`='" + TiposMovimentacao.AberturaCaixa + "' AND `DataHora` > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
        private string sql_vendas_dinheiro = "SELECT * FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Dinheiro + "' AND DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
        private string sql_vendas_cartao = "SELECT * FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Cartao + "' AND DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
        private string sql_vendas_prazo = "SELECT * FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Prazo + "' AND DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
        private string sql_vendas_pix = "SELECT * FROM `fluxocaixa` WHERE(TiposMovimentacao = '" + TiposMovimentacao.VendaBalcao + "' OR TiposMovimentacao = '" + TiposMovimentacao.VendaComanda + "' or TiposMovimentacao = '" + TiposMovimentacao.VendaEncomenda + "') AND `FormaPagamento`= '" + FormaPagamento.Pix + "' AND DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";

        private string sql_fornecedores = "SELECT * FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SaidaFornecedor + "' AND DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
        private string sql_outros = "SELECT * FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SaidaOutros + "' AND DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
        private string sql_funcionarios = "SELECT * FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SaidaFuncionario + "' AND DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
        private string sql_retiradas = "SELECT * FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.RetiradaDinheiro + "' AND DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
        private string sql_saidas = "SELECT * FROM `fluxocaixa` WHERE `Saida` != 0 AND DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
        private string sql_suprimentos = "SELECT * FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.SuprimentoDinheiro + "' AND DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
        private string sql_recebimentos = "SELECT * FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.RecebimentoCrediario + "' AND DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
        private string sql_estornos = "SELECT * FROM `fluxocaixa` WHERE TiposMovimentacao = '" + TiposMovimentacao.Estorno + "' AND DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
        private string sql_entradas = "SELECT * FROM `fluxocaixa` WHERE `Entrada` != 0 AND DataHora > '" + hoje + "'";
        private string sql_tudo = "SELECT * FROM `fluxocaixa` WHERE  DataHora > '" + hoje + "' ORDER BY `fluxocaixa`.`DataHora` ASC";
        private string sql_vendas_canceladas = "SELECT * FROM `pedido` WHERE `FormaPagamento` = '"+FormaPagamento.Nenhum+"' AND DataHora > '" + hoje + "'";


        public FrmDetalhesRelatorioVendas(FrmRelatorioVendas frmRelatorioVendas, TipoConsultaFluxoCaixa tipoConsultaFluxoCaixa)
        {
            InitializeComponent();
            _frmRelatorioVendas = frmRelatorioVendas;
            _tipoConsultaFluxoCaixa = tipoConsultaFluxoCaixa;
            caixa = _caixa.ObterCaixa();
        }

        private void FrmDetalhesRelatorioVendas_Load(object sender, EventArgs e)
        {
            switch (_tipoConsultaFluxoCaixa)
            {
                case TipoConsultaFluxoCaixa.VendasDinheiro:
                    this.Text = "Vendas à Dinheiro";
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_vendas_dinheiro);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaEstornoVendas();
                    dgDetalhesFluxoCaixa.ClearSelection();
                    break;
                case TipoConsultaFluxoCaixa.VendasCartao:
                    this.Text = "Vendas à Cartão";
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_vendas_cartao);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaEstornoVendas();
                    dgDetalhesFluxoCaixa.ClearSelection();
                    break;
                case TipoConsultaFluxoCaixa.VendasPrazo:
                    this.Text = "Vendas à Prazo";
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_vendas_prazo);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaEstornoVendas(); 
                    dgDetalhesFluxoCaixa.ClearSelection();
                    break;
                case TipoConsultaFluxoCaixa.VendasPix:
                    this.Text = "Vendas por Pix";
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_vendas_pix);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaEstornoVendas();
                    dgDetalhesFluxoCaixa.ClearSelection();
                    break;
                case TipoConsultaFluxoCaixa.TotalEstornos:
                    this.Text = "Vendas Estornadas";
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_estornos);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaVermelhas();
                    dgDetalhesFluxoCaixa.ClearSelection();
                    break;
                case TipoConsultaFluxoCaixa.VendasCanceladas:
                    this.Text = "Vendas Canceladas";
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_vendas_canceladas);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    ColoreLinhaVermelhas();
                    dgDetalhesFluxoCaixa.ClearSelection();
                    break;
                case TipoConsultaFluxoCaixa.TodasEntradas:
                    dtDetalhes = _fluxoCaixaRepository.ObterFluxoCaixaPorMovimentacao(sql_vendas_canceladas);
                    dgDetalhesFluxoCaixa.DataSource = dtDetalhes;
                    break;

            }
            disableBotoes();
        }

        private void ColoreLinhaEstornoVendas()
        {

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

        }

        private void dgDetalhesFluxoCaixa_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnDetalhar_Click_1(object sender, EventArgs e)
        {
            FrmDetalhesVenda frm = new FrmDetalhesVenda(idVenda);
            frm.ShowDialog();
        }

        private void btnEstornar_Click_1(object sender, EventArgs e)
        {
            pedido = _pedidoRepository.ObterPedido(idVenda);

            if (pedido.StatusPedido != StatusPedido.Estornado)
            {

                string msg1 = "Deseja Estornar essa Venda? ";
                string msg2 = "";
                FrmMensagens frmMensagens3 = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.FrmDetalhesRelatorioVendas);
                frmMensagens3.ShowDialog();

                if (ConfirmacaoMensagem)
                {
                    pedido.StatusPedido = StatusPedido.Estornado;

                    _pedidoRepository.Atualizar(pedido);

                    FluxoCaixa fluxoCaixa = new FluxoCaixa(idVenda, TiposMovimentacao.Estorno, "", pedido.FormaPagamento, 0, pedido.Valor, caixa.gerente.Nome, caixa.operador.Nome);

                    _fluxoCaixaRepository.Cadastrar(fluxoCaixa);
                    _frmRelatorioVendas.preencheValores();
                    ConfirmacaoMensagem = false;
                }
            }
            else
            {
                MessageBox.Show("Essa Venda já foi estornada!");
            }
        }

        private void dgDetalhesFluxoCaixa_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dgDetalhesFluxoCaixaClicado = true;
            enableBotoes();
            int indice = dgDetalhesFluxoCaixa.CurrentRow.Index;
            idVenda = Convert.ToInt32(dgDetalhesFluxoCaixa.Rows[indice].Cells[1].Value);
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            ImprimeVenda imprime = new ImprimeVenda(idVenda);
            imprime.imprimeVenda();
        }
    }
}
