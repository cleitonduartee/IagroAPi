using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidades.Entidades
{
    [Table("tb_municipio")]
    public class Municipio
    {
        [Key]
        public int Id { get; protected set; }
        public string Nome { get; set; }

        public Municipio()
        {
        }

        public Municipio(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
