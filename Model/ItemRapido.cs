using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Model
{
    public class ItemRapido
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public int CodigoBarrasBalanca { get; set; }
        public string Nome { get; set; }
        public string CorFundo { get; set; }
        public string CorFonte { get; set; }
        public int Posicao { get; set; }
    }
}
