
using Moq;
using CommentManagementApp.BusinessLayer.Interfaces;
using CommentManagementApp.BusinessLayer.Services.Repository;
using CommentManagementApp.BusinessLayer.Services;
using CommentManagementApp.BusinessLayer.ViewModels;
using CommentManagementApp.DataLayer;
using CommentManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CommentManagementApp.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly CommentManagementAppDbContext _dbContext;

        private readonly ICommentManagementService  _commentService;
        public readonly Mock<ICommentManagementRepository> commentservice = new Mock<ICommentManagementRepository>();

        private readonly Comment _comment;
        private readonly CommentViewModel _commentViewModel;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
        {
             _commentService = new CommentManagementService(commentservice.Object);

            _output = output;

            _comment = new Comment
            {
                CommentId = 1,
                CommentText = "Comment",
                SubmissionDate = DateTime.Now,
                Rating = 2,
                UserId = 1
            };

            _commentViewModel = new CommentViewModel
            {
                CommentId = 1,
                CommentText = "Comment",
                SubmissionDate = DateTime.Now,
                Rating = 2,
                UserId = 1
            };
        }
        
        [Fact]
        public async Task<bool> Testfor_Comment_Comment_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                commentservice.Setup(repo => repo.CreateComment(_comment)).ReturnsAsync(_comment);
                var result = await  _commentService.CreateComment(_comment);
                var actualLength = _comment.CommentText.ToString().Length;
                if (result.CommentText.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

       
        [Fact]
        public async Task<bool> Testfor_Comment_Rating_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                commentservice.Setup(repo => repo.CreateComment(_comment)).ReturnsAsync(_comment);
                var result = await  _commentService.CreateComment(_comment);
                var actualLength = _comment.Rating.ToString().Length;
                if (result.Rating.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Comment_Date_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                commentservice.Setup(repo => repo.CreateComment(_comment)).ReturnsAsync(_comment);
                var result = await  _commentService.CreateComment(_comment);
                var actualLength = _comment.SubmissionDate.ToString().Length;
                if (result.SubmissionDate.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_CommentId_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                commentservice.Setup(repo => repo.CreateComment(_comment)).ReturnsAsync(_comment);
                var result = await  _commentService.CreateComment(_comment);
                var actualLength = _comment.CommentId.ToString().Length;
                if (result.CommentId.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


    }
}