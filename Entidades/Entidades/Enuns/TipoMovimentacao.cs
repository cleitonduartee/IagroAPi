using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades.Enuns
{
    public enum TipoMovimentacao
    {
        [Description("Entrada")]
        ENTRADA = 0,

        [Description("Compra")]
        COMPRA = 1,

        [Description("Venda")]
        VENDA =2
    }
}
