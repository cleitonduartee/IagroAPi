using Dominio.ExceptionPersonalizada;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using Entidades.Entidades.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class ServicoMovimentacao : IServicoMovimentacao
    {
        private readonly IHistoricoMovimentacao _IHistoricoMovimentacao;
        private readonly IRebanho _IRebanho;
        public ServicoMovimentacao(IHistoricoMovimentacao IHistoricoMovimentacao, IRebanho IRebanho)
        {
            _IHistoricoMovimentacao = IHistoricoMovimentacao;
            _IRebanho = IRebanho;
        }
        public async Task<List<HistoricoMovimentacao>> BuscarPorIdPropriedade(int idPropriedade)
        {
             return await _IHistoricoMovimentacao.BuscarPorIdPropriedade(m => m.PropriedadeId.Equals(idPropriedade));
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

            await _IHistoricoMovimentacao.Atualizar(movimentacao);

            //Implementar posteriormente com if, caso for entrada faz isso, caso for venda, faz isso. Verificar como pegar os dois id
        }
        private async Task RealizaEstornoEntrada(HistoricoMovimentacao movimentacao)
        {
            var rebanho = _IRebanho.BuscarPorId(movimentacao.RebanhoId).Result;
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
    }
}
