using System.Collections.Generic;
using System;
using BuckleUp.Models.Entities;

namespace BuckleUp.Interface.Repository
{
    public interface IStudentRepository
    {
         public Student Add(Student student);
         public Student FindById(Guid id);
         public List<Student> FindAllStudentOfferingACourse (Guid courseId);
         public Student FindStudentWithTeacherCoursesById(Guid id);
    }
}