using System;
using System.Threading.Tasks;
using Infrastructure.DynamicQuery;
using OnlineCourse.Api.Dtos.Request;
using OnlineCourse.Api.Dtos.Views;

namespace OnlineCourse.ApplicationService.Contracts
{
	public interface ICourseServiceRead
    {
        Task<DynamicQueryView<CourseView>> Get(CourseQueryRequest request);

        Task<DynamicQueryView<CourseView>> GetWithoutName(CourseQueryRequestWithoutName request);
        Task<CourseView> GetById(Guid id);
    }
}
