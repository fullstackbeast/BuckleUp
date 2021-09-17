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
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;

        public GroupController(IGroupService groupService, IUserService userService)
        {
            _groupService = groupService;
            _userService = userService;
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Details(string id, int? errId)
        {

            var groupId = Guid.Parse(id);

            var group = _groupService.GetGroupWithStudentsAndAssessmentsById(groupId);

            var teacherId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            if (!group.TeacherId.Equals(teacherId)) return RedirectToAction("Groups", "Teacher");

            var groupDetailsVM = new GroupDetailsVM
            {
                Group = group
            };

            if (errId != null)
            {
                ViewBag.ErrorMessage = errId switch
                {
                    1 => "Student Not Found",
                    _ => ViewBag.ErrorMessage
                };

                return View(groupDetailsVM);
            }

            return View(groupDetailsVM);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return RedirectToAction("Groups", "Teacher");
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public IActionResult AddStudent(GroupDetailsVM model)
        {
            User user = _userService.FindByEmail(model.StudentEmail);

            if (user == null)
            {
                return RedirectToAction(nameof(Details), new {id = model.Group.Id.ToString(), errId = 1});
            }

            _groupService.AddStudent(model.Group.Id, user.Id);

            return RedirectToAction(nameof(Details), new {id = model.Group.Id.ToString()});


        }
        
        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public IActionResult RemoveStudent(string id, string studentId)
        {
            _groupService.RemoveStudent(Guid.Parse(id), Guid.Parse(studentId));
            return RedirectToAction(nameof(Details), new {id = id});
        }
        
        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public IActionResult Delete(Guid? id)
        {
            // _groupService.RemoveStudent(Guid.Parse(id), Guid.Parse(studentId));
            // return RedirectToAction(nameof(Details), new {id = id});

            if (id != null) _groupService.DeleteGroup(id.Value);

            return RedirectToAction("Groups", "Teacher");
        }
    }
}