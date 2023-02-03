using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using VarejoSimplesModa.Banco;
using VarejoSimplesModa.Enums;
using VarejoSimplesModa.Model;
using VarejoSimplesModa.Repository;
using VarejoSimplesModa.Repository.RepositoryInterfaces;

namespace VarejoSimplesModa.Pagamento
{
    public class FinalizaPedido
    {
        IPedidoRepository _pedidoRepository = new PedidoRepository();
        IFluxoCaixaRepository _fluxoCaixaRepository = new FluxoCaixaRepository();


        public void Avista(Pedido pedido, FluxoCaixa fluxoCaixa) 
        {
            pedido.StatusPedido = StatusPedido.Finalizado;

            try
            {
                _pedidoRepository.Atualizar(pedido);
                _fluxoCaixaRepository.Cadastrar(fluxoCaixa);

            }
            catch (Exception erro)
            {
                string teste = erro.ToString();
                MessageBox.Show(teste);
            }
        }
        //
        //
        //
        //
        public void Aprazo(Pedido pedido, FluxoCaixa fluxoCaixa)
        {
            pedido.StatusPedido = StatusPedido.Finalizado;
            pedido.FormaPagamento = FormaPagamento.Prazo;
            try
            {
                _pedidoRepository.Atualizar(pedido);
                _fluxoCaixaRepository.Cadastrar(fluxoCaixa);

            }
            catch (Exception erro)
            {
                string teste = erro.ToString();
                MessageBox.Show(teste);
            }

        }
        //
        //
        public void Cartao(Pedido pedido, FluxoCaixa fluxoCaixa)
        {
            pedido.StatusPedido = StatusPedido.Finalizado;
            pedido.FormaPagamento = FormaPagamento.Cartao;
            try
            {
                _pedidoRepository.Atualizar(pedido);
                _fluxoCaixaRepository.Cadastrar(fluxoCaixa);

            }
            catch (Exception erro)
            {
                string teste = erro.ToString();
                MessageBox.Show(teste);
            }
        }
        //
        //
        public void Pix(Pedido pedido, FluxoCaixa fluxoCaixa)
        {
            pedido.StatusPedido = StatusPedido.Finalizado;
            pedido.FormaPagamento = FormaPagamento.Pix;
            try
            {
                _pedidoRepository.Atualizar(pedido);
                _fluxoCaixaRepository.Cadastrar(fluxoCaixa);

            }
            catch (Exception erro)
            {
                string teste = erro.ToString();
                MessageBox.Show(teste);
            }
        }

    }
    }

