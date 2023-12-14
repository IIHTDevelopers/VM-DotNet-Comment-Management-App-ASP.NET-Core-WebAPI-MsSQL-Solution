

using Moq;
using CommentManagementApp.BusinessLayer.Services.Repository;
using CommentManagementApp.BusinessLayer.Services;
using CommentManagementApp.BusinessLayer.ViewModels;
using CommentManagementApp.DataLayer;
using CommentManagementApp.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using CommentManagementApp.BusinessLayer.Interfaces;

namespace CommentManagementApp.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly CommentManagementAppDbContext _dbContext;

        private readonly ICommentManagementService  _commentService;
        public readonly Mock<ICommentManagementRepository> commentservice = new Mock<ICommentManagementRepository>();

        private readonly Comment _comment;
            
        private readonly CommentViewModel _commentViewModel;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_Validate_ifInvalidCommentIdIsPassed()
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
                if (result != null || result.CommentId !=0)
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
        public async Task<bool> Testfor_Validate_ifInvalidCommentRatingIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                commentservice.Setup(repo => repo.CreateComment(_comment)).ReturnsAsync(_comment);
                var result = await _commentService.CreateComment(_comment);
                if (result != null || result.Rating != 0)
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