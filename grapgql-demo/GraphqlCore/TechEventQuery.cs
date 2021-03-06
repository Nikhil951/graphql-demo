using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using grapgql_demo.Infrastructure.Repositories;
using GraphQL;
using GraphQL.Types;

namespace grapgql_demo.GraphqlCore
{
    public class TechEventQuery : ObjectGraphType<object>
    {
        public TechEventQuery(ITechEventRepository repository)
        {
            Name = "TechEventQuery";

            Field<TechEventInfoType>(
               "event",
               arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "eventId" }),
               resolve: context => repository.GetTechEventById(context.GetArgument<int>("eventId"))
            );

            Field<ListGraphType<TechEventInfoType>>(
             "events",
             resolve: context => repository.GetTechEvents()
          );
        }
    }
}
