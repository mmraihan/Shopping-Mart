using Microsoft.AspNetCore.Mvc;
using ShoppingMart.API.Errors;

namespace ShoppingMart.API.Controllers
{
    // override
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)] //- ignore a controller when generating API documentation
    public class ErrorController : BaseApiController
    {
        
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
