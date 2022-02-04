﻿using Aplicacao.Dto.Rebanho;
using Aplicacao.Interfaces;
using Entidades.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{    
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {
        private readonly IAplicacaoRebanho _IAplicacaoRebanho;
        public AnimaisController(IAplicacaoRebanho IAplicacaoRebanho)
        {
            _IAplicacaoRebanho = IAplicacaoRebanho;
        }
        [HttpGet("BuscarPorProdutor/{produtor}")]
        public async Task<List<Rebanho>> BuscarPorProdutor(string produtor)
        {
            return await _IAplicacaoRebanho.BuscarPorProdutor(produtor);
        }
        [HttpGet("BuscarPorPropriedade/{propriedade}")]
        public async Task<ActionResult<Rebanho>> BuscarPorPropriedade(string propriedade)
        {
            var rebanho = await _IAplicacaoRebanho.BuscarPorPropriedade(propriedade);

            if (rebanho != null)
                return Ok(rebanho);
            else
                return NotFound("Não foi localizado nenhum rebanho para a propriedade informada.");
        }
        [HttpPost("EntradaAnimais")]
        public async Task<ActionResult> EntradaAnimais(RebanhoInsertDTO rebanhoDto)
        {
            if (!ModelState.IsValid) { }
                       
            var validacoes = _IAplicacaoRebanho.validacoes(rebanhoDto);
            if (validacoes != null)
                    return BadRequest(validacoes);
            
            await _IAplicacaoRebanho.EntradaAnimais(rebanhoDto);
            return Ok("Entrada de animais realizada com sucesso.");
        }
        [HttpPost("CancelamentoEntradaAnimais")]
        public async Task CancelamentoEntradaAnimais(Rebanho rebanho)
        {
            await _IAplicacaoRebanho.CancelarEntrada(rebanho);
        }

    }
}