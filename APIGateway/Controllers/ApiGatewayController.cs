using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIGateway.Controllers
{
    [ApiController]
    [Route("ApiGateway")]
    public class ApiGatewayController : ControllerBase
    {
        [HttpGet]
        [Route("demo")]
        public async Task<string> GetHelloMessage()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://birthmicroservice:80/weatherforecast");
            var message = await response.Content.ReadAsStringAsync();
            return message;
        }

        [HttpGet]
        [Route("test")]
        public async Task<string> Test()
        {
            
            return "OK";
        }
    }
}
