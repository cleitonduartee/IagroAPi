using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("tb_produtor")]
    public class Produtor
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ProdutorId { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cpf { get;  set; }        
        public virtual int EnderecoId { get;  set; }
        public virtual Endereco Endereco { get;  set; }

        public Produtor()
        {
        }

        public Produtor(string nome, string cpf, Endereco endereco)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
        }

        public override bool Equals(object obj)
        {
            return obj is Produtor produtor &&
                   ProdutorId == produtor.ProdutorId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProdutorId);
        }
    }
}
