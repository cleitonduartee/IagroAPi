using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio.Crud;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioHistoricoMovimentacao : RepositorioCrud<HistoricoMovimentacao>, IHistoricoMovimentacao
    {
        private readonly ApiContext _ApiContext;
        public RepositorioHistoricoMovimentacao(ApiContext ApiContext) : base(ApiContext)
        {
            _ApiContext = ApiContext;
        }

        public async Task<HistoricoMovimentacao> BuscarPorCodigo(string codigoMovimentacao)
        {
            return await _ApiContext.Movimentacoes.FindAsync(codigoMovimentacao);
        }

        public async Task<List<HistoricoMovimentacao>> BuscarPorIdPropriedade(Expression<Func<HistoricoMovimentacao, bool>> expression)
        {
             return await _ApiContext.Movimentacoes.Where(expression).ToListAsync();
        }
    }
}
