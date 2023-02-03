using VarejoSimplesModa.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Model
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Senha { get; set; }

        public string ConfirmacaoSenha { get; set; }
        /*
         * TIPO = ColaboradorTipoConstant
         */
        public TipoUsuario TipoUsuario { get; set; }

        public Usuario()//int Id, string Nome, string Email, string Senha, string ConfirmacaoSenha, TipoUsuario TipoUsuario
        {
            this.Id = 0;
            this.Nome = "Adilson";
            this.Telefone = "thirso@live.com";
            this.Senha = "12345";
            this.ConfirmacaoSenha = "12345";
            this.TipoUsuario = TipoUsuario.Gerente;
        }
    }
}
