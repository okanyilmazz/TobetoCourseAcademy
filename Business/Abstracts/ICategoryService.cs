using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface ICategoryService
{
    Task<IPaginate<Category>> GetListAsync();
    Task<Category> GetByIdAsync(int id);
    Task AddAsync(Category category);
    Task DeleteAsync(Category category);
    Task UpdateAsync(Category category);
}
