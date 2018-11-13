using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.IO;

namespace TinyImage.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task Get(string token)
        {
            Response.ContentType = "image/jpeg";

            var url = "https://cdn-images-1.medium.com/max/1600/1*WgROsTKa6diRYTG5K0R5mw.jpeg";

            using (var client = new HttpClient())
            {
                var r = await client.GetByteArrayAsync(url);
                var provider = new SkiaSharpImageProcessingProvider();
                var image = new Image()
                {
                    data = r
                };

                image = provider.Resize(image);

                await Response.Body.WriteAsync(image.data);
            }

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
