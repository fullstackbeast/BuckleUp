using System.Security.Claims;
using BuckleUp.Interface.Service;
using BuckleUp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuckleUp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
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

    }
}