using BuckleUp.Interface.Repository;
using BuckleUp.Models;
using BuckleUp.Models.Entities;

namespace BuckleUp.Domain.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDBContext _context;
        public TeacherRepository(AppDBContext context)
        {
            _context = context;
        }

        public Teacher Add(Teacher teacher)
        {
           _context.Teachers.Add(teacher);
           _context.SaveChanges();
           return teacher;
        }
    }
}