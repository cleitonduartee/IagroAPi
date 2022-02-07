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
        public int RegistroVacinaId { get; set; }
        public int PropriedadeId { get; set; }
        public virtual Propriedade Propriedade { get; set; }
        public TipoVacina TipoVacina { get; set; }
        public int QtdBovinoVacinado { get; set; }
        public int QtdBubalinoVacinado { get; set; }
        public DateTime DataVacinacao { get; set; }        
    }
}
