using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IReceita;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class ReceitaServico : IReceitaServico
    {
        private readonly InterfaceReceita _interfaceReceita;
        public ReceitaServico(InterfaceReceita interfaceReceita)
        {
            _interfaceReceita = interfaceReceita;
        }
        public async Task AdicionarReceita(Receita receita)
        {
            var data = DateTime.UtcNow;
            receita.DataCadastro = data;
            receita.Ano = data.Year;
            receita.Mes = data.Month;

            var valido = receita.ValidarPropriedadeString(receita.Nome, "Nome");
            if (valido)
                await _interfaceReceita.Add(receita);
        }

        public async Task AtualizarReceita(Receita receita)
        {
            var data = DateTime.UtcNow;
            receita.DataAlteracao = data;

            var valido = receita.ValidarPropriedadeString(receita.Nome, "Nome");
            if (valido)
                await _interfaceReceita.Update(receita);
        }

        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            var receitasUsuario = await _interfaceReceita.ListarReceitasUsuario(emailUsuario);

            var receita_salario = receitasUsuario.Where(d => d.TipoReceita == Entities.Enums.EnumTipoReceita.Salario)
                .Sum(x => x.Valor);

            var receita_investimento = receitasUsuario.Where(d => d.TipoReceita == Entities.Enums.EnumTipoReceita.Investimento)
                .Sum(x => x.Valor);

            var receita_venda = receitasUsuario.Where(d => d.TipoReceita == Entities.Enums.EnumTipoReceita.Venda)
                .Sum(x => x.Valor);

            return new
            {
                sucesso = "OK",
                receita_salario = receita_salario,
                receita_investimento = receita_investimento,
                receita_venda = receita_venda
            };
        }
    }
}
