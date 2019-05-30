using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using ClosedXML.Excel;
using Infrastructure.DynamicQuery;
using OnlineCourse.Api.Dtos.Request;
using OnlineCourse.Api.Dtos.Views;
using OnlineCourse.ApplicationService.Contracts;

namespace OnlineCourse.Api.Controllers
{
	/// <summary>
    /// Course Query Controller
    /// </summary>
    public class CourseQueryController : ApiController
    {
        private readonly ICourseServiceRead CourseServiceRead;

        /// <summary>
        /// query service
        /// </summary>
        /// <param name="CourseServiceRead">The Course service read.</param>
        public CourseQueryController(ICourseServiceRead CourseServiceRead)
        {
            this.CourseServiceRead = CourseServiceRead;
        }

        /// <summary>
        /// Gets the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]//due to filter method, filter may some time cross the get url character limit
        [Route(ApiPaths.CourseGet)]
        public async Task<DynamicQueryView<CourseView>> Get(CourseQueryRequest request)
        {
            return await this.CourseServiceRead.Get(request);
        }

        /// <summary>
        /// Gets the name of the without.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]//due to filter method, filter may some time cross the get url character limit
        [Route(ApiPaths.CourseGet)]
        public async Task<DynamicQueryView<CourseView>> GetWithoutName(CourseQueryRequestWithoutName request)
        {
            return await this.CourseServiceRead.GetWithoutName(request);
        }
        /// <summary>
        /// Courses the get by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiPaths.CourseGetById)]
        public async Task<CourseView> CourseGetById(Guid id)
        {
            return await this.CourseServiceRead.GetById(id);
        }

        /// <summary>
        /// Exports the specified command.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiPaths.CourseExport)]
        public async Task<HttpResponseMessage> Export(CourseQueryRequest request)
        {
            var dt = new DataTable("Course Catalog");
            dt.Columns.AddRange(new[] { new DataColumn("Course Guid"),
                                                     new DataColumn("Name"),
                                                     new DataColumn("Teacher"),
                                                     new DataColumn("MaxParticipants"),
                                                     new DataColumn("Last Updated"),
                                                 });

            var items= await this.CourseServiceRead.Get(request);

            foreach (var Course in items.Data)
            {
                dt.Rows.Add(Course.CourseGuid, Course.Name, Course.MaxParticipants, Course.Teacher, Course.LastUpdated);
            }
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            using (var wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    
                    result.Content = new StreamContent(stream);
                    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                                                    {
                                                                        FileName = "Course Catalog.xlsx"
                                                                    };
                    result.Content.Headers.ContentType =new MediaTypeHeaderValue("application/octet-stream");
                    return result;
                }
            }
        }
    }
}