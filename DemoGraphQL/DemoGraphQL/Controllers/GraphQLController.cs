using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoGraphQL.GraphQL;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoGraphQL.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _executer;

        public GraphQLController(ISchema schema,IDocumentExecuter executer)
        {
            _schema = schema;
            _executer = executer;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQueryDTO query)
        {
            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.Inputs = query.Variables?.ToInputs();

            });
            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }
            return Ok(result.Data);
        }
    }
}
