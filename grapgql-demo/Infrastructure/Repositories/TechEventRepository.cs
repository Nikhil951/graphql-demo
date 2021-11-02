using grapgql_demo.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grapgql_demo.Infrastructure.Repositories
{
    /// <summary>  
    /// TechEventRepository.  
    /// </summary>  
    public class TechEventRepository : ITechEventRepository
    {

        /// <summary>  
        /// The _context.  
        /// </summary>  
        private readonly TechEventDBContext _context;

        public TechEventRepository(TechEventDBContext context)
        {
            _context = context;
        }

        public async Task<List<Participant>> GetParticipantInfoByEventId(int id)
        {
            return await (from ep in _context.EventParticipants
                          join p in _context.Participants on ep.ParticipantId equals p.ParticipantId
                          where ep.EventId == id
                          select p).ToListAsync();
        }

        public async Task<TechEventInfo> GetTechEventById(int id)
        {
            return await Task.FromResult(_context.TechEventInfos.FirstOrDefault(i => i.EventId == id));
        }

        public async Task<TechEventInfo[]> GetTechEvents()
        {
            return await _context.TechEventInfos.ToArrayAsync();
        }
    }
}
