using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace AP.BTP.Web.Shared.Controllers
{
    /// <summary>
    /// Controller that acts as a proxy for retrieving files from the backend API.
    /// </summary>
    /// <remarks>
    /// This controller provides a secure way to access files stored in the backend API
    /// without exposing the internal API URL to client applications. It handles authentication,
    /// fetches files from the API, and streams them to the client with appropriate headers
    /// for inline viewing (e.g., PDFs, images).
    /// </remarks>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FileProxyController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileProxyController"/> class.
        /// </summary>
        /// <param name="httpClientFactory">Factory for creating HTTP clients to communicate with the backend API.</param>
        public FileProxyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        /// <summary>
        /// Retrieves a file from the backend API and streams it to the client.
        /// </summary>
        /// <param name="fileName">The name of the file to retrieve (including extension).</param>
        /// <returns>
        /// Returns <see cref="FileResult"/> with the file content if successful,
        /// <see cref="NotFoundResult"/> if the file doesn't exist,
        /// or <see cref="StatusCodeResult"/> with status 500 if an error occurs.
        /// </returns>
        /// <remarks>
        /// This endpoint fetches files from the backend API's File controller and serves them
        /// with a Content-Disposition header set to "inline" for browser viewing.
        /// Requires user authentication via the [Authorize] attribute.
        /// </remarks>
        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetFile(string fileName)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("BTPApi");
                HttpResponseMessage response = await client.GetAsync($"File/{fileName}");

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