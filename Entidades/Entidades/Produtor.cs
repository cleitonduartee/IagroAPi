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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutorId { get; protected set; }
        public string Nome { get; set; }
        public long Cpf { get; protected set; }
        public string Rua { get; set; }        
        [ForeignKey("Municipio")]
        public int EnderecoId { get; protected set; }
        public Endereco Endereco { get; protected set; }
        public virtual Municipio Municipio { get; protected set; }

        public Produtor()
        {
        }

        public Produtor(int produtorId, string nome, long cpf, string rua, int enderecoId, Endereco endereco, Municipio municipio)
        {
            ProdutorId = produtorId;
            Nome = nome;
            Cpf = cpf;
            Rua = rua;
            EnderecoId = enderecoId;
            Endereco = endereco;
            Municipio = municipio;
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
