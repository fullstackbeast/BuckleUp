using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuckleUp.Controllers
{
    public class TestController:Controller
    {


        [Authorize(Roles = "Teacher")]
        public IActionResult ForTeacher(){

            return View();
        }
        
        [Authorize(Roles = "Student")]
        public IActionResult ForStudent(){

            return View();
        }
        
    }
}