using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class InstructorOfCourse : Entity<int>
    {
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
    }
}
