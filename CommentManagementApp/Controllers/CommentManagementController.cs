using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommentManagementApp.BusinessLayer.Interfaces;
using CommentManagementApp.BusinessLayer.ViewModels;
using CommentManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementApp.Entities;

namespace CommentManagementApp.Controllers
{
    [ApiController]
    public class CommentManagementController : ControllerBase
    {
        private readonly ICommentManagementService  _commentService;
        public CommentManagementController(ICommentManagementService commentservice)
        {
             _commentService = commentservice;
        }

        [HttpPost]
        [Route("create-comment")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateComment([FromBody] Comment model)
        {
            var CommentExists = await  _commentService.GetCommentById(model.CommentId);
            if (CommentExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Comment already exists!" });
            var result = await  _commentService.CreateComment(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Comment creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Comment created successfully!" });

        }


        [HttpPut]
        [Route("update-comment")]
        public async Task<IActionResult> UpdateComment([FromBody] CommentViewModel model)
        {
            var Comment = await  _commentService.UpdateComment(model);
            if (Comment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Comment With Id = {model.CommentId} cannot be found" });
            }
            else
            {
                var result = await  _commentService.UpdateComment(model);
                return Ok(new Response { Status = "Success", Message = "Comment updated successfully!" });
            }
        }

      
        [HttpDelete]
        [Route("delete-comment")]
        public async Task<IActionResult> DeleteComment(long id)
        {
            var Comment = await  _commentService.GetCommentById(id);
            if (Comment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Comment With Id = {id} cannot be found" });
            }
            else
            {
                var result = await  _commentService.DeleteCommentById(id);
                return Ok(new Response { Status = "Success", Message = "Comment deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-comment-by-id")]
        public async Task<IActionResult> GetCommentById(long id)
        {
            var Comment = await  _commentService.GetCommentById(id);
            if (Comment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Comment With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(Comment);
            }
        }

        [HttpGet]
        [Route("get-all-comments")]
        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return   _commentService.GetAllComments();
        }
    }
}
