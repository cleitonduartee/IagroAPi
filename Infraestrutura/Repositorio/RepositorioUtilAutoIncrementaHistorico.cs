using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioUtilAutoIncrementaHistorico : IUtilAutoIncrementaHistorico
    {
        private readonly ApiContext _ApiContext;
        public RepositorioUtilAutoIncrementaHistorico(ApiContext ApiContext) 
        {
            _ApiContext = ApiContext;
        }
        public async Task<int> GerarId()
        {
            var autoIncremento = new AutoIncrementoHistorico();
            await _ApiContext.AddAsync(autoIncremento);
            await _ApiContext.SaveChangesAsync();
            return autoIncremento.IdGerado;
        }
    }
}
