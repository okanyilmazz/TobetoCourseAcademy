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
    public interface IInstructorDal : IRepository<Instructor, int>, IAsyncRepository<Instructor, int>
    {
        Task<IPaginate<InstructorDetailsDto>> GetDetailsListAsync();
    }
}
