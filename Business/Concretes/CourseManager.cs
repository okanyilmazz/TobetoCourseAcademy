using Business.Abstracts;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public async Task AddAsync(Course course)
        {
            await _courseDal.AddAsync(course);
        }

        public async Task DeleteAsync(Course course)
        {
            await _courseDal.DeleteAsync(course, true);
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _courseDal.GetAsync(c => c.Id == id);
        }

        public async Task<IPaginate<CourseDetailsWithStudentAndInstructorDto>> GetDetailsWithStudentAndInstructorListAsync()
        {
            return await _courseDal.GetDetailsWithStudentAndInstructorListAsync();
        }

        public async Task<IPaginate<Course>> GetListAsync()
        {
            return await _courseDal.GetListAsync();
        }

        public async Task UpdateAsync(Course course)
        {
            await _courseDal.UpdateAsync(course);
        }
    }
}
