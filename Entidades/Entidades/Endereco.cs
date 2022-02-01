using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int EnderecoId { get; protected set; }
        public virtual string NomeRua { get; set; }
        public virtual int Numero { get; set; }
        [ForeignKey("Municipio")]
        public virtual int MunicipioId { get; set; }
        public virtual Municipio Municipio { get; set; }
    }
}
