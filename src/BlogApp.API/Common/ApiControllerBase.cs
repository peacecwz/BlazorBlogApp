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
            //TODO (peacecwz): Generate Response
            return Ok(response);
        }
    }
}
