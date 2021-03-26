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
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;

        public TeacherController(ITeacherService teacherService, IStudentService studentService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            return View(_teacherService.ListAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            _teacherService.AddTeacher(teacher);
            return RedirectToAction(nameof(Index));
        }


        [Authorize(Roles = "Teacher")]
        public IActionResult Dashboard()
        {

            Guid teacherId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            Teacher teacher = _teacherService.GetTeacherWithStudentsAndCoursesAndAssessmentsById(teacherId);
            return View(teacher);
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

            Student student = _studentService.FindByEmail(email);

            if (student == null)
            {
                ViewBag.Message = "Student does not exist";
                return View();
            }

            else
            {
                _teacherService.AddStudent(teacherId, student);
                return RedirectToAction(nameof(Dashboard));
            }
        }


        [Authorize(Roles = "Teacher")]
        public IActionResult RemoveStudent()
        {

            RemoveStudentVM removeStudentVm = new RemoveStudentVM();

             Guid teacherId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            Teacher teacher = _teacherService.GetTeacherWithStudentsAndCourses(teacherId);


            removeStudentVm.Teacher = teacher;

            

            return View(removeStudentVm);
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

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult DeleteCourse(Guid courseId, Guid teacherId)
        {
            Guid loggedInTeacherId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            if (loggedInTeacherId.Equals(teacherId))
            {
                _teacherService.DeleteCourse(courseId, teacherId);
            }

            return RedirectToAction(nameof(Dashboard));

        }
    }
}