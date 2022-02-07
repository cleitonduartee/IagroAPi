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
        public AplicacaoRebanho(IServicoRebanho IServicoRebanho)
        {
            _IServicoRebanho = IServicoRebanho;
        }
        public async Task<List<RebanhoResponseDTO>> BuscarPorProdutor(string produtor)
        {
            List<Rebanho> rebanhoList = await _IServicoRebanho.BuscarPorProdutor(produtor.ToUpper());
            var rebanhoDtoList = new List<RebanhoResponseDTO>();
            rebanhoList.ForEach(rebanho => rebanhoDtoList.Add(new RebanhoResponseDTO(rebanho)));
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
