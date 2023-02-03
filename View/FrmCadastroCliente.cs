using VarejoSimplesModa.Model;
using VarejoSimplesModa.Repository;
using VarejoSimplesModa.Repository.RepositoryInterfaces;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace VarejoSimplesModa.View
{
    public partial class FrmCadastroCliente : Form
    {

        private IClienteRepository _clienteRepository = new ClienteRepository();

        private int? Id;
        private Cliente cliente = new Cliente();
        private bool cpf;
        private bool cnpj;

        public FrmCadastroCliente(int id_cliente)
        {
            InitializeComponent();
            this.cliente.Id = id_cliente;
            MudaCorTextBox.RegisterFocusEvents(this.Controls);//chama a classe que muda a cor do campo que esta digitando
        }

        private void FrmCadastroCliente_Load(object sender, EventArgs e)
        {
            if (cliente.Id == 0)
            {
                //gera novo numero de cliente
                //cliente.Id = clienteDb.geraCodCliente();
                txtCod.Text = cliente.Id.ToString();
                cbStatus.SelectedIndex = 0;
                cbLogradouro.SelectedIndex = 0;
                cbTipoPessoa.SelectedIndex = 0;
                txtnome.Select();

                //esconde o textbox da pessoa jurídica
                txtCnpj.Visible = false;
                lblCnpj.Visible = false;
                btnCadastrar.Visible = true;
                btnAtualizar.Visible = false;
            }
            else if (cliente.Id > 0)
            {
                cliente = _clienteRepository.ObterCliente(cliente.Id);
                txtCod.Text = cliente.Id.ToString();
                //cbStatus.Text = cliente.status;
                txtnome.Text = cliente.nome;
                if (cliente.cpf.Length < 18)
                {
                    cbTipoPessoa.SelectedIndex = 0;
                    lblCpf.Visible = true;
                    txtcpf.Visible = true;
                    lblCnpj.Visible = false;
                    txtCnpj.Visible = false;
                    txtcpf.Text = cliente.cpf;
                }
                else
                {
                    cbTipoPessoa.SelectedIndex = 1;
                    lblCpf.Visible = false;
                    txtcpf.Visible = false;
                    lblCnpj.Visible = true;
                    txtCnpj.Visible = true;
                    txtCnpj.Text = cliente.cpf;
                }
                //cbSexo.Text = cliente.sexo;
                //txtRg.Text = cliente.rg;
                //txtNascimento.Text = cliente.data_nasc;

                
                txttelefone.Text = cliente.telefone;
                txttelefone_2.Text = cliente.telefone_2;
                //txtEmail.Text = contato.email;

                //cbLogradouro.Text = cliente.rua;
                txtrua.Text = cliente.rua;
                txtnumero.Text = cliente.numero;
                //txtComplemento.Text = cliente.complemento;
                //txtReferencia.Text = cliente.referencia;
                txtbairro.Text = cliente.bairro;
                txtcidade.Text = cliente.cidade;
                //cbUf.Text = cliente.uf;
                txtcep.Text = cliente.cep;
                //
                btnCadastrar.Visible = false;
                btnAtualizar.Visible = true;
            }

        }

        //executa quando muda o estado do combobox
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoPessoa.Text == "Física")
            {
                txtCnpj.Visible = false;
                lblCnpj.Visible = false;
                txtcpf.Visible = true;
                lblCpf.Visible = true;
                label13.Visible = true;
                label2.Visible = true;
                label15.Visible = true;
                cbSexo.Visible = true;
                txtNascimento.Visible = true;
                txtRg.Visible = true;

            }
            else if (cbTipoPessoa.Text == "Jurídica")
            {
                txtcpf.Visible = false;
                lblCpf.Visible = false;
                txtCnpj.Visible = true;
                lblCnpj.Visible = true;
                label13.Visible = false;
                label2.Visible = false;
                label15.Visible = false;
                cbSexo.Visible = false;
                txtNascimento.Visible = false;
                txtRg.Visible = false;
            }
        }

        private void txtcpf_Leave(object sender, EventArgs e)
        {
            if (txtcpf.Text == "   .   .   -")
            {
                txtcpf.BackColor = Color.White;
            }
            else
            {
                cpf = ValidaCpfCnpj.IsCpf(txtcpf.Text);
                //bool existeCpf = clienteDb.cpfJaCadastrado(txtcpf.Text);
                if (!cpf)
                {
                    MessageBox.Show("CPF inválido!");
                    txtcpf.Text = "";
                    txtcpf.BackColor = Color.Tomato;
                    txtcpf.Select();
                }
                //else if (existeCpf)
                //{
                //    MessageBox.Show("CPF já cadastrado!");
                //    txtcpf.Text = "";
                //    txtcpf.BackColor = Color.Tomato;
                //    txtcpf.Select();
                //}
            }
        }

        private void txtcpf_KeyUp(object sender, KeyEventArgs e)
        {
            txtcpf.BackColor = Color.White;
        }

        private void txtCnpj_Leave(object sender, EventArgs e)
        {
            cnpj = ValidaCpfCnpj.IsCnpj(txtCnpj.Text);
            //bool existeCnpj = _clienteRepository.cnpjJaCadastrado(txtCnpj.Text);

            if (txtCnpj.Text == "   .   .   /    -")
            {
                txtCnpj.BackColor = Color.White;
            }
            else
            {

                if (!cnpj)
                {
                    MessageBox.Show("CNPJ inválido!");
                    txtCnpj.Text = "";
                    txtCnpj.BackColor = Color.Tomato;
                    txtCnpj.Select();
                }
                //else if (existeCnpj)
                //{
                //    MessageBox.Show("CNPJ já cadastrado!");
                //    txtCnpj.Text = "";
                //    txtCnpj.BackColor = Color.Tomato;
                //    txtCnpj.Select();
                //}
            }

        }

        private bool validaCampos()
        {
            if (txtcpf.Text == "   .   .   -" && txtCnpj.Text == "   .   .   /    -")
            {
                MessageBox.Show("Informe o CPF/CNPJ");
                cbTipoPessoa.Select();
                return false;
            }
            else if (txtnome.Text == "")
            {
                MessageBox.Show("Informe o endereço.");
                txtnome.Select();
                return false;
            }
            else if (txtrua.Text == "")
            {
                MessageBox.Show("Informe o endereço.");
                txtrua.Select();
                return false;
            }
            else if (txttelefone.Text == "" || txttelefone_2.Text == "")
            {
                MessageBox.Show("Informe um telefone.");
                txttelefone.Select();
                return false;
            }
            else if (cbLogradouro.Text == "")
            {
                MessageBox.Show("Informe o logradouro");
                cbLogradouro.Select();
                return false;
            }
            else if (txtrua.Text == "")
            {
                MessageBox.Show("Informe o endereço.");
                txtrua.Select();
                return false;
            }
            else if (txtnumero.Text == "")
            {
                MessageBox.Show("Informe o número");
                txtnumero.Select();
                return false;
            }
            else if (txtbairro.Text == "")
            {
                MessageBox.Show("Informe o bairro.");
                txtbairro.Select();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void salvar()
        {
            //gera novo id de contato
            //contato.Id = contatoDb.geraCodContato();
            //gera novo id de endereço
            //endereco.Id = enderecoDb.geraCodEndereco();

            cliente.telefone = txttelefone.Text;
            cliente.telefone_2 = txttelefone_2.Text;
            //cliente.Email = txtEmail.Text;

            //cliente.Logradouro = cbLogradouro.Text;
            cliente.rua = txtrua.Text;
            cliente.numero = txtnumero.Text;
            //cliente.Complemento = txtReferencia.Text;
            //cliente.Referencia = txtReferencia.Text;
            cliente.bairro = txtbairro.Text;
            cliente.cidade = txtcidade.Text;
            //cliente.Uf = cbUf.Text;
            cliente.cep = txtcep.Text;

            cliente.Id = Convert.ToInt32(txtCod.Text);
            cliente.nome = txtnome.Text;
            //cliente.Sexo = cbSexo.Text;
            //cliente.Rg = txtRg.Text;
            if (cbTipoPessoa.Text == "Física")
            {
                cliente.cpf = txtcpf.Text;
            }
            else
            {
                cliente.cpf = txtCnpj.Text;
            }
            //cliente.Data_nasc = txtNascimento.Text;
            //cliente.Status = cbStatus.Text;
            //cliente.Contato = contato;
            //cliente.Endereco = endereco;

            //contatoDb.insere(contato);
            //enderecoDb.insere(endereco);
            _clienteRepository.Cadastrar(cliente);

            DialogResult result = MessageBox.Show("Cadastrar novo Cliente?", "Cancela", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {
                limpaCamposCad();
                //cliente.Id = clienteDb.geraCodCliente();
                txtCod.Text = cliente.Id.ToString();
                cbStatus.SelectedValue = "Ativo";
                txtnome.Select();
            }
            else
            {
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (validaCampos())
            {
                salvar();
            }
        }

        //private void btnCancelar_Click(object sender, EventArgs e)
        //{

        //    DateTime date = new DateTime();
        //    date = Convert.ToDateTime(cliente.Data_nasc);
        //    String DATA = date.ToString("yyyy-MM-dd");
        //    MessageBox.Show(DATA);
        //}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpaCamposCad()
        {
            txtnome.Text = string.Empty;
            txtcpf.Text = string.Empty;
            txtCnpj.Text = string.Empty;
            txtrua.Text = string.Empty;
            txttelefone.Text = string.Empty;
            txttelefone_2.Text = string.Empty;
            cbLogradouro.Text = string.Empty;
            txtnumero.Text = string.Empty;
            txtbairro.Text = string.Empty;
            txtReferencia.Text = string.Empty;
            txtcidade.Text = string.Empty;
            txtcep.Text = string.Empty;
            cbUf.Text = string.Empty;
            cbSexo.Text = string.Empty;
            txtRg.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtNascimento.Text = string.Empty;
        }



        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaCamposCad();
        }


        private void atualizar()
        {
            //gera novo id de contato
            //contato.Id = contatoDb.geraCodContato();
            //gera novo id de endereço
            //endereco.Id = enderecoDb.geraCodEndereco();

            cliente.telefone = txttelefone.Text;
            cliente.telefone_2 = txttelefone_2.Text;
            //cliente.Email = txtEmail.Text;

            //cliente.Logradouro = cbLogradouro.Text;
            cliente.rua = txtrua.Text;
            cliente.numero = txtnumero.Text;
            //cliente.Complemento = txtReferencia.Text;
            //cliente.Referencia = txtReferencia.Text;
            cliente.bairro = txtbairro.Text;
            cliente.cidade = txtcidade.Text;
            //cliente.Uf = cbUf.Text;
            cliente.cep = txtcep.Text;

            cliente.Id = Convert.ToInt32(txtCod.Text);
            cliente.nome = txtnome.Text;
            //cliente.Sexo = cbSexo.Text;
            //cliente.Rg = txtRg.Text;
            if (cbTipoPessoa.Text == "Física")
            {
                cliente.cpf = txtcpf.Text;
            }
            else
            {
                cliente.cpf = txtCnpj.Text;
            }
            //cliente.Data_nasc = txtNascimento.Text;
            //cliente.Status = cbStatus.Text;
            //cliente.Contato = contato;
            //cliente.Endereco = endereco;

            //contatoDb.insere(contato);
            //enderecoDb.insere(endereco);
            _clienteRepository.Atualizar(cliente);
            MessageBox.Show("Cliente atualizado com sucesso!");
            //this.Close();
        }

        private void btnAtualizar_Click_1(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                atualizar();
            }
        }

        private string letrasMaiusculas(string texto)
        {
            texto = texto.ToUpper();
            return texto;
        }

        private void txtnome_KeyUp(object sender, KeyEventArgs e)
        {
            //nao compensa
            //MudaParaMaiuscula.RegisterKeyUpEvents(this.Controls, txtnome.Text);//chama a classe que muda para maiuscula as letras do campo que esta digitando
            txtnome.Text = txtnome.Text.ToUpper();
            txtnome.SelectionStart = txtnome.Text.Length;
        }

        private void txtRg_KeyUp(object sender, KeyEventArgs e)
        {
            txtRg.Text = txtRg.Text.ToUpper();
            txtRg.SelectionStart = txtRg.Text.Length;
        }

        private void txtEmail_KeyUp(object sender, KeyEventArgs e)
        {
            txtEmail.Text = txtEmail.Text.ToUpper();
            txtEmail.SelectionStart = txtEmail.Text.Length;
        }

        private void txtrua_KeyUp(object sender, KeyEventArgs e)
        {
            txtrua.Text = txtrua.Text.ToUpper();
            txtrua.SelectionStart = txtrua.Text.Length;
        }

        private void txtnumero_KeyUp(object sender, KeyEventArgs e)
        {
            txtnumero.Text = txtnumero.Text.ToUpper();
            txtnumero.SelectionStart = txtnumero.Text.Length;
        }

        private void txtComplemento_KeyUp(object sender, KeyEventArgs e)
        {
            txtComplemento.Text = txtComplemento.Text.ToUpper();
            txtComplemento.SelectionStart = txtComplemento.Text.Length;
        }

        private void txtReferencia_KeyUp(object sender, KeyEventArgs e)
        {
            txtReferencia.Text = txtReferencia.Text.ToUpper();
            txtReferencia.SelectionStart = txtReferencia.Text.Length;
        }

        private void txtbairro_KeyUp(object sender, KeyEventArgs e)
        {
            txtbairro.Text = txtbairro.Text.ToUpper();
            txtbairro.SelectionStart = txtbairro.Text.Length;
        }

        private void txtcidade_KeyUp(object sender, KeyEventArgs e)
        {
            txtcidade.Text = txtcidade.Text.ToUpper();
            txtcidade.SelectionStart = txtcidade.Text.Length + 1;
        }

        private void FrmCadastroCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
