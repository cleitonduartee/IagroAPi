using Aplicacao.Dto.EnderecoDTO;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Dto.ProdutorDTO
{
    public class ProdutorResponseDTO
    {        
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public  EnderecoResponseDTO Endereco { get; set; }

        public ProdutorResponseDTO(Produtor produtor)
        {
            Nome = produtor.Nome;
            Cpf = produtor.Cpf;
            Endereco = new EnderecoResponseDTO(produtor.Endereco);
        }
    }
}
