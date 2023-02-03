using VarejoSimplesModa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Repository.RepositoryInterfaces
{
    public interface IItemRapidoRepository
    {
        void ExcluirTodos();
        ItemRapido[] buscaItemRapidos();

        void cadastrar(ItemRapido[] itemRapidos);
    }
}
