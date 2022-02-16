using Dominio.Dto.RebanhoDTO;
using Dominio.ExceptionPersonalizada;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using Entidades.Entidades.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class ServicoRebanho : IServicoRebanho
    {
        private readonly IRebanho _IRebanho;
        private readonly IServicoPropriedade _IServicoPropriedade;
        private readonly IServicoHistorico _IServicoHistorico;

        private Propriedade propriedadeOrigem;
        private Propriedade propriedadeDestino;
        private HistoricoMovimentacao historico;

        public ServicoRebanho(IRebanho IRebanho, IServicoPropriedade IServicoPropriedade, IServicoHistorico IServicoHistorico)
        {
            _IRebanho = IRebanho;
            _IServicoPropriedade = IServicoPropriedade;
            _IServicoHistorico = IServicoHistorico;
        }

        public async Task<List<Rebanho>> BuscarPorProdutor(string produtor)
        {
            return await _IRebanho.BuscarPorProdutor(p => p.Propriedade.Produtor.Nome.Equals(produtor));
        }

        public async Task<Rebanho> BuscarRebanhoPorNomePropriedade(string propriedade)
        {
            return await _IRebanho.BuscarRebanhoPorNomePropriedade(p => p.Propriedade.Nome.Equals(propriedade));
        }

        public async Task<Rebanho> BuscarRebanhoPorPropriedadeId(int propriedadeId)
        {
            return await _IRebanho.BuscarRebanhoPorPropriedadeId(r => r.PropriedadeId.Equals(propriedadeId));
        }        

        public async Task EntradaAnimais(RebanhoInsertDTO rebanhoInsertDTO)
        {
            await ValidacoesEntradaDeAnimais(rebanhoInsertDTO);

            try
            {
                var rebanho = propriedadeDestino.Rebanho;
                RealizarEntradasDeAnimaisNoRebanho(rebanhoInsertDTO, rebanho);
                await _IRebanho.Atualizar(rebanho);
                await CriarMovimentacaoDeEntrada(propriedadeDestino.ProdutorId,rebanhoInsertDTO);

            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public async Task CancelarMovimentacaoDeEntrada(string codigoHistorico)
        {
            await ValidacoesDeCancelamento(codigoHistorico);
            await RealizaEstornoEntrada();
            await _IServicoHistorico.CancelarHistorico(historico);
        }

        private async Task ValidacoesEntradaDeAnimais(RebanhoInsertDTO rebanhoDTO)
        {
            string validacao = "";
            propriedadeDestino = await _IServicoPropriedade.BuscarPorId(rebanhoDTO.PropriedadeId);
            if (propriedadeDestino == null)
                validacao += "ERROR: Propriedade informada não localizada.";

            if (!String.IsNullOrEmpty(validacao))
                throw new ExceptionGenerica(validacao);
        }
        private async Task ValidacoesDeCancelamento(string codigoHistorico)
        {
            string validacao = "";
            historico = await _IServicoHistorico.BuscarPorCodigoHistorico(codigoHistorico);            

            if (historico.Status.Equals(StatusMovimentacao.CANCELADO))
                validacao += "ERROR: Historico já encontra-se CANCELADA.";

            if (historico.TipoMovimentacao.Equals(TipoMovimentacao.ENTRADA))
            {
                propriedadeDestino = await _IServicoPropriedade.BuscarPorId(historico.PropriedadeDestinoId);
                if (propriedadeDestino == null)
                    validacao += "ERROR: Propriedade informada não localizada.";
                var rebanho = propriedadeDestino.Rebanho;
                if(historico.QtdSemVacinaBovino > rebanho.SaldoSemVacinaBovino || historico.QtdSemVacinaBubalino > rebanho.SaldoSemVacinaBubalino)
                    validacao += "ERROR: Houve registro de vacinação apos a entrada.";
            }
            else
            {
                propriedadeOrigem = await _IServicoPropriedade.BuscarPorId(historico.PropriedadeOrigemId.Value);
                propriedadeDestino = await _IServicoPropriedade.BuscarPorId(historico.PropriedadeDestinoId);
                if (propriedadeOrigem == null || propriedadeDestino == null)
                    validacao += "ERROR: Propriedade informada não localizada.";
            }

            if (!String.IsNullOrEmpty(validacao))
                throw new ExceptionGenerica(validacao);
        }

        private async Task CriarMovimentacaoDeEntrada(int idProdutor, RebanhoInsertDTO rebanhoInsertDTO)
        {
            await _IServicoHistorico.CriarHistoricoDeEntrada(idProdutor, rebanhoInsertDTO);
        }

        private void RealizarEntradasDeAnimaisNoRebanho(RebanhoInsertDTO rebanhoDto, Rebanho rebanho)
        {          
            rebanho.SaldoSemVacinaBovino += rebanhoDto.SaldoSemVacinaBovino;
            rebanho.SaldoSemVacinaBubalino += rebanhoDto.SaldoSemVacinaBubalino;
        }   
        private async Task RealizaEstornoEntrada()
        {            
            var rebanho = propriedadeDestino.Rebanho;
            rebanho.SaldoComVacinaBovino -= historico.QtdComVacinaBovino;
            rebanho.SaldoComVacinaBubalino -= historico.QtdComVacinaBubalino;
            rebanho.SaldoSemVacinaBovino -= historico.QtdSemVacinaBovino;
            rebanho.SaldoSemVacinaBubalino -= historico.QtdSemVacinaBubalino;
            await _IRebanho.Atualizar(rebanho);
        }

        public async Task<List<HistoricoMovimentacao>> BuscarEntradasPorPropriedadeId(int propriedadeId)
        {
           return await _IServicoHistorico.BuscarEntradasPorIdPropriedade(propriedadeId);
        }
    }
}
