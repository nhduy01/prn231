using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.IRepositories
{
    public interface ICompetitorRepository : IGenericRepository<Competitor>
    {
        public Task<Competitor?> Login(string email);

        public Task<bool> CheckDuplicate(string email, string phone);
    }
}
