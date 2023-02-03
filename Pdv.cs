using VarejoSimplesModa.Pagamento;
using VarejoSimplesModa.Enums;
using VarejoSimplesModa.Library;
using VarejoSimplesModa.Model;
using VarejoSimplesModa.Repository;
using VarejoSimplesModa.Repository.RepositoryInterfaces;
using VarejoSimplesModa.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VarejoSimplesModa
{
    public partial class Pdv : Form
    {
        private Pedido pedidoCorrente = new Pedido();
        private DataTable itens = new DataTable();
        private DataTable dtConsultaProduto = new DataTable();
        private double total;
        public double desconto;
        public bool PagamentoConfirmado = false;
        public bool ConfirmacaoMensagem = false;
        private int NumeroVenda = 1;
        private bool dgBuscaProdutoClicado = false;
        private TiposMovimentacao ComandaOuBalcao;
        private IPedidoRepository _pedidoRepository = new PedidoRepository();
        private IItemPedidoRepository _itempedidoRepository = new ItemPedidoRepository();
        private IProdutoRepository _produtoRepository = new ProdutoRepository();
        private FinalizaPedido finalizaPedido = new FinalizaPedido();
        private ICaixaRepository _caixa = new CaixaRepository();
        private IItemRapidoRepository _itemRapidoRepository = new ItemRapidoRepository();
        private List<Button> buttons = new List<Button>();

        private ItemRapido[] itemRapidos = new ItemRapido[16];

        //todo modificar usuario
        Usuario gerente = new Usuario();
        Usuario operador = new Usuario();


        //padrao Singleton
        private static Pdv instance = null;
        //
        // Construtor
        //
        private Pdv()
        {
            InitializeComponent();
        }

        //padrao Singleton
        public static Pdv Instance
        {
            get
            { 
                if(instance == null)
                {
                    instance = new Pdv();
                }

                    return instance;                
            }
        }

        //
        // Eventos
        //
        private void Pdv_Load(object sender, EventArgs e)
        {
            
            this.Text = "Itamogi - " + (DateTime.Now.ToString("dddd", new CultureInfo("pt-BR"))) + " " + (DateTime.Now.ToString("dd", new CultureInfo("pt-BR"))) + " de " + (DateTime.Now.ToString("MMMM", new CultureInfo("pt-BR"))) + " de " + (DateTime.Now.ToString("yyyy", new CultureInfo("pt-BR")));


            //carrega os botoes 'itens rapidos'
            carregaItensRapidosDoBanco();

            gerente = _caixa.ObterCaixa().gerente;
            operador = _caixa.ObterCaixa().operador;

            interligaBotoes();
            carregaBotoes();

            itens.Columns.Add("Id");
            itens.Columns.Add("ProdutoId");
            itens.Columns.Add("PedidoId");
            itens.Columns.Add("Nome");
            itens.Columns.Add("Preco");
            itens.Columns.Add("Qtde");
            itens.Columns.Add("Desconto");
            itens.Columns.Add("SubTotal");

            ProcessaInstanciaPedido();
            NumeroVenda = _pedidoRepository.ObterPedidosPorDia();
            if(NumeroVenda == 0)
            {
                NumeroVenda += 1;
            }
            textNumVenda.Text = "N°" + NumeroVenda.ToString();
            lblValTotal.Text = "0,00";
            lblOperador.Text = "Operador: " + operador.Nome;
            textCodProd.Select();
        }

        public void maximizaTela()
        {
            this.WindowState = FormWindowState.Maximized;
        }
        public void carregaItensRapidosDoBanco()
        {
            itemRapidos = _itemRapidoRepository.buscaItemRapidos();
        }

        public void interligaBotoes()
        {
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
            buttons.Add(button11);
            buttons.Add(button12);
            buttons.Add(button13);
            buttons.Add(button14);
            buttons.Add(button15);
            //buttons.Add(button16);

        }
        public void carregaBotoes()
        {
            
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Text = itemRapidos[i].Nome;

                //coloco atributo 'corFundo' num array de strings
                string[] corFundoStr = itemRapidos[i].CorFundo.Split(',');
                //converte para array de inteiros
                int[] corFundoInt = Array.ConvertAll(corFundoStr, s => int.Parse(s));
                //adicio a cor de fundo ao botao 
                buttons[i].BackColor = Color.FromArgb(corFundoInt[0], corFundoInt[1], corFundoInt[2], corFundoInt[3]);

                string[] corFontStr = itemRapidos[i].CorFonte.Split(',');
                int[] corFontInt = Array.ConvertAll(corFontStr, s => int.Parse(s));
                buttons[i].ForeColor = Color.FromArgb(corFontInt[0], corFontInt[1], corFontInt[2], corFontInt[3]);
            }

        }
        private void textCodProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                dgBuscaProduto.Visible = false;
               


            }
                //ao clicar na tecla ENTER
                if (e.KeyChar == 13)
            {
                if(textCodProd.Text != "")
                {
                    verificaTextoNumero(textCodProd.Text);
                    dgBuscaProduto.BringToFront();
                    //panel9.Visible = false;
                    //panel8.Visible = false;
                    //panel7.Visible = false;
                }
            }
        }
        //
        // Métodos
        //

        private void verificaTextoNumero(string codigoOuTexto)
        {
            //verifica se é texto ou numeros
            if (VerificaString.verificaString(codigoOuTexto))
            {
                dgBuscaProdutoClicado = false;
                dtConsultaProduto = _produtoRepository.ObterProdutosSimplificado(codigoOuTexto);
                dgBuscaProduto.DataSource = dtConsultaProduto;
                dgBuscaProduto.Visible = true;
            }
            else
            {
                //verifica o tamanho dos codigos de barras
                switch (codigoOuTexto.Length)
                {
                    case 13:
                        VerificaItemDeBalança(codigoOuTexto);
                        break;
                    case 12:
                    case 14:
                    case 8:
                    case 7:
                    case 6:
                    //case 5:
                    case 4:
                    case 3:
                    case 2:
                    case 1:
                        Produto produto = _produtoRepository.ObterProdutoPorCodigoBarras(codigoOuTexto);
                        if(produto.Id != 0)
                        {
                            produto = verificaImagemProduto(produto);
                            montaItemPedido(produto, produto.PrecoVenda, CalculaQtde());
                        }
                        else
                        {
                            MessageBox.Show("Produto não cadastrado!");
                            limpaTextCodProduto();
                        }
                        break;
                    //case 7:
                    //    FrmValorDiverso frmValorDiverso = new FrmValorDiverso();
                    //    frmValorDiverso.ShowDialog();
                    //    break;
                    case 5:
                        LeituraComanda(codigoOuTexto);
                        break;
                        //default:
                        //    MessageBox.Show("Código de barras inválido!");
                        //    break;
                }
            }
        }

        private void ProcessaInstanciaPedido()
        {
            PagamentoConfirmado = false;
            desconto = 0;
            int ultimoId = _pedidoRepository.RetornaUltimoId();

            //verificar se pedido com status finalizado ou iniciado
            Pedido ultimoPedido = _pedidoRepository.ObterPedido(ultimoId);
            //se iniciado, verificar se existem itens 
            switch (ultimoPedido.StatusPedido)
            {
                case StatusPedido.Finalizado:
                case StatusPedido.Cancelado:
                    pedidoCorrente.Id = ultimoId + 1;
                    NumeroVenda += 1;
                    GerarNovoPedido(pedidoCorrente.Id);
                    ModoComanda(false, "");
                    break;
                case StatusPedido.Iniciado:
                    //verificar se é comanda ou falha(como queda de energia)
                    if (ultimoPedido.Comanda > 0)
                    {
                        pedidoCorrente.Id = ultimoId + 1;
                        NumeroVenda += 1;
                        GerarNovoPedido(pedidoCorrente.Id);
                        ModoComanda(false, "");
                    }
                    else if (ultimoPedido.Comanda == 0)
                    {
                        //se nao for comand e existirem itens, carregar na grid
                        itens = _itempedidoRepository.ConsultaTodos(ultimoId);
                        if (itens.Rows.Count > 0)
                        {
                            string msg1 = "Existe venda em andamento!";
                            string msg2 = "";
                            FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.Ok, msg1, msg2, TiposForms.Pdv);
                            frmMensagens.ShowDialog();
                            ConfirmacaoMensagem = false;

                            pedidoCorrente.Id = ultimoId;
                            CarregaGridItensPedidoBanco(itens);
                            AtualizaTotal();
                            limpaTextCodProduto();

                        }
                        else
                        {
                            pedidoCorrente = ultimoPedido;
                        }
                        ModoComanda(false, "");
                    }
                    break;
                case StatusPedido.Suspenso:
                    pedidoCorrente.Id = ultimoId + 1;
                    NumeroVenda += 1;
                    GerarNovoPedido(pedidoCorrente.Id);
                    ModoComanda(false, "");
                    break;
            }

        }

        private int GerarNovoPedido(int idPedido)
        {
            Pedido pedido = new Pedido();
            pedido.Id = idPedido;
            pedido.NumVendaDoDia = NumeroVenda;
            pedido.ClienteId = 0;
            pedido.UsuarioId = 0;
            pedido.Valor = 0.00;
            pedido.Desconto = 0.00;
            pedido.Comanda = 0;
            pedido.FormaPagamento = FormaPagamento.Dinheiro;
            pedido.StatusPedido = StatusPedido.Iniciado;
            //pedido.DataHora;

            //retorna um inteiro com o numero de linhar afetadas no banco de dados
            return _pedidoRepository.Cadastrar(pedido);
        }

        private void CarregaGridItensPedidoBanco(DataTable itens)
        {
            dgListaItensPedido.DataSource = itens;
            if (dgListaItensPedido.Rows.Count > 0)
            {
                dgListaItensPedido.Rows[0].Selected = false;
            }
        }

        private void VerificaItemDeBalança(string codigoBarras)
        {
            string primeiroCaracter = codigoBarras.Substring(0, 1);
            if (primeiroCaracter == "2")
            {
                double qtde;
                string codigoProduto = codigoBarras.Substring(1, 6);//0 000000 000000
               
                Produto produto = buscaProdutoPorCodBarrasBalanca(codigoProduto);
                if (codigoProduto == "000000")
                {
                    string precoString = codigoBarras.Substring(7, 5);//000000 000000 0
                    
                    double precoDouble = Convert.ToDouble(precoString) / 100;

                    qtde = 1;
                    montaItemPedido(produto, precoDouble, qtde);
                }
                else
                {
                    if (produto.UnidVenda == "KG")
                    {
                        string precoString = codigoBarras.Substring(7, 5);//000000 000000 0
                        double precoDouble = Convert.ToDouble(precoString) / 100;

                        qtde = precoDouble / produto.PrecoVenda;
                        montaItemPedido(produto, produto.PrecoVenda, qtde);
                    }
                    else if (produto.UnidVenda == "UN")
                    {
                        qtde = 1;
                        montaItemPedido(produto, produto.PrecoVenda, qtde);
                    }
                }

              
            }
            else
            {
                Produto produto = buscaProdutoPorCodBarras(codigoBarras);
                if (produto != null)
                {
                    montaItemPedido(produto, produto.PrecoVenda, CalculaQtde());
                }
            }
        }

        private Produto buscaProdutoPorCodBarras(string codigoProduto)
        {
            Produto produto = _produtoRepository.ObterProdutoPorCodigoBarras(codigoProduto);
            if (produto.CodigoBarras != null)
            {
                produto = verificaImagemProduto(produto);

                return produto;
            }
            else
            {
                MessageBox.Show("Produto não encontrado!");
                return null;
            }
        }
        private Produto buscaProdutoPorCodBarrasBalanca(string codigoProduto)
        {
            Produto produto = _produtoRepository.ObterProdutoPorCodigoBarrasBalanca(codigoProduto);
            if (produto.CodigoBarras != null)
            {
                produto = verificaImagemProduto(produto);

                return produto;
            }
            else
            {
                MessageBox.Show("Produto não encontrado!");
                return null;
            }
        }

        private int contaLinhas()
        {
            return dgListaItensPedido.Rows.Count + 1;
        }

        private void ordenaLinhas()
        {

            for(int i= 0; i < itens.Rows.Count; i++)
            {
                int j = i + 1;
               
                itens.Rows[i][0] = j;
            }
        }

        //private string formataNumItem(int num)
        //{
           
        //    switch (num.ToString().Length)
        //    {
        //        case 1:
        //            return  "000" + num;
        //            break;
        //        case 2:
        //            return "00" + num;
        //            break;
        //        case 3:
        //            return "0" + num;
        //            break;
        //        default:
        //            return num.ToString();
        //    }
        //}


        public void montaItemPedido(Produto produto,double preco, double qtde)
        {
            ItemPedido itemPedido = new ItemPedido(pedidoCorrente.Id, contaLinhas(), produto.Nome, preco, qtde, 0);
            Console.WriteLine(preco.ToString());
            Console.WriteLine(qtde.ToString());
            //cria uma row pra inserir na datatable
            var row = itens.NewRow();

            //insere o itemPedido na linha
            row[0] = contaLinhas();
            row[1] = itemPedido.ProdutoId;
            row[2] = itemPedido.PedidoId;
            row[3] = itemPedido.Nome;
            row[4] = itemPedido.Preco;
            row[5] = itemPedido.Qtde;
            row[6] = itemPedido.Desconto;
            row[7] = itemPedido.SubTotal;

            //add a row
            itens.Rows.Add(row);
            AddItemPedidoDataGrid(itemPedido);
        }

        private Produto verificaImagemProduto(Produto produto)
        {
            if (!File.Exists(produto.Imagem))
            {
                produto.Imagem = "C:\\padaria\\img\\logo.jpg";
            }
            //pictureBox1.ImageLocation = produto.Imagem;
            return produto;
        }

        private void AddItemPedidoDataGrid(ItemPedido itemPedido)
        {
            //faz o source no datagrid
            dgListaItensPedido.DataSource = itens;
            //rolagem automática do grid
            this.dgListaItensPedido.CurrentCell = this.dgListaItensPedido[0, this.dgListaItensPedido.Rows.Count - 1];
            dgListaItensPedido.Rows[0].Selected = false;
            pedidoCorrente.Valor = AtualizaTotal();
            exibeUltimoItem(itemPedido);
            limpaTextCodProduto();
        }




        private double AtualizaTotal()
        {
            total = dgListaItensPedido.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDouble(i.Cells["SubTotal"].Value));
            lblValTotal.Text = total.ToString("N2");
            return total;
        }

        private void LeituraComanda(string codigoComanda)
        {
            bool existePedidoAbertoComandaLida = false;

            int codigoComandInt = Convert.ToInt32(codigoComanda);
            //verificar se existe pedido aberto com essa comanda
            Pedido pedidoDaComandaLida = _pedidoRepository.ObterPedidoAbertoPorComanda(codigoComanda);
            if (pedidoDaComandaLida.Comanda != 0)//esta comanda esta em algum pedido
            {
                existePedidoAbertoComandaLida = true;
            }
            //verifica se o pedido atual é do balcao ou de outra comanda
            //Pedido pedidoAtual = _pedidoRepository.ObterPedido(pedidoId);

            if (total == 0)//venda de balcao
            {
                if (existePedidoAbertoComandaLida)//esta comanda esta em algum pedido
                {
                    itens = _itempedidoRepository.ConsultaTodos(pedidoDaComandaLida.Id);

                    string msg1 = "Existe uma venda em andamento";
                    string msg2 = "para essa comanda!";
                    FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.Ok, msg1, msg2, TiposForms.Pdv);
                    ConfirmacaoMensagem = false;
                    frmMensagens.ShowDialog();


                    pedidoCorrente = pedidoDaComandaLida;
                    CarregaGridItensPedidoBanco(itens);
                    AtualizaTotal();
                    ModoComanda(true, codigoComanda);
                    limpaTextCodProduto();
                }
                else
                {
                    pedidoCorrente.Comanda = codigoComandInt;
                    _pedidoRepository.Atualizar(pedidoCorrente);
                    ModoComanda(true, codigoComanda);
                    limpaTextCodProduto();
                }
            }
            else
            {
                if (pedidoCorrente.Comanda == codigoComandInt)//qdo leio a comanda num pedido dela mesma
                {
                    string msg1 = "Esse pedido já pertence a essa comanda";
                    string msg2 = "";
                    FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.Ok, msg1, msg2, TiposForms.Pdv);
                    ConfirmacaoMensagem = false;
                    frmMensagens.ShowDialog();
                    limpaTextCodProduto();
                }
                else if (pedidoCorrente.Comanda != 0 && pedidoCorrente.Comanda != pedidoDaComandaLida.Comanda)
                {
                    string msg1 = "Comanda diferente do pedido atual!!!";
                    string msg2 = "Suspenda antes de inserir outra comanda!";
                    FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.Ok, msg1, msg2, TiposForms.Pdv);
                    frmMensagens.ShowDialog();
                    ConfirmacaoMensagem = false;
                    limpaTextCodProduto();
                }
                else if (pedidoCorrente.Comanda == 0 && total > 0)//venda de balcao
                {
                    string msg1 = "Venda de Balcao!";
                    string msg2 = "Finalize!";
                    FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.Ok, msg1, msg2, TiposForms.Pdv);
                    frmMensagens.ShowDialog();
                    ConfirmacaoMensagem = false;
                    limpaTextCodProduto();
                }
            }
        }


        //_pedidoRepository.ObterPedido(pedidoId);

        //if (AtualizaTotal() == 0)
        //{
        //    pedido.Comanda = Convert.ToInt32(codigoComanda);
        //    _pedidoRepository.Atualizar(pedido);
        //}
        //else if(AtualizaTotal() != 0 && pedido.Comanda == 0)
        //{
        //    DialogResult result = MessageBox.Show("Deseja inserir esses itens nessa Comanda?", "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        //    if (result.Equals(DialogResult.OK))
        //    {
        //        pedido.Comanda = Convert.ToInt32(codigoComanda);
        //        _pedidoRepository.Atualizar(pedido);
        //    }
        //    //if (pedido.Comanda == 0)
        //    //{

        //    //}



        //    //

        //    //dgListaItensPedido.DataSource = itens;
        //    //if (produto.CodigoBarras != null) ;

        //}
        private void ModoComanda(bool comComanda, string codigoComanda)
        {
            if (comComanda)
            {
                btnSuspender.Visible = true;
                btnSuspender.BackColor = Color.Black;
                lblAlertaComanda.Text = "Comanda: " + codigoComanda;
                lblStatusCaixa.Visible = false;
                textNumVenda.Visible = false;
                pnTotal2.BackColor = Color.Black;
                panel1.BackColor = Color.Black; ;
                panel2.BackColor = Color.Black; ;
                lblHeadCod.ForeColor = Color.Yellow;
                lblHeadDescricao.ForeColor = Color.Yellow;
                lblHeadValUni.ForeColor = Color.Yellow;
                lblHeadQtde.ForeColor = Color.Yellow;
                lblHeadValTotal.ForeColor = Color.Yellow;
                lblValTot.ForeColor = Color.Yellow;
                lblValTot.BackColor = Color.Black; ;
                lblValTotal.ForeColor = Color.Yellow;
                lblValTotal.BackColor = Color.Black;
                ComandaOuBalcao = TiposMovimentacao.VendaComanda;
            }
            else
            {
                lblStatusCaixa.Visible = true;
                lblStatusCaixa.Text = "Venda PDV";
                textNumVenda.Text = "N°" + NumeroVenda.ToString();
                btnSuspender.Visible = false;
                lblAlertaComanda.Text = "";
                textNumVenda.Visible = true;
                pnTotal2.BackColor = Color.MidnightBlue;
                panel1.BackColor = Color.MidnightBlue;
                panel2.BackColor = Color.MidnightBlue; ;
                lblHeadCod.ForeColor = Color.White;
                lblHeadDescricao.ForeColor = Color.White;
                lblHeadValUni.ForeColor = Color.White;
                lblHeadQtde.ForeColor = Color.White;
                lblHeadValTotal.ForeColor = Color.White;
                lblValTot.ForeColor = Color.White;
                lblValTot.BackColor = Color.MidnightBlue;
                lblValTotal.ForeColor = Color.White;
                lblValTotal.BackColor = Color.MidnightBlue;
                ComandaOuBalcao = TiposMovimentacao.VendaBalcao;
            }
        }


        private void limparCampos()
        {
            //limpar datatable
            itens.Clear();
            //limpar grid
            dgListaItensPedido.DataSource = itens;
            //limpar textbox prod
            textCodProd.Text = string.Empty;
            //limpar texbox qtde
            textQtde.Text = "1";
            //limpar total
            AtualizaTotal();
            limpaExibeUltimoItem();
            textCodProd.Focus();
            //desabilitar botoes
        }

        private void limpaExibeUltimoItem()
        {
            //limpar imagem
            pictureBox1.ImageLocation = "C:\\padaria\\img\\logo.jpg";
            lblExibeDesc.Text = String.Empty;
            lblExibeValUni.Text = String.Empty;
            lblExibeQtde.Text = String.Empty;
            lblExibeTotal.Text = String.Empty;
        }

        private double CalculaQtde()
        {
            double qtde = 1;
            if (textQtde.Text == "" || textQtde.Text == "0")
            {
                qtde = 1;
            }
            else if (textQtde.Text != "1")
            {
                qtde = Convert.ToDouble(textQtde.Text);
            }
            return qtde;
        }

        private void limpaTextCodProduto()
        {
            textQtde.Text = "1";
            textCodProd.Text = string.Empty;
            textCodProd.Select();
        }

        public void exibeUltimoItem(ItemPedido itemPedido)
        {
            lblExibeDesc.Text = itemPedido.Nome;
            lblExibeValUni.Text = itemPedido.Preco.ToString("N2");
            lblExibeQtde.Text = itemPedido.Qtde.ToString("N3");
            lblExibeTotal.Text = itemPedido.SubTotal.ToString("N2");

            //pictureBox1.ImageLocation = imagem;
        }
        //
        //
        private void CadastraItens()
        {
            List<ItemPedido> listaDeItens = new List<ItemPedido>();
            //percorre a datatable gerando uma list de ItemPedido
            foreach (DataRow row in itens.Rows)
            {
                ItemPedido itemPedido = new ItemPedido(
                    Convert.ToInt32(row[2]),
                    Convert.ToInt32(row[1]),
                    row[3].ToString(),
                    Convert.ToDouble(row[4]),
                    Convert.ToDouble(row[5]),
                    Convert.ToDouble(row[6])
                    );
                //itemPedido.SubTotal = Convert.ToDouble(row[7]);
                listaDeItens.Add(itemPedido);
            }
            _itempedidoRepository.CadastrarTodos(listaDeItens);
        }

        //
        // Botões
        //
        private void btnSuspender_Click(object sender, EventArgs e)
        {
            pedidoCorrente.Valor = AtualizaTotal();
            pedidoCorrente.StatusPedido = StatusPedido.Suspenso;
            _itempedidoRepository.ExcluirTodos(pedidoCorrente.Id);

            CadastraItens();

            _pedidoRepository.Atualizar(pedidoCorrente);
            ModoComanda(false, "");
            limparCampos();
            ProcessaInstanciaPedido();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (AtualizaTotal() > 0)
            {

                string msg1 = "Deseja Cancelar a Venda?";
                string msg2 = "";
                FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.Pdv);
                frmMensagens.ShowDialog();
                if (ConfirmacaoMensagem)
                {
                    pedidoCorrente.StatusPedido = StatusPedido.Cancelado;
                    pedidoCorrente.Valor = AtualizaTotal();
                    pedidoCorrente.FormaPagamento = FormaPagamento.Nenhum;
                    //pedidoCorrente.Comanda = 0;
                    _pedidoRepository.Atualizar(pedidoCorrente);

                    //_itempedidoRepository.ExcluirTodos(pedidoCorrente.Id);
                    ModoComanda(false, "");
                    limparCampos();
                    ProcessaInstanciaPedido();
                }
                ConfirmacaoMensagem = false;
            }
        }


        private void pagamentoDinheiro()
        {
            if (AtualizaTotal() == 0)
            {
                limpaTextCodProduto();
            }
            else
            {
                FrmTroco troco = new FrmTroco(pedidoCorrente.Valor, TiposForms.Pdv);
                troco.ShowDialog();
            }

            if (PagamentoConfirmado)
            {
                pedidoCorrente.Desconto = desconto;
                pedidoCorrente.Valor -= desconto;
                pedidoCorrente.NumVendaDoDia = NumeroVenda;
                FluxoCaixa fluxoCaixa = new FluxoCaixa(pedidoCorrente.Id, ComandaOuBalcao, "", FormaPagamento.Dinheiro, pedidoCorrente.Valor, 0, gerente.Nome,operador.Nome);
                finalizaPedido.Avista(pedidoCorrente, fluxoCaixa);
                CadastraItens();
                ImprimeVenda imprimeVenda = new ImprimeVenda(pedidoCorrente.Id);
                imprimeVenda.imprimeVenda();

                ModoComanda(false, "");
                limparCampos();
                ProcessaInstanciaPedido();
            }
        }


        private void pagamentoCartao()
        {
            if (AtualizaTotal() == 0)
            {
                limpaTextCodProduto();
            }
            else
            {
                string msg1 = "Confirma Pagamento por Cartão ? ";
                string msg2 = "";
                FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.Pdv);
                frmMensagens.ShowDialog();

                if (ConfirmacaoMensagem)
                {
                    ConfirmacaoMensagem = false;
                    msg1 = "Passe o Cartão......... ";
                    msg2 = "";
                    FrmMensagens frmMensagens2 = new FrmMensagens(TiposMensagens.Ok, msg1, msg2, TiposForms.Pdv);
                    frmMensagens2.ShowDialog();

                    msg1 = "O Pagamento foi Efetudo? ";
                    msg2 = "";
                    FrmMensagens frmMensagens3 = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.Pdv);
                    frmMensagens3.ShowDialog();

                    if (ConfirmacaoMensagem)
                    {
                        FluxoCaixa fluxoCaixa = new FluxoCaixa(pedidoCorrente.Id, ComandaOuBalcao, "", FormaPagamento.Cartao, pedidoCorrente.Valor, 0, gerente.Nome, operador.Nome);
                        FinalizaPedido finalizaPedido = new FinalizaPedido();
                        pedidoCorrente.NumVendaDoDia = NumeroVenda;

                        finalizaPedido.Cartao(pedidoCorrente, fluxoCaixa);
                        CadastraItens();
                        ImprimeVenda imprimeVenda = new ImprimeVenda(pedidoCorrente.Id);
                        imprimeVenda.imprimeVenda();
                        ConfirmacaoMensagem = false;
                        ModoComanda(false, "");
                        limparCampos();
                        ProcessaInstanciaPedido();

                    }

                }
            }
        }

        private void pagamentoPix()
        {
            if (AtualizaTotal() == 0)
            {
                limpaTextCodProduto();
            }
            else
            {
                string msg1 = "Confirma Pagamento por Pix? ";
                string msg2 = "";
                FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.Pdv);
                frmMensagens.ShowDialog();

                if (ConfirmacaoMensagem)
                {
                    ConfirmacaoMensagem = false;
                    msg1 = "Prossiga......... ";
                    msg2 = "";
                    FrmMensagens frmMensagens2 = new FrmMensagens(TiposMensagens.Ok, msg1, msg2, TiposForms.Pdv);
                    frmMensagens2.ShowDialog();

                    msg1 = "O Pagamento foi Efetudo? ";
                    msg2 = "";
                    FrmMensagens frmMensagens3 = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.Pdv);
                    frmMensagens3.ShowDialog();

                    if (ConfirmacaoMensagem)
                    {
                        FluxoCaixa fluxoCaixa = new FluxoCaixa(pedidoCorrente.Id, ComandaOuBalcao, "", FormaPagamento.Pix, pedidoCorrente.Valor, 0, gerente.Nome, operador.Nome);
                        FinalizaPedido finalizaPedido = new FinalizaPedido();
                        pedidoCorrente.NumVendaDoDia = NumeroVenda;

                        finalizaPedido.Pix(pedidoCorrente, fluxoCaixa);
                        CadastraItens();
                        ImprimeVenda imprimeVenda = new ImprimeVenda(pedidoCorrente.Id);
                        imprimeVenda.imprimeVenda();
                        ConfirmacaoMensagem = false;
                        ModoComanda(false, "");
                        limparCampos();
                        ProcessaInstanciaPedido();

                    }

                }
            }
        }

        private void pagamentoPrazo()
        {
            if (AtualizaTotal() == 0)
            {
                limpaTextCodProduto();
            }
            else
            {
                FrmConsultaCliente frm = new FrmConsultaCliente(pedidoCorrente);
                frm.ShowDialog();


                if (PagamentoConfirmado)
                {
                    FluxoCaixa fluxoCaixa = new FluxoCaixa(pedidoCorrente.Id, ComandaOuBalcao, "", FormaPagamento.Prazo, 0, 0, gerente.Nome, operador.Nome);
                    FinalizaPedido finalizaPedido = new FinalizaPedido();
                    pedidoCorrente.NumVendaDoDia = NumeroVenda;

                    finalizaPedido.Aprazo(pedidoCorrente, fluxoCaixa);
                    CadastraItens();
                    ImprimeVenda imprimeVenda = new ImprimeVenda(pedidoCorrente.Id);
                    imprimeVenda.imprimeVenda();
                    ModoComanda(false, "");
                    limparCampos();
                    ProcessaInstanciaPedido();
                }
            }

        }

        //
        //Eventos
        //


        private void textQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
            //ao clicar na tecla ENTER
            if (e.KeyChar == 13)
            {
                if (textQtde.Text != "")
                {
                    verificaTextoNumero(textCodProd.Text);
                }
            }
        }
        private void textCodProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgBuscaProduto.Select();
                dgBuscaProduto.Rows[0].Selected = true;
            }
        }

        private void dgBuscaProduto_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgBuscaProdutoClicado == false)
            {
                dgBuscaProduto.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgBuscaProduto.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void dgBuscaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewRow linha = dgBuscaProduto.CurrentRow;
                int indice = linha.Index;
                string codigoBarras = dgBuscaProduto.Rows[indice].Cells[1].Value.ToString();
                var codigoBarrasBalanca = dgBuscaProduto.Rows[indice].Cells[2].Value.ToString();

                Produto produto;

                if (codigoBarras != "NOT")
                {
                    produto = _produtoRepository.ObterProdutoPorCodigoBarras(codigoBarras);
                }
                else
                {
                    produto = _produtoRepository.ObterProdutoPorCodigoBarrasBalanca(codigoBarrasBalanca);
                }
                produto = verificaImagemProduto(produto);
                montaItemPedido(produto, produto.PrecoVenda, CalculaQtde());
                dgBuscaProduto.Visible = false;
                limpaTextCodProduto();
            }
            if (e.KeyCode == Keys.Escape)
            {
                dgBuscaProduto.Visible = false;
                textCodProd.Select();
                textCodProd.SelectionStart = textCodProd.Text.Length;
            }

        }

        private void dgBuscaProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linhaAtual = dgBuscaProduto.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;

            var codigoBarras = dgBuscaProduto.Rows[indice].Cells[1].Value.ToString();
            var codigoBarrasBalanca = dgBuscaProduto.Rows[indice].Cells[2].Value.ToString();
            dgBuscaProduto.Visible = false;

            Produto produto;

            if (codigoBarras != "NOT")
            {
                 produto = _produtoRepository.ObterProdutoPorCodigoBarras(codigoBarras);
            }
            else
            {
              produto = _produtoRepository.ObterProdutoPorCodigoBarrasBalanca(codigoBarrasBalanca);
            }
            produto = verificaImagemProduto(produto);
            montaItemPedido(produto, produto.PrecoVenda, CalculaQtde());
            //Console.WriteLine(CalculaQtde());
            dgBuscaProduto.Visible = false;
        }

        private void deletaProdutoGrid()
        {

            string msg1 = "Excluir esse item?";
            string msg2 = "";
            FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.Pdv);
            frmMensagens.ShowDialog();

            if (ConfirmacaoMensagem)
            {
                DataGridViewRow linhaAtual = dgListaItensPedido.CurrentRow;
                // vamos exibir o índice da linha atual
                int indice = linhaAtual.Index;

                //deleta a linha na datatable
                itens.Rows[indice].Delete();
                dgListaItensPedido.DataSource = itens;
                limpaExibeUltimoItem();
                AtualizaTotal();
            }
            ordenaLinhas();
            ConfirmacaoMensagem = false;
        }



        private void dgListaItensPedido_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            deletaProdutoGrid();
            textCodProd.Select();
        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            pagamentoDinheiro();
        }

        private void btnCartao_Click(object sender, EventArgs e)
        {
             pagamentoCartao();
        }

        private void btnPrazo_Click(object sender, EventArgs e)
        {
            pagamentoPrazo();
        }

        private void btnPdv_Click(object sender, EventArgs e)
        {
            pagamentoPix();
        }

        private void Pdv_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                pagamentoDinheiro();
            }

            if (e.KeyCode == Keys.F6)
            {
                pagamentoPrazo();
            }

            if (e.KeyCode == Keys.F7)
            {
                pagamentoCartao();
            }
            if (e.KeyCode == Keys.F8)
            {
                pagamentoPix();
            }
            if (e.KeyCode == Keys.F9)
            {
                FrmValorDiverso frm = new FrmValorDiverso();
                frm.ShowDialog();
            }
            if (e.KeyCode == Keys.F10)
            {
                DialogResult cancela = MessageBox.Show("Cancelar Venda?", "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (cancela.Equals(DialogResult.OK))
                {
                    if (AtualizaTotal() > 0)
                    {
                        string msg1 = "Deseja Cancelar a Venda?";
                        string msg2 = "";
                        FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.Pdv);
                        frmMensagens.ShowDialog();
                        if (ConfirmacaoMensagem)
                        {
                            pedidoCorrente.StatusPedido = StatusPedido.Cancelado;
                            //pedidoCorrente.Comanda = 0;
                            _pedidoRepository.Atualizar(pedidoCorrente);

                            //_itempedidoRepository.ExcluirTodos(pedidoCorrente.Id);
                            ModoComanda(false, "");
                            limparCampos();
                            ProcessaInstanciaPedido();
                        }
                        ConfirmacaoMensagem = false;
                    }
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            textCodProd.Select();
            this.SendToBack();
            //this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void processaItemRapido(Button button)
        {
            ItemRapido itemRapido = itemRapidos[buttons.IndexOf(button)];
            if (itemRapido.CodigoBarras == "NOT")
            {
                string codigo = itemRapido.CodigoBarrasBalanca.ToString();
                Produto produto = _produtoRepository.ObterProdutoPorCodigoBarrasBalanca(codigo);
                if (produto.Id != 0)
                {
                    produto = verificaImagemProduto(produto);
                    montaItemPedido(produto, produto.PrecoVenda, CalculaQtde());
                }
                else
                {
                    MessageBox.Show("Produto não cadastrado!");
                    limpaTextCodProduto();
                }

            }
            else
            {
                string codigo = itemRapido.CodigoBarras;
                Produto produto = _produtoRepository.ObterProdutoPorCodigoBarras(codigo);
                if (produto.Id != 0)
                {
                    produto = verificaImagemProduto(produto);
                    montaItemPedido(produto, produto.PrecoVenda, CalculaQtde());
                }
                else
                {
                    MessageBox.Show("Produto não cadastrado!");
                    limpaTextCodProduto();
                }
            }
        }

        private void btnDiversos_Click(object sender, EventArgs e)
        {
            FrmValorDiverso frm = new FrmValorDiverso();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Button x in buttons)
            {
                if (x == sender as Button)
                {
                    processaItemRapido(x);
                }
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            dgBuscaProduto.Visible = false;
        }

        private void dgListaItensPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                deletaProdutoGrid();
            }
            textCodProd.Select();
        }

        private void textCodProd_Enter(object sender, EventArgs e)
        {
            textCodProd.BackColor = Color.PaleGoldenrod;
        }

        private void textCodProd_Leave(object sender, EventArgs e)
        {
            textCodProd.BackColor = Color.White;
        }

        private void textQtde_Enter(object sender, EventArgs e)
        {
            textQtde.BackColor = Color.PaleGoldenrod;
        }

        private void textQtde_Leave(object sender, EventArgs e)
        {
            textQtde.BackColor = Color.White;
        }

        private void Pdv_KeyDown(object sender, KeyEventArgs e)
        {
            if (!dgBuscaProduto.Visible)
            {
                if (e.KeyValue == 27)
                {
                    this.SendToBack();
                }
            }
        }
    }
}

