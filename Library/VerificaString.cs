using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Library
{
    public static class VerificaString
    {
        public static bool verificaString(string str)
        {
            char[] c = str.ToCharArray();
            char le = ' ';
            for (int cont = 0; cont < c.Length; cont++)
            {
                le = c[cont];
                if (char.IsLetter(le) || char.IsPunctuation(le))
                    return true;
            }
            return false;
        }
    }
}
