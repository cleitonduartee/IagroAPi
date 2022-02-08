using Entidades.Entidades.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("tb_registro_vacina")]
    public class RegistroVacina
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CodigoRegistro { get; set; }
        public int PropriedadeId { get; set; }
        public virtual Propriedade Propriedade { get; set; }
        public TipoVacina TipoVacina { get; set; }
        public int QtdBovinoVacinado { get; set; }
        public int QtdBubalinoVacinado { get; set; }
        public DateTime DataVacinacao { get; set; }        
        public DateTime DataRegistro { get; set; }        
        public DateTime? DataCancelamento { get; set; }        
        public bool Ativo { get; set; }

        public RegistroVacina(int propriedadeId,Propriedade propriedade, TipoVacina tipoVacina, int qtdBovinoVacinado, int qtdBubalinoVacinado, DateTime dataVacinacao)
        {
            PropriedadeId = propriedadeId;
            Propriedade = propriedade;
            TipoVacina = tipoVacina;
            QtdBovinoVacinado = qtdBovinoVacinado;
            QtdBubalinoVacinado = qtdBubalinoVacinado;
            DataRegistro = DateTime.Now;
            DataVacinacao = dataVacinacao;
            DataCancelamento = null;
            Ativo = true;
        }
        public static bool DataVacinacaoEValida(DateTime dtVacinacao)
        {
            if(DateTime.Now.Year.Equals(dtVacinacao.Year))
                return true;

            return false;
        }
    }
}
