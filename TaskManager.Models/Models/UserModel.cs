using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Models
{
    public class UserModel
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        public string UserName {  get; set; }
    }
}
