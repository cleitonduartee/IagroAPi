using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto.VendaDTO
{
    public class VendaInsertDTO
    {
        public int PropriedadeOrigemId { get; set; }
        public int PropriedadeDestinoId { get; set; }
        public int SaldoComVacinaBovino { get; set; }
        public int SaldoComVacinaBubalino { get; set; }
    }
}
