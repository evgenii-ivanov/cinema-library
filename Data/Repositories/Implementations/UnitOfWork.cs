using Data.Context;
using Data.Repositories.Interfaces;
using Objects.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private IRepository<User> _userRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new Repository<User>(_context);
                }
                return _userRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
