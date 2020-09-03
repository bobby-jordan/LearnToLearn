using AutoMapper;
using LearnToLearn.AutoMapperProfiles;

namespace LearnToLearn.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new BindModelToModelProfile());
                cfg.AddProfile(new ModelToBindModelProfile());
            });
        }
    }
}