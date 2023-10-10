using AutoMapper;

using GameDatabase.API.AuthEndpoints.Payloads;
using GameDatabase.Core.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Reflection.Metadata.Ecma335;

namespace GameDatabase.API.AuthEndpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signup")]
        public async Task<IResult> Signup(SignupRequest input)
        {
            var signupResult = await _authService.SignupUser(input.Email, input.Password, input.UserName);
            if (signupResult != null)
            {
                return Results.Ok(_mapper.Map<SignupResponse>(signupResult));
            }
            return Results.Ok("User or password does not match");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public async Task<IResult> Signin(AuthRequest input)
        {
            var tokenResult = await _authService.AuthenticateUser(input.Email, input.Password);
            if (tokenResult == null)
            {
                return Results.Unauthorized();
            }
            return Results.Ok(new AuthResponse(tokenResult));
        }
    }
}
