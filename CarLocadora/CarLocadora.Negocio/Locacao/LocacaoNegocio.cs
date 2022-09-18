using CarLocadora.Infra.Entity;
using CarLocadora.Modelo.Models;

namespace CarLocadora.Negocio.Locacao
{
    public class LocacaoNegocio : ILocacaoNegocio
    {
        private readonly Context _context;

        public LocacaoNegocio(Context context)
        {
            _context = context;
        }

        public void Alterar(LocacaoModel model)
        {
            model.DataAlteracao = DateTime.Now;
            _context.Update(model);
            _context.SaveChangesAsync();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(LocacaoModel model)
        {
            model.DataInclusao = DateTime.Now;
            _context.AddAsync(model);
            _context.SaveChangesAsync();
        }


        public LocacaoModel Obter(int id) => _context.Locacao.SingleOrDefault(x => x.Id.Equals(id));

        public List<LocacaoModel> ObterLista() => _context.Locacao.ToList();

    }
}

