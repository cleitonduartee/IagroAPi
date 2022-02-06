using Dominio.ExceptionPersonalizada;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using Entidades.Entidades.Enuns;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Dominio.Dto.Movimentacao.MovimentacaoDTO;

namespace Dominio.Servico
{
    public class ServicoMovimentacao : IServicoMovimentacao
    {
        private readonly IMovimentacao _IMovimentacao;
        private readonly IRebanho _IRebanho;
        private readonly IPropriedade _IPropriedade;
        public ServicoMovimentacao(IMovimentacao IMovimentacao, IRebanho IRebanho, IPropriedade IPropriedade)
        {
            _IMovimentacao = IMovimentacao;
            _IRebanho = IRebanho;
            _IPropriedade = IPropriedade;
        }
        public async Task<List<HistoricoMovimentacao>> BuscarVendasPorProdutor(int idProdutor)
        {
            return await _IMovimentacao.BuscarVendasPorProdutor(
               m => m.ProdutorOrigemId.Equals(idProdutor) && TipoMovimentacao.VENDA.Equals(m.TipoMovimentacao));
        }

        public async Task<List<HistoricoMovimentacao>> BuscarComprasPorProdutor(int idProdutor)
        {
            return await _IMovimentacao.BuscarVendasPorProdutor(
              m => m.ProdutorDestinoId.Equals(idProdutor) && TipoMovimentacao.COMPRA.Equals(m.TipoMovimentacao));
        }
        public async Task<List<HistoricoMovimentacao>> BuscarPorIdPropriedade(int idPropriedade)
        {         
            return await _IMovimentacao.BuscarPorIdPropriedade(
                m => m.PropriedadeOrigemId.Equals(idPropriedade) && TipoMovimentacao.VENDA.Equals(m.TipoMovimentacao) || m.PropriedadeDestinoId.Equals(idPropriedade));
        }
        public async Task<List<HistoricoMovimentacao>> BuscarPorIdProdutor(int idProdutor)
        {
            return await _IMovimentacao.BuscarPorIdPropriedade(
                m => m.ProdutorOrigemId.Equals(idProdutor) && TipoMovimentacao.VENDA.Equals(m.TipoMovimentacao) || m.PropriedadeDestinoId.Equals(idProdutor));
        }

        public async Task CancelarMovimentacaoDeEntrada(string codigoMovimentacao)
        {
            var movimentacao = await _IMovimentacao.BuscarPorCodigo(codigoMovimentacao);

            if (movimentacao == null)
                throw new ExceptionGenerica("Não foi localizado histórico de movimentação com o código informado.");
            if (movimentacao.Status.Equals(StatusMovimentacao.CANCELADO))
                throw new ExceptionGenerica("Movimentação já encontra-se CANCELADA.");

            await RealizaEstornoEntrada(movimentacao);

            movimentacao.Status = StatusMovimentacao.CANCELADO;
            movimentacao.DataCancelamento = DateTime.Now;
            await _IMovimentacao.AtualizarHistoricoMovimentacao(movimentacao);

            //if (movimentacao.TipoMovimentacao.Equals(TipoMovimentacao.ENTRADA))
            //   await RealizaEstornoEntrada(movimentacao);
            //else if (movimentacao.TipoMovimentacao.Equals(TipoMovimentacao.VENDA))
            //    await RealizaEstornoVenda(movimentacao);
            //else
            //    await RealizaEstornoCompra(movimentacao); //Acredito que nao ira precisar implementar esse método

            //await _IHistoricoMovimentacao.AtualizarHistoricoMovimentacao(movimentacao);

            //Implementar posteriormente com if, caso for entrada faz isso, caso for venda, faz isso. Verificar como pegar os dois id
        }

        public async Task CancelarMovimentacaoDeVenda(string codigoMovimentacao)
        {
            //var movimentacao = await _IHistoricoMovimentacao.BuscarPorCodigo(codigoMovimentacao);

            //if (movimentacao == null)
            //    throw new ExceptionGenerica("Não foi localizado histórico de movimentação com o código informado.");
            //if (movimentacao.Status.Equals(StatusMovimentacao.CANCELADO))
            //    throw new ExceptionGenerica("Movimentação já encontra-se CANCELADA.");

            //movimentacao.Status = StatusMovimentacao.CANCELADO;
            //movimentacao.DataCancelamento = DateTime.Now;

            //if (movimentacao.TipoMovimentacao.Equals(TipoMovimentacao.ENTRADA))
            //    await RealizaEstornoEntrada(movimentacao);
            //else if (movimentacao.TipoMovimentacao.Equals(TipoMovimentacao.VENDA))
            //    await RealizaEstornoVenda(movimentacao);
            //else
            //    await RealizaEstornoCompra(movimentacao); //Acredito que nao ira precisar implementar esse método

            //await _IHistoricoMovimentacao.AtualizarHistoricoMovimentacao(movimentacao);

            //Implementar posteriormente com if, caso for entrada faz isso, caso for venda, faz isso. Verificar como pegar os dois id
        }
        private async Task RealizaEstornoEntrada(HistoricoMovimentacao movimentacao)
        {
            var propriedade = _IPropriedade.BuscarPorId(movimentacao.PropriedadeDestinoId).Result;
            var rebanho = propriedade.Rebanho;
            rebanho.SaldoComVacinaBovino -= movimentacao.QtdComVacinaBovino;
            rebanho.SaldoComVacinaBubalino -= movimentacao.QtdComVacinaBubalino;
            rebanho.SaldoSemVacinaBovino -= movimentacao.QtdSemVacinaBovino;
            rebanho.SaldoSemVacinaBubalino -= movimentacao.QtdSemVacinaBubalino;
            await _IRebanho.Atualizar(rebanho);
        }
        private async Task RealizaEstornoVenda(HistoricoMovimentacao movimentacao)
        {

        }
        private async Task RealizaEstornoCompra(HistoricoMovimentacao movimentacao)
        {

        }

        public async Task CriarHistoricoDeMovimentacao(HistoricoMovimentacao historico)
        {
            await _IMovimentacao.CriarHistoricoMovimentacao(historico);
        }

       
    }
}
