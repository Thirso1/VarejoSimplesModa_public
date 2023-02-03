using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Model
{
    class Login
    {
        public bool Logado { get; set; }
        public Usuario Usuario { get; set; }
        //padrao Singleton
        private static Login instance = null;

        //padrao Singleton
        public static Login Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Login();
                }

                return instance;
            }
        }
    }
}
