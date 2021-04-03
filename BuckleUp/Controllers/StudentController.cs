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
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly IQuizService _quizService;
        private readonly IStudentService _studentService;
        private readonly IUserService _userService;
        private readonly ITeacherService _teacherService;
        public StudentController(IQuizService quizService, IStudentService studentService, IUserService userService, ITeacherService teacherService)
        {
            _teacherService = teacherService;
            _userService = userService;
            _studentService = studentService;
            _quizService = quizService;
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Quizzes()
        {
            Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            List<Quiz> quizzes = _quizService.GetAllGuizByCreatorId(studentId);

            MyQuizzesVM myQuizzesVM = new MyQuizzesVM
            {
                Quizzes = quizzes
            };

            return View(myQuizzesVM);
        }

        public IActionResult Teachers()
        {
            Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            TeacherListVM teacherListVM = new TeacherListVM();

            Student student = _studentService.GetStudentWithTeachers(studentId);

            foreach (var teacherStudent in student.TeacherStudents)
            {
                User teacherUser = _userService.FindById(teacherStudent.TeacherId);
                teacherListVM.Teachers.Add(teacherUser);
            }

            return View(teacherListVM);
        }


        [Authorize(Roles = "Student")]
        public IActionResult Enroll()
        {
            Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            Student student = _studentService.GetStudentWithTeacherCoursesById(studentId);


            List<SelectListItem> teacherSelect = new List<SelectListItem>();

            foreach (var teacher in student.TeacherStudents)
            {
                User teacherUser = _userService.FindById(teacher.TeacherId);
                teacherSelect.Add(new SelectListItem
                {
                    Text = $"{teacherUser.FirstName} {teacherUser.LastName}",
                    Value = $"{teacher.TeacherId}"
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
                User teacherUser = _userService.FindById(teacher.TeacherId);
                teacherSelect.Add(new SelectListItem
                {
                    Text = $"{teacherUser.FirstName} {teacherUser.LastName}",
                    Value = $"{teacher.TeacherId}",
                    Selected = teacherId.Value.Equals(teacher.TeacherId)
                });
            }

            EnrollVM enrollVM = new EnrollVM
            {
                TeacherSelectList = teacherSelect,
                TeacherCourses = teacherCourses,
                Student = student
            };

            ViewBag.TeacherId = teacherId.Value;

            StudentCourse studentCourse = student.StudentCourses.FirstOrDefault(stdcou => stdcou.CourseId == courseId);

            if (courseId != null && (studentCourse == null || !studentCourse.IsEnrolled)) _studentService.Enroll(studentId, courseId.Value);
            else if (courseId != null && studentCourse != null && studentCourse.IsEnrolled) _studentService.UnEnroll(studentId, studentCourse);
           
            if (sourceId != null)
            {
                return RedirectToAction(controllerName: "Student", actionName: "Courses");
            }

            return View(enrollVM);


        }

        [Authorize(Roles = "Student")]
        public IActionResult Courses()
        {
            StudentCourseListVM studentCourseListVM = new StudentCourseListVM();
            Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            Student student = _studentService.GetStudentWithTeacherCoursesById(studentId);

            foreach (var course in student.StudentCourses)
            {
               if(course.IsEnrolled) studentCourseListVM.Courses.Add(course.Course);
            }
            return View(studentCourseListVM);
        }

        [Authorize(Roles = "Student")]
        public IActionResult Assessments()
        {
            StudentAssessmentListVM studentAssessmentListVM = new StudentAssessmentListVM();
            Guid studentId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            Student student = _studentService.GetEnrolledCourseAssessments(studentId);

            studentAssessmentListVM.Student = student;
            
            return View(studentAssessmentListVM);
        }
    }
}