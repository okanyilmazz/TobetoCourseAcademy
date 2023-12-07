using Core.DataAccess.Paging;
using Core.DataAccess.Repositories;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IStudentService
    {
        Task<IPaginate<Student>> GetListAsync();
        Task<IPaginate<StudentDetailsDto>> GetDetailsListAsync();
        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task DeleteAsync(Student student);
        Task UpdateAsync(Student student);
    }
}
