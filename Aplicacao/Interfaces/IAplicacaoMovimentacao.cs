using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoMovimentacao
    {
        Task CancelarMovimentacao(string codigoMovimentacao);
        Task<List<HistoricoMovimentacao>> BuscarPorIdPropriedade(int idPropriedade);      
    }
}
