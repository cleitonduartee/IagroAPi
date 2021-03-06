using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto.RebanhoDTO
{
    public class RebanhoInsertDTO
    {
        [Required(ErrorMessage = "Id da propriedade é obrigatório.")]
        [Range(1, 99999,  ErrorMessage = "Id da propriedade deve ser maior que 0")]
        public int PropriedadeId { get; set; }
        public int SaldoSemVacinaBovino { get; set; }
        public int SaldoSemVacinaBubalino { get; set; }
    }
}
