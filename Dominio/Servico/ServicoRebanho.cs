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
        private readonly IHistoricoMovimentacao _IHistoricoMovimentacao;
        private readonly IServicoPropriedade _IServicoPropriedade;
        private readonly IUtilAutoIncrementaHistorico _IUtilAutoIncrementaHistorico;
        public ServicoRebanho(IRebanho IRebanho, IHistoricoMovimentacao IHistoricoMovimentacao, IServicoPropriedade IServicoPropriedade, IUtilAutoIncrementaHistorico IUtilAutoIncrementaHistorico)
        {
            _IRebanho = IRebanho;
            _IHistoricoMovimentacao = IHistoricoMovimentacao;
            _IServicoPropriedade = IServicoPropriedade;
            _IUtilAutoIncrementaHistorico = IUtilAutoIncrementaHistorico;
        }

        public async Task<List<Rebanho>> BuscarPorProdutor(string produtor)
        {
            return await _IRebanho.BuscarPorProdutor(p => p.Propriedade.Produtor.Nome.Equals(produtor));
        }

        public async Task<Rebanho> BuscarPorPropriedade(string propriedade)
        {
            return await _IRebanho.BuscarPorPropriedade(p => p.Propriedade.Nome.Equals(propriedade));
        }

        public async Task<Rebanho> BuscarRebanhoPorPropriedadeId(int propriedadeId)
        {
            return await _IRebanho.BuscarRebanhoPorPropriedadeId(r => r.PropriedadeId.Equals(propriedadeId));
        }

        public async Task CancelarEntrada(Rebanho rebanho)
        {
            throw new System.NotImplementedException();
        }

        public async Task EntradaAnimais(RebanhoInsertDTO rebanhoInsertDTO)
        {
            ValidacoesEntradaDeAnimais(rebanhoInsertDTO);

            try
            {
                //Verificar depois como obter uma conexao com banco aqui para fazer o rollback caso aconteca algum erro.

                var rebanho = BuscarRebanhoPorPropriedadeId(rebanhoInsertDTO.PropriedadeId).Result;
                RealizarEntradasDeAnimaisNoRebanho(rebanhoInsertDTO, rebanho);
                await _IRebanho.Atualizar(rebanho);

                await _IHistoricoMovimentacao.Adicionar(new HistoricoMovimentacao(
                    GerarCodigoHistorico(), rebanho.RebanhoId,rebanhoInsertDTO.PropriedadeId, TipoMovimentacao.ENTRADA, rebanhoInsertDTO.SaldoSemVacinaBovino, rebanhoInsertDTO.SaldoComVacinaBovino,
                    rebanhoInsertDTO.SaldoSemVacinaBubalino, rebanhoInsertDTO.SaldoComVacinaBubalino, rebanhoInsertDTO.DataVacina
                    ));
            }catch(Exception ex)
            {
                throw new Exception();
            }
            
        }

        public void ValidacoesEntradaDeAnimais(RebanhoInsertDTO rebanhoDTO)
        {            
            string validacao = "";
            var propriedade = _IServicoPropriedade.BuscarPorId(rebanhoDTO.PropriedadeId).Result;
            if (propriedade == null)
                validacao += "ERROR: Propriedade não localizada.";
            else if (rebanhoDTO.SaldoComVacinaBubalino > 0 || rebanhoDTO.SaldoComVacinaBovino > 0)
            {
                if (!rebanhoDTO.DataVacina.HasValue)
                    validacao += "ERROR: Para entradas de espécies vacinadas é obrigatório a data de vacinação.";
                else if (rebanhoDTO.DataVacina.Value.Year < DateTime.Now.Year)
                    validacao += "ERROR: Para entradas de espécies vacinadas a data de vacinação deve ser do ano atual.";
            }


            if (!String.IsNullOrEmpty(validacao))
                throw new EntradaAnimalException(validacao);
           
        }
        private void RealizarEntradasDeAnimaisNoRebanho(RebanhoInsertDTO rebanhoDto, Rebanho rebanho)
        {
            if (rebanhoDto.SaldoComVacinaBubalino > 0 || rebanhoDto.SaldoComVacinaBovino > 0)
            {
                rebanho.SaldoComVacinaBovino += rebanhoDto.SaldoComVacinaBovino;
                rebanho.SaldoComVacinaBubalino += rebanhoDto.SaldoComVacinaBubalino;
                rebanho.DataVacina = rebanhoDto.DataVacina;
            }
            rebanho.SaldoSemVacinaBovino += rebanhoDto.SaldoSemVacinaBovino;
            rebanho.SaldoSemVacinaBubalino += rebanhoDto.SaldoSemVacinaBubalino;
        }
        private string GerarCodigoHistorico()
        {            
            int idGerado = _IUtilAutoIncrementaHistorico.GerarId().Result;
            return "HISTORICO-" + idGerado;
        }
    }
}
