using AutoMapper;
using LearnToLearn.BindingModels;
using LearnToLearn.Models;

namespace LearnToLearn.AutoMapperProfiles
{
    public class ModelToBindModelProfile : Profile
    {
        public ModelToBindModelProfile()
        {
            CreateMap<Users, UsersBindingModels>();
            CreateMap<Courses, CoursesBindingModels>();
            CreateMap<Enrollments, EnrollmentsBindingModels>();

            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
        } 
    }
}