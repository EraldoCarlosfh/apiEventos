using System.Threading.Tasks;
using CursoAngularDotNet.Domain;

namespace CursoAngularDotNet.Persistence.Contratos
{
    public interface IRedeSocialPersist
    {
        /// <summary>
        /// Método get que retornará uma lista de lotes por eventoId. 
        /// </summary>
        /// <param name="eventoId">Código chave da tabela Evento</param>
        /// <returns>Array de Lotes</returns>
        Task<RedeSocial[]> GetRedesSociaisByEventoIdAsync(int eventoId);

        /// <summary>
        /// Método get que retornará apenas 1 Lote
        /// </summary>
        /// <param name="eventoId">Código chave da tabela Evento</param>
        /// <param name="id">Código chave da tabela Lote</param>
        /// <returns>Apenas 1 lote</returns>
        Task<RedeSocial> GetRedeSocialByIdsAsync(int eventoId, int id);
    }
}