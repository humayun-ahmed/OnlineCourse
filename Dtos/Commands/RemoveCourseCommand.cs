using System;

namespace OnlineCourse.Api.Dtos.Commands
{
	/// <summary>
    ///     remove command
    /// </summary>
    public class RemoveCourseCommand
    {
        /// <summary>
        ///     Gets or sets the Course unique identifier.
        /// </summary>
        /// <value>
        ///     The Course unique identifier.
        /// </value>
        public Guid CourseGuid { get; set; }
    }
}