using System;
using DemoGraphQL.GraphQL.Services;
using DemoGraphQL.GraphQL.Types;
using GraphQL;
using GraphQL.Types;

namespace DemoGraphQL.GraphQL.Queries
{
    public class LugaresQuery : ObjectGraphType
    {
        public LugaresQuery(LugarService lugarservice)
        {
            int id = 0;
            Field<ListGraphType<LugaresType>>(
            name: "lugares",
            resolve: context =>
            {
                return lugarservice.GetAllLugares();
            });

            Field<LugaresType>(
                name: "lugar",
                arguments: new QueryArguments(new QueryArgument<IntGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    id = context.GetArgument<int>("id");
                    return lugarservice.GetLugarById(id);
                }
            );

        }
    }
}
