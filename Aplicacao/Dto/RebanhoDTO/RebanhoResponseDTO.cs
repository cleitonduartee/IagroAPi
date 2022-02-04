using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Dto.RebanhoDTO
{
    public class RebanhoResponseDTO
    {
        public int RebanhoId { get; set; }
        public int PropriedadeId { get; set; }
        public int SaldoSemVacinaBovino { get; set; }
        public int SaldoComVacinaBovino { get; set; }
        public int SaldoSemVacinaBubalino { get; set; }
        public int SaldoComVacinaBubalino { get; set; }
        public DateTime? DataVacina { get; set; }

        public RebanhoResponseDTO(Rebanho rebanho)
        {
            RebanhoId = rebanho.RebanhoId;
            PropriedadeId = rebanho.PropriedadeId;
            SaldoSemVacinaBovino = rebanho.SaldoSemVacinaBovino;
            SaldoComVacinaBovino = rebanho.SaldoComVacinaBovino;
            SaldoSemVacinaBubalino = rebanho.SaldoSemVacinaBubalino;
            SaldoComVacinaBubalino = rebanho.SaldoComVacinaBubalino;
            DataVacina = rebanho.DataVacina;
        }
    }
}
