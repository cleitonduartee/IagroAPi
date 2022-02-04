using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto.PropriedadeDTO
{
    public class PropriedadeDTO
    {
        [Required(ErrorMessage = "Id da Propriedade é obriatório")]
        public int PropriedadeId { get;  set; }   
        [Required(ErrorMessage = "Nome do Propriedade é obriatório")]
        public string NomePropriedade { get;  set; }
        [Required(ErrorMessage = "Id do Produtor é obriatório")]
        public int ProdutorId { get; set; }
        [Required(ErrorMessage = "Id do municipio é obriatório")]
        public int MunicipioId { get; set; }

        public static void AtualizaPropriedade(PropriedadeDTO dto, Propriedade propriedade) 
        {
                propriedade.Nome = dto.NomePropriedade.ToUpper();
                propriedade.ProdutorId = dto.ProdutorId;
                propriedade.MunicipioId = dto.MunicipioId;
        }
    }
}
