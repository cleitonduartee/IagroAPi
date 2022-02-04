using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio.Crud;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioRebanho : RepositorioCrud<Rebanho>, IRebanho
    {
        private readonly ApiContext _ApiContext;
        public RepositorioRebanho(ApiContext ApiContext) : base(ApiContext)
        {
            _ApiContext = ApiContext;
        }

        public async Task<List<Rebanho>> BuscarPorProdutor(Expression<Func<Rebanho, bool>> expression)
        {
            return await _ApiContext.Rebanhos.Where(expression).ToListAsync();
        }

        public async Task<Rebanho> BuscarPorPropriedade(Expression<Func<Rebanho, bool>> expression)
        {
            return await _ApiContext.Rebanhos.FirstOrDefaultAsync(expression);
        }
        public async Task<Rebanho> BuscarRebanhoPorPropriedadeId(Expression<Func<Rebanho, bool>> expression)
        {
            return await _ApiContext.Rebanhos.FirstOrDefaultAsync(expression);
        }
    }
}
