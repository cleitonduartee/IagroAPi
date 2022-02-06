using System;
using Entidades.Entidades.Enuns;
using Entidades.Entidades;

namespace Dominio.Dto.Movimentacao.MovimentacaoDTO
{
    public class MovimentacaoResponseDTO
    {
        //public string CodigoHistorico { get; set; }
        //public int PropriedadeId { get; set; }
        //public string TipoMovimentacao { get; set; }
        //public int QtdSemVacinaBovino { get; set; }
        //public int QtdComVacinaBovino { get; set; }
        //public int QtdSemVacinaBubalino { get; set; }
        //public int QtdComVacinaBubalino { get; set; }
        //public DateTime? DataVacina { get; set; }
        //public DateTime DataMovimentacao { get; set; }
        //public DateTime? DataCancelamento { get; set; }
        //public string Status { get; set; }

        //public MovimentacaoResponseDTO(HistoricoMovimentacao movimentacao)
        //{ 
        //    CodigoHistorico = movimentacao.CodigoHistorico;
        //    PropriedadeId = movimentacao.PropriedadeId;
        //    TipoMovimentacao = movimentacao.TipoMovimentacao.ToString();
        //    QtdSemVacinaBovino = movimentacao.QtdSemVacinaBovino;
        //    QtdComVacinaBovino = movimentacao.QtdComVacinaBovino;
        //    QtdSemVacinaBubalino = movimentacao.QtdSemVacinaBubalino;
        //    QtdComVacinaBubalino = movimentacao.QtdComVacinaBubalino;
        //    DataVacina = movimentacao.DataVacina;
        //    DataMovimentacao = movimentacao.DataMovimentacao;
        //    DataCancelamento = movimentacao.DataCancelamento;
        //    Status =movimentacao.Status.ToString();
        //}

        public string CodigoHistorico { get; set; }
        public string? CodigoMovimentacaoDaCompra { get; set; }
        public int? RebanhoOrigemId { get; set; }
        public int RebanhoDestinoId { get; set; }
        public int? PropriedadeOrigemId { get; set; }
        public int PropriedadeDestinoId { get; set; }
        // public virtual Propriedade Propriedade { get; set; }
        public string TipoMovimentacao { get; set; }
        public int QtdSemVacinaBovino { get; set; }
        public int QtdComVacinaBovino { get; set; }
        public int QtdSemVacinaBubalino { get; set; }
        public int QtdComVacinaBubalino { get; set; }
        public DateTime? DataVacina { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public string Status { get; set; }


        public MovimentacaoResponseDTO(HistoricoMovimentacao movimentacao)
        {
            CodigoHistorico = movimentacao.CodigoHistorico;
            CodigoMovimentacaoDaCompra = movimentacao.CodigoMovimentacaoDaCompra;
            RebanhoOrigemId = movimentacao.RebanhoOrigemId;
            RebanhoDestinoId = movimentacao.RebanhoDestinoId;
            PropriedadeOrigemId = movimentacao.PropriedadeOrigemId;
            PropriedadeDestinoId = movimentacao.PropriedadeDestinoId;
            TipoMovimentacao = movimentacao.TipoMovimentacao.ToString();
            QtdSemVacinaBovino = movimentacao.QtdSemVacinaBovino;
            QtdComVacinaBovino = movimentacao.QtdComVacinaBovino;
            QtdSemVacinaBubalino = movimentacao.QtdSemVacinaBubalino;
            QtdComVacinaBubalino = movimentacao.QtdComVacinaBubalino;
            DataVacina = movimentacao.DataVacina;
            DataMovimentacao = movimentacao.DataMovimentacao;
            DataCancelamento = movimentacao.DataCancelamento;
            Status = movimentacao.Status.ToString();
        }
    }
}
