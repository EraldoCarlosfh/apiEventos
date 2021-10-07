using System.Linq;
using System.Threading.Tasks;
using CursoAngularDotNet.Domain;
using CursoAngularDotNet.Persistence.Contextos;
using CursoAngularDotNet.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace CursoAngularDotNet.Persistence
{
    public class RedeSocialPersist : IRedeSocialPersist
    {
        private readonly CursoAngularDotNetContext _context;
        public RedeSocialPersist(CursoAngularDotNetContext context)
        {
            _context = context;           
        }

        public async Task<RedeSocial[]> GetRedesSociaisByEventoIdAsync(int eventoId)
        {
            IQueryable<RedeSocial> query = _context.RedesSociais;

            query = query.AsNoTracking()
                         .Where(redeSocial => redeSocial.EventoId == eventoId);

            return await query.ToArrayAsync();
        }

        public async Task<RedeSocial> GetRedeSocialByIdsAsync(int eventoId, int id)
        {
            IQueryable<RedeSocial> query = _context.RedesSociais;

            query = query.AsNoTracking()
                         .Where(redeSocial => redeSocial.EventoId == eventoId
                                     && redeSocial.Id == id);

            return await query.FirstOrDefaultAsync();
        }

    }
}