using Dominio.Dto.RebanhoDTO;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using Entidades.Entidades.Enuns;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class ServicoRebanho : IServicoRebanho
    {
        private readonly IRebanho _IRebanho;
        private readonly IHistoricoMovimentacao _IHistoricoMovimentacao;
        public ServicoRebanho(IRebanho IRebanho, IHistoricoMovimentacao IHistoricoMovimentacao)
        {
            _IRebanho = IRebanho;
            _IHistoricoMovimentacao = IHistoricoMovimentacao;
        }

        public async Task<List<Rebanho>> BuscarPorProdutor(string produtor)
        {
            return await _IRebanho.BuscarPorProdutor(p => p.Propriedade.Produtor.Nome.Equals(produtor));
        }

        public async Task<Rebanho> BuscarPorPropriedade(string propriedade)
        {
            return await _IRebanho.BuscarPorPropriedade(p => p.Propriedade.Nome.Equals(propriedade));
        }

        public async Task<Rebanho> BuscarRebanhoPorPropriedadeId(int propriedadeId)
        {
            //throw new System.NotImplementedException();
            return await _IRebanho.BuscarRebanhoPorPropriedadeId(r => r.PropriedadeId.Equals(propriedadeId));
        }

        public async Task CancelarEntrada(Rebanho rebanho)
        {
            throw new System.NotImplementedException();
        }

        public async Task EntradaAnimais(RebanhoInsertDTO rebanho)
        {
            //await _IRebanho.Atualizar(rebanho);
            //await _IHistoricoMovimentacao.CriarHistoricoMovimentacao(new HistoricoMovimentacao(
            //    "", rebanho.RebanhoId, rebanho.PropriedadeId, TipoMovimentacao.ENTRADA, rebanho.SaldoSemVacinaBovino, rebanho.SaldoComVacinaBovino,
            //    rebanho.SaldoSemVacinaBubalino, rebanho.SaldoComVacinaBubalino,rebanho.DataVacina
            //    ));
        }
    }
}
