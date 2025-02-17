using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Repositories.Entities;

namespace TaskManager.Repositories.Interface
{
    public interface IUserRepository
    {
        public Task<List<UserEntity>> GetAllUsers();
        public Task<UserEntity> GetByUserId(int UserId);
        public Task<UserEntity> AddUser(UserEntity ue);
        public Task<UserEntity> UpdateUser(int UserId, UserEntity ue);
        public Task<bool> DeleteUser(int UserId);

    }
}
