using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarejoSimplesModa.Model;


namespace VarejoSimplesModa.Repository.RepositoryInterfaces
{
    interface IClienteRepository
    {//CRUD
        void Cadastrar(Cliente produto);
        void Atualizar(Cliente produto);
        void Excluir(int Id);

        Cliente ObterCliente(int Id);
        DataTable ObterClientes(string pesquisa);
        int QuantidadeTotalClientes();
    }
}
