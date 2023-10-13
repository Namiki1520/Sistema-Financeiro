using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Domain.Servicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceSistemaFinanceiro _interfaceSistemaFinanceiro;
        private readonly ISistemaFinanceiroServico _iSistemaFinanceiroServico;
        public SistemaFinanceiroController(InterfaceSistemaFinanceiro interfaceSistemaFinanceiro, 
            ISistemaFinanceiroServico iSistemaFinanceiroServico)
        {
            _interfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
            _iSistemaFinanceiroServico = iSistemaFinanceiroServico;
        }

        [HttpGet("/api/ListaSistemasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListaSistemasUsuario(string emailUsuario)
        {
            return await _interfaceSistemaFinanceiro.ListaSistemasUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _iSistemaFinanceiroServico.AdicionarSistemaFinanceiro(sistemaFinanceiro);

            return sistemaFinanceiro;
        }

        [HttpPut("/api/AtualizarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _iSistemaFinanceiroServico.AtualizarSistemaFinanceiro(sistemaFinanceiro);
            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpGet("/api/ObterSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> ObterSistemaFinanceiro(int id)
        {
            return await _interfaceSistemaFinanceiro.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteSistemaFinanceiro(int id)
        {
            try
            {
                var sistemaFinanceiro = await _interfaceSistemaFinanceiro.GetEntityById(id);

                await _interfaceSistemaFinanceiro.Delete(sistemaFinanceiro);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
