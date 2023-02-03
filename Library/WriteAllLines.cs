using VarejoSimplesModa.Model;
using VarejoSimplesModa.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VarejoSimplesModa.Library
{
    public class WriteAllLines
    {
        private IProdutoRepository _produtoRepository = new ProdutoRepository();
        private FormataTxtProdutos formataTxtProdutos = new FormataTxtProdutos();
        private FormataTxtSetor formataTxtSetor = new FormataTxtSetor();
        private List<Produto> produtos = new List<Produto>();

        private void buscaProdutos()
        {
            produtos = _produtoRepository.ObterTodosProdutoDeBalanca();
        }

        public void CriaCadTxt()
        {
            criaDiretorio();
            buscaProdutos();

            string[] lines = new string[produtos.Count];
            for (int i= 0; i<produtos.Count; i++)
            {
                string cod = produtos[i].CodigoBarrasBalanca.ToString();
                string codFormatado = formataTxtProdutos.formataCodigo(cod);
                string tipo = produtos[i].UnidVenda;

                switch (tipo)
                {
                    case "UN":
                        tipo = "U";
                        break;
                    case "KG":
                        tipo = "P";
                        break;
                    case "LT":
                        tipo = "L";
                        break;
                    case "JG":
                        tipo = "J";
                        break;
                    case "Kit":
                        tipo = "K";
                        break;
                    case "Metro":
                        tipo = "M";
                        break;
                }

                string nome = produtos[i].Nome;
                string nomeFormatado = formataTxtProdutos.formataNome(nome);

                string preco = produtos[i].PrecoVenda.ToString("N2");
                string precoFormatado = formataTxtProdutos.formataPreco(preco);

                //string preco = produtos[i].PrecoVenda.ToString().Replace(",", "");
                lines[i] = codFormatado + tipo + nomeFormatado + precoFormatado + "000";
            }

             File.WriteAllLines("C:\\FILIZOLA\\CADTXT.txt", lines);
        }

        public void CriaSetorTxt()
        {
            string[] lines = new string[produtos.Count];
            for (int i = 0; i < produtos.Count; i++)
            {
                //string nome = produtos[i].Nome;
                string nomeFormatado = formataTxtSetor.formataNome("loja");

                string cod = produtos[i].CodigoBarrasBalanca.ToString();
                string codFormatado = formataTxtSetor.formataCodigo(cod);

                string indice = "";

                switch (i.ToString().Length)
                {
                    case 1:
                        indice = "000" + i;
                        break;
                    case 2:
                        indice = "00" + i;
                        break;
                    case 3:
                        indice = "0" + i;
                        break;
                    case 4:
                        indice = i.ToString();
                        break;
                }


                //string preco = produtos[i].PrecoVenda.ToString().Replace(",", "");
                lines[i] = nomeFormatado + codFormatado + indice + "000";
            }

            File.WriteAllLines("C:\\FILIZOLA\\SETORTXT.txt", lines);
        }


        private void criaDiretorio()
        {
            // Specify the directory you want to manipulate.
            string path = @"c:\FILIZOLA";

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                else
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("The directory was created successfully at {0}.", 
                    Directory.GetCreationTime(path));
                }


                // Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }
    }
}
