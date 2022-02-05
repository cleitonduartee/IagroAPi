using Dominio.Dto.VendaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoVenda
    {
        Task RealizarVenda(VendaInsertDTO vendaInsertDto);
        Task CancelarVenda(string codigoMovimentacao);
    }
}
