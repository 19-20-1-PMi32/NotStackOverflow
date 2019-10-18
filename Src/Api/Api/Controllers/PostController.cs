using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOEntities;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("create")]
        public IActionResult CreatePost(PostDTO postDTO)
        {
            return Ok(_postService.CreatePost(postDTO));
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            return Ok(_postService.GetPostById(id));
        }

        [HttpGet("all")]
        public IActionResult GetAllPosts()
        {
            return Ok(_postService.GetPostList());
        }

        [HttpGet("issue/{postId}")]
        public IActionResult GetPostWithComments(int postId)
        {
            return Ok(_postService.GetPostsWithComments(postId));
        }
    }
}