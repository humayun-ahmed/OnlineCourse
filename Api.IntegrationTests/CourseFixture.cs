using System.Net;
using System.Threading.Tasks;
using Infrastructure.DynamicQuery;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCourse.Api.Dtos.Commands;
using OnlineCourse.Api.Dtos.Request;
using OnlineCourse.Api.Dtos.Views;

namespace OnlineCourse.Api.IntegrationTests
{
	[TestClass]
    public class CourseFixture : BasicRepositorySecured<TestStartup>
    {
        /// <summary>
        /// The set up.
        /// </summary>
        /// <param name="a">
        /// The a.
        /// </param>
        [ClassInitialize]
        public static void SetUp(TestContext a)
        {
            ClassInitializeInitial();
        }

        /// <summary>
        ///     Tears down.
        /// </summary>
        [ClassCleanup]
        public static void TearDown()
        {
            ClassCleanup();
        }

        [TestMethod]
        public async Task CourseGetTest()
        {

            var request = new CourseQueryRequest
                                {
                                  Page = 1,
                                  PageSize = 10,
                              };

            var response = await this.PostAsJsonAsync<DynamicQueryView<CourseView>>(ApiPaths.CourseGet, request);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task CourseGetByIdTest()
        {
            var url = $"{ApiPaths.CourseGetById}?id={ConstantValues.Course1.CourseGuid}";
            var response = await HttpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task CourseAddTest()
        {
            var command = new AddCourseCommand()
                              {
                                  CourseGuid = ConstantValues.Course2.CourseGuid,
                                  Name = ConstantValues.Course2.Name,
                                  Teacher = ConstantValues.Course2.Teacher,
                                  MaxParticipants = ConstantValues.Course2.MaxParticipants

			};
            var response = await this.PostAsJsonAsync<CourseView>(ApiPaths.CourseAdd, command);
            Assert.IsNotNull(response);
            Assert.AreEqual(command.Name,response.Name);
        }
        [TestMethod]
        public async Task CourseEditTest()
        {
            var commandAdd = new AddCourseCommand()
            {
                CourseGuid = ConstantValues.Course2.CourseGuid,
                Name = ConstantValues.Course2.Name,
                Teacher = ConstantValues.Course2.Teacher,
                MaxParticipants = ConstantValues.Course2.MaxParticipants

			};
            var responsecommandAdd = await this.PostAsJsonAsync<CourseView>(ApiPaths.CourseAdd, commandAdd);
            var command = new EditCourseCommand()
                              {
                                  CourseGuid = ConstantValues.Course2.CourseGuid,
                                  Name = ConstantValues.Course2.Name,
                                  Teacher = ConstantValues.Course2.Teacher,
                                  MaxParticipants = ConstantValues.Course1.MaxParticipants

                              };
            var response = await this.PutAsJsonAsync<CourseView,EditCourseCommand>(ApiPaths.CourseEdit, command);
            Assert.IsNotNull(response);
            Assert.AreEqual(command.MaxParticipants, response.MaxParticipants);
        }
    }
}
