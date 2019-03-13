using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LoremIpsum.Controllers
{
    [ApiController]
    [Route("interface/lipsum_generator")]
    public class LoremIpsumController : ControllerBase
    {
        private HttpClient Client { get; }

        public LoremIpsumController()
        {
            Client = new HttpClient();
        }

        [HttpGet("{generatorType}/{count}/{length}")]
        [ActionName("GetLoremIpsumText")]
        public async Task<IEnumerable<string>> GetLoremIpsumText(string generatorType, int count, int length)
        {
            var url = "https://lipsumapi.azurewebsites.net/api/lipsum_generator/" +
                      generatorType + "/" + count + "/" + length;

            var content = string.Empty;

            try
            {
                var response = await Client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content
                        .ReadAsAsync<string>();
                }
                else
                {
                    content = JsonConvert.SerializeObject(new List<string>()
                        {"The required service currently seems to be down."});
                }   
            }
            catch
            {
                // ignored
            }

            var test =  JsonConvert.DeserializeObject<IEnumerable<string>>(content);

            return test;
        }
    }
}
