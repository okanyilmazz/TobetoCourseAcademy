using Core.DataAccess.Paging;
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCourseDal : EfRepositoryBase<Course, int, TobetoContext>, ICourseDal
    {
        TobetoContext _context;

        public EfCourseDal(TobetoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IPaginate<CourseDetailsWithStudentAndInstructorDto>> GetDetailsWithStudentAndInstructorListAsync()
        {
            int index = 0;
            int size = 20;

            var result = await (from course in _context.Courses
                                join category in _context.Categories
                                on course.CategoryId equals category.Id
                                join instructorOfCourse in _context.InstructorOfCourses
                                on course.Id equals instructorOfCourse.CourseId
                                join instructor in _context.Instructors
                                on instructorOfCourse.InstructorId equals instructor.Id
                                join studentOfCourse in _context.StudentOfCourses
                                on course.Id equals studentOfCourse.CourseId
                                join student  in _context.Students
                                on studentOfCourse.StudentId equals student.Id
                                group new { course, category, instructor , student } by course into courseGrouped
                                select new CourseDetailsWithStudentAndInstructorDto
                                {
                                    Id = courseGrouped.Key.Id,
                                    CategoryName = courseGrouped.First().category.Name,
                                    CourseName = courseGrouped.Key.Name,
                                    CourseDescription = courseGrouped.Key.Description,
                                    Instructors = courseGrouped.Select(ins => new Instructor
                                    {
                                        Id = ins.instructor.Id,
                                        FirstName = ins.instructor.FirstName,
                                        LastName = ins.instructor.LastName,
                                        Email = ins.instructor.Email,
                                        CreatedDate = ins.instructor.CreatedDate,
                                        DeletedDate = ins.instructor.DeletedDate,
                                        UpdatedDate = ins.instructor.UpdatedDate

                                    }).Distinct().ToList(),
                                    Students=courseGrouped.Select(stu=>new Student
                                    {
                                        Id=stu.student.Id,
                                        FirstName=stu.student.FirstName,
                                        LastName=stu.student.LastName,
                                        Email=stu.student.Email,
                                        CreatedDate=stu.student.CreatedDate,
                                        DeletedDate=stu.student.DeletedDate,
                                        UpdatedDate = stu.student.UpdatedDate
                                    }).Distinct().ToList()
                                }).ToPaginateAsync(index, size, from: 0);

            return result;
        }
    }
}
