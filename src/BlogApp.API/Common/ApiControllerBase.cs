using BlogApp.Contract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Common
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        [NonAction]
        public IActionResult GenerateResponse(ResponseBase response)
        {
            return StatusCode(response.StatusCode, response);
        }
    }
}