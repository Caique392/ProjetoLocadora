using CarLocadora.Modelo.Models;

namespace CarLocadora.Negocio.Cliente
{
    public interface IClienteNegocio
    {
        List<ClienteModel> ObterLista();
        void Alterar(ClienteModel model);
        void Inserir(ClienteModel model);
        ClienteModel Obter(string cpf);
    }
}
