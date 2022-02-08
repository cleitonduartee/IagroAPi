using Dominio.ValidadorCustomizado.ValidadorDTO;
using Entidades.Entidades.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto.RegistroVacinaDTO
{
    public class RegistroVacinaInsertDTO
    {
        [Required(ErrorMessage = "Id da propriedade é obrigatório.")]
        public int PropriedadeId { get; set; }
        [DefinedEnumValue(typeof(TipoVacina))]
        public TipoVacina TipoVacina { get; set; }
        public int QtdBovinoVacinado { get; set; }
        public int QtdBubalinoVacinado { get; set; }
        [Required(ErrorMessage = "Data da vacinação é obrigatório")]
        public DateTime DataVacinacao { get; set; }
    }
}
