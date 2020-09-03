using System;
using System.ComponentModel.DataAnnotations;

namespace LearnToLearn.Models
{
    public class Enrollments : BaseModel
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public double Grade { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}