using System;
using System.Collections.Generic;
using System.Text;

namespace CommentManagementApp.BusinessLayer.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; }
        public int Rating { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
