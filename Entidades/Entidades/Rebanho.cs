﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("tb_rebanho")]
    public class Rebanho
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RebanhoId { get; set; }
        public int PropriedadeId { get; set; }
        public virtual Propriedade Propriedade { get; set; }
        public int SaldoSemVacinaBovino { get; set; }
        public int SaldoComVacinaBovino { get; set; }
        public int SaldoSemVacinaBubalino { get; set; }
        public int SaldoComVacinaBubalino { get; set; }
        public DateTime? DataVacina { get; set; }
        public int SaldoTotal()
        {
            return SaldoSemVacinaBovino + SaldoComVacinaBovino + SaldoSemVacinaBubalino + SaldoComVacinaBubalino;
        }
    }
}