using Aplicacao.Dto.PropriedadeDTO;
using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacao
{
    public class AplicacaoPropriedade : IAplicacaoPropriedade
    {
        private readonly IServicoPropriedade _IServicoPropriedade;
        public AplicacaoPropriedade(IServicoPropriedade IServicoPropriedade)
        {
            _IServicoPropriedade = IServicoPropriedade;
        }


        public async Task<Propriedade> BuscarPorId(int id)
        {
            return await _IServicoPropriedade.BuscarPorId(id);
        }

        public async Task<PropriedadeResponseDTO> BuscarPorIE(int ie)
        {
            var propriedade = await _IServicoPropriedade.BuscarPorIE(ie);
            if (propriedade != null)
                return new PropriedadeResponseDTO(propriedade);
            else
                return null;
        }
        public async Task<Propriedade> BuscarPorProdutor(string produtor)
        {
            return await _IServicoPropriedade.BuscarPorProdutor(produtor);

        }

        public async Task<List<PropriedadeResponseDTO>> BuscarTodos()
        {
            var propriedades = await _IServicoPropriedade.BuscarTodos();
            var propriedadesResponseDTO = new List<PropriedadeResponseDTO>();
            propriedades.ForEach(propriedade =>
                propriedadesResponseDTO.Add(new PropriedadeResponseDTO(propriedade))
            );

            return propriedadesResponseDTO;
        }

        public async Task CadastrarPropriedade(Propriedade propriedade)
        {
            await _IServicoPropriedade.CadastrarPropriedade(propriedade);
        }

        public async Task EditarPropriedade(Propriedade propriedade)
        {
            await _IServicoPropriedade.EditarPropriedade(propriedade);
        }
    }
}
