using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskManager.Models.Models;
using TaskManager.Repositories.Entities;
using TaskManager.Repositories.Interface;
using TaskManager.Services.Interface;

namespace TaskManager.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            List<UserEntity> ue = await _userRepo.GetAllUsers();
            return _mapper.Map<List<UserModel>>(ue);
        }
        public async Task<UserModel> GetByUserId(int UserId)
        {
            var user = await _userRepo.GetByUserId(UserId);
            return _mapper.Map<UserModel>(user);
        }
        public async Task<UserModel> AddUser(UserModel um)
        {
            var u = _mapper.Map<UserEntity>(um);
            var newUser = await _userRepo.AddUser(u);
            return _mapper.Map<UserModel>(newUser);
        }
        public async Task<UserModel> UpdateUser(int UserId, UserModel um)
        {
            var existingUser = await _userRepo.GetByUserId(UserId);
            if (existingUser == null)
                return null;
            _mapper.Map(um, existingUser);
            var updatedUser = await _userRepo.UpdateUser(UserId, existingUser);
            return _mapper.Map<UserModel>(updatedUser);


        }
        public async Task<bool> DeleteUser(int UserId)
        {
            return await _userRepo.DeleteUser(UserId);
        }
        

    }
}
