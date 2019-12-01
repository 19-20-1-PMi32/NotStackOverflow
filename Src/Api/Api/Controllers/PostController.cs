using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOEntities;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        public IActionResult CreatePost(CreatePostDTO postDTO)
        {
            return Ok(_postService.CreatePost(postDTO));
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            return Ok(_postService.GetPostById(id));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateText(int id, string text)
        {
            return Ok(_postService.UpdateText(id, text));
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeletePost(int id)
        {
            _postService.RemovePost(id);
            return Ok("Deleted");
        }

        [HttpGet("all/{page}")]
        public IActionResult GetAllPosts(int page)
        {
            return Ok(_postService.GetPostList(page));
        }

        [HttpGet("issue/{postId}/{page}")]
        public IActionResult GetPostWithComments(int postId, int page)
        {
            return Ok(_postService.GetPostsWithComments(postId, page));
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUsersPosts(int userId)
        {
            return Ok(_postService.GetUsersPostById(userId));
        }

        [HttpGet("like")]
        public IActionResult GetList(LikeDTO like)
        {
            return Ok(_postService.SetLike(like));
        }
    }
}