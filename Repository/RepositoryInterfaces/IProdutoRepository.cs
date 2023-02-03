using VarejoSimplesModa.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Repository.RepositoryInterfaces
{
    public interface IProdutoRepository
    {
        //CRUD
        void Cadastrar(Produto produto);
        void Atualizar(Produto produto);
        void Excluir(int Id);

        void DevolverProdutoAoEstoque(Pedido pedido);
        Produto ObterProduto(int Id);
        Produto ObterProdutoPorCodigoBarras(string CodigoBarras);
        Produto ObterProdutoPorCodigoBarrasBalanca(string CodigoBarras);
        List<Produto> ObterProdutoPorCategoria(int id);
        List<Produto> ObterTodosProdutoDeBalanca();
        DataTable ObterProdutosSimplificado(string pesquisa);
        DataTable ObterProdutos(string pesquisa);
        DataTable ObterProdutosSimplificadoBalanca(string pesquisa);
        DataTable ObterTodosProdutos();
        int QuantidadeTotalProdutos();
        int CalculaCodigoBalanca();
    }
}
