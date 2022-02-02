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
    public class MunicipioController : ControllerBase
    {
        private readonly IAplicacaoMunicipio _IAplicacaoMunicipio;
        public MunicipioController(IAplicacaoMunicipio IAplicacaoMunicipio)
        {
            _IAplicacaoMunicipio = IAplicacaoMunicipio;
        }
        [HttpGet("BuscarTodos")]
        public async Task<List<Municipio>> BuscarTodos()
        {
            return await _IAplicacaoMunicipio.BuscarTodos();
        }
        [HttpPost("Cadastrar")]
        public async Task Cadastrar(Municipio municipio)
        {
             await _IAplicacaoMunicipio.Adicionar(municipio);
        }
    }
}
