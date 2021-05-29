using System;
using DemoGraphQL.GraphQL.Mutations;
using DemoGraphQL.GraphQL.Queries;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace DemoGraphQL.GraphQL.SchemasGraph
{
    public class GraphQLDemoSchema: Schema, ISchema
    {
        public GraphQLDemoSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<LugaresQuery>();
            Mutation = provider.GetRequiredService<LugarMutation>();
        }
    }
}
