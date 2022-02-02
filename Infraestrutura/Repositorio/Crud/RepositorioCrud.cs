using Dominio.Interfaces.InterfaceCrud;
using Infraestrutura.Configuracao;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio.Crud
{
    public abstract class RepositorioCrud<T> : ICrud<T> where T : class
    {
        private readonly ApiContext _ApiContext;
        public RepositorioCrud(ApiContext ApiContext)
        {
            _ApiContext = ApiContext;
        }
        public async Task Adicionar(T obj)
        {
            await _ApiContext.Set<T>().AddAsync(obj);
            await _ApiContext.SaveChangesAsync();
        }

        public async Task Atualizar(T obj)
        {
            _ApiContext.Set<T>().Update(obj);
            await _ApiContext.SaveChangesAsync();
        }

        public async Task<T> BuscarPorId(int Id)
        {
            return await _ApiContext.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> BuscarTodos()
        {
            //AsNoTracking praticamente faz um select no banco e devolve, evitando trazer cofig do enti            
            return await _ApiContext.Set<T>()
                    .ToListAsync();
        }

        public async Task Excluir(T obj)
        {
            _ApiContext.Set<T>().Remove(obj);
            await _ApiContext.SaveChangesAsync();
        }
    }
}
