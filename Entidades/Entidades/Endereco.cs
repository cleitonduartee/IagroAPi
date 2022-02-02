using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
   [Table("tb_endereco")]
    public class Endereco
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  virtual int EnderecoId { get;  set; }
        public virtual string NomeRua { get; set; }
        public virtual int Numero { get; set; }
        public virtual int MunicipioId { get; set; }
        public virtual Municipio Municipio { get; set; }

        public Endereco(string nomeRua, int numero, int municipioId, Municipio municipio)
        {
            NomeRua = nomeRua;
            Numero = numero;
            MunicipioId = municipioId;
            Municipio = municipio;
        }

        public Endereco()
        {
        }
    }
}
