using Business.Abstracts;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task Add(Category category)
        {
            await _categoryDal.AddAsync(category);
        }

        public async Task AddAsync(Category category)
        {
            await _categoryDal.AddAsync(category);
        }

        public async Task DeleteAsync(Category category)
        {
            await _categoryDal.DeleteAsync(category);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryDal.GetAsync(c => c.Id == id);
        }

        public async Task<IPaginate<Category>> GetListAsync()
        {
            return await _categoryDal.GetListAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            await _categoryDal.UpdateAsync(category);
        }
    }
}
