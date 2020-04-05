using Objects.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<User>> AllAsync();
        public Task<User> GetAsync(int id);
        public Task<User> CreateAsync(User user);
        public Task<User> UpdateAsync(User user);
        public Task<bool> DeleteAsync(int id);
    }
}
