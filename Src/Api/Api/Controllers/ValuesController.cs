using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Authorize]
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

        [Authorize(Roles = "Admin")]
        [Route("getrole")]
        public IActionResult GetRole()
        {
            return Ok("Ваша роль: администратор");
        }
    }
}
