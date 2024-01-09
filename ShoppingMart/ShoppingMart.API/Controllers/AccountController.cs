using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingMart.API.Dtos;
using ShoppingMart.API.Errors;
using ShoppingMart.Core.Entities.Identity;
using ShoppingMart.Core.Interfaces;
using System.Security.Claims;

namespace ShoppingMart.API.Controllers
{

    public class AccountController : BaseApiController
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(email);

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }


        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<Address>> GetUserAddress()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(email);

            return user.Address;

        }



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
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }


        [HttpPost("register")]

        public async Task<ActionResult<UserDto>> Register( RegisterDto registerDto)
        {
            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName= registerDto.Email,
                
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return new UserDto
            {
                DisplayName=user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Email = user.Email,
            };


        }


    }
}
