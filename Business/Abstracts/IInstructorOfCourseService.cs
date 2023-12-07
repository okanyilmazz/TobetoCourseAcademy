using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IInstructorOfCourseService
    {
        Task<IPaginate<InstructorOfCourse>> GetListAsync();
        Task<InstructorOfCourse> GetByIdAsync(int id);
        Task AddAsync(InstructorOfCourse instructorOfCourse);
        Task DeleteAsync(InstructorOfCourse instructorOfCourse);
        Task UpdateAsync(InstructorOfCourse instructorOfCourse);
    }
}
