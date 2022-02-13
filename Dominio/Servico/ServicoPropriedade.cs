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
        private readonly IRebanho _IRebanho;
        public ServicoPropriedade(IPropriedade IPropriedade, IRebanho IRebanho)
        {
            _IPropriedade = IPropriedade;
            _IRebanho = IRebanho;
        }

        public async Task<Propriedade> BuscarPorId(int id)
        {
           return await _IPropriedade.BuscarPorId(id);
        }

        public async Task<Propriedade> BuscarPorIE(int ie)
        {
            return await _IPropriedade.BuscarPorIE(p => p.InscricaoEstadual.Equals(ie));
        }
        public async Task<List<Propriedade>> BuscarPorProdutor(string produtor)
        {
            return await _IPropriedade.BuscarPorProdutor(p => p.Produtor.Nome.Equals(produtor));
        }

        public async Task<List<Propriedade>> BuscarTodos()
        {
            return await _IPropriedade.BuscarTodos();
        }

        public async Task CadastrarPropriedade(Propriedade propriedade)
        {
            await  _IPropriedade.Adicionar(propriedade);
            var rebanho = new Rebanho();
            rebanho.Propriedade = propriedade;
            rebanho.PropriedadeId = propriedade.PropriedadeId;
            await _IRebanho.Adicionar(rebanho);

        }

        public async Task EditarPropriedade(Propriedade propriedade)
        {
            await _IPropriedade.Atualizar(propriedade);
        }
    }
}
