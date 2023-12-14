using CommentManagementApp.BusinessLayer.ViewModels;
using CommentManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommentManagementApp.BusinessLayer.Interfaces
{
    public interface ICommentManagementService
    {
        List<Comment> GetAllComments();
        Task<Comment> CreateComment(Comment comment);
        Task<Comment> GetCommentById(long id);
        Task<bool> DeleteCommentById(long id);
        Task<Comment> UpdateComment(CommentViewModel model);
    }
}
