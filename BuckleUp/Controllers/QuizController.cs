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
        private readonly IStudentService _studentService;
        public QuizController(IQuizService quizService, IStudentService studentService)
        {
            _studentService = studentService;
            _quizService = quizService;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(string id)
        {
            Quiz quiz = _quizService.GetByLink(id);
            RegisterQuizVM registerQuizVM = new RegisterQuizVM();

            if (quiz != null)
            {
                string creatorName = string.Empty;

                switch (quiz.CreatorRole)
                {
                    case "Student":
                       
                        Student student = _studentService.FindById(quiz.CreatorId);
                        if(User.Identity.IsAuthenticated && (User.IsInRole("Student"))){
                              Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                              if(student.Id.Equals(studentId)) return RedirectToAction(nameof(Room), new { id = id });
                        }
                        creatorName = $"{student.FirstName} {student.LastName}";
                        break;
                }

                registerQuizVM.CreatorName = creatorName;
            }
            return View(registerQuizVM);
        }

        [HttpPost]
        public IActionResult Register(string id, RegisterQuizVM viewModel)
        {
            string playerUsername = string.Empty;


            if (User.Identity.IsAuthenticated && (User.IsInRole("Student")))
            {
                if (viewModel.UseLoggedInUserName)
                {
                    Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

                    Student student = _studentService.FindById(studentId);
                    playerUsername = $"{student.FirstName} {student.LastName.Substring(0, 1)}.";
                }
                else
                {
                    playerUsername = viewModel.PlayerUsername;
                }
            }
            else
            {
                playerUsername = viewModel.PlayerUsername;
            }

            Quiz quiz = _quizService.GetQuizWithPlayersByLink(id);

            bool isUniquePlayerName = quiz.QuizPlayers.FirstOrDefault(qp => qp.Player.Name.Equals(playerUsername)) == null;

            if (!isUniquePlayerName)
            {
                switch (quiz.CreatorRole)
                {
                    case "Student":
                        Student student = _studentService.FindById(quiz.CreatorId);
                        viewModel.CreatorName = $"{student.FirstName} {student.LastName}";
                        break;
                }
                ViewBag.Message = "Player With the same name already exist fir this quiz. Please choose another name";
                return View(viewModel);
            }

            Player player = new Player
            {
                Id = Guid.NewGuid(),
                Name = playerUsername
            };

            _quizService.AddPlayerToQuiz(id, player);

            HttpContext.Response.Cookies.Append("drx1e", player.Id.ToString());



            return RedirectToAction(nameof(Room), new { id = id });
        }

        [HttpGet]
        public IActionResult Room(string id)
        {

           Guid playerId = Guid.Empty;

            Quiz quiz = _quizService.GetQuizWithPlayersByLink(id);

            if (quiz == null) return RedirectToAction(nameof(Index));

            if (User.Identity.IsAuthenticated && User.IsInRole("Student"))
            {

                switch (quiz.CreatorRole)
                {
                    case "Student":
                     Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                        Student student = _studentService.FindById(studentId);
                        if (student.Id.Equals(quiz.CreatorId))
                        {
                            QuizRoomVM roomVM = new QuizRoomVM
                            {
                                Players = quiz.QuizPlayers,
                                IsQuizCreator = true
                            };
                            
                            return View(roomVM);
                        }

                    break;
                }

            }

            string playerIdString = HttpContext.Request.Cookies["drx1e"];

            if (playerIdString == null) return RedirectToAction(nameof(Index));

            try { Guid.TryParse(playerIdString, out playerId); }
            catch (FormatException) { return RedirectToAction(nameof(Index)); }



            QuizPlayer player = quiz.QuizPlayers.FirstOrDefault(qp => qp.PlayerId.Equals(playerId));

            if (player == null) return RedirectToAction(nameof(Index));


            QuizRoomVM quizRoomVM = new QuizRoomVM
            {
                PlayerUsername = player.Player.Name,
                Players = quiz.QuizPlayers
            };

            return View(quizRoomVM);
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
            string creatorRole = string.Empty;

            if (User.IsInRole("Student"))
            {
                creatorId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                creatorRole = "Student";
            }

            if (Request.Form["submitbtn"].Equals("Add New Question"))
            {

                viewModel.NumberOfQuestions = viewModel.Questions.Length + 1;
                return View(viewModel);

            }

            else if (Request.Form["submitbtn"].Equals("Create"))
            {
                _quizService.Create(creatorId, creatorRole, viewModel.Questions.ToList());

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