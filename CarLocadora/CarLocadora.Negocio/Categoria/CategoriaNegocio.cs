using CarLocadora.Infra.Entity;
using CarLocadora.Modelo.Models;

namespace CarLocadora.Negocio.Categoria
{
    public class CategoriaNegocio : ICategoriaNegocio
    {
        private readonly Context _context;

        public CategoriaNegocio(Context context)
        {
            _context = context;
        }

        public void Alterar(CategoriaModel model)
        {
            model.DataAlteracao = DateTime.Now;
            _context.Update(model);
            _context.SaveChangesAsync();
        }

        public void Excluir(int id)
        {
            CategoriaModel model = _context.categorias.SingleOrDefault(x => x.Id.Equals(id));
            _context.Remove(model);
            _context.SaveChangesAsync();
        }

        public void Inserir(CategoriaModel model)
        {
            model.DataInclusao = DateTime.Now;
            _context.AddAsync(model);
            _context.SaveChangesAsync();
        }

        public CategoriaModel Obter(int id)
        {
            return _context.categorias.SingleOrDefault(x => x.Id.Equals(id));
        }

        public List<CategoriaModel> ObterLista() => _context.categorias.ToList();

    }
}
