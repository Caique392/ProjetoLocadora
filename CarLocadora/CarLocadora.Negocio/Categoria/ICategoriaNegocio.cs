using CarLocadora.Modelo.Models;

namespace CarLocadora.Negocio.Categoria
{
    public interface ICategoriaNegocio
    {
        Task<List<CategoriaModel>> ObterLista();
        Task Incluir (CategoriaModel model);
        Task Alterar(CategoriaModel model);
        Task<CategoriaModel> Obter(int id);
    }
}
