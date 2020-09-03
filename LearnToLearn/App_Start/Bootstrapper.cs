using LearnToLearn.Mapping;

namespace LearnToLearn.App_Start
{
    public class Bootstraper
    {
        public static void Run()
        {
            AutoMapperConfiguration.Configure();
        }
    }
}