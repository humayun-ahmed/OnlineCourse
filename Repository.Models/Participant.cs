using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Repository.Models
{
	public class Participant
	{
		public string Name { get; set; }

		public int Age { get; set; }

		public long CourseId { get; set; }

		public Course Course { get; set; }

		public long ParticipantId { get; set; }

	}
}
