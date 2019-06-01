using System.Threading.Tasks;
using OnlineCourse.Api.Dtos.Commands;
using OnlineCourse.Api.Dtos.Views;

namespace OnlineCourse.ApplicationService.Contracts
{
	public interface ICourseServiceWrite
    {
        Task<CourseView> Add(AddCourseCommand command);

        Task Signup(SignupCourseCommand command);

		Task<CourseView> Edit(EditCourseCommand command);

        Task Remove(RemoveCourseCommand command);
    }
}