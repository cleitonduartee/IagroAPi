using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto.EnderecoDTO
{
    public class EnderecoResponseDTO
    {        
        public  string NomeRua { get; set; }
        public  int Numero { get; set; }
        public MunicipioResponseDTO Municipio { get; set; }

        public EnderecoResponseDTO(Endereco endereco)
        {
            NomeRua = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(endereco.NomeRua.ToLower());
            Numero = endereco.Numero;
            Municipio = new MunicipioResponseDTO(endereco.Municipio);
        }
    }
}
