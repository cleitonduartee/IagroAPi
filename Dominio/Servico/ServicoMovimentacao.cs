using Dominio.ExceptionPersonalizada;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using Entidades.Entidades.Enuns;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class ServicoMovimentacao : IServicoMovimentacao
    {
        private readonly IHistoricoMovimentacao _IHistoricoMovimentacao;
        private readonly IRebanho _IRebanho;
        private readonly IUtilAutoIncrementaHistorico _IUtilAutoIncrementaHistorico;
        public ServicoMovimentacao(IHistoricoMovimentacao IHistoricoMovimentacao, IRebanho IRebanho, IUtilAutoIncrementaHistorico IUtilAutoIncrementaHistorico)
        {
            _IHistoricoMovimentacao = IHistoricoMovimentacao;
            _IRebanho = IRebanho;
            _IUtilAutoIncrementaHistorico = IUtilAutoIncrementaHistorico;
        }
        public async Task<List<HistoricoMovimentacao>> BuscarPorIdPropriedade(int idPropriedade)
        {
           //  return await _IHistoricoMovimentacao.BuscarPorIdPropriedade(m => m.PropriedadeId.Equals(idPropriedade));

            return await _IHistoricoMovimentacao.BuscarPorIdPropriedade(
                m => m.PropriedadeOrigemId.Equals(idPropriedade) && TipoMovimentacao.VENDA.Equals(m.TipoMovimentacao) || m.PropriedadeDestinoId.Equals(idPropriedade));
        }

        public async Task CancelarMovimentacao(string codigoMovimentacao)
        {
            var movimentacao = await _IHistoricoMovimentacao.BuscarPorCodigo(codigoMovimentacao);

            if (movimentacao == null)
                throw new ExceptionGenerica("Não foi localizado histórico de movimentação com o código informado.");
            if (movimentacao.Status.Equals(StatusMovimentacao.CANCELADO))
                throw new ExceptionGenerica("Movimentação já encontra-se CANCELADA.");

            movimentacao.Status = StatusMovimentacao.CANCELADO;
            movimentacao.DataCancelamento = DateTime.Now;

            if (movimentacao.TipoMovimentacao.Equals(TipoMovimentacao.ENTRADA))
               await RealizaEstornoEntrada(movimentacao);
            else if (movimentacao.TipoMovimentacao.Equals(TipoMovimentacao.VENDA))
                await RealizaEstornoVenda(movimentacao);
            else
                await RealizaEstornoCompra(movimentacao); //Acredito que nao ira precisar implementar esse método

            await _IHistoricoMovimentacao.AtualizarHistoricoMovimentacao(movimentacao);

            //Implementar posteriormente com if, caso for entrada faz isso, caso for venda, faz isso. Verificar como pegar os dois id
        }
        private async Task RealizaEstornoEntrada(HistoricoMovimentacao movimentacao)
        {
            var rebanho = _IRebanho.BuscarPorId(movimentacao.RebanhoDestinoId).Result;
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
            await _IHistoricoMovimentacao.CriarHistoricoMovimentacao(historico);
        }
        //private string GerarCodigoHistorico()
        //{
        //    int idGerado = _IUtilAutoIncrementaHistorico.GerarId().Result;
        //    return "HISTORICO-" + idGerado;
        //}
    }
}
