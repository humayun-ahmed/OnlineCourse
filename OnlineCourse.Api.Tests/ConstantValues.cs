using System;

namespace OnlineCourse.Api.Tests
{
	public class ConstantValues
	{
		public static class Course1
		{
			public static readonly string Name = "Auto Air Freshner";
			public static readonly Guid CourseGuid = Guid.Parse("7b4d2c86-7d26-4181-abb7-47ae2ac6d6c5");
			public static readonly int MaxParticipants = 20;
			public static readonly long CourseId = 1;
			public static readonly string Teacher = "John Abraham";
			public static readonly DateTime LastUpdated = DateTime.UtcNow;
		}
		public static class Course2
		{
			public static readonly string Name = "Auto Air Fan";
			public static readonly Guid CourseGuid = Guid.Parse("8d5909bc-300f-446e-851f-790d7f26df08");
			public static readonly int MaxParticipants = 30;
			public static readonly long CourseId = 2;
			public static readonly string Teacher = "Paul Adam";
			public static readonly DateTime LastUpdated = DateTime.UtcNow;
		}
	}
}