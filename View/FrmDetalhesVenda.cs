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
    public partial class FrmDetalhesVenda : Form
    {
        private IPedidoRepository _pedidoRepository = new PedidoRepository();
        private IItemPedidoRepository _itemPedidoRepository = new ItemPedidoRepository();
        private IClienteRepository _clienteRepository = new ClienteRepository();
        private ICrediarioRepository _crediarioRepository = new CrediarioRepository();
        private Cliente cliente;
        private Pedido pedido;
        private int _numVenda;
        public FrmDetalhesVenda(int NumVenda)
        {
            this._numVenda = NumVenda;
            InitializeComponent();
        }

        private void FrmDetalhesVenda_Load(object sender, EventArgs e)
        {
            pedido = _pedidoRepository.ObterPedido(_numVenda);
            Crediario crediario = _crediarioRepository.ObterCrediarioPorPedido(pedido.Id);
            cliente = _clienteRepository.ObterCliente(crediario.IdCliente);
            if(cliente.nome == null)
            {
                lblCliente.ForeColor = Color.Red;
                lblCpf.ForeColor = Color.Red;
                lblCliente.Text = "Não Informado";
                lblCpf.Text = "Não Informado";
            }
            else
            {
                lblCliente.Text = cliente.nome;
                lblCpf.Text = cliente.cpf;
            }
            lblDataHora.Text = pedido.DataHora.ToString();
            lblNumVenda.Text = pedido.NumVendaDoDia.ToString();
                

            dgItensVenda.DataSource = _itemPedidoRepository.ConsultaTodos(_numVenda);
            dgItensVenda.ClearSelection();

            double total = dgItensVenda.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDouble(i.Cells["SubTotal"].Value));

            txtTotal.Text = total.ToString("N2"); 
        }
    }
}
