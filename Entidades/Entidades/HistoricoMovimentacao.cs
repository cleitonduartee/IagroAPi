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
        public string CodigoHistorico { get; set; }
        public string? CodigoMovimentacaoDaCompra { get; set; }
        public int? PropriedadeOrigemId { get; set; }
        public int PropriedadeDestinoId { get; set; }
        public int? ProdutorOrigemId { get; set; }
        public int ProdutorDestinoId { get; set; }      
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public int QtdSemVacinaBovino { get; set; }
        public int QtdComVacinaBovino { get; set; }
        public int QtdSemVacinaBubalino { get; set; }
        public int QtdComVacinaBubalino { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public StatusMovimentacao Status { get; set; }
        public FinalidadeVenda Finalidade { get; set; }

        //Construtor para entrada de animais.
        public HistoricoMovimentacao(int produtorDestinoId, int propriedadeDestinoId, int qtdSemVacinaBovino, int qtdSemVacinaBubalino)
        {
            ProdutorDestinoId = produtorDestinoId;
            PropriedadeDestinoId = propriedadeDestinoId;
            TipoMovimentacao = TipoMovimentacao.ENTRADA;
            QtdSemVacinaBovino = qtdSemVacinaBovino;
            QtdSemVacinaBubalino = qtdSemVacinaBubalino;
            DataMovimentacao = DateTime.Now;
            DataCancelamento = null;
            Status = StatusMovimentacao.ATIVO;
            Finalidade = FinalidadeVenda.ENGORDA;
        }       

        public HistoricoMovimentacao(string? codigoMovimentacaoDaCompra, int? produtorOrigemId, int produtorDestinoId,
                                    int? propriedadeOrigemId, int propriedadeDestinoId, TipoMovimentacao tipoMovimentacao,
                                     int qtdComVacinaBovino, int qtdComVacinaBubalino, FinalidadeVenda finalidade)
        {
            CodigoMovimentacaoDaCompra = codigoMovimentacaoDaCompra;
            ProdutorOrigemId = produtorOrigemId;
            ProdutorDestinoId = produtorDestinoId;
            PropriedadeOrigemId = propriedadeOrigemId;
            PropriedadeDestinoId = propriedadeDestinoId;
            TipoMovimentacao = tipoMovimentacao;
            QtdComVacinaBovino = qtdComVacinaBovino;
            QtdComVacinaBubalino = qtdComVacinaBubalino;
            DataMovimentacao = DateTime.Now;
            DataCancelamento = null;
            Status = StatusMovimentacao.ATIVO;
            Finalidade = finalidade;
        }
       
    }
}
