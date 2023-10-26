using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IReceita
{
    public interface InterfaceReceita : InterfaceGeneric<Receita>
    {
        Task<IList<Receita>> ListarReceitasUsuario(string emailUsuario);
    }
}

