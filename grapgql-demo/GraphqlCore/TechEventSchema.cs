using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grapgql_demo.GraphqlCore
{
    public class TechEventSchema : Schema
    {
        //public TechEventSchema(IDependencyResolver resolver)
        public TechEventSchema(IServiceProvider serviceProvider): base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<TechEventQuery>();

            //Query = resolver.Resolve<TechEventQuery>();
            //DependencyResolver = resolver;
        }
    }
}
