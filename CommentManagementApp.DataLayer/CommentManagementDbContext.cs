using Microsoft.EntityFrameworkCore;
using CommentManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommentManagementApp.DataLayer
{
    public class CommentManagementAppDbContext : DbContext
    {
        public CommentManagementAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
    }

}