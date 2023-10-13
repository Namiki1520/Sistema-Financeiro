using Domain.Interfaces.IReceita;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioReceita : RepositoryGenerics<Receita>, InterfaceReceita
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositorioReceita()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<Receita>> ListarReceitasUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from s in banco.SistemaFinanceiro
                     join c in banco.Categoria on s.Id equals c.IdSistema
                     join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     join r in banco.Receita on c.Id equals r.IdCategoria
                     where us.EmailUsuario.Equals(emailUsuario) && s.Mes == r.Mes && s.Ano == r.Ano
                     select r).AsNoTracking().ToListAsync();
            }
        }
    }
}