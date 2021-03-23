using Microsoft.AspNetCore.Mvc;

namespace BuckleUp.Controllers
{
    public class RoleController:Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create(string roleName){
            return View();
        }
        
    }
}