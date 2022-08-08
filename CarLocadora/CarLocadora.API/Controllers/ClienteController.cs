﻿using CarLocadora.Modelo.Models;
using CarLocadora.Negocio.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteNegocio _clienteNegocio;
        public ClienteController(IClienteNegocio clienteNegocio)
        {
            _clienteNegocio = clienteNegocio;
        }

        [HttpGet()]
        public List<ClienteModel> Get()
        {
            return _clienteNegocio.ObterLista();
        }
        [HttpGet("ObterDados")]
        public ClienteModel Get([FromQuery] string cpf)
        {
            return _clienteNegocio.Obter(cpf);
        }
        [HttpPost()]
        public void Post([FromBody] ClienteModel clienteModel)
        {
            _clienteNegocio.Inserir(clienteModel);
        }

        [HttpPut()]
        public void Put([FromBody] ClienteModel clienteModel)
        {
            _clienteNegocio.Alterar(clienteModel);
        }
    }
}
