using Dominio.Dto.VendaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServico
{
    public interface IServicoVenda
    {
        Task RealizarVenda(VendaInsertDTO vendaInsertDto);
        Task CancelarVenda(string codigoMovimentacao);
    }
}
