using LearnToLearn.Models;
using System.Collections.Generic;

namespace LearnToLearn.BindingModels
{
    public class UsersBindingModels
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isTeacher { get; set; }

        public virtual List<Courses> courses { get; set; }
    }
}