using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BuckleUp.Interface.Service;
using BuckleUp.Models.Entities;
using BuckleUp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuckleUp.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly IQuizService _quizService;
        public StudentController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Quizzes()
        {
            Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            List<Quiz> quizzes = _quizService.GetAllGuizByCreatorId(studentId);

            MyQuizzesVM myQuizzesVM =  new MyQuizzesVM{
                Quizzes = quizzes
            };

            return View(myQuizzesVM);
        }

        public IActionResult Teachers()
        {
            return View();
        }

    }
}