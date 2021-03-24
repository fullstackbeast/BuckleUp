using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BuckleUp.Interface.Repository;
using BuckleUp.Interface.Service;
using BuckleUp.Models;
using BuckleUp.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace BuckleUp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;

        public AuthController(IAuthRepository authRepository, ITeacherService teacherService, IStudentService studentService)
        {
            _studentService = studentService;
            _teacherService = teacherService;

            _authRepository = authRepository;

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {


            User user = _authRepository.Login(email, password);

            if (user != null)
            {

                Details loggingInUser;

                switch (user.Type)
                {
                    case ("Teacher"): loggingInUser = _teacherService.FindById(user.Id); break;
                    case ("Student"): loggingInUser = _studentService.FindById(user.Id); break;
                    default: loggingInUser = null; break;
                }

                var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier , loggingInUser.Id.ToString()),
                new Claim(ClaimTypes.Role, loggingInUser.Role),
            };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);

                ViewBag.Message = $"Logged in as {loggingInUser.FirstName} {loggingInUser.LastName}";

                return RedirectToAction(actionName: "Dashboard", controllerName: user.Type);
            }
            else
            {
                ViewBag.Message = $"Id is not found o";
                return View();
            }


        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}