using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BuckleUp.Interface.Service;
using BuckleUp.Models.Entities;
using BuckleUp.Models.ViewModels;
using BuckleUp.signalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BuckleUp.Controllers
{
    public class QuizController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IHubContext<QuizHub> _hubContext;
        private readonly IQuizService _quizService;
        private readonly IUserService _userService;
        public QuizController(IUserService userService, IStudentService studentService, IQuizService quizService, IHubContext<QuizHub> hubContext)
        {
            _userService = userService;
            _quizService = quizService;
            _hubContext = hubContext;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string id)
        {
            Quiz quiz = _quizService.GetByLink(id);
            if(quiz == null){
                ViewBag.ErroMessage = "Quiz not found";
                return View();
            }

            return RedirectToAction(nameof(Register), new{ id = id});
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

                        User studentUser = _userService.FindById(quiz.UserId);
                        if (User.Identity.IsAuthenticated && (User.IsInRole("Student")))
                        {
                            Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                            if (studentUser.Id.Equals(studentId)) return RedirectToAction(nameof(Room), new { id = id });
                        }
                        creatorName = $"{studentUser.FirstName} {studentUser.LastName}";
                        break;
                }

                registerQuizVM.CreatorName = creatorName;
                return View(registerQuizVM);
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

                    User studentUser = _userService.FindById(studentId);
                    playerUsername = $"{studentUser.FirstName} {studentUser.LastName.Substring(0, 1)}.";
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
                        User studentUser = _userService.FindById(quiz.UserId);
                        viewModel.CreatorName = $"{studentUser.FirstName} {studentUser.LastName}";
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
        public async Task<IActionResult> Room(string id)
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
                        User user = _userService.FindById(studentId);

                        if (user.Id.Equals(quiz.UserId))
                        {
                            QuizRoomVM roomVM = new QuizRoomVM
                            {
                                Players = quiz.QuizPlayers,
                                IsQuizCreator = true,
                                Quiz = quiz,
                                CreatorName = user.FirstName
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
                Players = quiz.QuizPlayers,
                Quiz = quiz,
                PlayerHasPlayed = player.HasPlayed,
                PlayerScore = player.Score,
                FinishedPlayers = quiz.QuizPlayers.Where(qp => qp.HasPlayed).ToList()
            };

            await _hubContext.Clients.All.SendAsync("receivemessage", $"{player.Player.Name}-{id}");
            return View(quizRoomVM);
        }

        public async Task<IActionResult> Start(string id)
        {
            Console.WriteLine(id);
            _quizService.StartQuiz(id);
            await _hubContext.Clients.All.SendAsync("startquiz", $"{id}");
            return RedirectToAction(nameof(Room), new { id = id });
        }

        public IActionResult Play(string id)
        {

            Guid playerId = Guid.Empty;
            string playerIdString = HttpContext.Request.Cookies["drx1e"];
            if (playerIdString == null) return RedirectToAction(nameof(Index));

            try { Guid.TryParse(playerIdString, out playerId); }
            catch (FormatException) { return RedirectToAction(nameof(Index)); }

            Quiz quizplayers = _quizService.GetQuizWithPlayersByLink(id);

            QuizPlayer player = quizplayers.QuizPlayers.FirstOrDefault(qp => qp.PlayerId.Equals(playerId));

            if(player == null || player.HasPlayed){
                return RedirectToAction(nameof(Room), new { id = id });
            }

            Quiz quiz = _quizService.GetQuizWithQuestions(id);

            PlayQuizVM playQuizVM = new PlayQuizVM
            {
                Questions = quiz.Questions.ToArray(),
                PlayerName = player.Player.Name
            };

            return View(playQuizVM);
        }


        [HttpPost]
        public async Task<IActionResult> Play(string id, PlayQuizVM playQuizVM)
        {
            Guid playerId = Guid.Empty;
            int correctAnswers = 0;

            string playerIdString = HttpContext.Request.Cookies["drx1e"];

            if (playerIdString == null) return RedirectToAction(nameof(Index));

            try { Guid.TryParse(playerIdString, out playerId); }
            catch (FormatException) { return RedirectToAction(nameof(Index)); }

            Quiz quiz = _quizService.GetQuizWithQuestions(id);

            Question[] questions = quiz.Questions.ToArray();


            playQuizVM.Questions = quiz.Questions.ToArray();

            string answers = string.Empty;

            for (int i = 0; i < questions.Length; i++)
            {
                Question question = questions[i];

                string optionIndexString = $"selectedAnswer[{i}]";

                string option = Request.Form[optionIndexString];

                if (option != null)
                {
                    answers += option;
                    // if (_questionService.IsRightAnswer(question, option)) correctAnswers++;
                    if (question.CorrectOption.Equals(option)) correctAnswers++;
                    
                }
                else
                {
                    answers += "null";
                }

                if (i < questions.Length - 1) answers += "-";

            }

            Quiz updatedQuiz = _quizService.SetPlayerScore(id, playerId, correctAnswers);

            QuizPlayer quizPlayer = updatedQuiz.QuizPlayers
            .FirstOrDefault(qp => qp.PlayerId.Equals(playerId));

             await _hubContext.Clients.All.SendAsync("playerFinish", $"{quizPlayer.Player.Name}-{correctAnswers}");

             return RedirectToAction(nameof(Room), new { id = id });

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

            Guid userId = Guid.Empty;
            string creatorRole = string.Empty;

            if (User.IsInRole("Student"))
            {
                userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                creatorRole = "Student";
            }

            if (Request.Form["submitbtn"].Equals("Add New Question"))
            {

                viewModel.NumberOfQuestions = viewModel.Questions.Length + 1;
                return View(viewModel);

            }

            else if (Request.Form["submitbtn"].Equals("Create"))
            {
                _quizService.Create(userId, creatorRole, viewModel.Questions.ToList());

                return RedirectToAction("Quizzes", "Student");
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