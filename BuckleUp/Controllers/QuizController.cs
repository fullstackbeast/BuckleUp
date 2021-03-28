using System;
using System.Linq;
using System.Security.Claims;
using BuckleUp.Interface.Service;
using BuckleUp.Models.Entities;
using BuckleUp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuckleUp.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizService _quizService;
        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register(string id)
        {
            ViewBag.Message = id;
            return View();
        }
        public IActionResult Room(string id)
        {
            ViewBag.Message = id;
            return View();
        }
        public IActionResult Play(string id)
        {
            ViewBag.Message = id;
            return View();
        }
        public IActionResult Create()
        {

            CreateQuizVM viewModel = new CreateQuizVM
            {
                NumberOfQuestions = 3,
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public IActionResult Create(CreateQuizVM viewModel)
        {

            Guid creatorId = Guid.Empty;

            if (User.IsInRole("Student"))
            {
                creatorId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            }

            if (Request.Form["submitbtn"].Equals("Add New Question"))
            {

                viewModel.NumberOfQuestions = viewModel.Questions.Length + 1;
                return View(viewModel);

            }

            else if (Request.Form["submitbtn"].Equals("Create"))
            {
                _quizService.Create(creatorId, viewModel.Questions.ToList());

                return View(viewModel);
            }

            else if (Request.Form["submitbtn"].Equals("Remove A Question"))
            {

                QuizQuestion[] newQuestions = new QuizQuestion[viewModel.Questions.Length - 1];

                for (int q = 0; q < viewModel.Questions.Length - 1; q++)
                {

                    newQuestions[q] = viewModel.Questions[q];
                }


                viewModel.Questions = newQuestions;
                viewModel.NumberOfQuestions = newQuestions.Length;

                return View(viewModel);
            }



            return View(viewModel);
        }
    }
}