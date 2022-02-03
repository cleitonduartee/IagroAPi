using Aplicacao.Dto.ProdutorDTO;
using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacao
{
    public class AplicacaoProdutor : IAplicacaoProdutor
    {
        private readonly IServicoProdutor _IServicoProdutor;
        public AplicacaoProdutor(IServicoProdutor IServicoProdutor)
        {
            _IServicoProdutor = IServicoProdutor;
        }

        public async Task<ProdutorResponseDTO> BuscarPorCpf(string cpf)
        {
            var produtor = await _IServicoProdutor.BuscarPorCpf(cpf);
            if (produtor != null)
                return new ProdutorResponseDTO(produtor);
            else
                return null;
        }

        public async Task<Produtor> BuscarPorId(int id)
        {
            return await _IServicoProdutor.BuscarPorId(id); 
        }

        public async Task<List<ProdutorResponseDTO>> BuscarTodos()
        {
            var produtoresList = await _IServicoProdutor.BuscarTodos();
            var produtoresResponseList = new List<ProdutorResponseDTO>();
            produtoresList.ForEach(produtor => {
                produtoresResponseList.Add(new ProdutorResponseDTO(produtor));
            });
            return produtoresResponseList;
        }

        public async Task CadastrarProdutor(Produtor produtor)
        {
            await _IServicoProdutor.CadastrarProdutor(produtor);
        }

        public async Task EditarProdutor(Produtor produtor)
        {
            await _IServicoProdutor.EditarProdutor(produtor);
        }

        public bool ValidarCpf(string cpf)
        {
            return _IServicoProdutor.ValidarCpf(cpf);
        }
    }
}
