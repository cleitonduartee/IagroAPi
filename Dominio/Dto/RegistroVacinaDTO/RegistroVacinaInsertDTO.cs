using Entidades.Entidades.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto.RegistroVacinaDTO
{
    public class RegistroVacinaInsertDTO
    {
        public int PropriedadeId { get; set; }
        public TipoVacina TipoVacina { get; set; }
        public int QtdBovinoVacinado { get; set; }
        public int QtdBubalinoVacinado { get; set; }
    }
}
