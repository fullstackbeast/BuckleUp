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
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        public TeacherController(IUserService userService, ITeacherService teacherService, IStudentService studentService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _userService = userService;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult AddStudent()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult AddStudent(string email)
        {

            Guid teacherId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            User user = _userService.FindByEmail(email);

            if (user == null || !user.Type.Equals("Student"))
            {
                ViewBag.ErrorMessage = "Student Not Found";
                return View();
            }

            Student student = _studentService.FindById(user.Id);

            _teacherService.AddStudent(teacherId, student);

             return RedirectToAction(nameof(Dashboard));
        }

        
         [Authorize(Roles = "Teacher")]
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult AddCourse(AddCourseVM addCourseVM)
        {

            Guid teacherId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            _teacherService.AddCourse(teacherId, addCourseVM.Title);
            return RedirectToAction(nameof(Dashboard));

        }
        
        
        [Authorize(Roles = "Teacher")]
        public IActionResult Students()
        {
            StudentListVM studentListVM = new StudentListVM();

            Guid teacherId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            Teacher teacher = _teacherService.GetTeacherWithStudentsAndCourses(teacherId);

            studentListVM.Teacher = teacher;

            foreach (var stud in teacher.TeacherStudents)
            {
                User student = _userService.FindById(stud.StudentId);
                studentListVM.Students.Add(student);
            }

            return View(studentListVM);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult RemoveStudent(Guid studentId)
        {

            Guid teacherId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            Student student = _studentService.GetStudentWithTeacherCoursesById(studentId);

            if (student == null)
            {
                ViewBag.Message = "Student does not exist";
                return View();
            }

            else
            {
                _teacherService.RemoveStudent(teacherId, student);
                return RedirectToAction(nameof(Dashboard));
            }
        }

          
        [Authorize(Roles = "Teacher")]
        public IActionResult Courses()
        {
            Guid teacherId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            TeacherCourseListVM teacherCourseListVM = new TeacherCourseListVM();

            Teacher teacher = _teacherService.GetTeacherWithCourses(teacherId);

            teacherCourseListVM.Courses = teacher.Courses.ToList();
            return View(teacherCourseListVM);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Assessments()
        {
            Guid teacherId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            TeacherAssessmentListVM teacherAssessmentListVM = new TeacherAssessmentListVM();

            Teacher teacher = _teacherService.GetTeacherWithAssessmentsById(teacherId);

            teacherAssessmentListVM.Teacher = teacher;

            return View(teacherAssessmentListVM);
        }

    }
}