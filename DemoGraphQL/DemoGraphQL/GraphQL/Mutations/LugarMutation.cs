using System;
using DemoGraphQL.GraphQL.Services;
using DemoGraphQL.GraphQL.Types;
using DemoGraphQL.Models;
using GraphQL;
using GraphQL.Types;

namespace DemoGraphQL.GraphQL.Mutations
{
    /// <example>
    /// This is an example JSON request for a mutation
    /// {
    ///   "query": "mutation ($lugarmutation:InputLugaresType!){ createHuman(human: $lugarmutation) { id name } }",
    ///   "variables": {
    ///     "human": {
    ///       "name": "Boba Fett"
    ///     }
    ///   }
    /// }
    /// </example>
    public class LugarMutation : ObjectGraphType
    {
        public LugarMutation(LugarService lugarservice)
        {
            Name = "Mutation";

            Field<LugaresType>(
                "createLugar",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<InputLugaresType>> { Name = "lugarmutation" }
                ),
                resolve: context =>
                {
                    var lugar = context.GetArgument<Lugares>("lugarmutation");
                    return lugarservice.AddLugar(lugar);
                });
        }
    }
}
