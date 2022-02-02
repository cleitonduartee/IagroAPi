using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio.Crud;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioProdutor : RepositorioCrud<Produtor>, IProdutor
    {
        private readonly DbContextOptions<ApiContext> _OptionsBuilder;
        public RepositorioProdutor()
        {
            _OptionsBuilder = new DbContextOptions<ApiContext>();
        }
        public async Task<Produtor> BuscarPorCpf(Expression<Func<Produtor, bool>> expression)
        {
            using (var db = new ApiContext(_OptionsBuilder))
            {
                return await db.Produtors.FirstOrDefaultAsync(expression);
            }
        }
    }
}
