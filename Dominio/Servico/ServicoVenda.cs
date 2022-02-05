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
        private readonly IUtilAutoIncrementaHistorico _IUtilAutoIncrementaHistorico;
        private Propriedade propriedadeOrigem;
        private Propriedade propriedadeDestino;
        public ServicoVenda(IRebanho IRebanho, IHistoricoMovimentacao IHistoricoMovimentacao, IServicoPropriedade IServicoPropriedade, IUtilAutoIncrementaHistorico IUtilAutoIncrementaHistorico)
        {
            _IRebanho = IRebanho;
            _IHistoricoMovimentacao = IHistoricoMovimentacao;
            _IServicoPropriedade = IServicoPropriedade;
            _IUtilAutoIncrementaHistorico = IUtilAutoIncrementaHistorico;
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

            RealizaDebitoRebanhoOrigem(rebanhoOrigem,vendaInsertDto);
            RealizaCreditoRebanhoDestino(rebanhoDestino, vendaInsertDto);
            await AtualizaRebanhosNoBanco(rebanhoOrigem, rebanhoDestino);

            var novaMovimentacao = CriaHistoricoDeMovimentacaoDeVenda(rebanhoOrigem.RebanhoId, vendaInsertDto);
            await AdicionaMovimentacaoNoBanco(novaMovimentacao);
        }


        private void RealizaDebitoRebanhoOrigem(Rebanho rebanhoOrigem,VendaInsertDTO vendaInsertDto)
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
        private HistoricoMovimentacao CriaHistoricoDeMovimentacaoDeVenda(int idRebanho, VendaInsertDTO vendaInsertDto)
        {
           return new HistoricoMovimentacao(
                    GerarCodigoHistorico(), idRebanho, vendaInsertDto.PropriedadeOrigemId, TipoMovimentacao.VENDA, vendaInsertDto.SaldoSemVacinaBovino, vendaInsertDto.SaldoComVacinaBovino,
                    vendaInsertDto.SaldoSemVacinaBubalino, vendaInsertDto.SaldoComVacinaBubalino, vendaInsertDto.DataVacina
                    );
        }
        private async Task AdicionaMovimentacaoNoBanco(HistoricoMovimentacao movimentacao)
        {
            await _IHistoricoMovimentacao.Adicionar(movimentacao);
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
        private string GerarCodigoHistorico()
        {
            int idGerado = _IUtilAutoIncrementaHistorico.GerarId().Result;
            return "HISTORICO-" + idGerado;
        }
    }
}
