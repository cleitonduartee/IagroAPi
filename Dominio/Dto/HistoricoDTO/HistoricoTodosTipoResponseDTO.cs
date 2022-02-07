using System;
using Entidades.Entidades.Enuns;
using Entidades.Entidades;

namespace Dominio.Dto.Movimentacao.HistoricoDTO
{
    public class HistoricoTodosTipoResponseDTO
    {
       
        public string CodigoHistorico { get; set; }
     //   public string? CodigoMovimentacaoDaCompra { get; set; }
        public int? ProdutorOrigemId { get; set; }
        public int ProdutorDestinoId { get; set; }
        public int? PropriedadeOrigemId { get; set; }
        public int PropriedadeDestinoId { get; set; }
        public string TipoMovimentacao { get; set; }
        public int QtdSemVacinaBovino { get; set; }
        public int QtdComVacinaBovino { get; set; }
        public int QtdSemVacinaBubalino { get; set; }
        public int QtdComVacinaBubalino { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public string Status { get; set; }


        public HistoricoTodosTipoResponseDTO(HistoricoMovimentacao movimentacao)
        {
            CodigoHistorico = movimentacao.CodigoHistorico;
       //     CodigoMovimentacaoDaCompra = movimentacao.CodigoMovimentacaoDaCompra;
            ProdutorOrigemId = movimentacao.ProdutorOrigemId;
            ProdutorDestinoId = movimentacao.ProdutorDestinoId;
            PropriedadeOrigemId = movimentacao.PropriedadeOrigemId;
            PropriedadeDestinoId = movimentacao.PropriedadeDestinoId;
            TipoMovimentacao = movimentacao.TipoMovimentacao.ToString();
            QtdSemVacinaBovino = movimentacao.QtdSemVacinaBovino;
            QtdComVacinaBovino = movimentacao.QtdComVacinaBovino;
            QtdSemVacinaBubalino = movimentacao.QtdSemVacinaBubalino;
            QtdComVacinaBubalino = movimentacao.QtdComVacinaBubalino;
            DataMovimentacao = movimentacao.DataMovimentacao;
            DataCancelamento = movimentacao.DataCancelamento;
            Status = movimentacao.Status.ToString();
        }
    }
}
