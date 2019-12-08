using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using BLL;
using BLL.DTOEntities;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public AccountController(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

      

        [HttpPost("token")]
        public async Task Token()
        { 
            var email = Request.Form["email"];
            var password = Request.Form["password"];

            var jwtToken = _accountService.Authenticate(email, password);

            Response.ContentType = "application/json";

            await Response.WriteAsync(jwtToken);

        }

        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody]JObject data)
        {
            var token = data["token"].ToString();
            var refreshToken = data["refreshToken"].ToString();

            return Ok(_accountService.RefreshToken(token, refreshToken));
        }
    }
}