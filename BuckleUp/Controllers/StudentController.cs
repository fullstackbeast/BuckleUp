using System;
using System.Linq;
using System.Security.Claims;
using BuckleUp.Interface.Service;
using BuckleUp.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuckleUp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
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

            Student student = _studentService.GetStudentWithTeachers(studentId);
            return View(student);
        }

    }
}