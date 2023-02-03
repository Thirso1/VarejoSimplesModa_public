namespace VarejoSimplesModa.Model
{
    public class Cliente
    {
        public int Id {get; set;}
        public string cpf { get; set;}
        public string nome { get; set; }
        //public string sobrenome { get; set; }
        public string telefone { get; set; }
        public string telefone_2 { get; set; }
        public string rua { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string cep { get; set; }
        public int pedidos { get; set; }
        public double limite_credito { get; set; }

    }
}