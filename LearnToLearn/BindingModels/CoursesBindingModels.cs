using System;

namespace LearnToLearn.BindingModels
{
    public class CoursesBindingModels
    {
        public int id { get; set; }
        public int teacherId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int capacity { get; set; }
        public bool isVisible { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}