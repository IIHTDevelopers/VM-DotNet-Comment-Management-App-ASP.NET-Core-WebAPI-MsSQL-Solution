using CommentManagementApp.BusinessLayer.Interfaces;
using CommentManagementApp.BusinessLayer.Services.Repository;
using CommentManagementApp.BusinessLayer.ViewModels;
using CommentManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommentManagementApp.BusinessLayer.Services
{
    public class CommentManagementService : ICommentManagementService
    {
        private readonly ICommentManagementRepository _repo;

        public CommentManagementService(ICommentManagementRepository repo)
        {
            _repo = repo;
        }

        public async Task<Comment> CreateComment(Comment employeeComment)
        {
            return await _repo.CreateComment(employeeComment);
        }

        public async Task<bool> DeleteCommentById(long id)
        {
            return await _repo.DeleteCommentById(id);
        }

        public List<Comment> GetAllComments()
        {
            return  _repo.GetAllComments();
        }

        public async Task<Comment> GetCommentById(long id)
        {
            return await _repo.GetCommentById(id);
        }

        public async Task<Comment> UpdateComment(CommentViewModel model)
        {
           return await _repo.UpdateComment(model);
        }
    }
}
