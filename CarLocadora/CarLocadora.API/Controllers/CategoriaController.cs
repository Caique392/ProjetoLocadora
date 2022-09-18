using CarLocadora.Modelo.Models;
using CarLocadora.Negocio.Categoria;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaNegocio _categoriaNegocio;

        public CategoriaController(ICategoriaNegocio categoriaNegocio)
        {
            _categoriaNegocio = categoriaNegocio;
        }

        [HttpGet()]
        public async Task<List<CategoriaModel>> Get()
        {
            return await _categoriaNegocio.ObterLista();
        }
        [HttpGet("ObterDados")]
        public async Task<CategoriaModel> Get([FromQuery] int id)
        {
            return await _categoriaNegocio.Obter(id);
        }
        [HttpPost()]
        public async Task Post([FromBody] CategoriaModel categoriaModel)
        {
            await _categoriaNegocio.Incluir(categoriaModel);
        }

        [HttpPut()]
        public async Task Put([FromBody] CategoriaModel categoriaModel)
        {
            await _categoriaNegocio.Alterar(categoriaModel);
        }
    }
}
