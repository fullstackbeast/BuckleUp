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
        private readonly ITeacherService _teacherService;
        private readonly IAssessmentService _assessmentService;
        private readonly IStudentService _studentService;

        public AssessmentController(ITeacherService teacherService, IAssessmentService assessmentService,
            IStudentService studentService)
        {
            _studentService = studentService;
            _assessmentService = assessmentService;
            _teacherService = teacherService;
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
                    Questions = viewModel.Questions,
                    CourseId = viewModel.CourseId
                };

                _assessmentService.Add(assessment);
                
                //_assessmentService.AddAssessmentToStudents(assessment);
                
                return RedirectToAction("Dashboard", "Teacher");
            }

            else if (Request.Form["submitbtn"].Equals("Remove A Question"))
            {
                AssessmentQuestion[] newQuestions = new AssessmentQuestion[viewModel.Questions.Length - 1];

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

            if (User.IsInRole("Student"))
            {
                assessment = _assessmentService.GetAssessmentAndQuestionsWithStudentsById(id.Value);

                assessmentDetailsVM.StudentId =
                    Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            }

            if (User.IsInRole("Teacher"))
            {
                var teacherId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

                assessment = _assessmentService.GetAssessmentAndQuestionsWithStudentsById(id.Value);

                var teacher = _teacherService.GetTeacherWithGroups(teacherId);

                assessmentDetailsVM.Groups = teacher.Groups.ToList();
                assessmentDetailsVM.TeacherId = teacherId;
            }
            else
            {
                assessment = _assessmentService.GetAssessmentAndQuestionsById(id.Value);
            }

            assessmentDetailsVM.Assessment = assessment;
            return View(assessmentDetailsVM);
        }


        public IActionResult TakeAssessment(Guid? id)
        {
            Assessment assessment = _assessmentService.GetAssessmentAndQuestionsById(id.Value);

            if (User.Identity.IsAuthenticated && User.IsInRole("Student"))
            {
                Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                Student student = _studentService.GetStudentWithAssessments(studentId);

                Student studentWithAssessments = _studentService.GetEnrolledCourseAssessments(studentId);

                if (studentWithAssessments.StudentAssessments.FirstOrDefault(stdass =>
                        stdass.AssessmentId.Equals(id.Value)) ==
                    null) return RedirectToAction(nameof(Details), new {id = id.Value});

                foreach (var studentAssessment in student.StudentAssessments)
                {
                    if (studentAssessment.AssessmentId.Equals(id.Value))
                    {
                        if (studentAssessment.HasTaken)
                        {
                            return RedirectToAction(nameof(Details), new {id = id.Value});
                        }
                    }
                }
            }


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
                    if (question.CorrectOption.Equals(option)) correctAnswers++;
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

        public IActionResult Delete(Guid? id)
        {
            if (id != null) _assessmentService.DeleteAssessment(id.Value);
            return RedirectToAction("Assessments", "Teacher");
        }
        
        [HttpPost]
        public IActionResult AssignAssessment(AssessmentDetailsVM assessmentDetailsVm)
        {
            Console.WriteLine(assessmentDetailsVm.AssessmentId);
            Console.WriteLine(assessmentDetailsVm.GroupId);

            _assessmentService.AssignToGroup(assessmentDetailsVm.AssessmentId, assessmentDetailsVm.GroupId);

            return RedirectToAction(nameof(Details), new {id = assessmentDetailsVm.AssessmentId});
        }

        [HttpGet]
        public IActionResult UnassignAssessment(string id, string groupId)
        {
            Guid assessmentId = Guid.Parse(id);
            Guid groupIdGuid = Guid.Parse(groupId);

            _assessmentService.UnAssignFromGroup(assessmentId, groupIdGuid);
            
            return RedirectToAction(nameof(Details), new {id = assessmentId});
        }
        
    }
}