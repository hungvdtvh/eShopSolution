using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.System.Users;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authencate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authencate([FromForm]LoginRequest request)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _userService.Authencate(request);
            if (!string.IsNullOrEmpty(result))
                return Ok(new { token= result});
            else return BadRequest(ModelState);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] RegisterRequest request)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _userService.Register(request);
            if (result)
                return Ok();
            else return BadRequest(ModelState);
        }
    }
}
