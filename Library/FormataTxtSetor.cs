using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Library
{
    class FormataTxtSetor
    {
        private string[] nome = new string[12];
        private string[] cod = new string[6];
        //private string[] indece = new string[4];
        private string[] tecla = { "0", "0", "0" };// new string[3];


        public string formataNome(string nomeProd)
        {
            Console.WriteLine(nomeProd);
            //verifica o tamanho e corta o final do array
            if (nomeProd.Length > 12)
            {
                for (int i = 11; i < nomeProd.Length; i++)
                {
                    nomeProd = nomeProd.Remove(i, nomeProd.Length - 12);
                }
            }

            //preencho array nome
            Console.WriteLine(nomeProd);
            for (int i = 0; i < 12; i++)
            {
                nome[i] = " ";
            }
            //cria um array para receber o nome do produto
            char[] nomeArray;
            //transforma o nomeProd em array e atribui ao nomeArray
            nomeArray = nomeProd.ToCharArray(0, nomeProd.Length);

            Console.WriteLine(String.Join("", nomeArray));
            //cria o loop para substituir nome[] por nomeArray[] 
            for (int i = 0; i < nomeArray.Length; i++)
            {
                nome[i] = nomeArray[i].ToString();
            }
            return String.Join("", nome);
        }


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

        public string formataTecla()
        {
            return String.Join("", tecla);
        }

     













        //public string formataPreco(string precoProd)
        //{
        //    //retirar a virgula ou ponto
        //    precoProd = precoProd.Replace(",", "").Replace(".", "");
        //    //preencho array nome
        //    for (int i = 0; i < 7; i++)
        //    {
        //        preco[i] = "0";
        //    }
        //    //cria um array para receber o preco do produto
        //    char[] precoArray;
        //    //transforma o codProduto em array e atribui ao codArray
        //    precoArray = precoProd.ToCharArray(0, precoProd.Length);
        //    //verifica a diferença de tanmanho entre os dois arrays
        //    int resto = preco.Length - precoProd.Length;
        //    //cria o loop partindo do final do resto ate o fim
        //    for (int i = 0; i < precoArray.Length; i++)
        //    {
        //        preco[resto] = precoArray[i].ToString();
        //        resto++;
        //    }
        //    return String.Join("", preco);
        //}
    }
}

