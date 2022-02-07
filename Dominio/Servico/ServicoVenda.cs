using Dominio.Dto.VendaDTO;
using Dominio.ExceptionPersonalizada;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class ServicoVenda : IServicoVenda
    {
        private readonly IRebanho _IRebanho;
        private readonly IServicoPropriedade _IServicoPropriedade;
        private readonly IServicoHistorico _IServicoHistorico;
        private Propriedade propriedadeOrigem;
        private Propriedade propriedadeDestino;
        public ServicoVenda(IRebanho IRebanho,IServicoPropriedade IServicoPropriedade, IServicoHistorico IServicoHistorico)
        {
            _IRebanho = IRebanho;
            _IServicoPropriedade = IServicoPropriedade;
            _IServicoHistorico = IServicoHistorico;
        }
        public Task CancelarVenda(string codigoMovimentacao)
        {
            throw new NotImplementedException();
        }

        public async Task RealizarVenda(VendaInsertDTO vendaInsertDto)
        {
            await ValidacoesVendaDeAnimais(vendaInsertDto);

            var rebanhoOrigem = propriedadeOrigem.Rebanho;
            var rebanhoDestino = propriedadeDestino.Rebanho;

            RealizaDebitoRebanhoOrigem(rebanhoOrigem, vendaInsertDto);
            RealizaCreditoRebanhoDestino(rebanhoDestino, vendaInsertDto);
            await AtualizaRebanhosNoBanco(rebanhoOrigem, rebanhoDestino);
            
            await CriaHistoricoDeMovimentacaoDeCompraEVenda(propriedadeOrigem.ProdutorId, propriedadeDestino.ProdutorId, vendaInsertDto);

        }


        private void RealizaDebitoRebanhoOrigem(Rebanho rebanhoOrigem, VendaInsertDTO vendaInsertDto)
        {           
            rebanhoOrigem.SaldoComVacinaBubalino -= vendaInsertDto.SaldoComVacinaBubalino;
            rebanhoOrigem.SaldoComVacinaBovino -= vendaInsertDto.SaldoComVacinaBovino;
        }
        private void RealizaCreditoRebanhoDestino(Rebanho rebanhoDestino, VendaInsertDTO vendaInsertDto)
        {
            rebanhoDestino.SaldoComVacinaBubalino += vendaInsertDto.SaldoComVacinaBubalino;
            rebanhoDestino.SaldoComVacinaBovino += vendaInsertDto.SaldoComVacinaBovino;
        }
        private async Task AtualizaRebanhosNoBanco(Rebanho rebanhoOrigem, Rebanho rebanhoDestino)
        {
            await _IRebanho.Atualizar(rebanhoOrigem);
            await _IRebanho.Atualizar(rebanhoDestino);
        }

        private async Task ValidacoesVendaDeAnimais(VendaInsertDTO vendaInsertDto)
        {
            string validacao = "";
            propriedadeOrigem = await _IServicoPropriedade.BuscarPorId(vendaInsertDto.PropriedadeOrigemId);
            propriedadeDestino = await _IServicoPropriedade.BuscarPorId(vendaInsertDto.PropriedadeDestinoId);

            if (propriedadeOrigem == null)
            if (propriedadeOrigem == null)
                validacao += "ERROR: Propriedade origem não localizada.";
            if (propriedadeDestino == null)
                validacao += "ERROR: Propriedade destino não localizada.";

            var rebanhoOrigem = propriedadeOrigem.Rebanho;

            if (!rebanhoOrigem.ExisteSaldoParaVenda(vendaInsertDto.SaldoComVacinaBovino, vendaInsertDto.SaldoComVacinaBubalino))
            {
                validacao += "ERROR: Não existe saldo suficiente para realizar a venda.";
            }
            if (!rebanhoOrigem.VacinaEstaValida())
            {
                validacao += "ERROR: A Vacina dos animais deve ser do ano atual.";
            }

            if (!String.IsNullOrEmpty(validacao))
                throw new ExceptionGenerica(validacao);

        }
        private async Task CriaHistoricoDeMovimentacaoDeCompraEVenda(int idProdutorOrigem, int idProdutorDestino, VendaInsertDTO vendaInsertDto)
        {
            var movimentacaoCompra = await CriaHistoricoDeMovimentacaoDeCompra(idProdutorOrigem, idProdutorDestino, vendaInsertDto);
            await CriaHistoricoDeMovimentacaoDeVenda(movimentacaoCompra.CodigoHistorico, idProdutorOrigem, idProdutorDestino, vendaInsertDto);
        }
        private async Task<HistoricoMovimentacao> CriaHistoricoDeMovimentacaoDeCompra(int idProdutorOrigem, int idProdutorDestino, VendaInsertDTO vendaInsertDto)
        {
            var movimentacaoCompra = await _IServicoHistorico.CriarHistoricoDeCompra(idProdutorOrigem, idProdutorDestino, vendaInsertDto);            
            return movimentacaoCompra;
        }
        private async Task CriaHistoricoDeMovimentacaoDeVenda(string codigoHistoricoCompra, int idProdutorOrigem, int idProdutorDestino, VendaInsertDTO vendaInsertDto)
        {
            await _IServicoHistorico.CriarHistoricoDeVenda(codigoHistoricoCompra, idProdutorOrigem, idProdutorDestino, vendaInsertDto);
        }
    }
}
