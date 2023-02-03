using VarejoSimplesModa.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Repository.RepositoryInterfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Excluir(int Id);
        Usuario ObterUsuario(int id);
        Usuario ObterUsuarioPorNome(string id);

        Usuario ObterUsuarioPorNomeSenha(string nome, string senha);

        DataTable ObterUsuarios();
    }
}
