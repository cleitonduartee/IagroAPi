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
        public async Task Adicionar(Municipio obj)
        {
            await _IMunicipio.Adicionar(obj);
        }

        public async Task Atualizar(Municipio obj)
        {
            await _IMunicipio.Atualizar(obj);
        }

        public async Task<Municipio> BuscarPorId(int Id)
        {
           return await _IMunicipio.BuscarPorId(Id);
        }

        public async Task<List<Municipio>> BuscarTodos()
        {
            return await _IMunicipio.BuscarTodos();
        }

        public async Task Excluir(Municipio obj)
        {
            await _IMunicipio.Excluir(obj);
        }
    }
}
