using Dominio.ExceptionPersonalizada;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using Entidades.Entidades.Enuns;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Dominio.Dto.VendaDTO;
using Dominio.Dto.RebanhoDTO;

namespace Dominio.Servico
{
    public class ServicoHistorico : IServicoHistorico
    {
        private readonly IHistorico _IHistorico;
        public ServicoHistorico(IHistorico IMovimentacao)
        {
            _IHistorico = IMovimentacao;
        }
        public async Task<List<HistoricoMovimentacao>> BuscarVendasPorProdutor(int idProdutor)
        {
            return await _IHistorico.BuscarVendasPorProdutor(
               m => m.ProdutorOrigemId.Equals(idProdutor) && TipoMovimentacao.VENDA.Equals(m.TipoMovimentacao));
        }

        public async Task<List<HistoricoMovimentacao>> BuscarComprasPorProdutor(int idProdutor)
        {
            return await _IHistorico.BuscarVendasPorProdutor(
              m => m.ProdutorDestinoId.Equals(idProdutor) && TipoMovimentacao.COMPRA.Equals(m.TipoMovimentacao));
        }
        public async Task<List<HistoricoMovimentacao>> BuscarTodosPorIdPropriedade(int idPropriedade)
        {
            return await _IHistorico.BuscarPorIdPropriedade(
                m => m.PropriedadeOrigemId.Equals(idPropriedade) && TipoMovimentacao.VENDA.Equals(m.TipoMovimentacao) || m.PropriedadeDestinoId.Equals(idPropriedade) && !TipoMovimentacao.VENDA.Equals(m.TipoMovimentacao));
        }
        public async Task<List<HistoricoMovimentacao>> BuscarTodosPorIdProdutor(int idProdutor)
        {
            return await _IHistorico.BuscarPorIdPropriedade(
                m => m.ProdutorOrigemId.Equals(idProdutor) && TipoMovimentacao.VENDA.Equals(m.TipoMovimentacao) || m.PropriedadeDestinoId.Equals(idProdutor));
        }
        public async Task<HistoricoMovimentacao> BuscarPorCodigoHistorico(string codigohistorico)
        {
            var historico = await _IHistorico.BuscarPorCodigo(codigohistorico);

            if (historico == null)
                throw new ExceptionGenerica("Não foi localizado histórico de movimentação com o código informado.");

            return historico;
        }

        public async Task CancelarHistorico(HistoricoMovimentacao historico)
        {
            historico.Status = StatusMovimentacao.CANCELADO;
            historico.DataCancelamento = DateTime.Now;
            await _IHistorico.AtualizarHistoricoMovimentacao(historico);           
        }

        public async Task<HistoricoMovimentacao> CriarHistoricoDeCompra(int produtorOrigemId, int produtorDestinoId,  VendaInsertDTO vendaInsertDto)
        {
            var movimentacaoCompra = new HistoricoMovimentacao(null, produtorOrigemId, produtorDestinoId, 
                                                                vendaInsertDto.PropriedadeOrigemId, 
                                                                vendaInsertDto.PropriedadeDestinoId, TipoMovimentacao.COMPRA,
                                                                vendaInsertDto.SaldoComVacinaBovino,
                                                                vendaInsertDto.SaldoComVacinaBubalino,
                                                                vendaInsertDto.Finalidade);

            await _IHistorico.AdicionarHistoricoMovimentacao(movimentacaoCompra);
            return movimentacaoCompra;
        }

        public async Task<HistoricoMovimentacao> CriarHistoricoDeVenda(string codigoHistorico, int produtorOrigemId, int produtorDestinoId, VendaInsertDTO vendaInsertDto)
        {
            var movimentacaoVenda = new HistoricoMovimentacao(codigoHistorico, produtorOrigemId, produtorDestinoId, 
                                                              vendaInsertDto.PropriedadeOrigemId,
                                                              vendaInsertDto.PropriedadeDestinoId, TipoMovimentacao.VENDA,
                                                              vendaInsertDto.SaldoComVacinaBovino, 
                                                              vendaInsertDto.SaldoComVacinaBubalino,
                                                              vendaInsertDto.Finalidade);

            await _IHistorico.AdicionarHistoricoMovimentacao(movimentacaoVenda);
            return movimentacaoVenda;
        }

        public async Task CriarHistoricoDeEntrada(int idProdutor, RebanhoInsertDTO rebanhoInsertDto)
        {
            var historico = new HistoricoMovimentacao(idProdutor,rebanhoInsertDto.PropriedadeId,
                                              rebanhoInsertDto.SaldoSemVacinaBovino,
                                              rebanhoInsertDto.SaldoSemVacinaBubalino);
            await _IHistorico.AdicionarHistoricoMovimentacao(historico);
        }

        public async Task<List<HistoricoMovimentacao>> BuscarEntradasPorIdPropriedade(int idPropriedade)
        {
            return await _IHistorico.BuscarPorIdPropriedade(
                m => m.PropriedadeDestinoId.Equals(idPropriedade) && TipoMovimentacao.ENTRADA.Equals(m.TipoMovimentacao));
        }
    }
}
