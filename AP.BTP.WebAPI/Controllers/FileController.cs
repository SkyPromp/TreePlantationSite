using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    /// <summary>
    /// Controller for handling file operations such as uploading and retrieving files.
    /// </summary>
    /// <remarks>
    /// Provides endpoints under "api/v1/file" for managing files in the "media" directory.
    /// Inherits from <see cref="APIv1Controller"/>.
    /// </remarks>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FileController: APIv1Controller
    {
        private readonly string mediaPath;

        /// <summary>
        /// The allowed filetypes that can be uploaded.
        /// </summary>
        readonly string[] allowedFileTypes = {
            "image/jpeg",
            "image/png",
            "image/webp",
            "image/bmp",
            "application/pdf"
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="FileController"/> class.
        /// Ensures that the media folder exists.
        /// </summary>
        /// <param name="env">The hosting environment used to determine the content root path.</param>
        public FileController(IWebHostEnvironment env)
        {
            mediaPath = Path.Combine(env.ContentRootPath, "media");

            if (!Directory.Exists(mediaPath)) Directory.CreateDirectory(mediaPath); 
        }

        /// <summary>
        /// Uploads a file to the server.
        /// </summary>
        /// <param name="file">The file to upload.</param>
        /// <returns>
        /// Returns <see cref="BadRequestObjectResult"/> if the file is null or empty, 
        /// or <see cref="OkObjectResult"/> containing the generated file name on success.
        /// </returns>
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)  // TODO move to CQRS
        {
            if (file == null || file.Length == 0) return BadRequest("No file uploaded");

            if (!this.allowedFileTypes.Contains(file.ContentType)) return StatusCode(StatusCodes.Status415UnsupportedMediaType);

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string filePath = Path.Combine(mediaPath, fileName);

            await using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { fileName });
        }

        /// <summary>
        /// Retrieves a file from the server by its file name.
        /// </summary>
        /// <param name="fileName">The name of the file to retrieve.</param>
        /// <returns>
        /// Returns <see cref="BadRequestObjectResult"/> if the file name is empty,
        /// <see cref="NotFoundResult"/> if the file does not exist, 
        /// or <see cref="PhysicalFileResult"/> containing the file contents on success.
        /// </returns>
        [HttpGet("{fileName}")]
        public IActionResult Get(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return BadRequest("Filename is required.");

            string filePath = Path.Combine(mediaPath, fileName);

            if (!System.IO.File.Exists(filePath)) return NotFound();

            string contentType = GetContentType(filePath);

            return PhysicalFile(filePath, contentType);
        }

        /// <summary>
        /// Determines the MIME content type of a file based on its extension.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <returns>The MIME type as a string.</returns>
        private static string GetContentType(string path)
        {
            string ext = Path.GetExtension(path).ToLowerInvariant();

            return ext switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                ".svg" => "image/svg+xml",
                ".pdf" => "application/pdf",
                _ => "application/octet-stream"
            };
        }
    }        
}
