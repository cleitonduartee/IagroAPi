using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.InterfaceCrud
{
    public interface ICrudAplicacao<T> where T : class
    {
        Task Adicionar(T obj);
        Task Atualizar(T obj);
        Task Excluir(T obj);
        Task<T> BuscarPorId(int Id);
        Task<List<T>> BuscarTodos();
    }
}
