using BlogApp.Contract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogApp.API.Common
{
    public class ApiControllerBase : ControllerBase
    {
        [NonAction]
        public IActionResult GenerateResponse<T>(T response) where T : ResponseBase
        {
            var result = Content(JsonConvert.SerializeObject(response), "application/json");
            result.StatusCode = response.StatusCode;
            return result;
        }
    }
}