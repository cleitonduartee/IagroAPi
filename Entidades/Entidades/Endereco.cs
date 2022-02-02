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
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int EnderecoId { get; set; }
        public  string NomeRua { get; set; }
        public  int Numero { get; set; }
        public  int MunicipioId { get; set; }
        public  Municipio Municipio { get; set; }
    }
}
