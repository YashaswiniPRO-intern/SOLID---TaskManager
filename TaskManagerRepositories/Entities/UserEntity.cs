using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Repositories.Entities
{
    public class UserEntity
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        public string UserName { get; set; }
        //one-to-many relationship, one user has many tasks, so we are listing the tasks here
        public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
    }
}
