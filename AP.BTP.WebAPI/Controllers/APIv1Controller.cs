using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class APIv1Controller : ControllerBase
    {
    }
}
