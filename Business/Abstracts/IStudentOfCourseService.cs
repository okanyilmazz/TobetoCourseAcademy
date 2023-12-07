using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IStudentOfCourseService
    {
        Task<IPaginate<StudentOfCourse>> GetListAsync();
        Task<StudentOfCourse> GetByIdAsync(int id);
        Task AddAsync(StudentOfCourse studentOfCourse);
        Task DeleteAsync(StudentOfCourse studentOfCourse);
        Task UpdateAsync(StudentOfCourse studentOfCourse);
    }
}
