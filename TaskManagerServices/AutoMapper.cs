using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskManager.Models.Models;
using TaskManager.Repositories.Entities;

namespace TaskManager.Services
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            //we use reverse map for two-way mapping
            CreateMap<TaskEntity, TaskModel>().ReverseMap();
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}
