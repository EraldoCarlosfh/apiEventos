using CursoAngularDotNet.Application.Dtos;
using System.Threading.Tasks;

namespace CursoAngularDotNet.Application.Contratos
{
   public interface IRedeSocialService
    {
        Task<RedeSocialDto[]> SaveRedesSociais(int eventoId, RedeSocialDto[] models);
        Task<bool> DeleteRedeSocial(int eventoId, int redeSocialId);

        Task<RedeSocialDto[]> GetRedesSociaisByEventoIdAsync(int eventoId);
        Task<RedeSocialDto> GetRedeSocialByIdsAsync(int eventoId, int redeSocialId);
    }
}
