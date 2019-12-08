using Api.Filters;
using BLL.DTOEntities;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionFilter]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(CreateUserDTO userDTO)
        {
            _userService.CreateUser(userDTO);
            return Ok();
        }

        [HttpGet("info/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateUserDto userDto)
        {
            _userService.UpdateUser(userDto);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAll());
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult SetAdmin()
        {
            return Ok();
        }
    }
}