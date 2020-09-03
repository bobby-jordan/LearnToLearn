using AutoMapper;
using LearnToLearn.BindingModels;
using LearnToLearn.Models;

namespace LearnToLearn.AutoMapperProfiles
{
    public class BindModelToModelProfile : Profile
    {
        public BindModelToModelProfile() 
        {
            CreateMap<UsersBindingModels, Users>();
            CreateMap<EnrollmentsBindingModels, Enrollments>();
            CreateMap<CoursesBindingModels, Courses>();

            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
        }
    }
}
