using System.Threading.Tasks;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineCourse.Api.Controllers;
using OnlineCourse.Api.Dtos.Commands;
using OnlineCourse.Api.Dtos.Views;
using OnlineCourse.ApplicationService.Contracts;

namespace OnlineCourse.Api.Tests
{
	[TestClass]
    public class CourseControllerTests
    {
        private static Mock<ICourseServiceWrite> mockedCourseServiceWrite;
        private static CourseController courseController;
        /// <summary>
        /// The set up.
        /// </summary>
        /// <param name="a">
        /// The a.
        /// </param>
        [ClassInitialize]
        public static void SetUp(TestContext a)
        {
            mockedCourseServiceWrite=new Mock<ICourseServiceWrite>();

            var CourseView =Builder<CourseView>.CreateNew()
                    .With(x => x.CourseGuid = ConstantValues.Course2.CourseGuid)
                    .With(x => x.Name = ConstantValues.Course2.Name)
                    .With(x => x.Teacher = ConstantValues.Course2.Teacher)
                    .With(x => x.MaxParticipants = ConstantValues.Course2.MaxParticipants)
                    .Build();
            mockedCourseServiceWrite.Setup(x => x.Add(It.IsAny<AddCourseCommand>())).Returns(Task.FromResult(CourseView));
            mockedCourseServiceWrite.Setup(x => x.Edit(It.IsAny<EditCourseCommand>())).Returns(Task.FromResult(CourseView));
            mockedCourseServiceWrite.Setup(x => x.Remove(It.IsAny<RemoveCourseCommand>())).Returns(Task.CompletedTask);

            courseController =new CourseController(mockedCourseServiceWrite.Object);
        }

        /// <summary>
        ///     Tears down.
        /// </summary>
        [ClassCleanup]
        public static void TearDown()
        {
            
        }

        [TestMethod]
        public async Task AddTest()
        {
            var command = new AddCourseCommand()
                              {
                                  CourseGuid = ConstantValues.Course2.CourseGuid,
                                  Name = ConstantValues.Course2.Name,
                                  Teacher = ConstantValues.Course2.Teacher,
                                  MaxParticipants = ConstantValues.Course2.MaxParticipants

                              };

            var courseView = await courseController.Add(command);
            Assert.AreEqual(command.Name, courseView.Name);
        }
        [TestMethod]
        public async Task EditTest()
        {
            var command = new EditCourseCommand()
                              {
				CourseGuid = ConstantValues.Course2.CourseGuid,
				Name = ConstantValues.Course2.Name,
				Teacher = ConstantValues.Course2.Teacher,
				MaxParticipants = ConstantValues.Course2.MaxParticipants
			};

            var courseView = await courseController.Edit(command);
            Assert.AreEqual(command.MaxParticipants, ConstantValues.Course2.MaxParticipants);
        }
    }
}
