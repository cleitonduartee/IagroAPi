using Entidades.Entidades.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("tb_historico_movimentacao")]
    public class HistoricoMovimentacao
    {
        //public string CodigoHistorico { get; set; }
        //public int RebanhoId { get; set; }
        //public int PropriedadeId { get; set; }
        //public virtual Propriedade Propriedade { get; set; }
        //public TipoMovimentacao TipoMovimentacao { get; set; }
        //public int QtdSemVacinaBovino { get; set; }
        //public int QtdComVacinaBovino { get; set; }
        //public int QtdSemVacinaBubalino { get; set; }
        //public int QtdComVacinaBubalino { get; set; }
        //public DateTime? DataVacina { get; set; }
        //public DateTime DataMovimentacao { get; set; }
        //public DateTime? DataCancelamento { get; set; }
        //public StatusMovimentacao Status { get; set; }

        //public HistoricoMovimentacao(string codigoHistorico, int rebanhoId, int propriedadeId, TipoMovimentacao tipoMovimentacao, 
        //            int qtdSemVacinaBovino, int qtdComVacinaBovino, int qtdSemVacinaBubalino, int qtdComVacinaBubalino, DateTime? dataVacina)
        //{
        //    CodigoHistorico = codigoHistorico;
        //    RebanhoId = rebanhoId;
        //    PropriedadeId = propriedadeId;
        //    TipoMovimentacao = tipoMovimentacao;
        //    QtdSemVacinaBovino = qtdSemVacinaBovino;
        //    QtdComVacinaBovino = qtdComVacinaBovino;
        //    QtdSemVacinaBubalino = qtdSemVacinaBubalino;
        //    QtdComVacinaBubalino = qtdComVacinaBubalino;
        //    DataVacina = dataVacina;
        //    DataMovimentacao = DateTime.Now;
        //    Status = StatusMovimentacao.ATIVO;
        //}
        public string CodigoHistorico { get; set; }
        public string? CodigoMovimentacaoDaCompra { get; set; }
        public int? PropriedadeOrigemId { get; set; }
        public int PropriedadeDestinoId { get; set; }
        public int? ProdutorOrigemId { get; set; }
        public int ProdutorDestinoId { get; set; }
        // public virtual Propriedade Propriedade { get; set; }
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public int QtdSemVacinaBovino { get; set; }
        public int QtdComVacinaBovino { get; set; }
        public int QtdSemVacinaBubalino { get; set; }
        public int QtdComVacinaBubalino { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public StatusMovimentacao Status { get; set; }

        public HistoricoMovimentacao(string? codigoMovimentacaoDaCompra, int? produtorOrigemId, int produtorDestinoId,
                                    int? propriedadeOrigemId, int propriedadeDestinoId, TipoMovimentacao tipoMovimentacao,
                                    int qtdSemVacinaBovino, int qtdComVacinaBovino, int qtdSemVacinaBubalino, int qtdComVacinaBubalino)
        {
            CodigoMovimentacaoDaCompra = codigoMovimentacaoDaCompra;
            ProdutorOrigemId = produtorOrigemId;
            ProdutorDestinoId = produtorDestinoId;
            PropriedadeOrigemId = propriedadeOrigemId;
            PropriedadeDestinoId = propriedadeDestinoId;
            TipoMovimentacao = tipoMovimentacao;
            QtdSemVacinaBovino = qtdSemVacinaBovino;
            QtdComVacinaBovino = qtdComVacinaBovino;
            QtdSemVacinaBubalino = qtdSemVacinaBubalino;
            QtdComVacinaBubalino = qtdComVacinaBubalino;
            DataMovimentacao = DateTime.Now;
            DataCancelamento = null;
            Status = StatusMovimentacao.ATIVO;
        }
       
    }
}
