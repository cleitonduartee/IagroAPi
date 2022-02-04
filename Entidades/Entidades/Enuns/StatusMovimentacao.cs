using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades.Enuns
{
    public enum StatusMovimentacao
    {
        [Description("Ativo")]
        ATIVO = 0,

        [Description("Cancelado")]
        CANCELADO =1
    }
}
