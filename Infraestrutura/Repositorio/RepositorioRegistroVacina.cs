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
    public class RepositorioRegistroVacina : IRegistroVacina
    {
        private readonly ApiContext _ApiContext;
        public RepositorioRegistroVacina(ApiContext ApiContext)
        {
            _ApiContext = ApiContext;
        }

        public async Task AdicionarRegistroVacina(RegistroVacina registroVacina)
        {
            await _ApiContext.RegistroVacinacao.AddAsync(registroVacina);
            await _ApiContext.SaveChangesAsync();
        }

        public async Task<RegistroVacina> BuscarRegistroVacinaPorId(int idRegistroVacina)
        {
           return await _ApiContext.RegistroVacinacao.FindAsync(idRegistroVacina);
        }

        public async Task CancelarRegistroVacina(RegistroVacina registroVacina)
        {
            _ApiContext.RegistroVacinacao.Update(registroVacina);
            await _ApiContext.SaveChangesAsync();
        }
    }
}
