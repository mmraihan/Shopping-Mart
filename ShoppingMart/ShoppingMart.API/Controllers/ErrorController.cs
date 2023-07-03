
using Microsoft.AspNetCore.Mvc;
using ShoppingMart.API.Errors;

namespace ShoppingMart.API.Controllers
{
    [Route("errors/{code}")] // override
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
