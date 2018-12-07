using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinyImage.Web.Models;
using TinyImage.Web.Providers;

namespace TinyImage.Web.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        // POST api/values
        [HttpPost]
        [ProducesResponseType(statusCode: 200, type: typeof(ImageRegistrationResponse))]
        public async Task<IActionResult> Post([FromBody]ImageRegistration registration)
        {

            using (var client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(registration.Url);
                var provider = new SkiaSharpImageProcessingProvider();
                var image = provider.Resize(bytes);
             

                var result = new ImageRegistrationResponse()
                {
                    CustomData = registration.CustomData,
                    Token = "Mats är en gök",
                    Url = "/abc/123.jpg"
                };

                return Ok(result);
            }
        }
    }
}
