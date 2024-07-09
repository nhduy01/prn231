using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.IRepositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategoryUnused();
        Task<List<Category>> GetCategoryUsed();
    }
}
