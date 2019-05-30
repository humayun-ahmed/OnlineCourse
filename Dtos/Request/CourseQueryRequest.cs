using Infrastructure.DynamicQuery;

namespace OnlineCourse.Api.Dtos.Request
{
	/// <summary>
    /// request
    /// </summary>
    /// <seealso cref="Infrastructure.DynamicQuery.DynamicQueryRequest" />
    public class CourseQueryRequest : DynamicQueryRequest
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
    /// <summary>
    /// query
    /// </summary>
    public class CourseQueryRequestWithoutName : DynamicQueryRequest
    {
        
    }
}