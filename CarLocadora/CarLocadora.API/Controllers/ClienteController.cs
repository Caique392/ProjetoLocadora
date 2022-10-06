using CarLocadora.Modelo.Models;
using CarLocadora.Negocio.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteNegocio _clienteNegocio;

        public ClienteController(IClienteNegocio cliente)
        {
            _clienteNegocio = cliente;
        }

        [HttpGet()]

        public async Task<List<ClienteModel>> Get()
        {

            return await _clienteNegocio.ObterLista();

        }


        [HttpGet("ObterDados")]

        public async Task<ClienteModel> Get([FromQuery] string CPF)
        {

            return await _clienteNegocio.Obter(CPF);
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task Post([FromBody] ClienteModel cliente)
        {
            cliente.DataInclusao = DateTime.Now;
            cliente.DataAlteracao = null;
            await _clienteNegocio.Inserir(cliente);
        }


        [HttpPut()]
        public async Task Put([FromBody] ClienteModel cliente)
        {
            cliente.DataAlteracao = DateTime.Now;
            await _clienteNegocio.Alterar(cliente);
        }

        [HttpPut("AlterarEnvioDeEmail")]
        public async Task PutAlterarEnvioDeEmail([FromBody] string cpf)
        {
            await _clienteNegocio.AlterarEnvioDeEmail(cpf);
        }

        [HttpDelete()]
        public async Task Delete([FromQuery] string cpf)
        {


            await _clienteNegocio.Excluir(cpf);
        }

        [HttpGet("ObterListaEnviarEmail")]
        public async Task<List<ClienteModel>> GetObterListaEnviarEmail()
        {
            return await _clienteNegocio.ObterListaEnviarEmail();
        }
    }
}
