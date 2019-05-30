using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCourse.Api.Dtos.Commands;

namespace OnlineCourse.Api.Dtos.Validation.Tests
{
	[TestClass]
    public class EditCourseCommandSpecificationTest : BaseSpecificationTests
    {
        /// <summary>
        /// The class init.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            ClassInitialize();
        }

        [TestMethod]
        public void InvalidImageUrl()
        {
            var command = new EditCourseCommand
                              {
                                  Name = "Test Course",
                                  Teacher = "John",
                                  MaxParticipants = -1,
                                  CourseGuid = Guid.NewGuid()
                              };
            var validationResults = this.Validate(command);
            Assert.AreEqual(validationResults.Errors.Count, 1);
        }
    }
}
