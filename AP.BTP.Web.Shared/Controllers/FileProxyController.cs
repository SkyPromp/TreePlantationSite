using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace AP.BTP.Web.Shared.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FileProxyController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FileProxyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetFile(string fileName)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("BTPApi");
                HttpResponseMessage response = await client.GetAsync($"File/{fileName}");

                Console.WriteLine(response.Content);

                if (response.IsSuccessStatusCode)
                {
                    byte[] bytes = await response.Content.ReadAsByteArrayAsync();
                    string contentType = response.Content.Headers.ContentType?.MediaType ?? "application/octet-stream";
                    
                    Response.Headers.Append("Content-Disposition", $"inline; filename=\"{fileName}\"");
                    
                    return File(bytes, contentType);
                }

                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}