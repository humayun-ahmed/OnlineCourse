using System.Threading.Tasks;
using System.Web.Http;
using Infrastructure.Validation.WebApi;
using OnlineCourse.Api.Dtos.Commands;
using OnlineCourse.Api.Dtos.Views;
using OnlineCourse.ApplicationService.Contracts;

namespace OnlineCourse.Api.Controllers
{
	/// <summary>
    ///     Course end points
    /// </summary>
    public class CourseController : ApiController
    {
        private readonly ICourseServiceWrite courseServiceWrite;

        /// <summary>
        /// Course controller
        /// </summary>
        /// <param name="courseServiceWrite"></param>
        public CourseController(ICourseServiceWrite courseServiceWrite)
        {
            this.courseServiceWrite = courseServiceWrite;
        }

        /// <summary>
        /// Adds the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [ValidateFilter]
        [HttpPost]
        [Route(ApiPaths.CourseAdd)]
        public async Task<CourseView> Add(AddCourseCommand command)
        {
            return await this.courseServiceWrite.Add(command);
        }
        /// <summary>
        /// Edits the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [ValidateFilter]
        [HttpPut]
        [Route(ApiPaths.CourseEdit)]
        public async Task<CourseView> Edit(EditCourseCommand command)
        {
            return await this.courseServiceWrite.Edit(command);
        }

        /// <summary>
        /// Removes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [ValidateFilter]
        [HttpDelete]
        [Route(ApiPaths.CourseRemove)]
        public async Task Remove(RemoveCourseCommand command)
        {
            await this.courseServiceWrite.Remove(command);
        }
    }
}