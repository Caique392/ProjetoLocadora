using CarLocadora.Modelo.Models;
using CarLocadora.Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Vistoria
{
    public interface IVistoriaNegocio
    {
        List<VistoriaModel> ObterLista();
        void Inserir(VistoriaModel model);
        void Alterar(VistoriaModel model);
        VistoriaModel Obter(int id);

    }
}
