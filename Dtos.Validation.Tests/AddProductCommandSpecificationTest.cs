using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCourse.Api.Dtos.Commands;

namespace OnlineCourse.Api.Dtos.Validation.Tests
{
	[TestClass]
    public class AddCourseCommandSpecificationTest : BaseSpecificationTests
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
        public void InvalidName()
        {
            var command = new AddCourseCommand
                              {
                                  Name = "HHH && 2 as",
                                  Teacher = "Test",
                                  MaxParticipants = 20,
                                  CourseGuid = Guid.NewGuid()
                              };
            var validationResults = this.Validate(command);
            Assert.AreEqual(validationResults.Errors.Count, 1);
        }
    }
}
