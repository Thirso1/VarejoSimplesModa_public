using VarejoSimplesModa.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Repository.RepositoryInterfaces
{
    public interface IItemPedidoRepository
    {
        void Cadastrar(ItemPedido itemPedido);
        void CadastrarTodos(List<ItemPedido> itens);
        void Atualizar(ItemPedido itemPedido);
        void Excluir(int Id);
        void ExcluirTodos(int Id);
        ItemPedido ObterItemPedido(int Id);
        DataTable ConsultaTodos(int pedidoId);
    }
}
