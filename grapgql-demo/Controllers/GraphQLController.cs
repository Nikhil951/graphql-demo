using grapgql_demo.GraphqlCore;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace grapgql_demo.Controllers
{
    //[Route("api/[controller]")]
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly IDocumentWriter _documentWriter;
        private readonly ISchema _schema;
        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter, IDocumentWriter documentWriter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
            _documentWriter = documentWriter;
        }

        [HttpPost]
        public async Task PostAsync([FromBody] GraphqlQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }
            //var inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = query.Variables
            };

            var executionResult = await _documentExecuter.ExecuteAsync(executionOptions);


            await WriteResponseAsync(HttpContext, executionResult);
        }

        //[HttpGet]
        //public async Task GetAsync(string query)
        //{
        //    if (query == null) { throw new ArgumentNullException(nameof(query)); }
        //    //var inputs = query.Variables.ToInputs();
        //    var executionOptions = new ExecutionOptions
        //    {
        //        Schema = _schema,
        //        Query = query
        //    };

        //    var executionResult = await _documentExecuter.ExecuteAsync(executionOptions);


        //    await WriteResponseAsync(HttpContext, executionResult);
        //}

        private async Task WriteResponseAsync(HttpContext context, ExecutionResult result)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = result.Errors?.Any() == true ? (int)HttpStatusCode.BadRequest : (int)HttpStatusCode.OK;

            await _documentWriter.WriteAsync(context.Response.Body, result);
        }
    }
}
