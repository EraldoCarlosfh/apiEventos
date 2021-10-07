using System.Linq;
using System.Threading.Tasks;
using CursoAngularDotNet.Domain;
using CursoAngularDotNet.Persistence.Contextos;
using CursoAngularDotNet.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace CursoAngularDotNet.Persistence
{
    public class LotePersist : ILotePersist
    {
        private readonly CursoAngularDotNetContext _context;
        public LotePersist(CursoAngularDotNetContext context)
        {
            _context = context;           
        }

        public async Task<Lote[]> GetLotesByEventoIdAsync(int eventoId)
        {
            IQueryable<Lote> query = _context.Lotes;

            query = query.AsNoTracking()
                         .Where(lote => lote.EventoId == eventoId);

            return await query.ToArrayAsync();
        }

        public async Task<Lote> GetLoteByIdsAsync(int eventoId, int id)
        {
            IQueryable<Lote> query = _context.Lotes;

            query = query.AsNoTracking()
                         .Where(lote => lote.EventoId == eventoId
                                     && lote.Id == id);

            return await query.FirstOrDefaultAsync();
        }

    }
}