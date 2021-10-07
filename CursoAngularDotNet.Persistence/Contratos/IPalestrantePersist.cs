using System.Threading.Tasks;
using CursoAngularDotNet.Domain;

namespace CursoAngularDotNet.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
        
         //PALESTRANTES
         Task<Palestrante[]> GetAllPalestrantesByNameAsync(string nome, bool includeEventos = false);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
         Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false);

    }
}