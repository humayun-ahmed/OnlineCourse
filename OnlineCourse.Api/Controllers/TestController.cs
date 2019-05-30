using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OnlineCourse.Api.Dtos.Views;
using OnlineCourse.Repository;
using OnlineCourse.Repository.Models;

namespace OnlineCourse.Api.Controllers
{
	/// <summary>
    ///     test controller
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class TestController : ApiController
    {
        private readonly IRepositoryOnlineCourse repositoryOnlineCourse;

        /// <summary>
        ///     test controller constructor
        /// </summary>
        /// <param name="repositoryOnlineCourse"></param>
        public TestController(IRepositoryOnlineCourse repositoryOnlineCourse)
        {
            this.repositoryOnlineCourse = repositoryOnlineCourse;
        }

        /// <summary>
        ///     test any get method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Test/Get")]
        public async Task<CourseView> Get()
        {
            var test = this.repositoryOnlineCourse.Get<Course>();
            var ss = await test.ToListAsync();

            CourseView courseView = new CourseView();
            return courseView;
        }
    }
}