using CarLocadora.Modelo.Models;

namespace CarLocadora.Negocio.Cliente
{
    public interface IClienteNegocio
    {
        Task<List<ClienteModel>> ObterLista();
        Task<ClienteModel> Obter(string CPF);
        Task Alterar(ClienteModel cliente);

        Task AlterarEnvioDeEmail(string cpf);
        Task Inserir(ClienteModel cliente);
        Task Excluir(string CPF);
        Task<List<ClienteModel>> ObterListaEnviarEmail();
    }
}
