
using CarLocadora.Infra.Entity;
using CarLocadora.Modelo.Models;

namespace CarLocadora.Negocio.Veiculo
{
    public class VeiculoNegocio : IVeiculoNegocio
    {
        private readonly Context _context;

        public VeiculoNegocio(Context context)
        {
            _context = context;
        }

        public void Alterar(VeiculoModel model)
        {
            model.DataAlteracao = DateTime.Now;
            _context.Update(model);
            _context.SaveChangesAsync();
        }

        public void Inserir(VeiculoModel model)
        {
            model.DataInclusao = DateTime.Now;
            _context.AddAsync(model);
            _context.SaveChangesAsync();
        }

        public VeiculoModel Obter(string placa) => _context.veiculos.SingleOrDefault(x => x.Placa.Equals(placa));
    

        public List<VeiculoModel> ObterLista() => _context.veiculos.ToList();

    }
}
