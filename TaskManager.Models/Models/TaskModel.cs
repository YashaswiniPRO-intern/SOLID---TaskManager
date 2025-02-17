using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Models
{
    public class TaskModel
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; } //1-High , 2-Medium, 3-Low
        public string Category { get; set; }
        public int UserId { get; set; }//foreign key
    }
}
