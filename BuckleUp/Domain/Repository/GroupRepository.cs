using System;
using System.Collections.Generic;
using System.Linq;
using BuckleUp.Interface.Repository;
using BuckleUp.Models;
using BuckleUp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuckleUp.Domain.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDBContext _context;

        public GroupRepository(AppDBContext context)
        {
            _context = context;
        }

        public Group AddGroup(Group group)
        {
            _context.Groups.Add(group);
            _context.SaveChanges();
            return group;
        }

        public Group UpdateGroup(Group group)
        {
            _context.Groups.Update(group);
            _context.SaveChanges();
            return group;
        }

        public void DeleteGroup(Guid id)
        {
            var group = _context.Groups.Find(id);
            _context.Groups.Remove(group);
            _context.SaveChanges();
        }

        public List<Group> GetAll()
        {
            return _context.Groups.ToList();
        }

        public Group FindById(Guid id)
        {
            return _context.Groups.Find(id);
        }

        public Group FindWithStudentsBy(Guid id)
        {
            var group = _context.Groups
                .Include(g => g.StudentGroups)
                .ThenInclude(sg => sg.Student)
                .FirstOrDefault(g => g.Id.Equals(id));

            return group;
        }

        public Group FindWithStudentsAndAssessmentsBy(Guid id)
        {
            var group = _context.Groups
                .Include(g => g.StudentGroups)
                .ThenInclude(sg => sg.Student)
                .ThenInclude(s => s.User)
                .Include(g => g.GroupAssessments)
                .ThenInclude(ga => ga.Assessment)
                .FirstOrDefault(g => g.Id.Equals(id));

            return group;
        }
        
        public Group FindWithStudentsCourseAndAssessmentsBy(Guid id)
        {
            var group = _context.Groups
                .Include(g => g.StudentGroups)
                .ThenInclude(sg => sg.Student)
                .ThenInclude(s => s.StudentCourses)
                .Include(g => g.GroupAssessments)
                .ThenInclude(ga => ga.Assessment)
                .FirstOrDefault(g => g.Id.Equals(id));

            return group;
        }
    }
}