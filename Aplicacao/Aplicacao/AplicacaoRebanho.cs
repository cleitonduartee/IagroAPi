using Aplicacao.Interfaces;
using Dominio.Dto.Movimentacao.HistoricoDTO;
using Dominio.Dto.RebanhoDTO;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacao
{
    public class AplicacaoRebanho : IAplicacaoRebanho
    {
        private readonly IServicoRebanho _IServicoRebanho;
        private readonly IServicoPropriedade _IServicoPropriedade;
        public AplicacaoRebanho(IServicoRebanho IServicoRebanho, IServicoPropriedade IServicoPropriedade)
        {
            _IServicoRebanho = IServicoRebanho;
            _IServicoPropriedade = IServicoPropriedade;
        }

        public async Task<List<HistoricoTodosTipoResponseDTO>> BuscarEntradasPorPropriedadeId(int propriedadeId)
        {
           var historicoEntradas = await _IServicoRebanho.BuscarEntradasPorPropriedadeId(propriedadeId);
            List<HistoricoTodosTipoResponseDTO> historicoEntradasDTo = new List<HistoricoTodosTipoResponseDTO>();
            historicoEntradas.ForEach(item => historicoEntradasDTo.Add(new HistoricoTodosTipoResponseDTO(item)));
            return historicoEntradasDTo;
        }

        public async Task<List<RebanhoResponseDTO>> BuscarPorProdutor(string produtor)
        {
            List<Rebanho> rebanhoList = await _IServicoRebanho.BuscarPorProdutor(produtor.ToUpper());
            var rebanhoDtoList = new List<RebanhoResponseDTO>();
            rebanhoList.ForEach(async rebanho =>
            {               
                rebanhoDtoList.Add(new RebanhoResponseDTO(rebanho));
            });
            return rebanhoDtoList;
        }

        public async Task<RebanhoResponseDTO> BuscarRebanhoPorNomePropriedade(string propriedade)
        {
            var rebanho = await _IServicoRebanho.BuscarRebanhoPorNomePropriedade(propriedade.ToUpper());
            if (rebanho != null)
            {
                return new RebanhoResponseDTO(rebanho);
            }
            else
                return null;
          
        }

        public async Task CancelarEntrada(string codigoMovimentacaoEntrada)
        {
            await _IServicoRebanho.CancelarMovimentacaoDeEntrada(codigoMovimentacaoEntrada);
        }

        public async Task EntradaAnimais(RebanhoInsertDTO rebanhoInsertDto)
        {
            await _IServicoRebanho.EntradaAnimais(rebanhoInsertDto);
        }
    }
}
