using System;
namespace DemoGraphQL.GraphQL
{
    public class GraphQLQueryDTO
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public Newtonsoft.Json.Linq.JObject Variables { get; set; }
    }
  
}
