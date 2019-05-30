using System;

namespace OnlineCourse.Api.Dtos.Commands
{
    /// <summary>
    /// edit command
    /// </summary>
    public class EditCourseCommand
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

		/// <summary>
		/// gets or sets MaxParticipants
		/// </summary>
		public int MaxParticipants { get; set; }

		/// <summary>
		/// gets or sets Teacher
		/// </summary>
		public string Teacher { get; set; }

		/// <summary>
		/// Gets or sets the Course unique identifier.
		/// </summary>
		/// <value>
		/// The Course unique identifier.
		/// </value>
		public Guid CourseGuid { get; set; }
    }
}
