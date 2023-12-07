using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<IPaginate<Instructor>> GetListAsync();
        Task<IPaginate<InstructorDetailsDto>> GetDetailsListAsync();
        Task<Instructor> GetByIdAsync(int id);
        Task AddAsync(Instructor instructor);
        Task DeleteAsync(Instructor instructor);
        Task UpdateAsync(Instructor instructor);
    }
}
