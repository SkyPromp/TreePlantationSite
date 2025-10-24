using Microsoft.AspNetCore.Mvc;
using MediatR;
using AP.BTP.Application.CQRS.PlantationSite;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace AP.BTP.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FileController: APIv1Controller
    {
        private readonly string mediaPath;

        public FileController(IWebHostEnvironment env)
        {
            mediaPath = Path.Combine(env.ContentRootPath, "media");

            if (!Directory.Exists(mediaPath))
                Directory.CreateDirectory(mediaPath); 
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string filePath = Path.Combine(mediaPath, fileName);

            await using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok(new { fileName });
        }
        
        [HttpGet("{fileName}")]
        public IActionResult Get(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return BadRequest("Filename is required.");

            string filePath = Path.Combine(mediaPath, fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            string contentType = GetContentType(filePath);

            return PhysicalFile(filePath, contentType);
        }

        private static string GetContentType(string path)
        {
            var ext = Path.GetExtension(path).ToLowerInvariant();

            return ext switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                ".svg" => "image/svg+xml",
                _ => "application/octet-stream"
            };
        }
    }        
}
