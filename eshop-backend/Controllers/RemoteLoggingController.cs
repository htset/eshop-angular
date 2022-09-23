using eshop_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace eshop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoteLoggingController : ControllerBase
    {
        private readonly ILogger Logger;

        public RemoteLoggingController(ILogger<RemoteLoggingController> logger) : base()
        {
            Logger = logger;
        }

        [HttpPost]
        public void Post(LogMessage logMessage)
        {
            Logger.LogError("Remote message: {message}, " +
                "Stack trace: {stackTrace}", logMessage.Message, 
                logMessage.StackTrace);
        }
    }
}
