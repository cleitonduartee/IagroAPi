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
        public  int ProdutorId { get; set; }
        public  string Nome { get; set; }
        public  string Cpf { get;  set; }        
        public  int EnderecoId { get;  set; }
        public Endereco Endereco { get;  set; }

        public Produtor()
        {
        }

        public Produtor(int produtorId, string nome, string cpf, Endereco endereco)
        {
            ProdutorId = produtorId;
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
