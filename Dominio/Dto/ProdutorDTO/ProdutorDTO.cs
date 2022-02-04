using Dominio.Interfaces;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto.ProdutorDTO
{
    public class ProdutorDTO
    {        
        [Required(ErrorMessage = "ProdutorId é obriatório")]
        public int ProdutorId { get; set; }
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

        public static void AtualizaProdutor(ProdutorDTO produtorDTO, Produtor produtor)
        {
            produtor.Nome = produtorDTO.Nome.ToUpper();
            produtor.Cpf = produtorDTO.Cpf;
            produtor.Endereco.NomeRua = produtorDTO.NomeRua;
            produtor.Endereco.Numero = produtorDTO.Numero;
            produtor.Endereco.MunicipioId = produtorDTO.MunicipioId;
        }
    }
}
