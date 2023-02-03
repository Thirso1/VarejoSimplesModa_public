using VarejoSimplesModa.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Repository.RepositoryInterfaces
{
    public interface IPedidoRepository
    {
        int Cadastrar(Pedido pedido);
        void Atualizar(Pedido pedido);
        void Excluir(int Id);
        Pedido ObterPedido(int Id);
        int ObterPedidosPorDia();
        Pedido ObterPedidoPorComanda(string codigoComanda);
        DataTable ObterPedidoPorCliente(int IdCliente);
        Pedido ObterPedidoAbertoPorComanda(string codigoComanda);
        int RetornaUltimoId();
    }
}
