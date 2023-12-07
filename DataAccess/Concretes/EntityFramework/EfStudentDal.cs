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
    public class EfStudentDal : EfRepositoryBase<Student, int, TobetoContext>, IStudentDal
    {
        TobetoContext _context;
        public EfStudentDal(TobetoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IPaginate<StudentDetailsDto>> GetDetailsListAsync()
        {
            int index = 0;
            int size = 10;
            var result = await (from student in _context.Students
                                join studentOfCourse in _context.StudentOfCourses on student.Id equals studentOfCourse.StudentId
                                join course in _context.Courses on studentOfCourse.CourseId equals course.Id
                                join category in _context.Categories on course.CategoryId equals category.Id
                                group new {student, course, category} by student into studentGroup
                                select new StudentDetailsDto
                                {
                                    FirstName = studentGroup.Key.FirstName,
                                    LastName = studentGroup.Key.LastName,
                                    Email = studentGroup.Key.Email,
                                    Courses = studentGroup.Select(cou=>new CourseDetailsDto
                                    {
                                        Id = cou.course.Id,
                                        CourseName = cou.course.Name,
                                        CourseDescription = cou.course.Description,
                                        CategoryName = cou.category.Name
                                    }).ToList()
                                }).ToPaginateAsync(index, size, from: 0);

            return result;
        }

        /*Designed to come along with the Instructor */

        /*public async Task<IPaginate<StudentDetailsDto>> GetDetailsListAsync()
        {
            int index = 0;
            int size = 10;
            var result = await (from student in _context.Students
                                join studentOfCourse in _context.StudentOfCourses
                                on student.Id equals studentOfCourse.StudentId
                                join course in _context.Courses
                                on studentOfCourse.CourseId equals course.Id
                                join category in _context.Categories
                                on course.CategoryId equals category.Id
                                join instructorOfCourse in _context.InstructorOfCourses
                                on course.Id equals instructorOfCourse.CourseId
                                join instructor in _context.Instructors
                                on instructorOfCourse.InstructorId equals instructor.Id
                                group new { student, course, category, instructor } by student into studentGroup
                                select new StudentDetailsDto
                                {
                                    FirstName = studentGroup.Key.FirstName,
                                    LastName = studentGroup.Key.LastName,
                                    Email = studentGroup.Key.Email,
                                    CourseDetails = studentGroup.Select(s => new CourseDetailsForStudentDto
                                    {
                                        Id = s.course.Id,
                                        CourseName = s.course.Name,
                                        CourseDescription = s.course.Description,
                                        CategoryName = s.category.Name,
                                        InstructorFirstName = s.instructor.FirstName,
                                        InstructorLastName = s.instructor.LastName,
                                        InstructorEmail = s.instructor.Email
                                    }).ToList()
                                }).ToPaginateAsync(index, size);

            return result;
        }*/

        // #endregion
    }
}
