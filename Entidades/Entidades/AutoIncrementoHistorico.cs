using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("tb_auto_incremento_historico")]
    public class AutoIncrementoHistorico
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGerado { get; set; }
    }
}
