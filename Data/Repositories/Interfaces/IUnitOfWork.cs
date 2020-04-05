using Objects.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository
        {
            get;
        }

        Task<int> SaveAsync();
    }
}
