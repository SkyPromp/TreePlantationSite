using Microsoft.AspNetCore.Mvc;

namespace AP.BTP.WebAPI.Controllers
{
    /// <summary>
    /// Base controller for version 1 of the API (v1).
    /// </summary>
    /// <remarks>
    /// All API v1 controllers should inherit from this class. 
    /// It sets the route prefix to "api/v1/[controller]" and applies
    /// the <see cref="ApiControllerAttribute"/> for automatic model validation and other conventions.
    /// </remarks>
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class APIv1Controller : ControllerBase
    {
    }
}
