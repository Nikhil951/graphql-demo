using grapgql_demo.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grapgql_demo.Infrastructure.Repositories
{
    public interface ITechEventRepository
    {
        Task<TechEventInfo[]> GetTechEvents();
        Task<TechEventInfo> GetTechEventById(int id);
        Task<List<Participant>> GetParticipantInfoByEventId(int id);
    }
}
