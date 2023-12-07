using Business.Abstracts;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        IInstructorDal _instructorDal;

        public InstructorManager(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }

        public async Task AddAsync(Instructor instructor)
        {
            await _instructorDal.AddAsync(instructor);
        }

        public async Task DeleteAsync(Instructor instructor)
        {
            await _instructorDal.DeleteAsync(instructor, true);
        }

        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await _instructorDal.GetAsync(i => i.Id == id);
        }

        public async Task<IPaginate<InstructorDetailsDto>> GetDetailsListAsync()
        {
            return await _instructorDal.GetDetailsListAsync();
        }

        public async Task<IPaginate<Instructor>> GetListAsync()
        {
            return await _instructorDal.GetListAsync();
        }

        public async Task UpdateAsync(Instructor instructor)
        {
            await _instructorDal.UpdateAsync(instructor);
        }
    }
}
