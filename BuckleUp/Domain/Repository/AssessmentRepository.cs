using System;
using System.Collections.Generic;
using System.Linq;
using BuckleUp.Interface.Repository;
using BuckleUp.Models;
using BuckleUp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuckleUp.Domain.Repository
{
    public class AssessmentRepository : IAssessmentRepository
    {
        private readonly AppDBContext _context;
        public AssessmentRepository(AppDBContext context)
        {
            _context = context;
        }

        public Assessment Add(Assessment assessment)
        {
            _context.Assessments.Add(assessment);
            _context.SaveChanges();
            return assessment;
        }

        public Assessment Delete(Assessment assessment)
        {
            _context.Assessments.Remove(assessment);
            _context.SaveChanges();
            return assessment;
        }

        public List<Assessment> FindAllCourseAssessment(Guid courseId)
        {
            return _context.Assessments
                .Include(ass => ass.GroupAssessments)
                .ThenInclude(grpass => grpass.Group)
                .Where(ass => ass.CourseId == courseId).ToList();
        }
        public Assessment FindAssessmentAndQuestionsById(Guid id)
        {
            return _context.Assessments
                .Include(ass => ass.Questions)
                .FirstOrDefault(ass => ass.Id == id);
        }

        public Assessment FindAssessmentAndQuestionsWithStudentsById(Guid id)
        {
            return _context.Assessments
                .Include(ass => ass.Questions)
                .Include(ass => ass.StudentAssessments)
                .ThenInclude(stdass => stdass.Student)
                .ThenInclude(std => std.User)
                .Include(a => a.GroupAssessments)
                .ThenInclude(ga => ga.Group)
                .FirstOrDefault(ass => ass.Id == id);
        }

        public Assessment FindAssessmentAndGroupsWithStudentsById(Guid id)
        {
            return _context.Assessments.Include(a => a.GroupAssessments)
                .ThenInclude(ga => ga.Group)
                .ThenInclude(g => g.StudentGroups)
                .ThenInclude(sg => sg.Student)
                .ThenInclude(s => s.User)
                .FirstOrDefault(a => a.Id.Equals(id));
        }

        public Assessment FindById(Guid id)
        {
            return _context.Assessments.Find(id);
        }

        public Assessment Update(Assessment assessment)
        {
            _context.Assessments.Update(assessment);
            _context.SaveChanges();
            return assessment;
        }
    }
}