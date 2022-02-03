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
    public class RepositorioPropriedade : RepositorioCrud<Propriedade>, IPropriedade
    {
        private readonly ApiContext _ApiContext;
        public RepositorioPropriedade(ApiContext ApiContext) : base(ApiContext)
        {
            _ApiContext = ApiContext;
        }
       
        public async Task<Propriedade> BuscarPorIE(Expression<Func<Propriedade, bool>> expression)
        {
            return await _ApiContext.Propriedades.FirstOrDefaultAsync(expression);
        }
        public async Task<Propriedade> BuscarPorProdutor(Expression<Func<Propriedade, bool>> expression)
        {
            return await _ApiContext.Propriedades.FirstOrDefaultAsync(expression);
        }
    }
}
