
using Dominio.Dto.EnderecoDTO;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto.ProdutorDTO
{
    public class ProdutorResponseDTO
    {
        public int ProdutorId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public  EnderecoResponseDTO Endereco { get; set; }

        public ProdutorResponseDTO(Produtor produtor)
        {
            ProdutorId = produtor.ProdutorId;
            Nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(produtor.Nome.ToLower());
            Cpf = produtor.Cpf;
            Endereco = new EnderecoResponseDTO(produtor.Endereco);
        }
    }
}
