using Dominio.Interfaces.InterfaceCrud;
using Infraestrutura.Configuracao;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio.Crud
{
    public class RepositorioCrud<T> : ICrud<T> where T : class
    {
        private readonly DbContextOptions<ApiContext> _OptionsBuilder;
        public RepositorioCrud()
        {
            _OptionsBuilder = new DbContextOptions<ApiContext>();
        }
        public async Task Adicionar(T obj)
        {
            using (var db = new ApiContext(_OptionsBuilder))
            {
                await db.Set<T>().AddAsync(obj);
                await db.SaveChangesAsync();
            }
        }

        public async Task Atualizar(T obj)
        {
            using (var db = new ApiContext(_OptionsBuilder))
            {
                db.Set<T>().Update(obj);
                await db.SaveChangesAsync();
            }
        }

        public async Task<T> BuscarPorId(int Id)
        {
            using (var db = new ApiContext(_OptionsBuilder))
            {
                return await db.Set<T>().FindAsync(Id);
            }
        }

        public async Task<List<T>> BuscarTodos()
        {
            //AsNoTracking praticamente faz um select no banco e devolve, evitando trazer cofig do enti            
            using (var db = new ApiContext(_OptionsBuilder))
            {
                return await db.Set<T>()
                    .ToListAsync();
            }
        }

        public async Task Excluir(T obj)
        {
            using (var db = new ApiContext(_OptionsBuilder))
            {
                db.Set<T>().Remove(obj);
                await db.SaveChangesAsync();
            }
        }
    }
}
