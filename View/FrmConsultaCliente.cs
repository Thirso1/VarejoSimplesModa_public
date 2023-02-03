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
    public partial class FrmConsultaCliente : Form
    {
        private bool dgConsultaClienteClicado = false;
        private DataTable dtConsultaRapidaCliente = new DataTable();
        private IClienteRepository _clienteRepository = new ClienteRepository();
        private IPedidoRepository _pedidoRepository = new PedidoRepository();
        private ICrediarioRepository _crediarioRepository = new CrediarioRepository();
        private Cliente cliente = new Cliente();
        public static bool ConfirmacaoMensagem = false;
        private Pedido pedido;


        public FrmConsultaCliente(Pedido pedido)
        {
            InitializeComponent();
            btnConfirma.Enabled = false;
            this.pedido = pedido;
        }

        private void textNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textNome.Text.Length > 2)
            {
                dgConsultaClienteClicado = false;
                dtConsultaRapidaCliente = _clienteRepository.ObterClientes(textNome.Text);
                dgConsultaCliente.DataSource = dtConsultaRapidaCliente;
                dgConsultaCliente.Visible = true;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmCadastroCliente frm = new FrmCadastroCliente(0);
            frm.ShowDialog();
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

        private void dgConsultaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linha = dgConsultaCliente.CurrentRow;
            int indice = linha.Index;
            int Id = Convert.ToInt32(dgConsultaCliente.Rows[indice].Cells[1].Value);

            cliente = _clienteRepository.ObterCliente(Id);
            textNome.Text = cliente.nome; //+ " " + cliente.sobrenome;

            if(cliente.rua != "")
            {
                textRua.ForeColor = Color.Black;
                textRua.Text = "Rua " + cliente.rua + ", "+ cliente.numero +"  -  " + cliente.bairro;
            }
            else
            {
                textRua.ForeColor = Color.Red;
                textRua.Text = "Endereço não cadastrado!";
            }

            btnConfirma.Enabled = true;
        }

        private void textNome_Enter(object sender, EventArgs e)
        {
            btnConfirma.Enabled = false;
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            string msg1 = "Confirma Cliente:";
            string msg2 = cliente.nome;// + " " + cliente.sobrenome;
            FrmMensagens frmMensagens = new FrmMensagens(TiposMensagens.SimNao, msg1, msg2, TiposForms.BuscaCliente);
            frmMensagens.ShowDialog();

            if (ConfirmacaoMensagem)
            {
                Crediario crediario = new Crediario(cliente.Id, pedido.Id, DescricaoCrediario.Compra, pedido.Valor,0);
                _crediarioRepository.Cadastrar(crediario);
                MessageBox.Show("Crediario cadastrado com sucesso!");

                Pdv pdv = Pdv.Instance;
                pdv.PagamentoConfirmado = true;

                this.Close();
            }
        }
        private void FrmConsultaCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FrmConsultaCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
