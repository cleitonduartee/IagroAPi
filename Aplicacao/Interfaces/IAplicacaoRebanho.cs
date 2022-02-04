using Aplicacao.Dto.Rebanho;
using Aplicacao.Interfaces.InterfaceCrud;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoRebanho
    {
        Task EntradaAnimais(RebanhoInsertDTO rebanho);
        Task CancelarEntrada(Rebanho rebanho);
        Task<List<Rebanho>> BuscarPorProdutor(string produtor);
        Task<Rebanho> BuscarPorPropriedade(string propriedade);
        Dictionary<string, string> validacoes(RebanhoInsertDTO rebanhoDTO) ;


    }
}
