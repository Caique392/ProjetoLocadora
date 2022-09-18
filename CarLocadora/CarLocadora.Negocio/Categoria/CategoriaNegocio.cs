using CarLocadora.Infra.Entity;
using CarLocadora.Modelo.Models;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.Negocio.Categoria
{
    public class CategoriaNegocio : ICategoriaNegocio
    {
        private readonly Context _context;

        public CategoriaNegocio(Context context)
        {
            _context = context;
        }

        public async Task Alterar(CategoriaModel model)
        {
            _context.categorias.Update(model);
            await _context.SaveChangesAsync();
        }


        public async Task Incluir(CategoriaModel model)
        {
            await _context.categorias.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task< CategoriaModel> Obter(int id)
        {
            return await _context.categorias.SingleAsync(x => x.Id.Equals(id));
        }

        public async Task <List<CategoriaModel>> ObterLista()
        {
            return await _context.categorias.ToListAsync();
        }

    }
}
