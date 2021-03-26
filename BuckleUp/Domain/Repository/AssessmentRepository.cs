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
            return _context.Assessments.Where(ass => ass.CourseId == courseId).ToList();
        }

        public List<Assessment> FindAllStudentAssessment(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public List<Assessment> FindAllTeacherAssessment(Guid teacherId)
        {
            return _context.Assessments.Where(ass => ass.TeacherId == teacherId).ToList();
        }

        public Assessment FindAssessmentAndQuestionsById(Guid id)
        {
            return _context.Assessments
                .Include(ass => ass.Questions)
                .FirstOrDefault(ass => ass.Id == id);
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