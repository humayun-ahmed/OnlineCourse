using AutoMapper;
using OnlineCourse.Api.Dtos.Commands;
using OnlineCourse.Api.Dtos.Views;
using OnlineCourse.Repository.Models;

namespace OnlineCourse.Api
{
	public class MappingConfig
    {
        public static void RegisterMapping()
        {
            Mapper.AddProfile(new Map());
        }
    }
    public class Map : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AddCourseCommand, Course>();
            Mapper.CreateMap<EditCourseCommand, Course>();
            Mapper.CreateMap<SignupCourseCommand, Participant>();
			Mapper.CreateMap<Course, CourseView>().ForMember(dest => dest.TotalParticipants,
				opts => opts.MapFrom(src => src.Participants.Count)); 

        }
    }
}