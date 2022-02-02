using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidades.Entidades
{
    [Table("tb_municipio")]
    public class Municipio
    {        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MunicipioId { get; set; }
        public string Nome { get; set; }

        public Municipio()
        {
        }

        public Municipio(string nome)
        {
            Nome = nome;
        }
    }
}
