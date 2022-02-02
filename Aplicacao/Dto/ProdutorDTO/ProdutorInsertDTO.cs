using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Dto.ProdutorDTO
{
    public class ProdutorInsertDTO
    {
        [Required(ErrorMessage = "Nome do Produtor obriatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF do Produtor obriatório")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Nome da rua obriatório")]
        public string NomeRua { get; set; }
        [Required(ErrorMessage = "Numero da rua obriatório")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Id do municipio obrigatório")]
        public int MunicipioId { get; set; }

        public static Produtor ToProdutor(ProdutorInsertDTO produtorDto)
        {
            Endereco enderecoProdutor = new Endereco( produtorDto.NomeRua, produtorDto.Numero, produtorDto.MunicipioId, null);
            return new Produtor(produtorDto.Nome, produtorDto.Cpf, enderecoProdutor);
        }
    }
}
