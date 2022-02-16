using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("tb_propriedade")]
    public class Propriedade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropriedadeId { get; set; }
        public int InscricaoEstadual { get; set; }
        public string Nome { get; set; }
        public DateTime? DataUltimaVacinacao { get; set; }
        public int ProdutorId { get; set; }
        public virtual  Produtor Produtor { get; set; }
        public int MunicipioId { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual Rebanho Rebanho { get; set; }


        public Propriedade(string nome, int produtorId, int municipioId)
        {
            Nome = nome;
            ProdutorId = produtorId;
            MunicipioId = municipioId;

        }
       

        public override bool Equals(object obj)
        {
            return obj is Propriedade propriedade &&
                   PropriedadeId == propriedade.PropriedadeId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PropriedadeId);
        }
    }
}
