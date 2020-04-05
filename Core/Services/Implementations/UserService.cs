using Core.Services.Interfaces;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Objects.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Implementations
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<List<User>> AllAsync()
        {
            var result = await _unitOfWork.UserRepository.All().ToListAsync();
            return result;
        }

        public async Task<User> GetAsync(int id)
        {
            var result = await _unitOfWork.UserRepository.Find(x => x.Id == id);
            return result;
        }

        public async Task<User> CreateAsync(User user)
        {
            var result = _unitOfWork.UserRepository.Create(user);
            await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.Find(x => x.Id == id);
            if (user != null)
            {
                user.IsDeleted = true;
                _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.SaveAsync();
                return true;
            }
            throw new Exception("There is no such user");
        }
    }
}
