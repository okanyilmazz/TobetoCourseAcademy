using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICourseService
    {
        Task Add(Course course);
        Task<IPaginate<Course>> GetListAsync();
        Task<IPaginate<CourseDetailsDto>> GetDetailsListAsync();
        Task Delete(Course course);
    }
}
