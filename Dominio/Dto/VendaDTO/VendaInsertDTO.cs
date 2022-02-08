using Entidades.Entidades.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using Dominio.ValidadorCustomizado.ValidadorDTO;

namespace Dominio.Dto.VendaDTO
{
    public class VendaInsertDTO
    {
        [Required(ErrorMessage = "Id da propriedade de origem é obriatório")]
        public int PropriedadeOrigemId { get; set; }
        [Required(ErrorMessage = "Id da propriedade de destino é obriatório")]
        public int PropriedadeDestinoId { get; set; }
        public int SaldoComVacinaBovino { get; set; }
        public int SaldoComVacinaBubalino { get; set; }
       
        [DefinedEnumValue(typeof(FinalidadeVenda))]
        public FinalidadeVenda Finalidade { get; set; }
    }

   
}