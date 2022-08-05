//using CarLocadora.Modelo.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;



//namespace CarLocadora.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ClienteController : ControllerBase
//    {
//        private readonly ICliente _cliente;

//        public ClienteController(ICliente cliente)
//        {
//            _cliente = cliente;
//        }

//        [HttpGet()]

//        public async Task <List<ClienteModel>> Get()
//        {

//            return _cliente.ObterLista();
                                      
//        }
//        [HttpGet("ObterDadosCliente")]
//        public ClienteModel Get([FromQuery] string cpf)
//        {
//            return _cliente.ObterUmCliente(cpf);
//        }


//        [HttpGet("ObterListaPorUF")]
//        public List<ClienteModel> GetObterListaPorUF([FromQuery] string siglaUF)
//        {
//            return _cliente.ObterListaPorUF(siglaUF);
//        }

//        [HttpGet("ObterListaPorNome")]
//        public List<ClienteModel> GetObterListaPorNome([FromQuery] string nome)
//        {
//            return _cliente.ObterListaPorNome(nome);
//        }

//        [HttpGet("ObterListaPorNome")]
//        public List<ClienteModel> GetObterListaPorNomeEUF([FromQuery] string nome, [FromQuery] string siglaUF)
//        {
//            return _cliente.ObterListaPorNomeEUF(nome, siglaUF);
//        }

//        [HttpPost()]
//        public void Post([FromBody] ClienteModel clienteModel)
//        {

//            _cliente.Incluir(clienteModel);



//        }

//        [HttpPut()]
//        public void Put([FromBody] ClienteModel clienteModel)
//        {

//            _cliente.Alterar(clienteModel);

//        }

//        [HttpDelete()]
//        public void Delete([FromQuery] string cpf)
//        {
//            _cliente.Excluir(cpf);
//        }
//    }
//}
