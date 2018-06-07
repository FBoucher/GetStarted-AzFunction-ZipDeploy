using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GenFu;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace AzFunctionZipDeploy
{
    public static class Function1
    {
        [FunctionName("GetTopRunner")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string top = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "top", true) == 0)
                .Value;

            if (top == null)
            {
                dynamic data = await req.Content.ReadAsAsync<object>();
                top = data?.top;
            }

        return top == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a number to get your top x runner on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK, new { message = $"Hello, here is your Top {top} runners", runners = A.ListOf<Person>(int.Parse(top)) });
        }
    }


    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
