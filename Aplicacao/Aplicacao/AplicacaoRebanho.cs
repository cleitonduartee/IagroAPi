using Aplicacao.Interfaces;
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

        public async Task EntradaAnimais(RebanhoInsertDTO rebanhoInsertDto)
        {
            await _IServicoRebanho.EntradaAnimais(rebanhoInsertDto);
        }

        //public Dictionary<string, string> ValidacoesEntradaDeAnimais(RebanhoInsertDTO rebanhoDTO)
        //{
        //   return _IServicoRebanho.ValidacoesEntradaDeAnimais(rebanhoDTO);
        //}
       
    }
}
