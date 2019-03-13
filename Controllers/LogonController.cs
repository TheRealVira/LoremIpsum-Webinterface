using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LoremIpsum.Controllers
{
    [Route("interface/logon")]
    [ApiController]
    public class LogonController : ControllerBase
    {
        private HttpClient Client { get; }

        public LogonController()
        {
            Client = new HttpClient();
        }

        [HttpGet("{username}/{password}")]
        [ActionName("GetLoremIpsumText")]
        public Task<string> GetLoremIpsumText(string username, string password)
        {
            var url = "temp/api/logon/" +
                      username + "/" + password;

            //var content = JsonConvert.SerializeObject(new MyToken()
            //{
            //    AccessToken = "denied",
            //    ExpiresIn = 0
            //});

            //try
            //{
            //    content = await Client.GetStringAsync(url);
            //}
            //catch
            //{
            //    // ignored
            //}

            //return JsonConvert.DeserializeObject<MyToken>(content).AccessToken;
            return null;
        }
    }
}