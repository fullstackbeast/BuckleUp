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

        public AssessmentController(ITeacherService teacherService, IAssessmentService assessmentService, IStudentService studentService)
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

       
    }
}