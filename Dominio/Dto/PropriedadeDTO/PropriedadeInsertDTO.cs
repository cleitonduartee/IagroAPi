using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto.PropriedadeDTO
{
    public class PropriedadeInsertDTO
    {
        [Required(ErrorMessage = "Nome do Propriedade é obriatório")]
        public string NomePropriedade { get; set; }
        [Required(ErrorMessage = "Id do Produtor é obriatório")]
        public int ProdutorId { get; set; }
        [Required(ErrorMessage = "Id do municipio é obriatório")]
        public int MunicipioId { get; set; }

        public static Propriedade ToPropriedade(PropriedadeInsertDTO dto)
        {
            return new Propriedade(dto.NomePropriedade, dto.ProdutorId, dto.MunicipioId);
        }
    }
}
