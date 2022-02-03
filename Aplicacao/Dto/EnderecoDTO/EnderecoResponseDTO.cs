using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Dto.EnderecoDTO
{
    public class EnderecoResponseDTO
    {
        public  string NomeRua { get; set; }
        public  int Numero { get; set; }
        public  string Municipio { get; set; }

        public EnderecoResponseDTO(Endereco endereco)
        {
            NomeRua = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(endereco.NomeRua.ToLower());
            Numero = endereco.Numero;
            Municipio = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(endereco.Municipio.Nome);
        }
    }
}
