using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Library
{
    class MascaraDecimal
    {
        public static double ConverterIntToDouble(int valor)
        {
            //10000 -> "10000" -> "100.00" -> 100.00
            string valorPagarMeString = valor.ToString();
            string valorDecimalString = valorPagarMeString.Substring(0, valorPagarMeString.Length - 2) + "," + valorPagarMeString.Substring(valorPagarMeString.Length - 2);

            var dec = double.Parse(valorDecimalString);

            return dec;
        }

        public static int ConverterValorParaInt(string valor)
        {
            //string valorString = valor.ToString("C");
            string valorString = Remover(valor);
            int valorInt = Convert.ToInt32(valorString);

            return valorInt;
        }

        public static string Remover(string valor)
        {
            return valor.Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace("R$", "").Replace(",", "").Replace(" ", "");
        }

        public static string mascara(string valor)
        {
            string valorSemVirgulaStr = valor.Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace("R$", "").Replace(",", "").Replace(" ", "");
            int valorSemVirgulaInt = Convert.ToInt32(valorSemVirgulaStr);

            if(valorSemVirgulaInt != 0)
            {
                string valorPagarMeString = valorSemVirgulaInt.ToString();
                string valorDecimalString = valorPagarMeString.Substring(0, valorPagarMeString.Length - 2) + "," + valorPagarMeString.Substring(valorPagarMeString.Length - 2);

                //var dec = double.Parse(valorDecimalString);

                return valorDecimalString;

            }
            else
            {
                return "0";
            }
            //return ConverterIntToDouble(valorSemVirgulaInt);
            //texdinheiro.SelectionStart = texdinheiro.Text.Length + 1;
        }
    }
}
