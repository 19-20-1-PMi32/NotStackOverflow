using System.Net;
using Api.Filters;
using BLL.DTOEntities;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionFilter]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("create")]
        public IActionResult CreateComment(CommentDTO comment)
        {
            return Ok(_commentService.CreateComment(comment));
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateComment(int id, [FromBody]string text)
        {
            return Ok(_commentService.UpdateComment(id, text));
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteComment(int id)
        {
            _commentService.RemoveComment(id);
            return Ok();
        }

        [HttpDelete("delete/{id}/{userId}")]
        public IActionResult DeleteComment(int id, int userId)
        {
            _commentService.RemoveComment(id, userId);
            return Ok();
        }
    }
}