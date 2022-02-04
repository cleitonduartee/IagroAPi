using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IHistoricoMovimentacao
    {
        Task CriarHistoricoMovimentacao(HistoricoMovimentacao historicoMovimentacao);
        Task CancelarHistoricoMovimentacao(HistoricoMovimentacao historicoMovimentacao);
    }
}
