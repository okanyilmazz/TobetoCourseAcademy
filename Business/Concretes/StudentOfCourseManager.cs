using Business.Abstracts;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class StudentOfCourseManager : IStudentOfCourseService
    {
        IStudentOfCourseDal _studentOfCourseDal;

        public StudentOfCourseManager(IStudentOfCourseDal studentOfCourseDal)
        {
            _studentOfCourseDal = studentOfCourseDal;
        }

        public async Task AddAsync(StudentOfCourse studentOfCourse)
        {
            await _studentOfCourseDal.AddAsync(studentOfCourse);
        }

        public async Task DeleteAsync(StudentOfCourse studentOfCourse)
        {
            await _studentOfCourseDal.DeleteAsync(studentOfCourse);
        }

        public async Task<StudentOfCourse> GetByIdAsync(int id)
        {
            return await _studentOfCourseDal.GetAsync(s => s.Id == id);
        }

        public async Task<IPaginate<StudentOfCourse>> GetListAsync()
        {
            return await _studentOfCourseDal.GetListAsync();
        }

        public async Task UpdateAsync(StudentOfCourse studentOfCourse)
        {
            await _studentOfCourseDal.UpdateAsync(studentOfCourse);
        }
    }
}
