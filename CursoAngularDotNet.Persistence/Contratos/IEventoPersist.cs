using System.Threading.Tasks;
using CursoAngularDotNet.Domain;

namespace CursoAngularDotNet.Persistence.Contratos
{
    public interface IEventoPersist
    {
      
         //EVENTOS
         Task<Evento[]> GetAllEventosByThemeAsync(string tema, bool includePalestrantes = false);
         Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
         Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false); 

    }
}