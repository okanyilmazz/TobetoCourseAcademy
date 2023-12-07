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
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public async Task AddAsync(Student student)
        {
            await _studentDal.AddAsync(student);
        }

        public async Task DeleteAsync(Student student)
        {
            await _studentDal.DeleteAsync(student, true);
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentDal.GetAsync(c => c.Id == id);
        }

        public async Task<IPaginate<StudentDetailsDto>> GetDetailsListAsync()
        {
            return await _studentDal.GetDetailsListAsync();
        }

        public async Task<IPaginate<Student>> GetListAsync()
        {
            return await _studentDal.GetListAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            await _studentDal.UpdateAsync(student);
        }
    }
}
