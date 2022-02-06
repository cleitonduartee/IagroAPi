using Entidades.Entidades;
using Entidades.Entidades.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServico
{
    public interface IServicoMovimentacao
    {
        Task CancelarMovimentacao(string codigoMovimentacao);
        Task<List<HistoricoMovimentacao>> BuscarPorIdPropriedade(int idPropriedade);
        Task CriarHistoricoDeMovimentacao(HistoricoMovimentacao historicoMovimentacao);

    }
}
