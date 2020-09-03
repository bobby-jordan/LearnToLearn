using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearnToLearn.Models
{
    public class Users : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Unique]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsTeacher { get; set; }

        public virtual List<Courses> Courses { get; set; }
    } 
}