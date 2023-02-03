using System.ComponentModel.DataAnnotations;

namespace VarejoSimplesModa.Model
{
    public class Categoria
    {
        [Key()]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}