using BLL.DTOEntities;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult DeleteComment(int id)
        {
            _commentService.RemoveComment(id);
            return Ok();
        }
    }
}