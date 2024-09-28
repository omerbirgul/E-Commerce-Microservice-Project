using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Dtos.UserCommentDtos;
using MultiShop.Comment.Entities;
using MultiShop.Comment.Services.CommentServices;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public  async Task<IActionResult> GetAllComments()
        {
            var value = await _commentService.UserCommentListAsync();
            return Ok(value);
        }

        [HttpGet("GetCommentByProductId/{id}")]
        public async Task<IActionResult> GetCommentByProductId(string id)
        {
            var values = await _commentService.GetUserCommentByProductIdAsync(id);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var value = await _commentService.GetCommentByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public  async Task<IActionResult> CreateComments(CreateUserCommentDto createUserCommentDto)
        {
            await _commentService.CreateUserCommentAsync(createUserCommentDto);
            return Ok("Comment created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateUserCommentDto updateUserCommentDto)
        {
            await _commentService.UpdateUserCommentAsync(updateUserCommentDto);
            return Ok("Comment updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteUserCommentAsync(id);
            return Ok("Comment deleted successfully");
        }
    }
}
