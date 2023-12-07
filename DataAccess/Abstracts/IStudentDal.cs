using Core.DataAccess.Paging;
using Core.DataAccess.Repositories;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IStudentDal : IRepository<Student, int>, IAsyncRepository<Student, int>
    {
        Task<IPaginate<StudentDetailsDto>> GetDetailsListAsync();
    }
}
