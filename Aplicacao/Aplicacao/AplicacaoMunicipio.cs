using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacao
{
    public class AplicacaoMunicipio : IAplicacaoMunicipio
    {
        IMunicipio _IMunicipio;
        public AplicacaoMunicipio(IMunicipio IMunicipio)
        {
            _IMunicipio = IMunicipio;
        }
        public async Task<List<Municipio>> BuscarTodos()
        {
            return await _IMunicipio.BuscarTodos();
        }
    }
}
