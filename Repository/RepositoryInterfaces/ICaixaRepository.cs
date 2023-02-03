using VarejoSimplesModa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Repository.RepositoryInterfaces
{
    public interface ICaixaRepository
    {
        void Cadastrar(Caixa caixa);
        void Atualizar(Caixa caixa);
        void Excluir(int Id);
        Caixa ObterCaixa();
    }
}
