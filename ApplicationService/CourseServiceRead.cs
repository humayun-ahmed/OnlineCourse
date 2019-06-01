using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.DynamicQuery;
using Infrastructure.Exception;
using Infrastructure.Interception.Contract;
using OnlineCourse.Api.Dtos.Request;
using OnlineCourse.Api.Dtos.Views;
using OnlineCourse.ApplicationService.Contracts;
using OnlineCourse.Repository;
using OnlineCourse.Repository.Models;
using OnlineCourse.Repository;

namespace OnlineCourse.ApplicationService
{
	public class CourseServiceRead: ICourseServiceRead
    {
        private readonly IDependencyResolver dependencyResolver;

        private readonly IRepositoryReadOnlineCourse repositoryReadOnlineCourse;

        public CourseServiceRead(IRepositoryReadOnlineCourse repositoryReadOnlineCourse, IDependencyResolver dependencyResolver)
        {
            this.repositoryReadOnlineCourse = repositoryReadOnlineCourse;
            this.dependencyResolver = dependencyResolver;
        }

        public async Task<DynamicQueryView<CourseView>> Get(CourseQueryRequest request)
        {
            List<CourseView> courseViews=new List<CourseView>();
            var courses = this.repositoryReadOnlineCourse.Get<Course>().Include(x => x.Participants);
            if (!string.IsNullOrEmpty(request.Name))
            {
                courses = courses.Where(x => x.Name.Contains(request.Name));
            }

            request.Sort = new List<SortDescriptor>();
            request.Sort.Add(new SortDescriptor { Field = "LastUpdated", Dir = "desc" });
            var data = request.GetData(courses, null);
            foreach (var course in data.Data.ToList())
            {
	            var courseView = AutoMapper.Mapper.Map<Course, CourseView>(course);
				courseViews.Add(courseView);
            }
            DynamicQueryView<CourseView> dynamicQueryView = new DynamicQueryView<CourseView>();
            dynamicQueryView.Data = courseViews;
            dynamicQueryView.Total = data.Total;
            return dynamicQueryView;
        }
        /// <summary>
        /// Gets the name of the without.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<DynamicQueryView<CourseView>> GetWithoutName(CourseQueryRequestWithoutName request)
        {
            List<CourseView> CourseViews = new List<CourseView>();
            var Courses = this.repositoryReadOnlineCourse.Get<Course>();

            request.Sort = new List<SortDescriptor>();
            request.Sort.Add(new SortDescriptor { Field = "LastUpdated", Dir = "desc" });
            var data = request.GetData(Courses, null);
            foreach (var Course in data.Data.ToList())
            {
                CourseViews.Add(AutoMapper.Mapper.Map<Course, CourseView>(Course));
            }
            DynamicQueryView<CourseView> dynamicQueryView = new DynamicQueryView<CourseView>();
            dynamicQueryView.Data = CourseViews;
            dynamicQueryView.Total = data.Total;
            return dynamicQueryView;
        }

        public async Task<CourseView> GetById(Guid id)
        {
            var course =await this.repositoryReadOnlineCourse.Get<Course>(x=>x.CourseGuid==id).Include(x=>x.Participants).SingleOrDefaultAsync();
           
            if (course == null)
            {
                var error = $"Course doesn't exist.";
                throw this.dependencyResolver.Resolve<InvalidInputException>().GetException(error);
            }

            var courseView = AutoMapper.Mapper.Map<Course, CourseView>(course);
            return courseView;
        }
    }
}
