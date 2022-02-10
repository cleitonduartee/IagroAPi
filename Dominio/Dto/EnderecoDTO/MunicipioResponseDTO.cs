using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto.EnderecoDTO
{
    public class MunicipioResponseDTO
    {
        public int MunicipioId { get; set; }
        public string Nome { get; set; }

        public MunicipioResponseDTO(Municipio municipio)
        {
            MunicipioId = municipio.MunicipioId;
            Nome = municipio.Nome;
        }

    }
}
