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

        public async Task<Propriedade> BuscarPorIE(int ie)
        {
            return await _IServicoPropriedade.BuscarPorIE(ie);
        }

        public async Task<List<Propriedade>> BuscarTodos()
        {
            return await _IServicoPropriedade.BuscarTodos();
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
