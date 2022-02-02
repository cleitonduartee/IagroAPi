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
        private readonly ApiContext _ApiContext;
        public RepositorioProdutor(ApiContext ApiContext) : base(ApiContext)
        {
            _ApiContext = ApiContext;
        }
        public async Task<Produtor> BuscarPorCpf(Expression<Func<Produtor, bool>> expression)
        {
            return await _ApiContext.Produtors.FirstOrDefaultAsync(expression);
        }
    }
}
