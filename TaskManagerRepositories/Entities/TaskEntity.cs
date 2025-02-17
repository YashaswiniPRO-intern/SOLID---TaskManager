using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Repositories.Entities
{
    public class TaskEntity
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        [Required]
        public int Priority { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public string Category {  get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
