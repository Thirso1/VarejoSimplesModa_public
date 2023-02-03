using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Library
{
    public class FormataTxtProdutos
    {
        private string[] cod = new string[6];
        private string[] item = new string[3];
        private string[] nome = new string[22];
        private string[] qtdeVenda = new string[6];
        private string[] nomeVenda = new string[21];
        private string[] preco = new string[7];
        private string[] validade = {"0","0","0"};// new string[3];


        //formata codigo do produto para criação do arquivo para a balança
        public string formataCodigo(string codProd)
        {
            //preencho array cod com zeros
            for (int i = 0; i < 6; i++)
            {
                cod[i] = "0";
            }
            //cria um array para receber o codigo do produto
            char[] codArray;
            //transforma o codProduto em array e atribui ao codArray
            codArray = codProd.ToCharArray(0, codProd.Length);
            //verifica a diferença de tanmanho entro os dois arrays
            int resto = cod.Length - codArray.Length;
            //cria o loop partindo do final do resto ate o fim
            for (int i = 0; i < codArray.Length; i++)
            {
                cod[resto] = codArray[i].ToString();
                resto++;
            }
            return String.Join("", cod);
        }

        //formata nome do produto para criação do arquivo para a balança
        public string formataNome(string nomeProd)
        {
            Console.WriteLine(nomeProd);
            //verifica o tamanho e corta o final do array
            if (nomeProd.Length > 21)
            {
                for (int i = 21; i < nomeProd.Length; i++)
                {
                    nomeProd = nomeProd.Remove(i, nomeProd.Length - 22);
                }
            }

            //preencho array nome
            Console.WriteLine(nomeProd);
            for (int i = 0; i < 22; i++)
            {
                nome[i] = " ";
            }
            //cria um array para receber o nome do produto
            char[] nomeArray;
            //transforma o nomeProd em array e atribui ao nomeArray
            nomeArray = nomeProd.ToCharArray(0, nomeProd.Length);

            Console.WriteLine(String.Join("", nomeArray));
            //cria o loop partindo do final do resto ate o fim
            for (int i = 0; i < nomeArray.Length; i++)
            {
                nome[i] = nomeArray[i].ToString();
            }
            return String.Join("", nome);
        }

        //formata preço do produto para criação do arquivo para a balança
        public string formataPreco(string precoProd)
        {
            //retirar a virgula ou ponto
            precoProd = precoProd.Replace(",", "").Replace(".", "");
            //preencho array nome
            for (int i = 0; i < 7; i++)
            {
                preco[i] = "0";
            }
            //cria um array para receber o preco do produto
            char[] precoArray;
            //transforma o codProduto em array e atribui ao codArray
            precoArray = precoProd.ToCharArray(0, precoProd.Length);
            //verifica a diferença de tanmanho entre os dois arrays
            int resto = preco.Length - precoProd.Length;
            //cria o loop partindo do final do resto ate o fim
            for (int i = 0; i < precoArray.Length; i++)
            {
                preco[resto] = precoArray[i].ToString();
                resto++;
            }
            return String.Join("", preco);
        }



        //formata numero do item de venda - impressao de venda
        public string formataItem(string codItem)
        {
            //preencho array cod com zeros
            for (int i = 0; i < 2; i++)
            {
                item[i] = " ";
            }
            //cria um array para receber o codigo do produto
            char[] codArray;
            //transforma o codProduto em array e atribui ao codArray
            codArray = codItem.ToCharArray(0, codItem.Length);
            //verifica a diferença de tanmanho entro os dois arrays
            int resto = item.Length - codArray.Length;
            //cria o loop partindo do final do resto ate o fim
            for (int i = 0; i < codArray.Length; i++)
            {
                item[resto] = codArray[i].ToString();
                resto++;
            }
            return String.Join("", item);
        }

        //formata qtde do item de venda - impressao de venda
        public string formataQtde(string codQtde)
        {
            //preencho array cod com zeros
            for (int i = 0; i < 5; i++)
            {
                qtdeVenda[i] = " ";
            }
            //cria um array para receber o codigo do produto
            char[] codArray;
            //transforma o codProduto em array e atribui ao codArray
            codArray = codQtde.ToCharArray(0, codQtde.Length);
            //verifica a diferença de tanmanho entro os dois arrays
            int resto = qtdeVenda.Length - codArray.Length;
            //cria o loop partindo do final do resto ate o fim
            for (int i = 0; i < codArray.Length; i++)
            {
                qtdeVenda[resto] = codArray[i].ToString();
                resto++;
            }
            return String.Join("", qtdeVenda);
        }


        //formata nome do produto do item de venda - impressao de venda
        public string formataNomeVenda(string nomeProd)
        {
            //verifica o tamanho e corta o final do array
            if (nomeProd.Length > 20)
            {
                for (int i = 21; i < nomeProd.Length; i++)
                {
                    nomeProd = nomeProd.Remove(i, nomeProd.Length - 21);
                }
            }

            //preencho array nome
            Console.WriteLine(nomeProd);
            for (int i = 0; i < 21; i++)
            {
                nomeVenda[i] = " ";
            }
            //cria um array para receber o nome do produto
            char[] nomeArray;
            //transforma o nomeProd em array e atribui ao nomeArray
            nomeArray = nomeProd.ToCharArray(0, nomeProd.Length);

            Console.WriteLine(String.Join("", nomeArray));
            //cria o loop partindo do final do resto ate o fim
            for (int i = 0; i < nomeArray.Length; i++)
            {
                nomeVenda[i] = nomeArray[i].ToString();
            }
            return String.Join("", nomeVenda);
        }


        //formata preço e subtotal do item de venda - impressao de venda
        public string formataPrecoVenda(string precoProd)
        {
            //retirar a virgula ou ponto
            //precoProd = precoProd.Replace(",", "").Replace(".", "");
            //preencho array nome
            for (int i = 0; i < 7; i++)
            {
                preco[i] = " ";
            }
            //cria um array para receber o preco do produto
            char[] precoArray;
            //transforma o codProduto em array e atribui ao codArray
            precoArray = precoProd.ToCharArray(0, precoProd.Length);
            //verifica a diferença de tanmanho entre os dois arrays
            int resto = preco.Length - precoProd.Length;
            //cria o loop partindo do final do resto ate o fim
            for (int i = 0; i < precoArray.Length; i++)
            {
                preco[resto] = precoArray[i].ToString();
                resto++;
            }
            return String.Join("", preco);
        }
    }
}