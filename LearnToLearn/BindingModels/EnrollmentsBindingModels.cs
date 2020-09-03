using System;

namespace LearnToLearn.BindingModels
{
    public class EnrollmentsBindingModels
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int courseId { get; set; }
        public double grade { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}