using CarLocadora.Infra.Entity;
using CarLocadora.Modelo.Models;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.Negocio.Cliente
{
    public class ClienteNegocio : IClienteNegocio
    {
        private readonly Context _context;

        public ClienteNegocio(Context context)
        {
            _context = context;
        }

        #region OBTENÇÃO
        public async Task<List<ClienteModel>> ObterLista()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<ClienteModel> Obter(string CPF)
        {
            return await _context.Clientes.SingleAsync(x => x.CPF.Equals(CPF));

        }
        public async Task<List<ClienteModel>> ObterListaEnviarEmail()
        {
            return await _context.Clientes.Where(e => e.Email != null && e.EmailEnviado.Equals(false)).ToListAsync();
        }
        #endregion

        #region ALTERAÇÃO
        public async Task Alterar(ClienteModel cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task AlterarEnvioDeEmail(string cpf)
        {
            //var cliente = await Obter(cpf)
            var cliente = await _context.Clientes.FirstAsync(x => x.CPF.Equals(cpf));
            cliente.EmailEnviado = true;

            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region INSERÇÃO E EXCLUSÃO

        public async Task Inserir(ClienteModel cliente)
        {
            _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(string cliente)
        {
            var CPF = _context.Clientes.Single(x => x.CPF.Equals(cliente));
            _context.Clientes.Remove(CPF);
            _context.SaveChanges();

        }
        #endregion

    }
}
