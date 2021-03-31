using System;
using BuckleUp.Interface.Service;
using BuckleUp.Models.Entities;
using BuckleUp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BuckleUp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        
        public UserController(IUserService userService, ITeacherService teacherService, IStudentService studentService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserVM registerUserVM)
        {

            User user = new User{
                Id = Guid.NewGuid(),
                FirstName = registerUserVM.FirstName,
                LastName = registerUserVM.LastName, 
                MiddleName = registerUserVM.MiddleName, 
                Email = registerUserVM.Email, 
                Password = registerUserVM.Password, 
                Type = registerUserVM.UserType
            };
            User registeredUser = _userService.Add(user);

            switch(registerUserVM.UserType){
                case "Teacher":
                    Teacher teacher = new Teacher {UserId = registeredUser.Id};
                    _teacherService.AddNewTeacher(teacher);
                break;
                case "Student":
                    Student student = new Student {UserId = registeredUser.Id};
                    _studentService.AddNewStudent(student);
                break;
            }

            return RedirectToAction("Index", "Home");
        }

    }
}