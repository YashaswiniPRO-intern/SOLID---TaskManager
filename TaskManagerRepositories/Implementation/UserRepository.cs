using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Repositories.Entities;
using TaskManager.Repositories.Interface;

namespace TaskManager.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<UserEntity>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<UserEntity> GetByUserId(int UserId)
        {
            var user = await _dbContext.Users.FindAsync(UserId);
            return user;
        }
        public async Task<UserEntity> AddUser(UserEntity ue)
        {
            _dbContext.Users.Add(ue);
            await _dbContext.SaveChangesAsync();
            return ue;

        }
        public async Task<UserEntity> UpdateUser(int UserId, UserEntity ue)
        {
            var existingUser = await _dbContext.Users.FindAsync(UserId);
            if (existingUser == null)
                return null;
            
            existingUser.UserName = ue.UserName;
            await _dbContext.SaveChangesAsync();
            return existingUser;
        }
        public async Task<bool> DeleteUser(int UserId)
        {
            var user = await _dbContext.Users.FindAsync(UserId);
            if (user == null)
                return false;
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
