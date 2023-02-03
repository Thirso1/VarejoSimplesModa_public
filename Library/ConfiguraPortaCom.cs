using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VarejoSimplesModa.Library
{
    /*
     * Esta classe inicia uma instancia do CMD e envia comandos 
     * configura as portas "COM" para conexao com impressora termica 
     */
    public class ConfiguraPortaCom
    {
        public void configuraPortaCom()
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                //impressora usando a porta "COM2" 
                //generica co windows usando a porta "LPT2"
                startInfo.Arguments = ("/C MODE COM4: 115200, N, 8, 1 && MODE LPT2=COM4");
                process.StartInfo = startInfo;
                process.Start();
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
        }
    }
}
