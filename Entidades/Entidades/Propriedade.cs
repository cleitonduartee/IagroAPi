using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("tb_propriedade")]
    public class Propriedade
    {
        public int PropriedadeId { get; protected set; }
        public int InscricaoEstadual { get; protected set; }
        public string Nome { get; protected set; }
        public int Saldo { get; set; }
        public int SaldoVacinado { get; set; }
        public int ProdutorId { get; set; }
        public virtual  Produtor Produtor { get; set; }
        public int MunicipioId { get; set; }
        public virtual Municipio Municipio { get; set; }

        public Propriedade()
        {
        }

        public Propriedade(int inscricaoEstadual, string nome, Produtor produtor, Municipio municipio)
        {
            InscricaoEstadual = inscricaoEstadual;
            Nome = nome;
            Produtor = produtor;
            Municipio = municipio;
        }
        public Propriedade(int propriedadeId, int inscricaoEstadual, string nome, Produtor produtor, Municipio municipio)
        {
            PropriedadeId = propriedadeId;
            InscricaoEstadual = inscricaoEstadual;
            Nome = nome;
            Produtor = produtor;
            Municipio = municipio;
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
