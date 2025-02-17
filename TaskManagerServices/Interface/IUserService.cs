using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Models;

namespace TaskManager.Services.Interface
{
    public interface IUserService
    {
        public Task<List<UserModel>> GetAllUsers();
        public Task<UserModel> GetByUserId(int UserId);
        public Task<UserModel> AddUser(UserModel um);
        public Task<UserModel> UpdateUser(int UserId, UserModel um);
        public Task<bool> DeleteUser(int UserId);

    }
}
