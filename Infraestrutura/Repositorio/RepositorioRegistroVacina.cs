using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioRegistroVacina : IRegistroVacina
    {
        private readonly ApiContext _ApiContext;
        private readonly IUtilAutoIncrementaHistorico _IUtilAutoIncrementaHistorico;
        public RepositorioRegistroVacina(ApiContext ApiContext, IUtilAutoIncrementaHistorico IUtilAutoIncrementaHistorico)
        {
            _ApiContext = ApiContext;
            _IUtilAutoIncrementaHistorico = IUtilAutoIncrementaHistorico;
        }

        public async Task<RegistroVacina> AdicionarRegistroVacina(RegistroVacina registroVacina)
        {
            registroVacina.CodigoRegistro = GerarCodigoHistorico();
            await _ApiContext.RegistroVacinacao.AddAsync(registroVacina);
            await _ApiContext.SaveChangesAsync();
            return registroVacina;
        }

        public async Task<List<RegistroVacina>> BuscarRegistrosPorPropriedadeId(Expression<Func<RegistroVacina, bool>> expression)
        {
            return await _ApiContext.RegistroVacinacao.Where(expression).ToListAsync();
        }

        public async Task<RegistroVacina> BuscarRegistroVacinaPorCodigo(string codigoRegistro)
        {
           return await _ApiContext.RegistroVacinacao.FindAsync(codigoRegistro);
        }

        public async Task CancelarRegistroVacina(RegistroVacina registroVacina)
        {
            _ApiContext.RegistroVacinacao.Update(registroVacina);
            await _ApiContext.SaveChangesAsync();
        }
        private string GerarCodigoHistorico()
        {
            int idGerado = _IUtilAutoIncrementaHistorico.GerarId().Result;
            return "REGISTRO-" + idGerado;
        }
    }
}
