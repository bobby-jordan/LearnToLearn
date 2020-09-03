using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnToLearn.Models
{
    public class Courses : BaseModel
    {
        [Required]
        public int TeacherId { get; set; }
        [Required]
        [Unique]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public bool IsVisible { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }

        public virtual List<Users> Users { get; set; }
    }

    internal class UniqueAttribute : Attribute
    {
    }
}
