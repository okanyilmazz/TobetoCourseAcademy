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
    public class InstructorOfCourseManager : IInstructorOfCourseService
    {
        IInstructorOfCourseDal _instructorOfCourseDal;

        public InstructorOfCourseManager(IInstructorOfCourseDal instructorOfCourseDal)
        {
            _instructorOfCourseDal = instructorOfCourseDal;
        }

        public async Task AddAsync(InstructorOfCourse instructorOfCourse)
        {
            await _instructorOfCourseDal.AddAsync(instructorOfCourse);
        }

        public async Task DeleteAsync(InstructorOfCourse instructorOfCourse)
        {
            await _instructorOfCourseDal.DeleteAsync(instructorOfCourse);
        }

        public async Task<InstructorOfCourse> GetByIdAsync(int id)
        {
            return await _instructorOfCourseDal.GetAsync(i => i.Id == id);
        }

        public async Task<IPaginate<InstructorOfCourse>> GetListAsync()
        {
            return await _instructorOfCourseDal.GetListAsync();
        }

        public async Task UpdateAsync(InstructorOfCourse instructorOfCourse)
        {
            await _instructorOfCourseDal.UpdateAsync(instructorOfCourse);
        }
    }
}
