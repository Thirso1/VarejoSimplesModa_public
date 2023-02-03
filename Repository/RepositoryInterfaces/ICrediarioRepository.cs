using VarejoSimplesModa.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Repository.RepositoryInterfaces
{
    public interface ICrediarioRepository
    {
        void Cadastrar(Crediario crediario);
        void Estornar(Crediario crediario);
        Crediario ObterCrediario(int Id);
        DataTable ObterCrediarioPorCliente(int IdCliente);
        Crediario ObterCrediarioPorPedido(int IdPedido);
    }
}