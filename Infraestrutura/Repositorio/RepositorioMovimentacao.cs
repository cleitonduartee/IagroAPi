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
    public class RepositorioMovimentacao : IMovimentacao
    {
        private readonly ApiContext _ApiContext;
        private readonly IUtilAutoIncrementaHistorico _IUtilAutoIncrementaHistorico;
        public RepositorioMovimentacao(ApiContext ApiContext, IUtilAutoIncrementaHistorico IUtilAutoIncrementaHistorico)
        {
            _ApiContext = ApiContext;
            _IUtilAutoIncrementaHistorico = IUtilAutoIncrementaHistorico;
        }

        public async Task AtualizarHistoricoMovimentacao(HistoricoMovimentacao historicoMovimentacao)
        {
            _ApiContext.Movimentacoes.Update(historicoMovimentacao);
            await _ApiContext.SaveChangesAsync();
        }

        public async Task<List<HistoricoMovimentacao>> BuscarComprasPorProdutor(Expression<Func<HistoricoMovimentacao, bool>> expression)
        {
            return await _ApiContext.Movimentacoes.Where(expression).ToListAsync();
        }

        public async Task<HistoricoMovimentacao> BuscarPorCodigo(string codigoMovimentacao)
        {
            return await _ApiContext.Movimentacoes.FindAsync(codigoMovimentacao);
        }

        public async Task<List<HistoricoMovimentacao>> BuscarPorIdPropriedade(Expression<Func<HistoricoMovimentacao, bool>> expression)
        {
             return await _ApiContext.Movimentacoes.Where(expression).ToListAsync();
        }

        public async Task<List<HistoricoMovimentacao>> BuscarVendasPorProdutor(Expression<Func<HistoricoMovimentacao, bool>> expression)
        {
            return await _ApiContext.Movimentacoes.Where(expression).ToListAsync();
        }

        public async Task CriarHistoricoMovimentacao(HistoricoMovimentacao historicoMovimentacao)
        {
            historicoMovimentacao.CodigoHistorico = GerarCodigoHistorico();
            await _ApiContext.Movimentacoes.AddAsync(historicoMovimentacao);
            await _ApiContext.SaveChangesAsync();
        }
        private string GerarCodigoHistorico()
        {
            int idGerado = _IUtilAutoIncrementaHistorico.GerarId().Result;
            return "HISTORICO-" + idGerado;
        }
    }
}
