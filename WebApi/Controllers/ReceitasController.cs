using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IReceita;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly InterfaceReceita _interfaceReceita;
        private readonly IReceitaServico _iReceitaServico;

        public ReceitasController(InterfaceReceita interfaceDespesa, IReceitaServico iReceitaServico)
        {
            _interfaceReceita = interfaceDespesa;
            _iReceitaServico = iReceitaServico;
        }

        [HttpGet("/api/ListarReceitasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarReceitasUsuario(string emailUsuario)
        {
            return await _interfaceReceita.ListarReceitasUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarReceita")]
        [Produces("application/json")]
        public async Task<object> AdicionarReceita(Receita receita)
        {
            await _iReceitaServico.AdicionarReceita(receita);

            return receita;
        }

        [HttpPut("/api/AtualizarReceita")]
        [Produces("application/json")]
        public async Task<object> AtualizarReceita(Receita receita)
        {
            await _iReceitaServico.AtualizarReceita(receita);

            return receita;
        }

        [HttpGet("/api/ObterReceita")]
        [Produces("application/json")]
        public async Task<object> ObterReceita(int id)
        {
            return await _interfaceReceita.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteReceita")]
        [Produces("application/json")]
        public async Task<object> DeleteReceita(int id)
        {
            try
            {
                var receita = await _interfaceReceita.GetEntityById(id);
                await _interfaceReceita.Delete(receita);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        [HttpGet("/api/CarregaGraficosReceitas")]
        [Produces("application/json")]
        public async Task<object> CarregaGraficosReceitas(string emailUsuario)
        {
            return await _iReceitaServico.CarregaGraficos(emailUsuario);
        }
    }

}
