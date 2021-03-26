using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BuckleUp.Interface.Service;
using BuckleUp.Models.Entities;
using BuckleUp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BuckleUp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        public CourseController(ITeacherService teacherService, IStudentService studentService, ICourseService courseService)
        {
            _courseService = courseService;
            _studentService = studentService;
            _teacherService = teacherService;
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            CourseDetailsVM courseDetailsVm = new CourseDetailsVM();

            if (User.Identity.IsAuthenticated)
            {
                var userRole = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role).Value;

                if (userRole == "Teacher")
                {
                    Course course = _courseService.GetCourseDetailsWithAllStudents(id);
                    courseDetailsVm.Course = course;
                }
                else if (userRole == "Student") {

                    Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
                    Course course = _courseService.GetCourseById(id);
                    Student student = _studentService.GetStudentWithTeacherCoursesById(studentId);
                    
                    courseDetailsVm.Course = course;
                    courseDetailsVm.Student = student;

                }
            }
            else
            {
                ViewBag.Message = $"You are not logged in to view course {id}";
            }

            return View(courseDetailsVm);

        }

        public IActionResult Enrolled(Guid? id){

            List<Student> students = _studentService.GetAllStudentOfferingACourse(id.Value);

            ViewBag.Students = students;
            return View();
        }



    }
}