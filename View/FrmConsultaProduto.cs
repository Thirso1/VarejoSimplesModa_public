using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VarejoSimplesModa.Repository.RepositoryInterfaces;

namespace VarejoSimplesModa.View
{
    public partial class FrmConsultaProduto : Form
    {
        DataTable produtos = new DataTable();
        IProdutoRepository _produtoRepository = new ProdutoRepository();
        public FrmConsultaProduto()
        {
            InitializeComponent();
        }

        private void FrmConsultaProduto_Load(object sender, EventArgs e)
        {
            produtos = _produtoRepository.ObterTodosProdutos();
            dgProdutos.DataSource = produtos;

        }

        private void txtBusca_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBusca.Text.Length > 2)
            {
                dgProdutos.DataSource = _produtoRepository.ObterProdutos(txtBusca.Text);

            }
        }

        private void FrmConsultaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }
        }
    }
}
