using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto.RebanhoDTO
{
    public class RebanhoResponseDTO
    {        
        public int PropriedadeId { get; set; }
        public string NomePropriedade { get; set; }
        public string NomeProdutor { get; set; }
        public int SaldoSemVacinaBovino { get; set; }
        public int SaldoComVacinaBovino { get; set; }
        public int SaldoSemVacinaBubalino { get; set; }
        public int SaldoComVacinaBubalino { get; set; }
        public DateTime? DataVacina { get; set; }

        public RebanhoResponseDTO(Rebanho rebanho)
        {
            PropriedadeId = rebanho.PropriedadeId;
            SaldoSemVacinaBovino = rebanho.SaldoSemVacinaBovino;
            SaldoComVacinaBovino = rebanho.SaldoComVacinaBovino;
            SaldoSemVacinaBubalino = rebanho.SaldoSemVacinaBubalino;
            SaldoComVacinaBubalino = rebanho.SaldoComVacinaBubalino;
            DataVacina = rebanho.DataVacina;
            NomePropriedade = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rebanho.Propriedade.Nome.ToLower()); 
            NomeProdutor = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rebanho.Propriedade.Produtor.Nome.ToLower());
        }
    }
}
