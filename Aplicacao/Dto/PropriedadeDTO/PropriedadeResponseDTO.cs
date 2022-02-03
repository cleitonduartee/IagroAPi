﻿using Aplicacao.Dto.ProdutorDTO;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Dto.PropriedadeDTO
{
    public class PropriedadeResponseDTO
    {
        public int InscricaoEstadual { get; set; }
        public string NomePropriedade { get; set; }
        public string MunicipioPropriedade { get; set; }
        public  ProdutorResponseDTO Produtor { get; set; }
        

        public PropriedadeResponseDTO(Propriedade propriedade)
        {
            InscricaoEstadual = propriedade.InscricaoEstadual;
            NomePropriedade = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(propriedade.Nome.ToLower()) ;
            Produtor = new ProdutorResponseDTO(propriedade.Produtor);
            MunicipioPropriedade = propriedade.Municipio.Nome;
        }
    }
}
