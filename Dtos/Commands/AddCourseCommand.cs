namespace OnlineCourse.Api.Dtos.Commands
{
	using System;

	/// <summary>
	/// </summary>
	public class AddCourseCommand
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