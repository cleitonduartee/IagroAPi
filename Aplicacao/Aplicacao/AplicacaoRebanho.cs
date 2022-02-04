using Aplicacao.Dto.RebanhoDTO;
using Aplicacao.Interfaces;
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
        public async Task<List<RebanhoResponseDTO>> BuscarPorProdutor(string produtor)
        {
            List<Rebanho> rebanhoList = await _IServicoRebanho.BuscarPorProdutor(produtor.ToUpper());
            var rebanhoDtoList = new List<RebanhoResponseDTO>();
            rebanhoList.ForEach(rebanho => rebanhoDtoList.Add(new RebanhoResponseDTO(rebanho)));
            return rebanhoDtoList;
        }

        public async Task<RebanhoResponseDTO> BuscarPorPropriedade(string propriedade)
        {
            var rebanho = await _IServicoRebanho.BuscarPorPropriedade(propriedade.ToUpper());
            if (rebanho != null)
            {
                return new RebanhoResponseDTO(rebanho);
            }
            else
                return null;
          
        }

        public async Task CancelarEntrada(Rebanho rebanho)
        {
            await _IServicoRebanho.CancelarEntrada(rebanho);
        }

        public async Task EntradaAnimais(RebanhoInsertDTO rebanhoDto)
        {            
            var rebanho = _IServicoRebanho.BuscarRebanhoPorPropriedadeId(rebanhoDto.PropriedadeId).Result;
            realizarEntradasDeAnimaisNoRebanho(rebanhoDto, rebanho);
            await _IServicoRebanho.EntradaAnimais(rebanho);
        }

        public Dictionary<string, string> validacoes(RebanhoInsertDTO rebanhoDTO)
        {
            Dictionary<string, string> validacao = new Dictionary<string, string>();
            var propriedade = _IServicoPropriedade.BuscarPorId(rebanhoDTO.PropriedadeId).Result;
            if (propriedade == null)
                validacao.Add("ERROR","Propriedade não localizada.");
            if (rebanhoDTO.SaldoComVacinaBubalino > 0 || rebanhoDTO.SaldoComVacinaBovino > 0)
            {
                if(!rebanhoDTO.DataVacina.HasValue)
                    validacao.Add("ERROR", "Para entradas de espécies vacinadas é obrigatório a data de vacinação.");
                else if(rebanhoDTO.DataVacina.Value.Year < DateTime.Now.Year)
                    validacao.Add("ERROR", "Para entradas de espécies vacinadas a data de vacinação deve ser do ano atual.");
            }
                
            
            if(validacao.ContainsKey("ERROR"))
                return validacao;
            else
                return null;
        }
        private void realizarEntradasDeAnimaisNoRebanho(RebanhoInsertDTO rebanhoDto, Rebanho rebanho)
        {
            if(rebanhoDto.SaldoComVacinaBubalino > 0 || rebanhoDto.SaldoComVacinaBovino > 0)
            {
                rebanho.SaldoComVacinaBovino += rebanhoDto.SaldoComVacinaBovino;
                rebanho.SaldoComVacinaBubalino += rebanhoDto.SaldoComVacinaBubalino;                
            }
            rebanho.SaldoSemVacinaBovino += rebanhoDto.SaldoSemVacinaBovino;
            rebanho.SaldoSemVacinaBubalino += rebanhoDto.SaldoSemVacinaBubalino;
        }
    }
}
