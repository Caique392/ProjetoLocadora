using CarLocadora.Modelo.Models;
using CarLocadora.Modelo.Models;

namespace CarLocadora.Negocio.Veiculo
{
    public interface IVeiculoNegocio
    {
        List<VeiculoModel> ObterLista();
        void Inserir(VeiculoModel model);
        void Alterar(VeiculoModel model);
        VeiculoModel Obter(string placa);
    }
}
