using Core.Entities;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CourseDetailsWithStudentAndInstructorDto : CourseDetailsDto, IDto
    {
        public List<Instructor> Instructors { get; set; }
        public List<Student> Students { get; set; }
    }
}
