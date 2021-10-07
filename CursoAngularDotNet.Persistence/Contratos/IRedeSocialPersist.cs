using System.Threading.Tasks;
using CursoAngularDotNet.Domain;

namespace CursoAngularDotNet.Persistence.Contratos
{
    public interface IRedeSocialPersist
    {
        /// <summary>
        /// M�todo get que retornar� uma lista de lotes por eventoId. 
        /// </summary>
        /// <param name="eventoId">C�digo chave da tabela Evento</param>
        /// <returns>Array de Lotes</returns>
        Task<RedeSocial[]> GetRedesSociaisByEventoIdAsync(int eventoId);

        /// <summary>
        /// M�todo get que retornar� apenas 1 Lote
        /// </summary>
        /// <param name="eventoId">C�digo chave da tabela Evento</param>
        /// <param name="id">C�digo chave da tabela Lote</param>
        /// <returns>Apenas 1 lote</returns>
        Task<RedeSocial> GetRedeSocialByIdsAsync(int eventoId, int id);
    }
}