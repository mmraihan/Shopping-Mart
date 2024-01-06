using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingMart.API.Dtos;
using ShoppingMart.API.Errors;
using ShoppingMart.Core.Entities.Identity;

namespace ShoppingMart.API.Controllers
{

    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {       
            _userManager = userManager;
            _signInManager = signInManager;
        }



        //[HttpPost("login")]
        //public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        //{
        //    var user = await _userManager.FindByEmailAsync(loginDto.Email);

        //    if (user == null) return Unauthorized(new ApiResponse(401));

        //    var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        //    if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

        //    return new UserDto
        //    {
        //        Email = loginDto.Email,
        //        Token="Dummy Token",
        //        DisplayName=user.DisplayName

        //    };


        //}

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            return new UserDto
            {
                Email = user.Email,
                Token = "Dummy Token",
                DisplayName = user.DisplayName
            };
        }



    }
}
