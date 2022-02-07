using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto.HistoricoDTO
{
    public class HistoricoCompraVendaResponseDTO
    {
        public string CodigoHistorico { get; set; }
        public int ProdutorOrigemId { get; set; }
        public int ProdutorDestinoId { get; set; }
        public int PropriedadeOrigemId { get; set; }
        public int PropriedadeDestinoId { get; set; }
        public string TipoMovimentacao { get; set; }
        public int QtdComVacinaBovino { get; set; }
        public int QtdComVacinaBubalino { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public string Status { get; set; }
        public string Finalidade { get; set; }


        public HistoricoCompraVendaResponseDTO(HistoricoMovimentacao movimentacao)
        {
            CodigoHistorico = movimentacao.CodigoHistorico;
            ProdutorOrigemId = (int)movimentacao.ProdutorOrigemId;
            ProdutorDestinoId = movimentacao.ProdutorDestinoId;
            PropriedadeOrigemId = (int)movimentacao.PropriedadeOrigemId;
            PropriedadeDestinoId = movimentacao.PropriedadeDestinoId;
            TipoMovimentacao = movimentacao.TipoMovimentacao.ToString();
            QtdComVacinaBovino = movimentacao.QtdComVacinaBovino;
            QtdComVacinaBubalino = movimentacao.QtdComVacinaBubalino;
            DataMovimentacao = movimentacao.DataMovimentacao;
            DataCancelamento = movimentacao.DataCancelamento;
            Status = movimentacao.Status.ToString();
            Finalidade = movimentacao.Finalidade.ToString();
        }
    }
}
