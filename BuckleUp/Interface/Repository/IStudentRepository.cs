using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface IStudentRepository
    {
         public Student Add(Student student);
    }
}