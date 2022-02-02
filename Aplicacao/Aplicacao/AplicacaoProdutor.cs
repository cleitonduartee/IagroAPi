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

        public async Task<Produtor> BuscarPorCpf(string cpf)
        {
            return await _IServicoProdutor.BuscarPorCpf(cpf);
        }

        public async Task<Produtor> BuscarPorId(int id)
        {
            return await _IServicoProdutor.BuscarPorId(id); 
        }

        public async Task<List<Produtor>> BuscarTodos()
        {
            return await _IServicoProdutor.BuscarTodos();
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
