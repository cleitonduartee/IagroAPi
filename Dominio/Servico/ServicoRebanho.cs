using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class ServicoRebanho : IServicoRebanho
    {
        private readonly IRebanho _IRebanho;
        public ServicoRebanho(IRebanho IRebanho)
        {
            _IRebanho = IRebanho;
        }

        public async Task<List<Rebanho>> BuscarPorProdutor(string produtor)
        {
            return await _IRebanho.BuscarPorProdutor(p => p.Propriedade.Produtor.Nome.Equals(produtor));
        }

        public async Task<Rebanho> BuscarPorPropriedade(string propriedade)
        {
            return await _IRebanho.BuscarPorPropriedade(p => p.Propriedade.Nome.Equals(propriedade));
        }

        public async Task<Rebanho> BuscarRebanhoPorPropriedadeId(int propriedadeId)
        {
            throw new System.NotImplementedException();
            // return await _IRebanho.BuscarRebanhoPorPropriedadeId(r => r.PropriedadeId.Equals(propriedadeId));
        }

        public async Task CancelarEntrada(Rebanho rebanho)
        {
            throw new System.NotImplementedException();
        }

        public async Task EntradaAnimais(Rebanho rebanho)
        {
            await _IRebanho.Atualizar(rebanho);
        }
    }
}
