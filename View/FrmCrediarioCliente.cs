using VarejoSimplesModa.Enums;
using VarejoSimplesModa.Library;
using VarejoSimplesModa.Model;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VarejoSimplesModa.Repository;
using VarejoSimplesModa.Repository.RepositoryInterfaces;

namespace VarejoSimplesModa.View
{
    public partial class FrmCrediarioCliente : Form
    {
        private bool dgConsultaClienteClicado = false;
        public static bool ConfirmacaoMensagem = false;
        public static bool pagamentoConfirmado = false;

        private double total;
        private int idCliente;

        private DataTable dtConsultaRapidaCliente = new DataTable();
        private DataTable dtPedidos = new DataTable();
        private Cliente cliente = new Cliente();

        private IClienteRepository _clienteRepository = new ClienteRepository();
        private IPedidoRepository _pedidoRepository = new PedidoRepository();
        private ICrediarioRepository _crediarioRepository = new CrediarioRepository();
        private IFluxoCaixaRepository _fluxoCaixaRepository = new FluxoCaixaRepository();
        private ICaixaRepository _caixaRepository = new CaixaRepository();
        private IUsuarioRepository _usuarioRepository = new UsuarioRepository();
        private Usuario gerente;
        private Usuario operador;





        public FrmCrediarioCliente(Usuario gerente, Usuario operador)
        {
            InitializeComponent();
            this.gerente = gerente;
            this.operador = operador;
        }

        private void FrmCrediarioCliente_Load(object sender, EventArgs e)
        {
            dgConsultaCliente.Visible = false;
            textNome.Select();
        }

        private void textNome_KeyUp(object sender, KeyEventArgs e)
        {
            if (textNome.Text.Length > 2)
            {
                dgConsultaClienteClicado = false;
                dtConsultaRapidaCliente = _clienteRepository.ObterClientes(textNome.Text);
                dgConsultaCliente.DataSource = dtConsultaRapidaCliente;
                dgConsultaCliente.Visible = true;
                dgConsultaCliente.BringToFront();

            }
        }

        private void dgConsultaCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewRow linha = dgConsultaCliente.CurrentRow;
                int indice = linha.Index;
                int Id = Convert.ToInt32(dgConsultaCliente.Rows[indice].Cells[0].Value);
            }
        }

        private void dgConsultaCliente_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgConsultaClienteClicado = true;

            DataGridViewRow linha = dgConsultaCliente.CurrentRow;
            int indice = linha.Index;
            idCliente = Convert.ToInt32(dgConsultaCliente.Rows[indice].Cells[1].Value);
           
            dgConsultaCliente.Visible = false;
            preencheCliente(idCliente);

        }



        private void preencheCliente(int id)
        {
            cliente = _clienteRepository.ObterCliente(id);

            textNome.Text = cliente.nome;// + " " + cliente.sobrenome;
            textCpf.Text = cliente.cpf;

            if (cliente.rua != "")
            {
                textRua.ForeColor = Color.Black;
                textRua.Text = "Rua " + cliente.rua + ", " + cliente.numero;
                textBairro.Text = cliente.bairro;
                textCidade.Text = cliente.cidade;
                textCep.Text = cliente.cep;
            }
            else
            {
                textRua.ForeColor = Color.Red;
                textRua.Text = "Endereço não cadastrado!";
            }
            carregaDgListaFiado(consultaPedidos(cliente.Id));
            calculaTotal();
            dgConsultaClienteClicado = false;
        }

        private DataTable consultaPedidos(int idCliente)
        {
            dtPedidos = _pedidoRepository.ObterPedidoPorCliente(idCliente);

            return dtPedidos;
        }

        private void carregaDgListaFiado(DataTable itens)
        {
            dgListaFiado.DataSource = itens;
            dgListaFiado.ClearSelection();
        }

        private double calculaTotal()
        {
            total = dtPedidos.AsEnumerable().Sum(s => s.Field<double>("debito"));
            textTotal.Text = total.ToString("N2");
            textValorParci.Text = total.ToString("N2");
            return total;
        }

        private void registrarRecebimento(double receberValor, FormaPagamento formaPagamento)
        {

            if (pagamentoConfirmado && receberValor < total)
            {

                Crediario recebimentoCrediario = new Crediario(cliente.Id, 0, Enums.DescricaoCrediario.Pagamento, 0, receberValor);
                _crediarioRepository.Cadastrar(recebimentoCrediario);
                double valorRestante = total - receberValor;
                Crediario restante = new Crediario(cliente.Id, 0, Enums.DescricaoCrediario.Restante, valorRestante, 0);
                _crediarioRepository.Cadastrar(restante);
                FluxoCaixa fluxoCaixa = new FluxoCaixa(0, Enums.TiposMovimentacao.RecebimentoCrediario, "", formaPagamento, receberValor, 0, gerente.Nome, operador.Nome);
                _fluxoCaixaRepository.Cadastrar(fluxoCaixa);


            }
            if (pagamentoConfirmado && receberValor == total)
            {
                Crediario recebimentoCrediario = new Crediario(cliente.Id, 0, Enums.DescricaoCrediario.Pagamento, 0, receberValor);
                _crediarioRepository.Cadastrar(recebimentoCrediario);
                FluxoCaixa fluxoCaixa = new FluxoCaixa(0, Enums.TiposMovimentacao.RecebimentoCrediario, "", formaPagamento, receberValor, 0, gerente.Nome, operador.Nome);
                _fluxoCaixaRepository.Cadastrar(fluxoCaixa);
            }

            preencheCliente(idCliente);
        }



        private void dgListaFiado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgConsultaCliente_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void dgConsultaCliente_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgConsultaClienteClicado == false)
            {
                dgConsultaCliente.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgConsultaCliente.Rows[e.RowIndex].Selected = true;
                }
            }
        }



        private void btnReceber_Click(object sender, EventArgs e)
        {
            if (textValorParci.Text != "")
            {
                double receberValor = Convert.ToDouble(textValorParci.Text);
                if (receberValor <= total && total > 0)
                {

                    FrmTroco Frm = new FrmTroco(receberValor, Enums.TiposForms.Crediario);
                    Frm.ShowDialog();

                    registrarRecebimento(receberValor, FormaPagamento.Dinheiro);
                }
            }
        }

        private void textValorParci_KeyUp(object sender, KeyEventArgs e)
        {
            //aqui
            if (textValorParci.Text.Length > 2)
            {
                try
                {
                    string valor = MascaraDecimal.mascara(textValorParci.Text);
                    textValorParci.Text = valor;
                    textValorParci.SelectionStart = textValorParci.Text.Length + 1;
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.ToString());
                }
            }
        }

        private void textValorParci_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;

            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                textValorParci.Text = "";
            }
        }

        private void btnCartao_Click(object sender, EventArgs e)
        {
            if (textValorParci.Text != "")
            {
                //aqui
                double receberValor = Convert.ToDouble(textValorParci.Text);
                if (receberValor <= total && total > 0)
                {

                    string msg1 = "Confirma Pagamento por Cartão ? ";
                    string msg2 = "";
                    FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.Crediario);
                    frmMensagens.ShowDialog();

                    if (ConfirmacaoMensagem)
                    {
                        ConfirmacaoMensagem = false;
                        msg1 = "Passe o Cartão......... ";
                        msg2 = "";
                        FrmMensagens frmMensagens2 = new FrmMensagens(TiposMensagens.Ok, msg1, msg2, TiposForms.Crediario);
                        frmMensagens2.ShowDialog();

                        msg1 = "O Pagamento foi Efetudo? ";
                        msg2 = "";
                        FrmMensagens frmMensagens3 = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.Crediario);
                        frmMensagens3.ShowDialog();

                        if (ConfirmacaoMensagem)
                        {
                            pagamentoConfirmado = true;
                            registrarRecebimento(receberValor, FormaPagamento.Cartao);
                        }
                    }
                }
            }
        }

        private void btnPix_Click(object sender, EventArgs e)
        {
            if (textValorParci.Text != "")
            {
                //aqui
                double receberValor = Convert.ToDouble(textValorParci.Text);
                if (receberValor <= total && total > 0)
                {

                    string msg1 = "Confirma Pagamento por Pix? ";
                    string msg2 = "";
                    FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.Crediario);
                    frmMensagens.ShowDialog();

                    if (ConfirmacaoMensagem)
                    {
                        ConfirmacaoMensagem = false;
                        msg1 = "Prossiga......... ";
                        msg2 = "";
                        FrmMensagens frmMensagens2 = new FrmMensagens(TiposMensagens.Ok, msg1, msg2, TiposForms.Crediario);
                        frmMensagens2.ShowDialog();

                        msg1 = "O Pagamento foi Efetudo? ";
                        msg2 = "";
                        FrmMensagens frmMensagens3 = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.Crediario);
                        frmMensagens3.ShowDialog();

                        if (ConfirmacaoMensagem)
                        {
                            pagamentoConfirmado = true;
                            registrarRecebimento(receberValor, FormaPagamento.Pix);
                        }
                    }
                }
            }
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            dgConsultaCliente.Visible = false;
        }

        private void textTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmCrediarioCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (!dgConsultaCliente.Visible)
            {
                if (e.KeyValue == 27)
                {
                    this.Close();
                }
            }
        }

        private void textNome_KeyDown(object sender, KeyEventArgs e)
        {

                if (e.KeyValue == 27)
                {
                    this.Close();
                }
            
        }
    }
}