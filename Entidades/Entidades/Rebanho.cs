using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("tb_rebanho")]
    public class Rebanho
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RebanhoId { get; set; }
        public int PropriedadeId { get; set; }
        [JsonIgnore]
        public virtual Propriedade Propriedade { get; set; }
        public int SaldoSemVacinaBovino { get; set; }
        public int SaldoComVacinaBovino { get; set; }
        public int SaldoSemVacinaBubalino { get; set; }
        public int SaldoComVacinaBubalino { get; set; }
        public DateTime? DataVacina { get; set; }
        public DateTime? DataUltimaVenda { get; set; }

        public bool ExisteSaldoParaVenda(int qtdComVacinaBovino, int qtdComVacinaBubalino)
        {
            return  SaldoComVacinaBovino >= qtdComVacinaBovino 
                && SaldoComVacinaBubalino >= qtdComVacinaBubalino;
        }
        public bool VacinaEstaValida()
        {
            if(DataVacina != null)
                return DataVacina.Value.Year == DateTime.Now.Year;

            return false;
        }        
    }
}
