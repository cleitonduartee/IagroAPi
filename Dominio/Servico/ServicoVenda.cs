using Dominio.Dto.VendaDTO;
using Dominio.ExceptionPersonalizada;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using Entidades.Entidades.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class ServicoVenda : IServicoVenda
    {
        private readonly IRebanho _IRebanho;
        private readonly IHistoricoMovimentacao _IHistoricoMovimentacao;
        private readonly IServicoPropriedade _IServicoPropriedade;
        private readonly IServicoMovimentacao _IServicoMovimentacao;
        private readonly IUtilAutoIncrementaHistorico _IUtilAutoIncrementaHistorico;
        private Propriedade propriedadeOrigem;
        private Propriedade propriedadeDestino;
        public ServicoVenda(IRebanho IRebanho, IHistoricoMovimentacao IHistoricoMovimentacao, IServicoPropriedade IServicoPropriedade, IUtilAutoIncrementaHistorico IUtilAutoIncrementaHistorico, IServicoMovimentacao IServicoMovimentacao)
        {
            _IRebanho = IRebanho;
            _IHistoricoMovimentacao = IHistoricoMovimentacao;
            _IServicoPropriedade = IServicoPropriedade;
            _IUtilAutoIncrementaHistorico = IUtilAutoIncrementaHistorico;
            _IServicoMovimentacao = IServicoMovimentacao;
        }
        public Task CancelarVenda(string codigoMovimentacao)
        {
            throw new NotImplementedException();
        }

        public async Task RealizarVenda(VendaInsertDTO vendaInsertDto)
        {
            await ValidacoesVendaDeAnimais(vendaInsertDto);

            var rebanhoOrigem = propriedadeOrigem.Rebanho;

            if (rebanhoOrigem.ExisteSaldoParaVenda(
                vendaInsertDto.SaldoSemVacinaBovino, vendaInsertDto.SaldoSemVacinaBubalino,
                vendaInsertDto.SaldoComVacinaBovino, vendaInsertDto.SaldoComVacinaBovino
                ))
            {
                var rebanhoDestino = propriedadeDestino.Rebanho;

                RealizaDebitoRebanhoOrigem(rebanhoOrigem, vendaInsertDto);
                RealizaCreditoRebanhoDestino(rebanhoDestino, vendaInsertDto);
                await AtualizaRebanhosNoBanco(rebanhoOrigem, rebanhoDestino);

                //var novaMovimentacao = CriaHistoricoDeMovimentacaoDeVenda(rebanhoOrigem.RebanhoId, vendaInsertDto);
                //await AdicionaMovimentacaoNoBanco(novaMovimentacao);
                await CriaHistoricoDeMovimentacaoDeCompraEVenda(rebanhoOrigem.RebanhoId, rebanhoDestino.RebanhoId, vendaInsertDto);
            }
            else
            {
                throw new ExceptionGenerica("Não existe saldo suficiente para realizar a venda.");
            }

        }


        private void RealizaDebitoRebanhoOrigem(Rebanho rebanhoOrigem, VendaInsertDTO vendaInsertDto)
        {
            rebanhoOrigem.SaldoSemVacinaBubalino -= vendaInsertDto.SaldoSemVacinaBubalino;
            rebanhoOrigem.SaldoSemVacinaBovino -= vendaInsertDto.SaldoSemVacinaBovino;
            rebanhoOrigem.SaldoComVacinaBubalino -= vendaInsertDto.SaldoComVacinaBubalino;
            rebanhoOrigem.SaldoComVacinaBovino -= vendaInsertDto.SaldoComVacinaBovino;
        }
        private void RealizaCreditoRebanhoDestino(Rebanho rebanhoDestino, VendaInsertDTO vendaInsertDto)
        {
            rebanhoDestino.SaldoSemVacinaBubalino += vendaInsertDto.SaldoSemVacinaBubalino;
            rebanhoDestino.SaldoSemVacinaBovino += vendaInsertDto.SaldoSemVacinaBovino;
            rebanhoDestino.SaldoComVacinaBubalino += vendaInsertDto.SaldoComVacinaBubalino;
            rebanhoDestino.SaldoComVacinaBovino += vendaInsertDto.SaldoComVacinaBovino;
        }
        private async Task AtualizaRebanhosNoBanco(Rebanho rebanhoOrigem, Rebanho rebanhoDestino)
        {
            await _IRebanho.Atualizar(rebanhoOrigem);
            await _IRebanho.Atualizar(rebanhoDestino);
        }

        //private async Task AdicionaMovimentacaoNoBanco(HistoricoMovimentacao movimentacao)
        //{
        //    await _IHistoricoMovimentacao.Adicionar(movimentacao);
        //}
        private async Task ValidacoesVendaDeAnimais(VendaInsertDTO vendaInsertDto)
        {
            string validacao = "";
            propriedadeOrigem = await _IServicoPropriedade.BuscarPorId(vendaInsertDto.PropriedadeOrigemId);
            propriedadeDestino = await _IServicoPropriedade.BuscarPorId(vendaInsertDto.PropriedadeDestinoId);

            if (propriedadeOrigem == null)
                validacao += "ERROR: Propriedade origem não localizada.";
            if (propriedadeDestino == null)
                validacao += "ERROR: Propriedade destino não localizada.";
            else if (vendaInsertDto.SaldoComVacinaBubalino > 0 || vendaInsertDto.SaldoComVacinaBovino > 0)
            {
                if (!vendaInsertDto.DataVacina.HasValue)
                    validacao += "ERROR: Para entradas de espécies vacinadas é obrigatório a data de vacinação.";
                else if (vendaInsertDto.DataVacina.Value.Year < DateTime.Now.Year)
                    validacao += "ERROR: Para entradas de espécies vacinadas a data de vacinação deve ser do ano atual.";
            }


            if (!String.IsNullOrEmpty(validacao))
                throw new ExceptionGenerica(validacao);

        }
        private async Task CriaHistoricoDeMovimentacaoDeCompraEVenda(int idRebanhoOrigem, int idRebanhoDestino, VendaInsertDTO vendaInsertDto)
        {
            var movimentacaoCompra = await CriaHistoricoDeMovimentacaoDeCompra(idRebanhoOrigem, idRebanhoDestino, vendaInsertDto);
            await CriaHistoricoDeMovimentacaoDeVenda(idRebanhoOrigem, idRebanhoDestino, movimentacaoCompra.CodigoHistorico, vendaInsertDto);
        }
        private async Task<HistoricoMovimentacao> CriaHistoricoDeMovimentacaoDeCompra(int idRebanhoOrigem, int idRebanhoDestino, VendaInsertDTO vendaInsertDto)
        {
            var movimentacaoCompra = new HistoricoMovimentacao(null, idRebanhoOrigem, idRebanhoDestino, vendaInsertDto.PropriedadeOrigemId, vendaInsertDto.PropriedadeDestinoId,
                                                               TipoMovimentacao.COMPRA, vendaInsertDto.SaldoSemVacinaBovino, vendaInsertDto.SaldoComVacinaBovino, 
                                                               vendaInsertDto.SaldoSemVacinaBubalino,vendaInsertDto.SaldoComVacinaBubalino, vendaInsertDto.DataVacina);

            await _IServicoMovimentacao.CriarHistoricoDeMovimentacao(movimentacaoCompra);
            return movimentacaoCompra;
        }
        private async Task CriaHistoricoDeMovimentacaoDeVenda(int idRebanhoOrigem, int idRebanhoDestino, string codigoMovimentacaoCompra, VendaInsertDTO vendaInsertDto)
        {
            var movimentacaoCompra = new HistoricoMovimentacao(codigoMovimentacaoCompra, idRebanhoOrigem, idRebanhoDestino, vendaInsertDto.PropriedadeOrigemId,
                                          vendaInsertDto.PropriedadeDestinoId, TipoMovimentacao.VENDA, vendaInsertDto.SaldoSemVacinaBovino,
                                          vendaInsertDto.SaldoComVacinaBovino, vendaInsertDto.SaldoSemVacinaBubalino,
                                          vendaInsertDto.SaldoComVacinaBubalino, vendaInsertDto.DataVacina);

            await _IServicoMovimentacao.CriarHistoricoDeMovimentacao(movimentacaoCompra);
        }
    }
}
