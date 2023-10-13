using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IReceitaServico
    {
        Task AdicionarReceita(Receita receita);
        Task AtualizarReceita(Receita receita);
        Task<object> CarregaGraficos(string emailUsuario);
    }
}
