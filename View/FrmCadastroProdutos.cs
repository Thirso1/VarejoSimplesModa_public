using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VarejoSimplesModa.Model;
using VarejoSimplesModa.Banco;
using VarejoSimplesModa.Repository.RepositoryInterfaces;
using VarejoSimplesModa.Library;

namespace VarejoSimplesModa.View
{
    public partial class FrmCadastroProdutos : Form
    {
        Produto produto = new Produto();
        IProdutoRepository _produtoRepository = new ProdutoRepository();
        private int novoCodProdBalanca = 0;

        int id_produto = 0;
        private bool dgProdutosClicado = false;
        public FrmCadastroProdutos(int id_produto)
        {
            InitializeComponent();
            this.id_produto = id_produto;
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmCadastroProdutos_Load(object sender, EventArgs e)
        {
            dgProdutos.Visible = false;
            pnHeaderDgProdutos.Visible = false;
            loadCategoria();
            txtCat.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            loadCadastro();
            txtCodBar.Select();
        }
        
        private void loadCadastro()
        {
            //rdComCodigo.Checked = true;
            btnAtualizar.Visible = false;
            btnSalvar.Visible = true;
            btnExcluir.Enabled = false;
        }

        private void limpCampProd()
        {
            txtCat.SelectedIndex = 0;
            novoCodProdBalanca = 0;
            checkBalanca.Checked = false;
            txtCod.Text = string.Empty;
            txtCodBar.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtImg.Text = string.Empty; ;//C:\\queijo_cia\\logo_queijo_cia.png

            txtPrecoCusto.Text = string.Empty;
            txtPrecoVenda.Text = string.Empty;
            txtMargemLucro.Text = string.Empty;
            txtDesconto.Text = string.Empty;

            cbUniVenda.SelectedIndex = 0;
            cbGondola.Text = string.Empty;
            cbGaveta.Text = string.Empty;
            cbPrateleira.Text = string.Empty;

            txtEstoqueMin.Text = string.Empty;
            txtEstoqueAtual.Text = string.Empty;
            txtEstoqueMax.Text = string.Empty;
            cbStatus.TabIndex = 0;
            txtCodBar.Select();
        }

        private void loadAtualizacao(Produto produto)
        {     
            //passa os dados para os campos do form direto da datatable
            txtCod.Text = produto.Id.ToString();
            if(produto.CodigoBarras == "NOT")
            {
                checkBalanca.Checked = true;
                novoCodProdBalanca = produto.CodigoBarrasBalanca;
                txtCodBar.Text = produto.CodigoBarrasBalanca.ToString();
            }
            else
            {
                checkBalanca.Checked = false;
                txtCodBar.Text = produto.CodigoBarras;
            }

            txtNome.Text = produto.Nome;
            txtDescricao.Text = produto.Descricao;
            //txtCodMarca.Text = produto.Cod_marca;
            txtPrecoCusto.Text = produto.PrecoCusto.ToString("N2");
            txtMargemLucro.Text = produto.MargemLucro.ToString("N2");
            txtPrecoVenda.Text = produto.PrecoVenda.ToString("N2");
            txtDesconto.Text = produto.Desconto.ToString("N2");
            txtImg.Text = produto.Imagem;
            cbUniVenda.Text = converteUnidVenda(produto.UnidVenda);

            //cbStatus.Text = produto.Status;

            //busca a cateoria
            //txtCat.Text = categoriaDb.retornaDescricaoPorId(produto.Id_categoria).ToString();
            //traz os dados de estoque nessa datatable

            //preenche os campos do form direto da datatable
            cbUniVenda.Text = produto.UnidVenda;
            txtEstoqueMin.Text = produto.EstoqueMin.ToString();
            txtEstoqueAtual.Text = produto.EstoqueAtual.ToString();
            txtEstoqueMax.Text = produto.EstoqueMax.ToString();


            //string local = estoque.Localizacao;
            //string prateleira = estoque.Localizacao;
            //string gaveta = estoque.Localizacao;
            //cbGondola.Text = local;
            //cbPrateleira.Text = prateleira;
            //cbGaveta.Text = gaveta;

            //
            //povoa_fornecedores(id_produto);
            //troca os botoes de salvar por atualizar
            btnSalvar.Visible = false;
            btnAtualizar.Visible = true;
            btnExcluir.Enabled = true;
            txtPrecoVenda.Select();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //o parametro tipo: '1' para salvar, '2' para atualizar
            valida(1);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            //o parametro tipo: '1' para salvar, '2' para atualizar
            valida(2);
        }

        private void valida(int tipo)//o parametro tipo: '1' para salvar, '2' para atualizar
        {

            //if (txtCat.Text == "")
            //{
            //    MessageBox.Show("Selecione a categoria");
            //    txtCat.Select();
            //}
            if (txtCodBar.Text == "")
            {
                MessageBox.Show("Preencha o código de barras");
                txtCodBar.Select();
            }
            else if (checkBalanca.Checked == false && txtCodBar.Text.Length < 8 )
            {
                MessageBox.Show("Código de barras  não pode ser menor que '8' dígitos");
                txtCodBar.Select();
            }
            else if (checkBalanca.Checked == true && novoCodProdBalanca == 0)
            {
                MessageBox.Show("Clique no CheckBox para gerar o Código de barras na Balança");
                txtCodBar.Select();
            }
            else if (txtNome.Text == "")
            {
                MessageBox.Show("Preencha o Nome!");
                txtNome.Select();
            }
            else if (txtPrecoCusto.Text == "")
            {
                MessageBox.Show("Preencha o preço de custo!");
                txtPrecoCusto.Select();
            }
            else if (txtPrecoVenda.Text == "")
            {
                MessageBox.Show("Preencha o preço de venda!");
                txtPrecoVenda.Select();
            }
            else if (cbUniVenda.Text == "")
            {
                MessageBox.Show("Selesione a Unidade de Venda!");
                cbUniVenda.Select();
            }
            //else if (cbGondola.Text == "")
            //{
            //    MessageBox.Show("PREENCHA A LOCALIZAÇÃO.");
            //    cbGondola.Select();
            //}
            else
            {
                salvar(tipo);
            }
        }

        private void montaProduto()
        {
            if (txtDesconto.Text == "")
            {
                txtDesconto.Text = "0,00";
            }
            if (txtEstoqueMax.Text == "")
            {
                txtEstoqueMax.Text = "10";
            }
            if (txtEstoqueMin.Text == "")
            {
                txtEstoqueMin.Text = "1";
            }
            if (txtEstoqueAtual.Text == "")
            {
                txtEstoqueAtual.Text = "0";
            }
            //monta o objeto produto
            if (txtCod.Text != "")
            {
                produto.Id = Convert.ToInt32(txtCod.Text);
            }
            if (checkBalanca.Checked == false)
            {
                produto.CodigoBarras = txtCodBar.Text;
                produto.CodigoBarrasBalanca = 0;
            }
            else if (checkBalanca.Checked == true)
            {
                produto.CodigoBarrasBalanca = novoCodProdBalanca;
                produto.CodigoBarras = "NOT";
            }

            produto.Nome = txtNome.Text;
            produto.Descricao = txtDescricao.Text;
            produto.PrecoCusto = Convert.ToDouble(txtPrecoCusto.Text);
            produto.MargemLucro = Convert.ToDouble(txtMargemLucro.Text);
            produto.PrecoVenda = Convert.ToDouble(txtPrecoVenda.Text);
            produto.Desconto = Convert.ToDouble(txtDesconto.Text);
            produto.Imagem = "C:\\queijo_cia\\logo_queijo_cia.png";
            produto.CategoriaId = 1;

            // categoriaDb.retornaIdPorDescricao(txtCat.Text);
            //produto.Status = cbStatus.Text;

            //monta o objeto estoque


            //string local = cbGondola.Text;
            //string prateleira = cbPrateleira.Text;
            //string gaveta = cbGaveta.Text;

            produto.UnidVenda = converteUnidVenda(cbUniVenda.Text);

            produto.EstoqueMin = Convert.ToInt32(txtEstoqueMin.Text);
            produto.EstoqueMax = Convert.ToInt32(txtEstoqueMax.Text);
            produto.EstoqueAtual = Convert.ToInt32(txtEstoqueAtual.Text);
            //produto.Localizacao = local;
            //estoque.Prateleira= gaveta;
            //estoque.Gaveta = gaveta;

            //estoque.Id_produto = produto.Id;
        }

        private string converteUnidVenda(string unidVenda)
        {
            switch (unidVenda)
            {
                case "Unidade":
                    return "UN";
                case "Kilograma":
                    return "KG";
                case "Litro":
                    return "LT";
                case "Jogo":
                    return "JG";
                case "Kit":
                    return "KT";
                case "Metro":
                    return "MT";
                case "UN":
                    return "Unidade";
                case "KG":
                    return "Kilograma";
                case "LT":
                    return "Litro";
                case "JG":
                    return "Jogo";
                case "KT":
                    return "KIT";
                case "MT":
                    return "Metro";
                default:
                    return "";
            }
        }
        //private bool verificaFornecedor()
        //{
        //    if(fornecedorDb.verificaOcorrencia())

        //    return true;
        //}


        private void insereFornecedor()
        {

            ////insere o produto na tabela produtos de orcamento
            //string inserItens = "INSERT INTO `parcela`(`id`,`id_crediario`,`num_parcela`, `qtde_parcelas`, `valor`,`vencimento`,`valor_recebido`, `status`) VALUES(NULL,?,?,?,?,?,?,?)";
            //MySqlConnection conn = Conect.obterConexao();
            //MySqlCommand objcmd = new MySqlCommand(inserItens, conn);

            //for (int i = 0; i < dgFornecedores.Rows.Count; i++)
            //{
            //    int id_fornecedor = Convert.ToInt32(dgFornecedores.Rows[i].Cells[0].Value);
            //    int id_produto = Convert.ToInt32(dgFornecedores.Rows[i].Cells[1].Value);

            //    if (fornecedorDb.verificaOcorrencia(id_fornecedor, id_produto))
            //    {
            //        insereFornecedor();
            //    }
            //    objcmd.Parameters.Add("@id_crediario", MySqlDbType.Int32, 11).Value = crediario.Id;
            //    objcmd.Parameters.Add("@num_parcela", MySqlDbType.Int32, 11).Value = dtParcelas.Rows[i]["num_parcela"];
            //    objcmd.Parameters.Add("@qtde_parcelas", MySqlDbType.Int32, 11).Value = dtParcelas.Rows[i]["qtde_parcela"];
            //    objcmd.Parameters.AddWithValue("@valor", dataGridView1.Rows[i].Cells[1].Value);
            //    string dataBarra = dataGridView1.Rows[i].Cells[2].Value.ToString() + " 00:00:00";
            //    DateTime date = new DateTime();
            //    date = Convert.ToDateTime(dataBarra);
            //    date.ToString("yyyy-MM-dd");

            //    objcmd.Parameters.Add("@vencimento", MySqlDbType.Date).Value = date;
            //    objcmd.Parameters.Add("@_valorRecebido", MySqlDbType.Decimal, 8).Value = 0.00;
            //    objcmd.Parameters.Add("@_status", MySqlDbType.Int32, 11).Value = 0;
            //    try
            //    {
            //        //executa a inserção
            //        objcmd.ExecuteNonQuery();

            //    }
            //    catch (Exception erro)
            //    {
            //        string teste = erro.ToString();
            //        MessageBox.Show(teste);
            //    }
            //    objcmd.Parameters.Clear();

            //}
        }

        private void salvar(int tipo)
        {


            if (tipo == 1)
            {
                montaProduto();
                _produtoRepository.Cadastrar(produto);

                DialogResult result = MessageBox.Show("Cadastrar novo produto?", "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    limpCampProd();
                    loadCadastro();
                    //dtFornecedores.Rows.Clear();
                    txtCodBar.Select();
                }
                else
                {
                    this.Close();
                }
            }
            if (tipo == 2)
            {
                montaProduto();

                //estoqueDb.atualiza(estoque);
                _produtoRepository.Atualizar(produto);
                MessageBox.Show("Produto atualizado com sucesso!");
                limpCampProd();
                loadCadastro();
                //dtFornecedores.Rows.Clear();
                txtCodBar.Text = string.Empty;
                txtCodBar.Select();
            }
        }



        private void loadCategoria()
        {
            //DataTable categoria = new DataTable();
            //categoria = categoriaDb.consultaTodos();
            //if (categoria != null)
            //{
            //    //Carrrega itens do DataTable para a ComboBox
            //    for (int i = 0; i < categoria.Rows.Count; i++)
            //    {
            //        txtCat.Items.Add(categoria.Rows[i]["descricao"].ToString());
            //    }
            //}
            txtCat.TabIndex = 0;
        }


        private void txtPrecoCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtPrecoCusto.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                if (txtPrecoCusto.Text != "")
                {
                    txtMargemLucro.Select();
                }
            }
        }

        private void txtMargemLucro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtDesconto.Text = "";
            }
            if (e.KeyChar == 13)
            {
                if (txtPrecoCusto.Text != "" && txtMargemLucro.Text != "")
                {
                    txtPrecoVenda.Text = "0,00";
                    calculaValores("lucro");
                    txtDesconto.Select();
                }
            }
        }

        private void txtPrecoVenda_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtPrecoVenda.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                if (txtPrecoCusto.Text != "" && txtPrecoVenda.Text != "")
                {
                    txtMargemLucro.Text = "0,00";
                    calculaValores("venda");
                    txtMargemLucro.Select();
                }
            }
        }

        private void txtDesconto_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtDesconto.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                txtEstoqueAtual.Select();
            }
        }
        void calculaValores(string tipo)
        {
            //MessageBox.Show(txtMargemLucro.Text);
            decimal custo = Convert.ToDecimal(txtPrecoCusto.Text);
            decimal venda = Convert.ToDecimal(txtPrecoVenda.Text);
            decimal lucro = Convert.ToDecimal(txtMargemLucro.Text);
            if (tipo == "venda")
            {
                lucro = ((venda - custo) / custo) * 100;
                lucro = Math.Round(lucro, 2);
                txtMargemLucro.Text = lucro.ToString();
            }
            if (tipo == "lucro")
            {
                venda = custo + ((custo / 100) * lucro);
                venda = Math.Round(venda, 2);
                txtPrecoVenda.Text = venda.ToString();
            }
            if (venda <= custo)
            {
                MessageBox.Show("Preço de custo maior que Preço de venda!");
                txtPrecoCusto.Text = "";
                txtMargemLucro.Text = "";
                txtPrecoVenda.Text = "";
            }
        }

        private void txtEstoqueMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero");
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtDesconto.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                cbUniVenda.Select();
            }
        }

        private void txtEstoqueMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero");
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtDesconto.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                txtEstoqueMax.Select();
            }
        }

        private void txtEstoqueAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero");
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtDesconto.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                txtEstoqueMin.Select();
            }
        }



        private void cbStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgProdutos.DataSource = _produtoRepository.ObterProdutos(txtNome.Text);

                if(dgProdutos.Rows.Count > 0)
                {
                    dgProdutos.Visible = true;
                    pnHeaderDgProdutos.Visible = true;
                    dgProdutos.BringToFront();
                    dgProdutos.Rows[0].Selected = true;
                }
            }
            if (e.KeyChar == 27)
            {
                dgProdutos.Visible = false;
                pnHeaderDgProdutos.Visible = false;
            }
        }

        private void btnListarFornecedores_Click(object sender, EventArgs e)
        {
            //ofuscaFundo();
            //FrmInsereFornecedor c = new FrmInsereFornecedor(produto.Id);
            //c.ShowDialog();
            //povoa_fornecedores(id_produto);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpCampProd();
        }

    

        private void txtCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodBar.Select();
        }


        private void btnNovoLocal_Click(object sender, EventArgs e)
        {
            //FrmLocalEstoque local = new FrmLocalEstoque();
            //local.ShowDialog();

            //for (int i = 0; i < cbGondola.Items.Count; i++)
            //{
            //    cbGondola.Items.Remove(cbGondola.SelectedIndex = i);
            //}

            //loadLocaisEstoque();
        }

        private void FrmCadastroProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            //}
        }

        private void txtMargemLucro_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnExcluirFornecedor_Click(object sender, EventArgs e)
        {
            //fornecedorDb.deleteFornecedorPorProduto(id_fornecedor, produto.Id);
            //povoa_fornecedores(id_produto);
        }

        private void dgFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //// vamos obter a linha da célula selecionada
            //DataGridViewRow linhaAtual = dgFornecedores.CurrentRow;
            //// vamos exibir o índice da linha atual
            //int indice = linhaAtual.Index;

            //id_fornecedor = Convert.ToInt32(dgFornecedores.Rows[indice].Cells[0].Value);
            //btnExcluirFornecedor.Enabled = true;
        }

        private Produto VerificaItemDeBalança(string codigoBarras)
        {
            string primeiroCaracter = codigoBarras.Substring(0, 1);
            if (primeiroCaracter == "2")
            {
                string codigoProduto = codigoBarras.Substring(1, 6);//000000 000000 0
                if (codigoProduto != "000000")
                {
                    codigoProduto = codigoProduto.TrimStart('0');
                }
                return _produtoRepository.ObterProdutoPorCodigoBarrasBalanca(codigoProduto);          
            }
            else
            {
                return _produtoRepository.ObterProdutoPorCodigoBarras(codigoBarras);
            }
        }



        private void txtCodBar_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero");
            }
          
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                string codbar = txtCodBar.Text;
                int tamanhoCod = codbar.Length;
                if (tamanhoCod == 13)
                {
                    produto = VerificaItemDeBalança(codbar);
                    if (produto.Id == 0)
                    {
                        limpCampProd();
                        loadCadastro();
                        txtCodBar.Text = codbar;
                    }
                    else
                    {
                        loadAtualizacao(produto);
                    }
                }
                else if (tamanhoCod > 13)
                {
                    produto = _produtoRepository.ObterProdutoPorCodigoBarras(codbar);
                    if (produto.Id == 0)
                    {
                        limpCampProd();
                        loadCadastro();
                        txtCodBar.Text = codbar;
                    }
                    else
                    {
                        loadAtualizacao(produto);
                    }
                }
                else if (tamanhoCod < 13 && codbar.Length > 7)
                {
                    produto = _produtoRepository.ObterProdutoPorCodigoBarras(codbar);
                    if (produto.Id == 0)
                    {
                        limpCampProd();
                        loadCadastro();
                        txtCodBar.Text = codbar;
                    }
                    else
                    {
                        loadAtualizacao(produto);
                    }
                }
                else if(codbar.Length < 8)
                {
                    produto = _produtoRepository.ObterProdutoPorCodigoBarrasBalanca(codbar);
                    if (produto.Id == 0)
                    {
                        //calcular o proximo numero de codigo de barras para produto de balança
                        limpCampProd();
                        loadCadastro();

                        MessageBox.Show("Produto não cadastrado!");
                    }
                    else
                    {
                        loadAtualizacao(produto);
                    }
                }
            }
        }

        //private void txtMarca_Enter(object sender, EventArgs e)
        //{
        //    txtDescricao.SelectionStart = txtDescricao.Text.Length + 1;
        //}

        private void btnImagem_Click(object sender, EventArgs e)
        {
            txtPrecoCusto.Select();
        }

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {    
            if(e.KeyValue == 27)
            {
                dgProdutos.Visible = false;
            }
        }

        private void dgProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewRow linha = dgProdutos.CurrentRow;
                int indice = linha.Index;
                int Id = Convert.ToInt32(dgProdutos.Rows[indice].Cells[0].Value);
                produto = _produtoRepository.ObterProduto(Id);
                loadAtualizacao(produto);
                dgProdutos.Visible = false;
                pnHeaderDgProdutos.Visible = false;
            }
            if (e.KeyCode == Keys.Escape)
            {
                dgProdutos.Visible = false;
                pnHeaderDgProdutos.Visible = false;
                txtNome.Select();
                txtNome.SelectionStart = txtNome.Text.Length;
            }
        }

        private void dgProdutos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!dgProdutosClicado) 
            {
                dgProdutos.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgProdutos.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void dgProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgProdutosClicado = true;
            DataGridViewRow linha = dgProdutos.CurrentRow;
            int indice = linha.Index;
            int Id = Convert.ToInt32(dgProdutos.Rows[indice].Cells[0].Value);
            produto = _produtoRepository.ObterProduto(Id);
            loadAtualizacao(produto);
            dgProdutos.Visible = false;
            pnHeaderDgProdutos.Visible = false;
        }

        private void FrmCadastroProdutos_Click(object sender, EventArgs e)
        {

                dgProdutos.Visible = false;
            pnHeaderDgProdutos.Visible = false;
        }

        private void txtPrecoCusto_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPrecoCusto.Text.Length > 2)
            {
                try
                {
                    string valor = MascaraDecimal.mascara(txtPrecoCusto.Text);
                    txtPrecoCusto.Text = valor.ToString();
                    txtPrecoCusto.SelectionStart = txtPrecoCusto.Text.Length + 1;
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.ToString());
                }
            }
        }

        private void txtPrecoVenda_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPrecoVenda.Text.Length > 2)
            {
                try
                {
                    string valor = MascaraDecimal.mascara(txtPrecoVenda.Text);
                    txtPrecoVenda.Text = valor.ToString();
                    txtPrecoVenda.SelectionStart = txtPrecoVenda.Text.Length + 1;
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.ToString());
                }
            }
        }

        private void txtDesconto_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtDesconto.Text.Length > 2)
            //{
            //    try
            //    {
            //        string valor = MascaraDecimal.mascara(txtDesconto.Text);
            //        txtDesconto.Text = valor.ToString();
            //        txtDesconto.SelectionStart = txtDesconto.Text.Length + 1;
            //    }
            //    catch (Exception erro)
            //    {
            //        MessageBox.Show(erro.ToString());
            //    }
            //}
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgProdutos.Select();
                dgProdutos.Rows[0].Selected = true;
            }
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            dgProdutos.Visible = false;
            pnHeaderDgProdutos.Visible = false;
            produto.Id = 0;
            limpCampProd();
            loadCadastro();
            tabControl1.SelectedIndex = 0;
            checkBalanca.Checked = false;
        }

        private void txtNome_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgProdutos.Select();
                dgProdutos.Select();
            }
        }

        private void checkBalanca_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBalanca.Checked == true)
            {
                loadCadastro();
                novoCodProdBalanca = _produtoRepository.CalculaCodigoBalanca();
                txtCodBar.ReadOnly = true;

                txtCodBar.Text = novoCodProdBalanca.ToString();
            }
            else
            {
                limpCampProd();
                loadCadastro();
                txtCodBar.ReadOnly = false;
            }
        }

        private void FrmCadastroProdutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!dgProdutos.Visible)
            {
                if (e.KeyChar == 27)
                {
                    this.Close();
                }
            }          
        }

        private void cbGondola_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja excluir esse produto?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {
                _produtoRepository.Excluir(produto.Id);
                MessageBox.Show("Produto excluído com sucesso!");
                limpCampProd();
            }
            else
            {
                MessageBox.Show("não");
            }
        }
    }
}