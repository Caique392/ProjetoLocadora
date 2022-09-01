using CarLocadora.Modelo.Models;
using CarLocadora.Modelo.Models;

namespace CarLocadora.Negocio.FormasDePagamento
{
    public interface IFormasDePagamentoNegocio
    {
        List<FormaPagamentoModel> ObterLista();
        void Inserir(FormaPagamentoModel model);
        void Alterar(FormaPagamentoModel model);
        FormaPagamentoModel Obter(int id);
    }
}
