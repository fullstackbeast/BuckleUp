using System.Net;
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
using static System.Net.WebRequestMethods;

namespace BuckleUp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;

        public StudentController(IStudentService studentService, ITeacherService teacherService)
        {
            _teacherService = teacherService;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View(_studentService.ListAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student Student)
        {
            _studentService.AddStudent(Student);
            return RedirectToAction(nameof(Index));
        }


        [Authorize(Roles = "Student")]
        public IActionResult Dashboard()
        {

            Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            Student student = _studentService.GetStudentWithTeacherCoursesAndAssessmentsById(studentId);
            return View(student);
        }


        [Authorize(Roles = "Student")]
        public IActionResult Enroll()
        {
            Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            Student student = _studentService.GetStudentWithTeacherCoursesById(studentId);


            List<SelectListItem> teacherSelect = new List<SelectListItem>();

            foreach (var teacher in student.TeacherStudents)
            {
                teacherSelect.Add(new SelectListItem
                {
                    Text = $"{teacher.Teacher.FirstName} {teacher.Teacher.LastName}",
                    Value = $"{teacher.Teacher.Id}"
                });
            }

            EnrollVM enrollVM = new EnrollVM
            {
                TeacherSelectList = teacherSelect
            };


            return View(enrollVM);
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public IActionResult Enroll(Guid? teacherId, Guid? courseId, int? sourceId)
        {

            Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            Student student = _studentService.GetStudentWithTeacherCoursesById(studentId);

            Teacher selectedTeacher = _teacherService.GetTeacherWithCourses(teacherId.Value);

            List<Course> teacherCourses = selectedTeacher.Courses.ToList();

            List<SelectListItem> teacherSelect = new List<SelectListItem>();

            foreach (var teacher in student.TeacherStudents)
            {
                teacherSelect.Add(new SelectListItem
                {
                    Text = $"{teacher.Teacher.FirstName} {teacher.Teacher.LastName}",
                    Value = $"{teacher.Teacher.Id}",
                    Selected = teacherId.Value.Equals(teacher.Teacher.Id)
                });
            }

            EnrollVM enrollVM = new EnrollVM
            {
                TeacherSelectList = teacherSelect,
                TeacherCourses = teacherCourses, 
                Student = student
            };

            ViewBag.TeacherId = teacherId.Value;

            StudentCourse studentCourse = student.StudentCourses.FirstOrDefault( stdcou => stdcou.CourseId == courseId);
            
            if(courseId != null && studentCourse == null) _studentService.Enroll(studentId, courseId.Value);
            if(courseId != null && studentCourse != null) _studentService.UnEnroll(studentId, studentCourse);
            if(sourceId != null) {
                return RedirectToAction(controllerName: "Course",  actionName: "Details", routeValues: new {
                    Id = courseId
                });
            }
            
            return View(enrollVM);


        }


    }
}