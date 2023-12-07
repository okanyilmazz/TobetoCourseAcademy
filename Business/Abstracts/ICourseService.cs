using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface ICourseService
{
    Task<IPaginate<Course>> GetListAsync();
    Task<IPaginate<CourseDetailsWithStudentAndInstructorDto>> GetDetailsWithStudentAndInstructorListAsync();
    Task<Course> GetByIdAsync(int id);
    Task AddAsync(Course course);
    Task DeleteAsync(Course course);
    Task UpdateAsync(Course course);
}
