using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using CarLocadora.Modelo.Models;

namespace CarLocadora.Negocio.FormasDePagamento
{
    public class FormasDePagamentoNegocio : IFormasDePagamentoNegocio
    {
        private readonly Context _context;

        public FormasDePagamentoNegocio(Context context)
        {
            _context = context;
        }

        public void Alterar(FormaPagamentoModel model)
        {
            model.DataAlteracao = DateTime.Now;
            _context.Update(model);
            _context.SaveChangesAsync();
        }

        public void Inserir(FormaPagamentoModel model)
        {
            model.DataInclusao = DateTime.Now;
            _context.AddAsync(model);
            _context.SaveChangesAsync();
        }


        public FormaPagamentoModel Obter(int id)
        {
            return _context.formasPagamentos.SingleOrDefault(x => x.ID.Equals(id));
        }

        public List<FormaPagamentoModel> ObterLista() => _context.formasPagamentos.ToList();

    }
}
