using CarLocadora.Infra.Entity;
using CarLocadora.Modelo.Models;
using CarLocadora.Modelo.Models;

namespace CarLocadora.Negocio.Vistoria
{
    public class VistoriasNegocio : IVistoriaNegocio
    {
        private readonly Context _context;
        public VistoriasNegocio(Context context)
        {
            _context = context;
        }

        public void Alterar(VistoriaModel model)
        {
            model.DataAlteracao = DateTime.Now;
            _context.Vistoria.Update(model);
            _context.SaveChangesAsync();
        }

        public void Inserir(VistoriaModel model)
        {
            model.DataInclusao = DateTime.Now;
            _context.Vistoria.AddAsync(model);
            _context.SaveChangesAsync();
        }

        public VistoriaModel Obter(int id) => _context.Vistoria.SingleOrDefault(x => x.Id.Equals(id));

        public List<VistoriaModel> ObterLista()
        {
            return _context.Vistoria.ToList();
        }
    }
}
