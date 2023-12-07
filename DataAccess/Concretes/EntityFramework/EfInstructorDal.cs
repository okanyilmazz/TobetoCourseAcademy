using Core.DataAccess.Paging;
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfInstructorDal : EfRepositoryBase<Instructor, int, TobetoContext>, IInstructorDal
    {
        TobetoContext _context;
        public EfInstructorDal(TobetoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IPaginate<InstructorDetailsDto>> GetDetailsListAsync()
        {
            int index = 0;
            int size = 10;
            var result = await (from instructor in _context.Instructors
                                join instructorOfCourse in _context.InstructorOfCourses
                                on instructor.Id equals instructorOfCourse.InstructorId
                                join course in _context.Courses
                                on instructorOfCourse.CourseId equals course.Id
                                join category in _context.Categories
                                on course.CategoryId equals category.Id
                                group new { course, category, instructor }
                                by instructor into instructorGroup
                                select new InstructorDetailsDto
                                {
                                    FirstName = instructorGroup.Key.FirstName,
                                    LastName = instructorGroup.Key.LastName,
                                    Email = instructorGroup.Key.Email,
                                    CourseDetails = instructorGroup.Select(i => new CourseDetailsDto
                                    {
                                        Id = i.course.Id,
                                        CourseName = i.course.Name,
                                        CourseDescription = i.course.Description,
                                        CategoryName = i.category.Name
                                    }).ToList()
                                }).ToPaginateAsync(index, size);
            return result;
        }
    }
}
