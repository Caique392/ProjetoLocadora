using CarLocadora.Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Locacao
{
    public interface ILocacaoNegocio
    {
        List<LocacaoModel> ObterLista();
        void Alterar(LocacaoModel model);
        void Inserir(LocacaoModel model);
        void Excluir(int id);
        LocacaoModel Obter(int id);
    }
}
