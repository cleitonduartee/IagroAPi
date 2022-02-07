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
        private readonly IServicoHistorico _IServicoMovimentacao;


        //private readonly IHistoricoMovimentacao _IHistoricoMovimentacao;
        // private readonly IUtilAutoIncrementaHistorico _IUtilAutoIncrementaHistorico;

        private Propriedade propriedadeEntradaAnimais;

        public ServicoRebanho(IRebanho IRebanho, IServicoPropriedade IServicoPropriedade, IServicoHistorico IServicoMovimentacao)
        {
            _IRebanho = IRebanho;
            _IServicoPropriedade = IServicoPropriedade;
            _IServicoMovimentacao = IServicoMovimentacao;

            //  _IHistoricoMovimentacao = IHistoricoMovimentacao;

            //  _IUtilAutoIncrementaHistorico = IUtilAutoIncrementaHistorico;
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
            ValidacoesEntradaDeAnimais(rebanhoInsertDTO);

            try
            {
                //Verificar depois como obter uma conexao com banco aqui para fazer o rollback caso aconteca algum erro.

                var rebanho = propriedadeEntradaAnimais.Rebanho;
                RealizarEntradasDeAnimaisNoRebanho(rebanhoInsertDTO, rebanho);
                await _IRebanho.Atualizar(rebanho);
                await CriarMovimentacaoDeEntrada(propriedadeEntradaAnimais.ProdutorId, rebanhoInsertDTO);


                //await _IServicoMovimentacao.CriarHistoricoDeMovimentacao(null,rebanho.RebanhoId,null ,rebanhoInsertDTO.PropriedadeId, TipoMovimentacao.ENTRADA, rebanhoInsertDTO.SaldoSemVacinaBovino, rebanhoInsertDTO.SaldoComVacinaBovino,
                //    rebanhoInsertDTO.SaldoSemVacinaBubalino, rebanhoInsertDTO.SaldoComVacinaBubalino, rebanhoInsertDTO.DataVacina,
                //    ));
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        private void ValidacoesEntradaDeAnimais(RebanhoInsertDTO rebanhoDTO)
        {
            string validacao = "";
            propriedadeEntradaAnimais = _IServicoPropriedade.BuscarPorId(rebanhoDTO.PropriedadeId).Result;
            if (propriedadeEntradaAnimais == null)
                validacao += "ERROR: Propriedade informada não localizada.";

            if (!String.IsNullOrEmpty(validacao))
                throw new ExceptionGenerica(validacao);
        }

        private void RealizarEntradasDeAnimaisNoRebanho(RebanhoInsertDTO rebanhoDto, Rebanho rebanho)
        {          
            rebanho.SaldoSemVacinaBovino += rebanhoDto.SaldoSemVacinaBovino;
            rebanho.SaldoSemVacinaBubalino += rebanhoDto.SaldoSemVacinaBubalino;
        }
        private async Task CriarMovimentacaoDeEntrada(int idPropriedade, RebanhoInsertDTO rebanhoInsertDTO)
        {
            await _IServicoMovimentacao.CriarHistoricoDeMovimentacao(
                new HistoricoMovimentacao(null, null, idPropriedade, null, rebanhoInsertDTO.PropriedadeId, TipoMovimentacao.ENTRADA,
                                          rebanhoInsertDTO.SaldoSemVacinaBovino, 0,
                                          rebanhoInsertDTO.SaldoSemVacinaBubalino, 0));
        }
    }
}
