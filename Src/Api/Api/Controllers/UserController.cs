using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.DTOEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserDTO userDTO)
        {
            return Ok(_userService.CreateUser(userDTO));
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAll());
        }
    }
}