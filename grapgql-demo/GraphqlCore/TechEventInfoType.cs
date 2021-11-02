using grapgql_demo.Infrastructure.DBContext;
using grapgql_demo.Infrastructure.Repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grapgql_demo.GraphqlCore
{
    public class TechEventInfoType : ObjectGraphType<TechEventInfo>
    {
        public TechEventInfoType(ITechEventRepository repository)
        {
            Field(x => x.EventId).Description("Event id.");
            Field(x => x.EventName).Description("Event name.");
            Field(x => x.Speaker).Description("Speaker name.");
            Field(x => x.EventDate, nullable: true).Description("Event date.");

            Field<ListGraphType<ParticipantType>>(
              "participants",
              arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "eventId" }),
              resolve: context => repository.GetParticipantInfoByEventId(context.Source.EventId)
           );
        }
    }
}
