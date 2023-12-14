using Microsoft.EntityFrameworkCore;
using CommentManagementApp.BusinessLayer.ViewModels;
using CommentManagementApp.DataLayer;
using CommentManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CommentManagementApp.BusinessLayer.Services.Repository
{
    public class CommentManagementRepository : ICommentManagementRepository
    {
        private readonly CommentManagementAppDbContext _dbContext;
        public CommentManagementRepository(CommentManagementAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> CreateComment(Comment CommentModel)
        {
            try
            {
                var result = await _dbContext.Comments.AddAsync(CommentModel);
                await _dbContext.SaveChangesAsync();
                return CommentModel;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteCommentById(long id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Comments.Single(a => a.CommentId== id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Comment> GetAllComments()
        {
            try
            {
                var result = _dbContext.Comments.
                OrderByDescending(x => x.CommentId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Comment> GetCommentById(long id)
        {
            try
            {
                return await _dbContext.Comments.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       
        public async Task<Comment> UpdateComment(CommentViewModel model)
        {
            var Comment = await _dbContext.Comments.FindAsync(model.CommentId);
            try
            {

                _dbContext.Comments.Update(Comment);
                await _dbContext.SaveChangesAsync();
                return Comment;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}