using CarLocadora.Modelo.Models;
using CarLocadora.Negocio.FormasDePagamento;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormasDePagamentoController : ControllerBase
    {
        private readonly IFormasDePagamentoNegocio _formasDePagamentoNegocio;
           public FormasDePagamentoController(IFormasDePagamentoNegocio formasDePagamentoNegocio)
        {
            _formasDePagamentoNegocio = formasDePagamentoNegocio;
        }

        [HttpGet()]
        public List<FormaPagamentoModel> Get()
        {
            return _formasDePagamentoNegocio.ObterLista();
        }
        [HttpGet("ObterDados")]
        public FormaPagamentoModel Get([FromQuery] int id)
        {
            return _formasDePagamentoNegocio.Obter(id);
        }
        [HttpPost()]
        public void Post([FromBody] FormaPagamentoModel FormaPagamentoModel)
        {
            _formasDePagamentoNegocio.Inserir(FormaPagamentoModel);
        }

        [HttpPut()]
        public void Put([FromBody] FormaPagamentoModel FormaPagamentoModel)
        {
            _formasDePagamentoNegocio.Alterar(FormaPagamentoModel);
        }
    }
}
