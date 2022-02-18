using Dominio.Dto.VendaDTO;
using Dominio.ExceptionPersonalizada;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using Entidades.Entidades.Enuns;
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
        private HistoricoMovimentacao hsitoricoVenda;
        private HistoricoMovimentacao hsitoricoCompra;
        public ServicoVenda(IRebanho IRebanho,IServicoPropriedade IServicoPropriedade, IServicoHistorico IServicoHistorico)
        {
            _IRebanho = IRebanho;
            _IServicoPropriedade = IServicoPropriedade;
            _IServicoHistorico = IServicoHistorico;
        }
        public async Task CancelarVenda(string codigoMovimentacao)
        {
            await ValidacoesCancelamentoVendaDeAnimais(codigoMovimentacao);

            var rebanhoOrigem = propriedadeOrigem.Rebanho;
            var rebanhoDestino = propriedadeDestino.Rebanho;
            RealizaEstornoDaVenda(rebanhoOrigem, rebanhoDestino);


            hsitoricoCompra = await _IServicoHistorico.BuscarPorCodigoHistorico(hsitoricoVenda.CodigoMovimentacaoDaCompra);
            if(hsitoricoCompra == null)
                throw new ExceptionGenerica("Erro ao realizar cancelamento. Historico da compra nao foi localizada.");


            await AtualizaHistoricosNoBanco();
            await AtualizaRebanhosNoBanco(rebanhoOrigem, rebanhoDestino);


        }

        public async Task RealizarVenda(VendaInsertDTO vendaInsertDto)
        {
            await ValidacoesVendaDeAnimais(vendaInsertDto);

            var rebanhoOrigem = propriedadeOrigem.Rebanho;
            var rebanhoDestino = propriedadeDestino.Rebanho;

            RealizaDebitoRebanhoOrigem(rebanhoOrigem, vendaInsertDto);
            RealizaCreditoRebanhoDestino(rebanhoDestino, vendaInsertDto);

            rebanhoOrigem.DataUltimaVenda = DateTime.Now;
            if (!rebanhoDestino.DataVacina.HasValue) // Ferifica se tem valor
                rebanhoDestino.DataVacina = rebanhoOrigem.DataVacina;

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
        private void RealizaEstornoDaVenda(Rebanho rebanhoOrigem, Rebanho rebanhoDestino)
        {
            int QtdBovinoVendido = hsitoricoVenda.QtdComVacinaBovino;
            int QtdBubalinoVendido = hsitoricoVenda.QtdComVacinaBubalino;

            //Debita do destino
            rebanhoDestino.SaldoComVacinaBovino -= QtdBovinoVendido;
            rebanhoDestino.SaldoComVacinaBubalino -= QtdBubalinoVendido;


            //Credita na origem
            rebanhoOrigem.SaldoComVacinaBovino += QtdBovinoVendido;
            rebanhoOrigem.SaldoComVacinaBubalino += QtdBubalinoVendido;
            
        }
        private async Task AtualizaRebanhosNoBanco(Rebanho rebanhoOrigem, Rebanho rebanhoDestino)
        {
            await _IRebanho.Atualizar(rebanhoOrigem);
            await _IRebanho.Atualizar(rebanhoDestino);
        }
        private async Task AtualizaHistoricosNoBanco()
        {
            await _IServicoHistorico.CancelarHistorico(hsitoricoVenda);
            await _IServicoHistorico.CancelarHistorico(hsitoricoCompra);
        }

        private async Task ValidacoesVendaDeAnimais(VendaInsertDTO vendaInsertDto)
        {
            string validacao = "";
            propriedadeOrigem = await _IServicoPropriedade.BuscarPorId(vendaInsertDto.PropriedadeOrigemId);
            propriedadeDestino = await _IServicoPropriedade.BuscarPorId(vendaInsertDto.PropriedadeDestinoId);
                        
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
        private async Task ValidacoesCancelamentoVendaDeAnimais(string codigoMovimentacao)
        {
            string validacao = "";
            hsitoricoVenda = await _IServicoHistorico.BuscarPorCodigoHistorico(codigoMovimentacao);

            if(hsitoricoVenda == null)
                validacao += "ERROR: Historico de movimentação não foi localizado.";
            if (!hsitoricoVenda.TipoMovimentacao.Equals(TipoMovimentacao.VENDA))
                validacao += "ERROR: Historico informado não é do tipo: VENDA.";
            if (hsitoricoVenda.Status.Equals(StatusMovimentacao.CANCELADO))
                validacao += "ERROR: Historico já encontra-se CANCELADA.";



            propriedadeOrigem = await _IServicoPropriedade.BuscarPorId(hsitoricoVenda.PropriedadeOrigemId.Value);
            propriedadeDestino = await _IServicoPropriedade.BuscarPorId(hsitoricoVenda.PropriedadeDestinoId);

            if (propriedadeOrigem == null)
                validacao += "ERROR: Propriedade origem não localizada.";
            if (propriedadeDestino == null)
                validacao += "ERROR: Propriedade destino não localizada.";           

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
