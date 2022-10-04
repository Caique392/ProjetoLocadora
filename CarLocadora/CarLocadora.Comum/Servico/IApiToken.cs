namespace CarLocadora.Comum
{
    public interface IApiToken
    {
        Task <string> Obter();
    }
}