using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Infra.Repositorio.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioUsuarioSistemaFinanceiro : RepositoryGenerics<UsuarioSistemaFinanceiro>, InterfaceUsuarioSistemaFinanceiro
    {
        public Task<IList<UsuarioSistemaFinanceiro>> ListaUsuariosSistema(int IdSistema)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUsuarios(List<UsuarioSistemaFinanceiro> Usuarios)
        {
            throw new NotImplementedException();
        }
    }
}
