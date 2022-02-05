using Aplicacao.Interfaces;
using Dominio.Dto.VendaDTO;
using Dominio.Interfaces.InterfaceServico;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacao
{
    public class AplicacaoVenda : IAplicacaoVenda
    {
        private readonly IServicoVenda _IServicoVenda;
        public AplicacaoVenda(IServicoVenda IServicoVenda)
        {
            _IServicoVenda = IServicoVenda;
        }

        public async Task CancelarVenda(string codigoMovimentacao)
        {
            await _IServicoVenda.CancelarVenda(codigoMovimentacao);
        }

        public async Task RealizarVenda(VendaInsertDTO vendaInsertDto)
        {
            await _IServicoVenda.RealizarVenda(vendaInsertDto);
        }
    }
}
