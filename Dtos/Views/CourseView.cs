using System;

namespace OnlineCourse.Api.Dtos.Views
{
	/// <summary>
    /// Course view
    /// </summary>
    public class CourseView
    {
        /// <summary>
        /// Gets or sets the last updated.
        /// </summary>
        /// <value>
        /// The last updated.
        /// </value>
        public DateTime LastUpdated { get; set; }

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
		/// gets or sets TotalParticipants
		/// </summary>
		public int TotalParticipants { get; set; }

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