using CursoAngularDotNet.Application.Contratos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using CursoAngularDotNet.Application.Dtos;

namespace CursoAngulareDotNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RedesSociaisController : ControllerBase
    {
        private readonly IRedeSocialService _redeSocialService;

        public RedesSociaisController(IRedeSocialService RedeSocialService)
        {
            _redeSocialService = RedeSocialService;
        }

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
        {
            try
            {
                var redesSociais = await _redeSocialService.GetRedesSociaisByEventoIdAsync(eventoId);
                if (redesSociais == null) return NoContent();

                return Ok(redesSociais);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Redes Sociais. Erro: {ex.Message}");
            }
        }

        [HttpPut("{eventoId}")]

        public async Task<IActionResult> SaveRedesSociais(int eventoId, RedeSocialDto[] models)
        {
            try
            {
                var redesSociais = await _redeSocialService.SaveRedesSociais(eventoId, models);
                if (redesSociais == null) return NoContent();

                return Ok(redesSociais);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar Redes Sociais. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{eventoId}/{redeSocialId}")]
        public async Task<IActionResult> Delete(int eventoId, int redeSocialId)
        {
            try
            {
                var redeSocial = await _redeSocialService.GetRedeSocialByIdsAsync(eventoId, redeSocialId);
                if (redeSocial == null) return NoContent();

                return await _redeSocialService.DeleteRedeSocial(redeSocial.EventoId, redeSocial.Id)
                       ? Ok(new { message = "Rede Social Deletada" })
                       : throw new Exception("Ocorreu um problem não específico ao tentar deletar Rede Social.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar Redes Sociais. Erro: {ex.Message}");
            }
        }
    }
}
