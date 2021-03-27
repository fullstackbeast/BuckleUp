using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BuckleUp.Interface.Service;
using BuckleUp.Models;
using BuckleUp.Models.Entities;
using BuckleUp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BuckleUp.Controllers
{
    public class AssessmentController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly ITeacherService _teacherService;
        private readonly IAssessmentService _assessmentService;
        private readonly IStudentService _studentService;

        public AssessmentController(IQuestionService questionService, ITeacherService teacherService, IAssessmentService assessmentService, IStudentService studentService)
        {
            _studentService = studentService;
            _assessmentService = assessmentService;
            _teacherService = teacherService;
            _questionService = questionService;

        }

        public IActionResult Create()
        {

            Guid teacherId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            Teacher teacher = _teacherService.GetTeacherWithCourses(teacherId);

            List<SelectListItem> courseSelect = new List<SelectListItem>();

            foreach (var course in teacher.Courses)
            {
                courseSelect.Add(new SelectListItem
                {
                    Text = $"{course.Title}",
                    Value = $"{course.Id}"
                });
            }

            CreateAssessmentVM viewModel = new CreateAssessmentVM
            {
                NumberOfQuestions = 3,
                CourseSelectList = courseSelect
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Create(CreateAssessmentVM viewModel)
        {

            Guid teacherId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            Teacher teacher = _teacherService.GetTeacherWithCourses(teacherId);

            List<SelectListItem> courseSelect = new List<SelectListItem>();

            foreach (var course in teacher.Courses)
            {
                courseSelect.Add(new SelectListItem
                {
                    Text = $"{course.Title}",
                    Value = $"{course.Id}",
                    Selected = course.Id.Equals(viewModel.CourseId)
                });
            }

            viewModel.CourseSelectList = courseSelect;



            if (Request.Form["submitbtn"].Equals("Add New Question"))
            {

                viewModel.NumberOfQuestions = viewModel.Questions.Length + 1;
                return View(viewModel);

            }

            else if (Request.Form["submitbtn"].Equals("Create"))
            {

                Assessment assessment = new Assessment
                {
                    Id = Guid.NewGuid(),
                    StartTime = DateTime.Parse("2020/11/4"),
                    StopTime = DateTime.Parse("2021/11/4"),
                    TeacherId = teacherId,
                    Type = viewModel.Type,
                    Title = viewModel.Title,
                    CourseId = viewModel.CourseId
                };

                foreach (var question in viewModel.Questions)
                {
                    question.AssessmentId = assessment.Id;
                }

                _teacherService.AddAssessment(teacherId, assessment);
                _questionService.AddMany(viewModel.Questions);



                _assessmentService.AddAssessmentToStudents(assessment);

                return View(viewModel);
            }

            else if (Request.Form["submitbtn"].Equals("Remove A Question"))
            {

                Question[] newQuestions = new Question[viewModel.Questions.Length - 1];

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

        public IActionResult Details(Guid? id)
        {

            Assessment assessment;
             AssessmentDetailsVM assessmentDetailsVM = new AssessmentDetailsVM();

            if(User.IsInRole("Student")){
                assessment = _assessmentService.GetAssessmentAndQuestionsWithStudentsById(id.Value);
                assessmentDetailsVM.StudentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            }
            if(User.IsInRole("Teacher")){
                assessment = _assessmentService.GetAssessmentAndQuestionsWithStudentsById(id.Value);
                assessmentDetailsVM.TeacherId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            }
            else{
                assessment = _assessmentService.GetAssessmentAndQuestionsById(id.Value);
            }

             assessmentDetailsVM.Assessment = assessment;
            return View(assessmentDetailsVM);
        }

        public IActionResult TakeAssessment(Guid? id)
        {

            Assessment assessment = _assessmentService.GetAssessmentAndQuestionsById(id.Value);

            if (assessment == null) return NotFound();

            TakeAssessmentVM takeAssessmentVM = new TakeAssessmentVM
            {
                questions = assessment.Questions.ToArray()
            };

            foreach (var question in takeAssessmentVM.questions)
            {
                question.CorrectOption = null;
            }

            return View(takeAssessmentVM);
        }

        [HttpPost]
        public IActionResult TakeAssessment(Guid? id, TakeAssessmentVM takeAssessmentVM)
        {
            int correctAnswers = 0;

            Assessment assessment = _assessmentService.GetAssessmentAndQuestionsById(id.Value);
            Question[] questions = assessment.Questions.ToArray();
            Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            string answers = string.Empty;

            for (int i = 0; i < questions.Length; i++)
            {
                Question question = questions[i];

                string optionIndexString = $"selectedAnswer[{i}]";

                string option = Request.Form[optionIndexString];

                if (option != null)
                {
                    answers += option;
                    if (_questionService.IsRightAnswer(question, option)) correctAnswers++;
                }
                else
                {
                    answers += "null";
                }

                if (i < questions.Length - 1) answers += "-";

            }

            _studentService.RegisterAssessmentPerformance(studentId, id.Value, correctAnswers, questions.Length);

            HttpContext.Response.Cookies.Append("Score", $"You scored {correctAnswers} / {questions.Length}");
            HttpContext.Response.Cookies.Append("Answers", answers);
            HttpContext.Response.Cookies.Append("AssessmentId", assessment.Id.ToString());

            return RedirectToAction(nameof(Result));

        }

        public IActionResult Result()
        {

            string assessmentIdString = HttpContext.Request.Cookies["AssessmentId"];
            string answers = HttpContext.Request.Cookies["Answers"];

            Guid assessmentId = Guid.Parse(assessmentIdString);

            Assessment assessment = _assessmentService.GetAssessmentAndQuestionsById(assessmentId);



            AssessmentResultVM assesmentResultVM = new AssessmentResultVM
            {
                Questions = assessment.Questions.ToArray(),
                Answers = answers.Split("-").ToList()
            };
            return View(assesmentResultVM);
        }
    }
}