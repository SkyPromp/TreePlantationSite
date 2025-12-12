using Moq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AP.BTP.WebAPI.Controllers;
using Microsoft.AspNetCore.Hosting;

namespace AP.BTP.Unittests.File
{
    [TestClass]
    public class FileControllerTests
    {
        [TestMethod]
        public async Task Upload_Should_Return_415_When_Invalid_FileType()
        {
            var envMock = new Mock<IWebHostEnvironment>();

            envMock.Setup(e => e.ContentRootPath).Returns(Path.GetTempPath());

            var controller = new FileController(envMock.Object);
            var fileMock = new Mock<IFormFile>();
            var content = "fake data";
            var fileName = "malware.exe";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            fileMock.Setup(f => f.OpenReadStream()).Returns(stream);
            fileMock.Setup(f => f.Length).Returns(stream.Length);
            fileMock.Setup(f => f.FileName).Returns(fileName);
            fileMock.Setup(f => f.ContentType).Returns("application/octet-stream");

            var result = (await controller.Upload(fileMock.Object)) as StatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status415UnsupportedMediaType, result.StatusCode);
        }

        [TestMethod]
        public async Task Upload_Should_Return_ok_When_Invalid_FileType()
        {
            var envMock = new Mock<IWebHostEnvironment>();

            envMock.Setup(e => e.ContentRootPath).Returns(Path.GetTempPath());

            var controller = new FileController(envMock.Object);
            var fileMock = new Mock<IFormFile>();
            var content = "fake data";
            var fileName = "malware.png";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            fileMock.Setup(f => f.OpenReadStream()).Returns(stream);
            fileMock.Setup(f => f.Length).Returns(stream.Length);
            fileMock.Setup(f => f.FileName).Returns(fileName);
            fileMock.Setup(f => f.ContentType).Returns("image/png");

            var result = (await controller.Upload(fileMock.Object)) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        }
    }
}
