using VarejoSimplesModa.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarejoSimplesModa.Repository.RepositoryInterfaces
{
    public interface IFluxoCaixaRepository
    {
        void Cadastrar(FluxoCaixa FluxoCaixa);
        void Estornar(FluxoCaixa FluxoCaixa);
        FluxoCaixa ObterFluxoCaixa(int Id);
        DataTable ObterFluxoCaixaPorMovimentacao(string sql);
        double ObterUltimoSaldoInicial();
        List<double> ObterValoresParciais();
        List<double> ObterValoresTotais();
        double SaldoGaveta();
    }
}
