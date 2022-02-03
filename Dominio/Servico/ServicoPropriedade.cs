using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class ServicoPropriedade : IServicoPropriedade
    {
        private readonly IPropriedade _IPropriedade;
        public ServicoPropriedade(IPropriedade IPropriedade)
        {
            _IPropriedade = IPropriedade;
        }

        public async Task<Propriedade> BuscarPorId(int id)
        {
           return await _IPropriedade.BuscarPorId(id);
        }

        public async Task<Propriedade> BuscarPorIE(int ie)
        {
            return await _IPropriedade.BuscarPorIE(p => p.InscricaoEstadual.Equals(ie));
        }
        public async Task<Propriedade> BuscarPorProdutor(string produtor)
        {
            return await _IPropriedade.BuscarPorIE(p => p.Produtor.Nome.Equals(produtor));
        }

        public async Task<List<Propriedade>> BuscarTodos()
        {
            return await _IPropriedade.BuscarTodos();
        }

        public async Task CadastrarPropriedade(Propriedade propriedade)
        {
            await  _IPropriedade.Adicionar(propriedade);
        }

        public async Task EditarPropriedade(Propriedade propriedade)
        {
            await _IPropriedade.Atualizar(propriedade);
        }
    }
}
