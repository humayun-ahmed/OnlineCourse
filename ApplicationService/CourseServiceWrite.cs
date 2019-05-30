using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Infrastructure.Exception;
using Infrastructure.Interception.Contract;
using OnlineCourse.Api.Dtos.Commands;
using OnlineCourse.Api.Dtos.Views;
using OnlineCourse.ApplicationService.Contracts;
using OnlineCourse.Repository;
using OnlineCourse.Repository.Models;

namespace OnlineCourse.ApplicationService
{
	public class CourseServiceWrite : ICourseServiceWrite
    {
        private readonly IDependencyResolver dependencyResolver;

        private readonly IRepositoryOnlineCourse repositoryOnlineCourse;

        public CourseServiceWrite(IRepositoryOnlineCourse repositoryOnlineCourse, IDependencyResolver dependencyResolver)
        {
            this.repositoryOnlineCourse = repositoryOnlineCourse;
            this.dependencyResolver = dependencyResolver;
        }

        public async Task<CourseView> Add(AddCourseCommand command)
        {
            var existingCourse = await this.repositoryOnlineCourse.Get<Course>(x => x.Name == command.Name || x.CourseGuid == command.CourseGuid).FirstOrDefaultAsync();
            if (existingCourse != null)
            {
                var error = $"Course already exist.";
                throw this.dependencyResolver.Resolve<InvalidInputException>().GetException(error);
            }

            Course course = AutoMapper.Mapper.Map<AddCourseCommand, Course>(command);
            course.LastUpdated = DateTime.UtcNow;
            this.repositoryOnlineCourse.Insert(course);
            await this.repositoryOnlineCourse.SaveChangesAsync();
            var courseView = AutoMapper.Mapper.Map<Course, CourseView>(course);
            return courseView;
        }

        public async Task<CourseView> Edit(EditCourseCommand command)
        {
            var existingCourse = await this.repositoryOnlineCourse.Get<Course>(x => x.CourseGuid == command.CourseGuid).SingleOrDefaultAsync();
            if (existingCourse == null)
            {
                var error = $"Course doesn't exist.";
                throw this.dependencyResolver.Resolve<InvalidInputException>().GetException(error);
            }

            Course course = AutoMapper.Mapper.Map<EditCourseCommand, Course>(command, existingCourse);
            course.LastUpdated = DateTime.UtcNow;
            this.repositoryOnlineCourse.Save(course);
            await this.repositoryOnlineCourse.SaveChangesAsync();
            var courseView = AutoMapper.Mapper.Map<Course, CourseView>(course);
            return courseView;
        }

        public async Task Remove(RemoveCourseCommand command)
        {
            var existingCourse = await this.repositoryOnlineCourse.Get<Course>(x => x.CourseGuid == command.CourseGuid).SingleOrDefaultAsync();
            if (existingCourse == null)
            {
                var error = $"Course doesn't exist.";
                throw this.dependencyResolver.Resolve<InvalidInputException>().GetException(error);
            }

            this.repositoryOnlineCourse.Delete(existingCourse);
            await this.repositoryOnlineCourse.SaveChangesAsync();
        }
    }
}